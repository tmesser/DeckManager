﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using DeckManager.Boards;
using DeckManager.Boards.Dradis;
using DeckManager.Cards.Enums;
using DeckManager.Characters;
using DeckManager.Components;
using DeckManager.Components.Enums;
using DeckManager.Decks;
using DeckManager.Extensions;
using DeckManager.States;
using Newtonsoft.Json;
using log4net;

namespace DeckManager
{
    public class GameManager
    {
        private readonly ILog _logger;
        private IEnumerable<Character> _characters;
        public IEnumerable<Character> CharacterList
        {
            get {
                if (_characters == null)
                {
                    using (var sr = new StreamReader(ConfigurationManager.AppSettings["CharacterListLocation"]))
                    {
                        var jsonText = sr.ReadToEnd();
                        _characters = JsonConvert.DeserializeObject<List<Character>>(jsonText);
                    }
                }
                return _characters;
            }
        }

        public GameManager()
        {
            _logger = LogManager.GetLogger(typeof (GameManager));
        }

        public GameManager(ILog logger)
        {
            _logger = logger;
        }

        public IList<GameState> GameStates { get; private set; }

        public GameState CurrentGameState
        {
            get { return GameStates.Last(); }
        }

        public bool SaveGame(string pathName)
        {
            try 
            {
                var jsonSettings = new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore, Converters = new List<JsonConverter> { new Newtonsoft.Json.Converters.StringEnumConverter() } };
                var json = JsonConvert.SerializeObject(CurrentGameState, Newtonsoft.Json.Formatting.Indented, jsonSettings);
                using (var file = new StreamWriter(pathName))
                {
                    file.Write(json);
                }
            }
            catch (Exception e)
            {
                _logger.Error("THINGS HAPPENED", e);
                return false;
            }
            return true;
        }

        public GameState LoadGame(string pathName)
        {
            GameState ret;
            try
            {
                using (var sr = new StreamReader(pathName))
                {
                    var jsonText = sr.ReadToEnd();
                    ret = JsonConvert.DeserializeObject<GameState>(jsonText, new Newtonsoft.Json.Converters.StringEnumConverter());
                    GameStates = new List<GameState> { ret };
                }                
            }
            catch (Exception e)
            {
                _logger.Error("THINGS HAPPENED", e);
                ret = null;
            }
            return ret;
        }

