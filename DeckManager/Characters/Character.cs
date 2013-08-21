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
    }
}
