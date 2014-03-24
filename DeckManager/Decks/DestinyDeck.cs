using System;
using System.Collections.Generic;
using DeckManager.Cards;
using DeckManager.Cards.Enums;
using Newtonsoft.Json;
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

        [JsonProperty(IsReference=true)]
        public SkillCardDeck LeadershipDeck { get; set; }
        [JsonProperty(IsReference = true)]
        public SkillCardDeck TacticsDeck { get; set; }
        [JsonProperty(IsReference = true)]
        public SkillCardDeck PilotingDeck { get; set; }
        [JsonProperty(IsReference = true)]
        public SkillCardDeck EngineeringDeck { get; set; }
        [JsonProperty(IsReference = true)]
        public SkillCardDeck PoliticsDeck { get; set; }

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
        /// 
        /// Piloting deck input is not actually a piloting deck.
        /// or
        /// Engineering deck input is not actually an engineering deck.
        /// or
        /// Politics deck input is not actually a politics deck.
        /// </exception>
        private void InitDeck(SkillCardDeck leadershipDeck, SkillCardDeck tacticsDeck, SkillCardDeck pilotingDeck, SkillCardDeck engineeringDeck, SkillCardDeck politicsDeck)
        {
            if (leadershipDeck == null || tacticsDeck == null || pilotingDeck == null || engineeringDeck == null ||
                politicsDeck == null)
            {
                return;
            }

            if (leadershipDeck.DeckColor != SkillCardColor.Leadership)
                throw new ArgumentException("Leadership deck input is not actually a leadership deck.");
            if (tacticsDeck.DeckColor != SkillCardColor.Tactics)
                throw new ArgumentException("Tactics deck input is not actually a tactics deck.");
            if (pilotingDeck.DeckColor != SkillCardColor.Piloting)
                throw new ArgumentException("Piloting deck input is not actually a piloting deck.");
            if (engineeringDeck.DeckColor != SkillCardColor.Engineering)
                throw new ArgumentException("Engineering deck input is not actually an engineering deck.");
            if (politicsDeck.DeckColor != SkillCardColor.Politics)
                throw new ArgumentException("Politics deck input is not actually a politics deck.");

            LeadershipDeck = leadershipDeck;
            TacticsDeck = tacticsDeck;
            PilotingDeck = pilotingDeck;
            EngineeringDeck = engineeringDeck;
            PoliticsDeck = politicsDeck;
            Deck = new List<SkillCard>();
            Discarded = new List<SkillCard>();
        }


        public override void Discard(SkillCard card)
        {
            switch (card.CardColor)
            {
                case SkillCardColor.Leadership:
                    LeadershipDeck.Discard(card);
                    break;
                case SkillCardColor.Engineering:
                    EngineeringDeck.Discard(card);
                    break;
                case SkillCardColor.Piloting:
                    PilotingDeck.Discard(card);
                    break;
                case SkillCardColor.Politics:
                    PoliticsDeck.Discard(card);
                    break;
                case SkillCardColor.Tactics:
                    TacticsDeck.Discard(card);
                    break;
            }
        }

        public override void Discard(IEnumerable<SkillCard> cards)
        {
            foreach (var card in cards)
                Discard(card);
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