        public GameState NewGame(IEnumerable<Player> numPlayers, int extraLoyaltyCards, bool usingSympathizer)
        {
            var playerList = numPlayers.ToList();
            GameStates = new List<GameState>();
            var firstTurn = new GameState
                {
                    TurnLog = "Begin game.",
                    Players = playerList,

                    CrisisDeck = new CrisisDeck(_logger, ConfigurationManager.AppSettings["CrisisDeckLocation"]),
                    MissionDeck  = new MissionDeck(_logger),
                    DestinationDeck = new DestinationDeck(_logger, ConfigurationManager.AppSettings["DestinationDeckLocation"]),

                    EngineeringDeck = new SkillCardDeck(_logger, SkillCardColor.Engineering, ConfigurationManager.AppSettings["EngineeringDeckLocation"]),
                    LeadershipDeck = new SkillCardDeck(_logger, SkillCardColor.Leadership, ConfigurationManager.AppSettings["LeadershipDeckLocation"]),
                    LoyaltyDeck = new LoyaltyDeck(_logger, playerList.Count(), extraLoyaltyCards, usingSympathizer, ConfigurationManager.AppSettings["LoyaltyDeckLocation"]),
                    PilotingDeck = new SkillCardDeck(_logger, SkillCardColor.Piloting, ConfigurationManager.AppSettings["PilotingDeckLocation"]),
                    PoliticsDeck = new SkillCardDeck(_logger, SkillCardColor.Politics, ConfigurationManager.AppSettings["PoliticsDeckLocation"]),
                    QuorumDeck = new QuorumDeck(_logger, ConfigurationManager.AppSettings["QuorumDeckLocation"]),
                    SuperCrisisDeck = new SuperCrisisDeck(_logger, ConfigurationManager.AppSettings["SuperCrisisDeckLocation"]),
                    TacticsDeck = new SkillCardDeck(_logger, SkillCardColor.Tactics, ConfigurationManager.AppSettings["TacticsDeckLocation"]),
                    //TreacheryDeck = new SkillCardDeck(_logger, SkillCardColor.Treachery, ConfigurationManager.AppSettings["TreacheryDeckLocation"]),

                    Dradis = new DradisBoard(),
                    Boards = BuildBoards(),

                    Civilians = BuildCivilians(),
                    Vipers = BuildVipers(),

                    Turn = 1,
                    Fuel = 8,
                    Food = 8,
                    Morale = 10,
                    Population = 12
                };
            firstTurn.DestinyDeck = new DestinyDeck(_logger, firstTurn.LeadershipDeck, firstTurn.TacticsDeck,
                                                    firstTurn.PilotingDeck, firstTurn.EngineeringDeck,
                                                    firstTurn.PoliticsDeck);
            GameStates.Add(firstTurn);

            ShuffleCivs();
            CurrentGameState.Dradis.AddComponentToNode(DrawCiv(), DradisNodeName.Delta);
            CurrentGameState.Dradis.AddComponentToNode(DrawCiv(), DradisNodeName.Delta);
            CurrentGameState.Dradis.AddComponentToNode(DrawViper(), DradisNodeName.Foxtrot);
            CurrentGameState.Dradis.AddComponentToNode(DrawViper(), DradisNodeName.Echo);
            CurrentGameState.Dradis.AddComponentToNode(new Basestar(), DradisNodeName.Alpha);
            CurrentGameState.Dradis.AddComponentToNode(new Raider(), DradisNodeName.Alpha);
            CurrentGameState.Dradis.AddComponentToNode(new Raider(), DradisNodeName.Alpha);
            CurrentGameState.Dradis.AddComponentToNode(new Raider(), DradisNodeName.Alpha);

            //TODO: Fuck it we're not handling Baltar here just let the moderator draw extra cards
            foreach (var player in playerList)
            {
                player.LoyaltyCards.Add(CurrentGameState.LoyaltyDeck.Draw());
                DoPlayerDraw(player);
                AttemptToPlacePlayer(player);
            }

            return CurrentGameState;
        }

        #region Private Methods

        private void AttemptToPlacePlayer(Player player)
        {
            foreach (var location in CurrentGameState.Boards.Select(board => board.Locations.FirstOrDefault(x => x.Name == player.Character.SetupLocation)).Where(location => location != null))
            {
                location.PlayersPresent.Add(player.PlayerName);
                return;
            }
        }

        private List<Board> BuildBoards()
        {
            string jsonString;
            using (var reader = new StreamReader(ConfigurationManager.AppSettings["BoardLocation"]))
            {
                jsonString = reader.ReadToEnd();
            }
            var fromBox = JsonConvert.DeserializeObject<List<BasicLocation>>(jsonString);
            var ret = new List<Board>();
            foreach (var boardName in fromBox.Select(x => x.BoardName).Distinct())
            {
                var nonClosureBoardName = boardName; // It's unstable to access a foreach variable in a closure like we do below, so we need to copy it out.
                var board = new Board{Locations = new List<BasicLocation>()};
                board.Locations.AddRange(fromBox.Where(x => x.BoardName == nonClosureBoardName));
                ret.Add(board);
            }
            return ret;
        }

        private List<Viper> BuildVipers()
        {
            // todo account for mk7 vipers

            var viperLimit = ConfigurationManager.AppSettings["MaxVipers"].ParseAs<int>();
            var vipers = new Viper[viperLimit];
            var viperInt = 0;
            // This is a janky way to do a ForEach loop but this is still superior to a For loop because this is guaranteed to terminate.
            foreach (var viper in vipers)
            {
                var newViper = new Viper
                    {
                        PermanentDesignation = Guid.NewGuid(),
                        InternalDesignation = Guid.NewGuid(),
                        PublicDesignation = "Vigilante " + (viperInt+1),
                        Status = ComponentStatus.InReserve
                    };
                vipers[viperInt] = newViper;
                viperInt++;
            }
            return vipers.OrderBy(x => x.InternalDesignation).ToList();
        }

