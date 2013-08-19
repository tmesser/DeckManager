using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeckManager.Cards.Enums;
using DeckManager.Cards;

namespace DeckManager.DeckManager.Characters
{
    class Character
    {
        /// <summary>
        /// Set of draw colors. Each inner list represents mixed draws.
        /// </summary>
        public List<List<SkillCardColor>> drawColors { get; set; }

        /// <summary>
        /// Skill card hand
        /// </summary>
        public List<SkillCard> skillHand { get; private set; }

        public List<Titles> titles { get; set; }

        public string characterName;
        public string playerName;


    }
}
