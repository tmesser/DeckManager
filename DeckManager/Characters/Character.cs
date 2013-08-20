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
        public List<List<SkillCardColor>> drawColors { get; set; }

        /// <summary>
        /// Skill card hand
        /// </summary>
        public List<SkillCard> skillHand { get; private set; }

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

    }
}