        private Viper DrawViper()
        {
            var viperDrawn = CurrentGameState.Vipers.FindIndex(x => x.Status == ComponentStatus.InReserve);
            if (viperDrawn == -1) // No vipers are in reserve
                return null;

            CurrentGameState.Vipers[viperDrawn].Status = ComponentStatus.Active;
            return CurrentGameState.Vipers[viperDrawn];
        }

        private List<Civilian> BuildCivilians()
        {
            string jsonString;
            using (var reader = new StreamReader(ConfigurationManager.AppSettings["CivilianLocation"]))
            {
                jsonString = reader.ReadToEnd();
            }
            var fromBox = JsonConvert.DeserializeObject<List<Civilian>>(jsonString);

            foreach (var civ in fromBox)
                civ.PermanentDesignation = Guid.NewGuid();

            return fromBox;
        }

        private void ShuffleCivs()
        {
            var civInt = 1;
            foreach (var civ in CurrentGameState.Civilians.Where(x => x.Status != ComponentStatus.Destroyed))
            {
                civ.InternalDesignation = Guid.NewGuid();
                civ.PublicDesignation = "Civ " + civInt;
                civ.Status = ComponentStatus.InReserve;
                civInt++;
            }
            
            CurrentGameState.Civilians = CurrentGameState.Civilians.OrderBy(x => x.InternalDesignation).ToList();
        }

        #endregion // Private Methods

        private Civilian DrawCiv()
        {
            var civDrawn = CurrentGameState.Civilians.FindIndex(x => x.Status == ComponentStatus.InReserve);
            if (civDrawn == -1) // No vipers are in reserve
                return null;

            CurrentGameState.Civilians[civDrawn].Status = ComponentStatus.Active;
            return CurrentGameState.Civilians[civDrawn];
        }

        public void KillCiv(Civilian civ)
        {
            CurrentGameState.Dradis.RemoveComponent(civ);
            var modifiedCiv = CurrentGameState.Civilians.FindIndex(x => x.PermanentDesignation == civ.PermanentDesignation);
            if (modifiedCiv == -1)
                return;
            CurrentGameState.Civilians[modifiedCiv].Status = ComponentStatus.Destroyed;
        }

        public void RemoveViper(Viper viper, bool destroyed = false)
        {
            CurrentGameState.Dradis.RemoveComponent(viper);
            var modifiedViper = CurrentGameState.Vipers.FindIndex(x => x.PermanentDesignation == viper.PermanentDesignation);
            if (modifiedViper == -1)
                return;
            CurrentGameState.Vipers[modifiedViper].Status = (destroyed ? ComponentStatus.Destroyed : ComponentStatus.Damaged);
        }

        public void RemoveComponent(BaseComponent component)
        {
            CurrentGameState.Dradis.RemoveComponent(component.PermanentDesignation);
        }

        public void WipeDradis()
        {
            CurrentGameState.Dradis.WipeDradis();
        }

