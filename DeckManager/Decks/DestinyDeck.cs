using System;
using System.Collections.Generic;
using DeckManager.Cards;
using DeckManager.Cards.Enums;
using log4net;

namespace DeckManager.Decks
{
    public class DestinyDeck : BaseDeck<SkillCard>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DestinyDeck"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="leadershipDeck">The leadership deck.</param>
        /// <param name="tacticsDeck">The tactics deck.</param>
        /// <param name="pilotingDeck">The piloting deck.</param>
        /// <param name="engineeringDeck">The engineering deck.</param>
        /// <param name="politicsDeck">The politics deck.</param>
        public DestinyDeck(ILog logger, SkillCardDeck leadershipDeck, SkillCardDeck tacticsDeck, SkillCardDeck pilotingDeck, SkillCardDeck engineeringDeck, SkillCardDeck politicsDeck)
            : base(logger)
        {
            InitDeck(leadershipDeck, tacticsDeck, pilotingDeck, engineeringDeck, politicsDeck);
        }

        private SkillCardDeck LeadershipDeck { get; set; }
        private SkillCardDeck TacticsDeck { get; set; }
        private SkillCardDeck PilotingDeck { get; set; }
        private SkillCardDeck EngineeringDeck { get; set; }
        private SkillCardDeck PoliticsDeck { get; set; }

        /// <summary>
        /// Initializes the deck.
        /// </summary>
        /// <param name="leadershipDeck">The leadership deck.</param>
        /// <param name="tacticsDeck">The tactics deck.</param>
        /// <param name="pilotingDeck">The piloting deck.</param>
        /// <param name="engineeringDeck">The engineering deck.</param>
        /// <param name="politicsDeck">The politics deck.</param>
        /// <exception cref="System.ArgumentException">
        /// Leadership deck input is not actually a leadership deck.
        /// or
        /// Tactics deck input is not actually a tactics deck.
        /// or
        /// Piloting deck input is not actually a piloting deck.
        /// or
        /// Engineering deck input is not actually an engineering deck.
        /// or
        /// Politics deck input is not actually a politics deck.
        /// </exception>
        private void InitDeck(SkillCardDeck leadershipDeck, SkillCardDeck tacticsDeck, SkillCardDeck pilotingDeck, SkillCardDeck engineeringDeck, SkillCardDeck politicsDeck)
        {
            if (leadershipDeck.DeckColor != SkillCardColor.Leadership)
                throw new ArgumentException("Leadership deck input is not actually a leadership deck.");
            if (leadershipDeck.DeckColor != SkillCardColor.Tactics)
                throw new ArgumentException("Tactics deck input is not actually a tactics deck.");
            if (leadershipDeck.DeckColor != SkillCardColor.Piloting)
                throw new ArgumentException("Piloting deck input is not actually a piloting deck.");
            if (leadershipDeck.DeckColor != SkillCardColor.Engineering)
                throw new ArgumentException("Engineering deck input is not actually an engineering deck.");
            if (leadershipDeck.DeckColor != SkillCardColor.Politics)
                throw new ArgumentException("Politics deck input is not actually a politics deck.");

            LeadershipDeck = leadershipDeck;
            TacticsDeck = tacticsDeck;
            PilotingDeck = pilotingDeck;
            EngineeringDeck = engineeringDeck;
            PoliticsDeck = politicsDeck;
            Discarded = new List<SkillCard>();
        }

        /// <summary>
        /// Reshuffles this instance.
        /// </summary>
        protected override void Reshuffle()
        {
            Deck = new List<SkillCard>();
            Deck.AddRange(LeadershipDeck.DrawMany(2));
            Deck.AddRange(TacticsDeck.DrawMany(2));
            Deck.AddRange(PilotingDeck.DrawMany(2));
            Deck.AddRange(EngineeringDeck.DrawMany(2));
            Deck.AddRange(PoliticsDeck.DrawMany(2));
            Deck = Shuffle(Deck);
        }
    }
}
