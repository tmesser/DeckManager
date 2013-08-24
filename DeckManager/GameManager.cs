using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeckManager.Cards.Enums;
using DeckManager.Decks;
using DeckManager.Extensions;
using DeckManager.States;
using log4net;

namespace DeckManager
{
    public class GameManager
    {
        private readonly ILog _logger;

        public GameManager()
        {
            _logger = LogManager.GetLogger(typeof (GameManager));
        }

        public GameManager(ILog logger)
        {
            _logger = logger;
        }

        public List<GameState> GameStates { get; set; }

        public GameState CurrentGameState { get; private set; }

        public GameState NewGame(IEnumerable<Player> numPlayers, int extraLoyaltyCards, bool usingSympathizer)
        {
            var playerList = numPlayers.ToList();
            GameStates = new List<GameState>();
            var firstTurn = new GameState
                {
                    TurnLog = "Begin game.",

                    CrisisDeck = new CrisisDeck(_logger, ConfigurationManager.AppSettings["EngineeringDeckLocation"], ConfigurationManager.AppSettings["usingXml"].ParseAs<bool>()),
                    MissionDeck  = new MissionDeck(_logger),
                    DestinationDeck = new DestinationDeck(_logger),

                    EngineeringDeck = new SkillCardDeck(_logger, SkillCardColor.Engineering, ConfigurationManager.AppSettings["EngineeringDeckLocation"], ConfigurationManager.AppSettings["usingXml"].ParseAs<bool>()),
                    LeadershipDeck = new SkillCardDeck(_logger, SkillCardColor.Leadership, ConfigurationManager.AppSettings["LeadershipDeckLocation"], ConfigurationManager.AppSettings["usingXml"].ParseAs<bool>()),
                    LoyaltyDeck = new LoyaltyDeck(_logger, playerList.Count(), extraLoyaltyCards, usingSympathizer),
                    PilotingDeck = new SkillCardDeck(_logger, SkillCardColor.Piloting, ConfigurationManager.AppSettings["PilotingDeckLocation"], ConfigurationManager.AppSettings["usingXml"].ParseAs<bool>()),
                    PoliticsDeck = new SkillCardDeck(_logger, SkillCardColor.Politics, ConfigurationManager.AppSettings["PoliticsDeckLocation"], ConfigurationManager.AppSettings["usingXml"].ParseAs<bool>()),
                    QuorumDeck = new QuorumDeck(_logger),
                    SuperCrisisDeck = new SuperCrisisDeck(_logger),
                    TacticsDeck = new SkillCardDeck(_logger, SkillCardColor.Tactics, ConfigurationManager.AppSettings["TacticsDeckLocation"], ConfigurationManager.AppSettings["usingXml"].ParseAs<bool>()),
                    TreacheryDeck = new SkillCardDeck(_logger, SkillCardColor.Treachery, ConfigurationManager.AppSettings["TreacheryDeckLocation"], ConfigurationManager.AppSettings["usingXml"].ParseAs<bool>()),
                    Turn = 1,
                    Fuel = 8,
                    Food = 8,
                    Morale = 10,
                    Population = 12
                };

            CurrentGameState = firstTurn;

            //TODO: Need a graceful way to handle Baltar here.
            foreach (var player in playerList)
            {
                player.LoyaltyCards.Add(firstTurn.LoyaltyDeck.Draw());
                DoPlayerDraw(player);
            }

            throw new NotImplementedException();
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
                            player.Cards.Add(CurrentGameState.EngineeringDeck.Draw());
                            break;
                        case SkillCardColor.Piloting:
                            player.Cards.Add(CurrentGameState.PilotingDeck.Draw());
                            break;
                        case SkillCardColor.Tactics:
                            player.Cards.Add(CurrentGameState.PilotingDeck.Draw());
                            break;
                        case SkillCardColor.Politics:
                            player.Cards.Add(CurrentGameState.PilotingDeck.Draw());
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

        public void DiscardCard(Cards.BaseCard card)
        {   
            // todo each discard creates new gamestate? that would let us implement undos
            // discards the passed card into its appropriate deck
            switch (card.CardType)
            {
                case CardType.Quorum:
                    this.CurrentGameState.QuorumDeck.Discard((Cards.QuorumCard)card);
                    break;
                case CardType.Skill:
                    switch (((Cards.SkillCard)card).CardColor)
                    {
                        case SkillCardColor.Politics:
                            CurrentGameState.PoliticsDeck.Discard((Cards.SkillCard)card);
                            break;
                        case SkillCardColor.Leadership:
                            CurrentGameState.LeadershipDeck.Discard((Cards.SkillCard)card);
                            break;
                        case SkillCardColor.Tactics:
                            CurrentGameState.TacticsDeck.Discard((Cards.SkillCard)card);
                            break;
                        case SkillCardColor.Engineering:
                            CurrentGameState.EngineeringDeck.Discard((Cards.SkillCard)card);
                            break;
                        case SkillCardColor.Piloting:
                            CurrentGameState.PilotingDeck.Discard((Cards.SkillCard)card);
                            break;
                        case SkillCardColor.Treachery:
                            CurrentGameState.TreacheryDeck.Discard((Cards.SkillCard)card);
                            break;
                    }
                    break;
            }
        }
        public void DiscardCards(IEnumerable<Cards.BaseCard> cards)
        {
            foreach (Cards.BaseCard card in cards)
                DiscardCard(card);
        }
    }
}