        public void DoPlayerDraw(Player player, int drawIndex = 0)
        {
            try
            {
                foreach (var color in player.SkillCardDraws.ElementAt(drawIndex))
                {
                    switch (color)
                    {
                        case SkillCardColor.Engineering:
                            player.Cards.Add(CurrentGameState.EngineeringDeck.Draw());
                            break;
                        case SkillCardColor.Leadership:
                            player.Cards.Add(CurrentGameState.LeadershipDeck.Draw());
                            break;
                        case SkillCardColor.Piloting:
                            player.Cards.Add(CurrentGameState.PilotingDeck.Draw());
                            break;
                        case SkillCardColor.Tactics:
                            player.Cards.Add(CurrentGameState.TacticsDeck.Draw());
                            break;
                        case SkillCardColor.Politics:
                            player.Cards.Add(CurrentGameState.PoliticsDeck.Draw());
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                _logger.Error("Error when executing player draw.", e);
                throw;
            }
        }

	    #region deck interactions

        public void DiscardCards(IEnumerable<Cards.BaseCard> cards)
        {
            foreach (var card in cards)
                DiscardCard(card);
        }
        public void DiscardCard(Cards.BaseCard card)
        {   
            // todo each discard creates new gamestate? that would let us implement undos
            // discards the passed card into its appropriate deck
            switch (card.CardType)
            {
                case CardType.Quorum:
                    CurrentGameState.QuorumDeck.Discard((Cards.QuorumCard)card);
                    break;
                case CardType.Skill:
                    var skillCard = (Cards.SkillCard) card;
                    switch (skillCard.CardColor)
                    {
                        case SkillCardColor.Politics:
                            CurrentGameState.PoliticsDeck.Discard(skillCard);
                            break;
                        case SkillCardColor.Leadership:
                            CurrentGameState.LeadershipDeck.Discard(skillCard);
                            break;
                        case SkillCardColor.Tactics:
                            CurrentGameState.TacticsDeck.Discard(skillCard);
                            break;
                        case SkillCardColor.Engineering:
                            CurrentGameState.EngineeringDeck.Discard(skillCard);
                            break;
                        case SkillCardColor.Piloting:
                            CurrentGameState.PilotingDeck.Discard(skillCard);
                            break;
                        case SkillCardColor.Treachery:
                            CurrentGameState.TreacheryDeck.Discard(skillCard);
                            break;
                    }
                    break;
            }
        }

        /// <summary>
        /// Place the card on the top of its deck
        /// </summary>
        /// <param name="card"></param>
        public void TopCard(Cards.BaseCard card)
        {
            switch (card.CardType)
            {
                case CardType.Crisis:
                    CurrentGameState.CrisisDeck.Top((Cards.CrisisCard)card);
                    break;
                case CardType.Destination:
                    CurrentGameState.DestinationDeck.Top((Cards.DestinationCard)card);
                    break;
                case CardType.Loyalty:
                    CurrentGameState.LoyaltyDeck.Top((Cards.LoyaltyCard)card);
                    break;
                case CardType.Mission:
                    CurrentGameState.MissionDeck.Top((Cards.MissionCard)card);
                    break;
                case CardType.Mutiny:
                    CurrentGameState.MutinyDeck.Top((Cards.MutinyCard)card);
                    break;
                case CardType.Quorum:
                    CurrentGameState.QuorumDeck.Top((Cards.QuorumCard)card);
                    break;
                case CardType.Skill:
                    var skill = (Cards.SkillCard)card;
                    switch (skill.CardColor)
                    {
                        case SkillCardColor.Politics:
                            CurrentGameState.PoliticsDeck.Top(skill);
                            break;
                        case SkillCardColor.Leadership:
                            CurrentGameState.LeadershipDeck.Top(skill);
                            break;
                        case SkillCardColor.Tactics:
                            CurrentGameState.TacticsDeck.Top(skill);
                            break;
                        case SkillCardColor.Engineering:
                            CurrentGameState.EngineeringDeck.Top(skill);
                            break;
                        case SkillCardColor.Piloting:
                            CurrentGameState.PilotingDeck.Top(skill);
                            break;
                        case SkillCardColor.Treachery:
                            CurrentGameState.TreacheryDeck.Top(skill);
                            break;
                    }
                    break;
                case CardType.SuperCrisis:
                    CurrentGameState.SuperCrisisDeck.Top((Cards.SuperCrisisCard)card);
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Places the cards on the top of their decks.
        /// </summary>
        /// <param name="cards"></param>
        public void TopCards(IEnumerable<Cards.BaseCard> cards)
        {
            foreach (Cards.BaseCard card in cards)
                TopCard(card);
        }
        /// <summary>
        /// Place the card on the bottom of its Deck
        /// </summary>
        /// <param name="card"></param>
        public void BuryCard(Cards.BaseCard card)
        {
            switch (card.CardType)
            { 
                case CardType.Crisis:
                    CurrentGameState.CrisisDeck.Bury((Cards.CrisisCard)card);
                    break;
                case CardType.Destination:
                    CurrentGameState.DestinationDeck.Bury((Cards.DestinationCard)card);
                    break;
                case CardType.Loyalty:
                    CurrentGameState.LoyaltyDeck.Bury((Cards.LoyaltyCard)card);
                    break;
                case CardType.Mission:
                    CurrentGameState.MissionDeck.Bury((Cards.MissionCard)card);
                    break;
                case CardType.Mutiny:
                    CurrentGameState.MutinyDeck.Bury((Cards.MutinyCard)card);
                    break;
                case CardType.Quorum:
                    CurrentGameState.QuorumDeck.Bury((Cards.QuorumCard)card);
                    break;
                case CardType.Skill:
                    var skill = (Cards.SkillCard)card;
                    switch (skill.CardColor)
                    { 
                        case SkillCardColor.Politics:
                            CurrentGameState.PoliticsDeck.Bury(skill);
                            break;
                        case SkillCardColor.Leadership:
                            CurrentGameState.LeadershipDeck.Bury(skill);
                            break;
                        case SkillCardColor.Tactics:
                            CurrentGameState.TacticsDeck.Bury(skill);
                            break;
                        case SkillCardColor.Engineering:
                            CurrentGameState.EngineeringDeck.Bury(skill);
                            break;
                        case SkillCardColor.Piloting:
                            CurrentGameState.PilotingDeck.Bury(skill);
                            break;
                        case SkillCardColor.Treachery:
                            CurrentGameState.TreacheryDeck.Bury(skill);
                            break;
                    }
                    break;
                case CardType.SuperCrisis:
                    CurrentGameState.SuperCrisisDeck.Bury((Cards.SuperCrisisCard)card);
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// places the cards on the bottom of their decks
        /// </summary>
        /// <param name="cards"></param>
        public void BuryCards(IEnumerable<Cards.BaseCard> cards)
        {
            foreach (Cards.BaseCard card in cards)
                BuryCard(card);
        }

        #endregion

        #region component interactions
        /// <summary>
        /// Marks the component as destroyed and changes the GameState accordingly.
        /// </summary>
        /// <param name="ship"></param>
        public void DestroyComponent(BaseComponent ship)
        { 
        }

        public void DestroyComponents(IEnumerable<BaseComponent> ships)
        { }

        /// <summary>
        /// Removes the component from active play and places it back in its pile
        /// </summary>
        /// <param name="ship"></param>
        public void DiscardComponent(BaseComponent ship)
        { }

        public void DiscardComponents(IEnumerable<BaseComponent> ships)
        { }

        public void MoveComponents(DradisNodeName source, DradisNodeName dest, IEnumerable<BaseComponent> ships)
        { 
            CurrentGameState.Dradis.MoveComponents(source, dest, ships);
        }

        /// <summary>
        /// Attempts to place a ship of type in DRADIS location
        /// </summary>
        /// <param name="location"></param>
        /// <param name="type"></param>
        /// <returns>The component that has been placed</returns>
        public BaseComponent PlaceComponent( DradisNodeName location, Components.Enums.ComponentType type)
        {
            BaseComponent ship = null;
            switch (type)
            { 
                case Components.Enums.ComponentType.Basestar:
                    ship = new Basestar();
                    break;
                case Components.Enums.ComponentType.Civilian:
                    ship = DrawCiv();
                    break;
                case Components.Enums.ComponentType.HeavyRaider:
                    ship = new HeavyRaider();
                    break;
                case Components.Enums.ComponentType.Raider:
                    ship = new Raider();
                    break;
                case Components.Enums.ComponentType.Viper:
                    ship = DrawViper();
                    break;
                default:
                    break;
            }
            CurrentGameState.Dradis.AddComponentToNode(ship, location);
            return ship;
        }
        #endregion

        #region player/character interactions
        // todo may want to add logging to these
        /// <summary>
        /// Inserts the card into the player's appropriate hand
        /// </summary>
        /// <param name="player"></param>
        /// <param name="card"></param>
        public void GiveCardToPlayer(Player player, Cards.BaseCard card)
        {
            switch (card.CardType)
            {
                case DeckManager.Cards.Enums.CardType.Skill:
                    player.Cards.Add((DeckManager.Cards.SkillCard)card);
                    break;
                case DeckManager.Cards.Enums.CardType.Quorum:
                    player.QuorumHand.Add((DeckManager.Cards.QuorumCard)card);
                    break;
                case DeckManager.Cards.Enums.CardType.Loyalty:
                    player.LoyaltyCards.Add((DeckManager.Cards.LoyaltyCard)card);
                    break;
                case DeckManager.Cards.Enums.CardType.SuperCrisis:
                    player.SuperCrisisCards.Add((DeckManager.Cards.SuperCrisisCard)card);
                    break;
                case DeckManager.Cards.Enums.CardType.Mutiny:
                    player.MutinyHand.Add((DeckManager.Cards.MutinyCard)card);
                    break;
                default:
                    break;
            }
        }
        public void GiveCardToPlayer(Player player, IEnumerable<Cards.BaseCard> cards)
        {
            foreach (DeckManager.Cards.BaseCard card in cards)
                GiveCardToPlayer(player, card);
        }
        /// <summary>
        /// Removes the card from the Player's hand and discards it to the appropriate Deck.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="card"></param>
        public void PlayerDiscardCard(Player player, Cards.BaseCard card)
        { }
        /// <summary>
        /// Removes the cards from the Player's hand and discards them to their appropriate Decks.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="cards"></param>
        public void PlayerDiscardCard(Player player, IEnumerable<Cards.BaseCard> cards)
        {
            // todo error checking on these
            foreach (Cards.BaseCard card in cards)
            {
                player.Discard(card);
                DiscardCard(card);
            }
        }

        /// <summary>
        /// Reveal's the Player's cylon loyalty card and marks the player as a revealed cylon
        /// </summary>
        /// <param name="player"></param>
        /// <param name="reveal"></param>
        public void PlayerRevealCylon(Player player, Cards.LoyaltyCard reveal)
        {
            if (player.LoyaltyCards.Contains(reveal))
                player.RevealedCylon = true;
            else ; // error case, exception
            // todo logging
            // todo effects from card reveal
        }

        /// <summary>
        /// Removes the card from the players hand. This can be used to move cards between players.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="card"></param>
        public void PlayerRemoveCard(Player player, Cards.BaseCard card)
        {
            switch (card.CardType)
            {
                case DeckManager.Cards.Enums.CardType.Skill:
                    player.Cards.Remove((DeckManager.Cards.SkillCard)card);
                    break;
                case DeckManager.Cards.Enums.CardType.Quorum:
                    player.QuorumHand.Remove((DeckManager.Cards.QuorumCard)card);
                    break;
                case DeckManager.Cards.Enums.CardType.Loyalty:
                    player.LoyaltyCards.Remove((DeckManager.Cards.LoyaltyCard)card);
                    break;
                case DeckManager.Cards.Enums.CardType.SuperCrisis:
                    player.SuperCrisisCards.Remove((DeckManager.Cards.SuperCrisisCard)card);
                    break;
                case DeckManager.Cards.Enums.CardType.Mutiny:
                    player.MutinyHand.Remove((DeckManager.Cards.MutinyCard)card);
                    break;
                default:
                    break;
            }
        }
        public void PlayerRemoveCard(Player player, IEnumerable<Cards.BaseCard> cards)
        {
            foreach (Cards.BaseCard card in cards)
                PlayerRemoveCard(player, card);
        }

        /// <summary>
        /// Moves the title designation from one player to another, along with any hands or tokens for that title
        /// </summary>
        /// <param name="title">The title to be transferred</param>
        /// <param name="newHolder">The player who should now possess the title</param>
        public void ChangePlayerTitle(Characters.Enums.Titles title, Player newHolder)
        { }

        #endregion
    }
}
