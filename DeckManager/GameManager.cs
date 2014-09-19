using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using DeckManager.Boards;
using DeckManager.Boards.Dradis;
using DeckManager.Boards.Dradis.Enums;
using DeckManager.Cards;
using DeckManager.Cards.Enums;
using DeckManager.Characters;
using DeckManager.Characters.Enums;
using DeckManager.Components;
using DeckManager.Components.Enums;
using DeckManager.Decks;
using DeckManager.Extensions;
using DeckManager.States;
using Newtonsoft.Json;
using log4net;
using Newtonsoft.Json.Converters;

namespace DeckManager
{
    public class GameManager
    {
        private readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All, ReferenceLoopHandling = ReferenceLoopHandling.Serialize, PreserveReferencesHandling = PreserveReferencesHandling.All, DefaultValueHandling = DefaultValueHandling.Ignore, Converters = new List<JsonConverter> { new StringEnumConverter() } };
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
                var json = JsonConvert.SerializeObject(CurrentGameState, Formatting.Indented, _jsonSettings);
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
                    ret = (GameState)JsonConvert.DeserializeObject(jsonText, null, _jsonSettings);
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

        public GameState NewGame(IEnumerable<Player> numPlayers, int extraLoyaltyCards, bool usingSympathizer, int firstPlayerDraw)
        {
            var playerList = numPlayers.ToList();
            GameStates = new List<GameState>();
            var firstTurn = new GameState
                {
                    Players = playerList,

                    CrisisDeck = new CrisisDeck(_logger, ConfigurationManager.AppSettings["CrisisDeckLocation"]),
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

            var firstPlayer = playerList.First();
            firstPlayer.LoyaltyCards.Add(CurrentGameState.LoyaltyDeck.Draw());
            DoPlayerDraw(firstPlayer, firstPlayerDraw);
            AttemptToPlacePlayer(firstPlayer);
            firstPlayer.OncePerGamePower = true;

            foreach (var player in playerList.Skip(1))
            {
                player.LoyaltyCards.Add(CurrentGameState.LoyaltyDeck.Draw());
                DoPlayerDraw(player);
                AttemptToPlacePlayer(player);
                player.OncePerGamePower = true;
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
            if (civDrawn == -1) // No civs are in reserve
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

        public void AddToTurnLog(string line)
        {
            CurrentGameState.TurnLog += line + Environment.NewLine;
        }

        public string GetTurnLog()
        {
            return CurrentGameState.TurnLog;
        }

        public void EndTurn()
        {
            var newTurn = CurrentGameState;
            newTurn.TurnLog = string.Empty;
            GameStates.Add(newTurn);
        }

        public void DoPlayerDraw(Player player, int drawIndex = 0)
        {
            try
            {
                AddToTurnLog(player.Character.CharacterName + " draws " + player.SkillCardString(player.SkillCardDraws.ElementAt(drawIndex)) + "!");
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

        public void DiscardCards(IEnumerable<BaseCard> cards, Player player= null)
        {
            foreach (var card in cards)
                DiscardCard(card, player);
        }
        public void DiscardCard(BaseCard card, Player player = null)
        {  
            // discards the passed card into its appropriate deck
            switch (card.CardType)
            {
                case CardType.Quorum:
                    CurrentGameState.QuorumDeck.Discard((QuorumCard)card);
                    break;
                case CardType.Skill:
                    var skillCard = (SkillCard) card;
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
                case CardType.SuperCrisis:
                    CurrentGameState.SuperCrisisDeck.Discard((SuperCrisisCard) card);
                    break;
                case CardType.Loyalty:
                    CurrentGameState.LoyaltyDeck.Discard((LoyaltyCard) card);
                    break;
            }
            if (player != null)
                player.Discard(card);
        }

        /// <summary>
        /// Place the card on the top of its deck
        /// </summary>
        /// <param name="card"></param>
        /// <param name="isDestiny"></param>
        public void TopCard(BaseCard card, bool isDestiny=false)
        {
            switch (card.CardType)
            {
                case CardType.Crisis:
                    CurrentGameState.CrisisDeck.Top((CrisisCard)card);
                    break;
                case CardType.Destination:
                    CurrentGameState.DestinationDeck.Top((DestinationCard)card);
                    break;
                case CardType.Loyalty:
                    CurrentGameState.LoyaltyDeck.Top((LoyaltyCard)card);
                    break;
                case CardType.Quorum:
                    CurrentGameState.QuorumDeck.Top((QuorumCard)card);
                    break;
                case CardType.Skill:
                    var skill = (SkillCard)card;
                    if (isDestiny)
                        CurrentGameState.DestinyDeck.Top(skill);
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
                    CurrentGameState.SuperCrisisDeck.Top((SuperCrisisCard)card);
                    break;
            }
        }

        /// <summary>
        /// Places the cards on the top of their decks.
        /// </summary>
        /// <param name="cards"></param>
        /// <param name="isDestiny"></param>
        public void TopCards(IEnumerable<BaseCard> cards, bool isDestiny=false)
        {
            foreach (BaseCard card in cards)
                TopCard(card, isDestiny);
        }

        public SkillCard DrawSkillCard(SkillCardColor color, Player player = null)
        {
            return DrawSkillCards(color, 1, player).FirstOrDefault();
        }

        public IEnumerable<SkillCard> DrawSkillCards(SkillCardColor color, int count, Player player = null)
        {
            List<SkillCard> ret;
            switch (color)
            {
                case SkillCardColor.Engineering:
                    ret = CurrentGameState.EngineeringDeck.DrawMany(count).ToList();
                    break;
                case SkillCardColor.Leadership:
                    ret = CurrentGameState.LeadershipDeck.DrawMany(count).ToList();
                    break;
                case SkillCardColor.Piloting:
                    ret = CurrentGameState.PilotingDeck.DrawMany(count).ToList();
                    break;
                case SkillCardColor.Politics:
                    ret = CurrentGameState.PoliticsDeck.DrawMany(count).ToList();
                    break;
                case SkillCardColor.Tactics:
                    ret = CurrentGameState.TacticsDeck.DrawMany(count).ToList();
                    break;
                case SkillCardColor.Treachery:
                    ret = CurrentGameState.TreacheryDeck.DrawMany(count).ToList();
                    break;
                default:
                    return new List<SkillCard>();
            }

            if (player != null)
                player.TakeCard(ret);
            return ret;
        }

        public void DrawCards(CardType cardType, int count, Player player = null)
        {
            DrawCards(Enumerable.Repeat(BaseCard.ReturnBaseCardFromCardType(cardType), count), player);
        }

        public void DrawCards(IEnumerable<BaseCard> cards, Player player = null)
        {
            foreach (var card in cards)
                DrawCard(card, player);
        }

        public BaseCard DrawCard(BaseCard card, Player player = null)
        {
            // todo each discard creates new gamestate? that would let us implement undos
            // discards the passed card into its appropriate deck
            BaseCard ret = new SkillCard();
            switch (card.CardType)
            {
                case CardType.Crisis:
                    ret = CurrentGameState.CrisisDeck.Draw();
                    break;
                case CardType.Quorum:
                    ret = CurrentGameState.QuorumDeck.Draw();
                    break;
                case CardType.Skill:
                    var skillCard = (SkillCard)card;
                    switch (skillCard.CardColor)
                    {
                        case SkillCardColor.Politics:
                            ret = CurrentGameState.PoliticsDeck.Draw();
                            break;
                        case SkillCardColor.Leadership:
                            ret = CurrentGameState.LeadershipDeck.Draw();
                            break;
                        case SkillCardColor.Tactics:
                            ret = CurrentGameState.TacticsDeck.Draw();
                            break;
                        case SkillCardColor.Engineering:
                            ret = CurrentGameState.EngineeringDeck.Draw();
                            break;
                        case SkillCardColor.Piloting:
                            ret = CurrentGameState.PilotingDeck.Draw();
                            break;
                        case SkillCardColor.Treachery:
                            ret = CurrentGameState.TreacheryDeck.Draw();
                            break;
                    }
                    break;
                case CardType.SuperCrisis:
                    ret = CurrentGameState.SuperCrisisDeck.Draw();
                    break;
                case CardType.Loyalty:
                    ret = CurrentGameState.LoyaltyDeck.Draw();
                    break;
            }
            if (player != null)
                player.TakeCard(ret);

            return ret;
        }

        /// <summary>
        /// Place the card on the bottom of its Deck
        /// </summary>
        /// <param name="card"></param>
        public void BuryCard(BaseCard card)
        {
            switch (card.CardType)
            { 
                case CardType.Crisis:
                    CurrentGameState.CrisisDeck.Bury((CrisisCard)card);
                    break;
                case CardType.Destination:
                    CurrentGameState.DestinationDeck.Bury((DestinationCard)card);
                    break;
                case CardType.Loyalty:
                    CurrentGameState.LoyaltyDeck.Bury((LoyaltyCard)card);
                    break;
                case CardType.Quorum:
                    CurrentGameState.QuorumDeck.Bury((QuorumCard)card);
                    break;
                case CardType.Skill:
                    var skill = (SkillCard)card;
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
                    CurrentGameState.SuperCrisisDeck.Bury((SuperCrisisCard)card);
                    break;
            }
        }
        /// <summary>
        /// places the cards on the bottom of their decks
        /// </summary>
        /// <param name="cards"></param>
        public void BuryCards(IEnumerable<BaseCard> cards)
        {
            foreach (BaseCard card in cards)
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
        public BaseComponent PlaceComponent( DradisNodeName location, ComponentType type)
        {
            AddToTurnLog("A " + type + " arrives in " + location + "!");
            BaseComponent ship = null;
            switch (type)
            { 
                case ComponentType.Basestar:
                    ship = new Basestar();
                    break;
                case ComponentType.Civilian:
                    ship = DrawCiv();
                    break;
                case ComponentType.HeavyRaider:
                    ship = new HeavyRaider();
                    break;
                case ComponentType.Raider:
                    ship = new Raider();
                    break;
                case ComponentType.Viper:
                    ship = DrawViper();
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
        /// <param name="toPlayer">The player to give the cards to.</param>
        /// <param name="card">The card to give them.</param>
        /// <param name="fromPlayer">The player who is giving the card (if applicable)</param>
        public void GiveCardToPlayer(Player toPlayer, BaseCard card, Player fromPlayer = null)
        {
            switch (card.CardType)
            {
                case CardType.Skill:
                    toPlayer.Cards.Add((SkillCard)card);
                    break;
                case CardType.Quorum:
                    toPlayer.QuorumHand.Add((QuorumCard)card);
                    break;
                case CardType.Loyalty:
                    toPlayer.LoyaltyCards.Add((LoyaltyCard)card);
                    break;
                case CardType.SuperCrisis:
                    toPlayer.SuperCrisisCards.Add((SuperCrisisCard)card);
                    break;
                case CardType.Mutiny:
                    toPlayer.MutinyHand.Add((MutinyCard)card);
                    break;
            }

            if (fromPlayer != null)
                fromPlayer.Discard(card);
        }
        public void GiveCardToPlayer(Player player, IEnumerable<BaseCard> cards)
        {
            foreach (var card in cards)
                GiveCardToPlayer(player, card);
        }

        public Player FindPlayerByName(string name)
        {
            return CurrentGameState.Players.FirstOrDefault(x => x.PlayerName == name);
        }

        /// <summary>
        /// Removes the card from the players hand. This can be used to move cards between players.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="card"></param>
        public void PlayerRemoveCard(Player player, BaseCard card)
        {
            switch (card.CardType)
            {
                case CardType.Skill:
                    player.Cards.Remove((SkillCard)card);
                    break;
                case CardType.Quorum:
                    player.QuorumHand.Remove((QuorumCard)card);
                    break;
                case CardType.Loyalty:
                    player.LoyaltyCards.Remove((LoyaltyCard)card);
                    break;
                case CardType.SuperCrisis:
                    player.SuperCrisisCards.Remove((SuperCrisisCard)card);
                    break;
                case CardType.Mutiny:
                    player.MutinyHand.Remove((MutinyCard)card);
                    break;
            }
        }
        public void PlayerRemoveCard(Player player, IEnumerable<BaseCard> cards)
        {
            foreach (BaseCard card in cards)
                PlayerRemoveCard(player, card);
        }

        /// <summary>
        /// Moves the title designation from one player to another, along with any hands or tokens for that title
        /// </summary>
        /// <param name="title">The title to be transferred</param>
        /// <param name="newHolder">The player who should now possess the title</param>
        public void ChangePlayerTitle(Titles title, Player newHolder)
        { }

        public BaseNode GetPlayerLocation(Player player)
        {
            return GetPlayerLocation(player.PlayerName);
        }

        public IEnumerable<BaseCard> GetPlayerHand(Player player)
        {
            return GetPlayerHand(player.PlayerName);
        }

        public IEnumerable<BaseCard> GetPlayerHand(string player)
        {
            var playerObject = CurrentGameState.Players.FirstOrDefault(x => x.PlayerName == player);
            return playerObject == default(Player) ? null : playerObject.Cards;
        }

        public BaseNode GetPlayerLocation(string playerName)
        {
            foreach (var board in CurrentGameState.Boards.Where(
                board => board.Locations.FirstOrDefault(x => x.PlayersPresent.Contains(playerName)) != default(BaseNode)))
            {
                return board.Locations.FirstOrDefault(x => x.PlayersPresent.Contains(playerName));
            }
            return CurrentGameState.Dradis.Nodes.FirstOrDefault(x => x.PlayersPresent.Contains(playerName));
        }

        public void SetPlayerLocation(string locationName, string playerName)
        {
            // Remove the player from wherever they were before
            foreach (var location in CurrentGameState.Boards.SelectMany(board => board.Locations.Where(x => x.PlayersPresent.Contains(playerName))))
            {
                location.PlayersPresent.Remove(playerName);
            }

            foreach (var location in CurrentGameState.Dradis.Nodes.Where(x => x.PlayersPresent.Contains(playerName)))
            {
                location.PlayersPresent.Remove(playerName);
            }

            AddToTurnLog(playerName + " moves to " + locationName + "!");

            // Add the player
            foreach (var location in CurrentGameState.Boards.Select(
                board => board.Locations.FirstOrDefault(x => x.Name == locationName)).Where(
                location => location != default(BaseNode)))
            {
                location.PlayersPresent.Add(playerName);
            }

            var applicableDradisNode = CurrentGameState.Dradis.Nodes.FirstOrDefault(x => x.Name == locationName);
            if(applicableDradisNode != default(BaseNode))
            {
                applicableDradisNode.PlayersPresent.Add(playerName);
            }
        }

        public IEnumerable<SkillCard> DrawDestiny(int count)
        {
            return CurrentGameState.DestinyDeck.DrawMany(count);
        }

        #endregion
    }
}
