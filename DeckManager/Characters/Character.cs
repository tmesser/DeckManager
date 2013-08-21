using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeckManager.Cards.Enums;
using DeckManager.Cards;

namespace DeckManager.Characters
{
    public class Character
    {
        /// <summary>
        /// Set of draw colors. Each inner list represents mixed draws.
        /// </summary>
        public List<List<SkillCardColor>> DefaultDrawColors { get; set; }

        public string CharacterName { get; set; }
        public List<QuorumCard> QuorumHand { get; set; }
        public List<SuperCrisisCard> SCCHand { get; private set; }

        public List<Titles> Titles { get; set; }

        public string characterName { get; set; }
        public string playerName { get; set; }

        /// <summary>
        /// Discard a specific card. Removes the card from the character's hand if it exists.
        /// </summary>
        /// <param name="card">The Card to remove</param>
        /// <returns>True if the card was present and successfully removed, false if not.</returns>
        public bool discard(DeckManager.Cards.SkillCard card)
        {
            if (this.skillHand.Contains(card))
                this.skillHand.Remove(card);
            else 
                return false;
            return true;
        }
        public bool discard(DeckManager.Cards.QuorumCard card)
        {
            if (this.QuorumHand.Contains(card))
                this.QuorumHand.Remove(card);
            else
                return false;
            return true;
        }
        public override string ToString()
        {
            // MetricUnit (President Roslin [1], 6Q)
            string titles = this.Titles.Count>0?string.Join(" ", this.Titles)+" ":"";
            return this.playerName + " (" + titles + this.characterName + ") [" + this.skillHand.Count.ToString() + "] " + (this.QuorumHand.Count > 0 ? this.QuorumHand.Count.ToString() + "Q" : "");
        }

    }
}
