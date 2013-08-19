using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeckManager.Cards.Enums;

namespace DeckManager.Cards
{
    class SkillCheck
    {
        public List<SkillCardColor> positiveColors { get; set; }
        public List<SkillCard> playedCards { get; private set; }
        public List<Consequence> consequences { get; set; }
        public Guid guid { get; set; }
        public string name { get; set; }
        public int passValue { get; set; }


        public SkillCheck()
        {
            playedCards = new List<SkillCard>();
        }

        /// <summary>
        /// Plays a card into the skill check
        /// </summary>
        /// <param name="card">The SkillCard to add to the skillcheck</param>
        /// <returns></returns>
        public void playCard(SkillCard card)
        {
            this.playedCards.Add(card);
        }

        /// <summary>
        /// Empties the SkillCheck's deck of skill cards and returns them to be discarded into their respective decks
        /// </summary>
        /// <returns></returns>
        public List<SkillCard> retrieveSkillCards()
        {
            List<SkillCard> copy = new List<SkillCard>(this.playedCards);
            this.playedCards.Clear();
            return copy;
        }

        public void addConsequence(string text, int threshold = 0)
        {
            this.consequences.Add(new Consequence(text, threshold));
        }
        /// <summary>
        /// Evaluates the skill check after all cards have been played.
        /// </summary>
        /// <returns>List of all consequences that occur as a result of the skill check's outcome.</returns>
        public List<Consequence> evalSkillCheck()
        {
            int posTotal = 0;
            int negTotal = 0;
            List<Consequence> results = new List<Consequence>();
            bool scaHit = false;
            foreach (SkillCard card in this.playedCards)
            {
                if (card.CardPower > 0)
                {
                    if (this.positiveColors.Contains(card.CardColor))
                        posTotal += card.CardPower;
                    else
                        negTotal += card.CardPower;
                }
                else if (!scaHit && this.consequences.Exists(x => x.threshold == -1))
                {
                    scaHit = true;
                    results.Add(this.consequences.Find(x => x.threshold == -1));    // SCA consequence only happens once
                }
            }



            return null;
        }

        class Consequence
        {   
            /// <summary>
            /// Threshold for consequence to occur. Max value for skill check is pass, 0 is fail, -1 is a skill check ability consequence.
            /// </summary>
            public int threshold { get; set; }

            public string conditionText { get; set; }

            public Consequence(string text, int threshold)
            {
                this.conditionText = text;
                this.threshold = threshold;
            }
        }
    }
}
