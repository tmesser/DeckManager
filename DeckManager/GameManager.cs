using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeckManager.Cards.Enums;
using DeckManager.Decks;
using DeckManager.States;
using log4net;

namespace DeckManager
{
    public class GameManager
    {
        private readonly ILog _logger;

        public GameManager(ILog logger)
        {
            _logger = logger;
        }

        public List<GameState> GameStates { get; set; }

        public GameState NewGame(IEnumerable<Player> numPlayers, int extraLoyaltyCards, bool usingSympathizer)
        {
            GameStates = new List<GameState>();
            var firstTurn = new GameState
                {
                    CrisisDeck = new CrisisDeck(_logger),
                    DestinationDeck = new DestinationDeck(_logger),
                    EngineeringDeck = new SkillCardDeck(_logger, SkillCardColor.Engineering),
                    LeadershipDeck = new SkillCardDeck(_logger, SkillCardColor.Leadership),
                    LoyaltyDeck = new LoyaltyDeck(_logger, numPlayers.Count(), extraLoyaltyCards, usingSympathizer),
                    PilotingDeck = new SkillCardDeck(_logger, SkillCardColor.Piloting),
                    PoliticsDeck = new SkillCardDeck(_logger, SkillCardColor.Politics),
                    QuorumDeck = new QuorumDeck(_logger),
                    SuperCrisisDeck = new SuperCrisisDeck(_logger),
                    TacticsDeck = new SkillCardDeck(_logger, SkillCardColor.Tactics),
                    Turn = 1,
                    Fuel = 8,
                    Food = 8,
                    Morale = 10,
                    Population = 12
                };

            throw new NotImplementedException();
        }

    }
}
