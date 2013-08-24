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
        public Character()
        {
            DefaultDrawColors = new List<List<SkillCardColor>>();

        }
        private List<List<SkillCardColor>> _DefaultDrawColors;
        /// <summary>
        /// Set of draw colors. Each inner list represents mixed draws.
        /// </summary>
        public List<List<SkillCardColor>> DefaultDrawColors 
        {
            get { return _DefaultDrawColors; }
            set 
            {
                _DefaultDrawColors = value;
                UniqueColors = GetUniqueColors();
            } 
        }


        /// <summary>
        /// Unique Skill Colors this character draws
        /// </summary>
        public List<SkillCardColor> UniqueColors { get; private set; }


        public string CharacterName { get; set; }

        private List<SkillCardColor> GetUniqueColors()
        { 
            var ret = new List<SkillCardColor>();
            foreach (List<SkillCardColor> draw in DefaultDrawColors)
                foreach (SkillCardColor color in draw)
                    if (ret.Contains(color))
                        continue;
                    else
                        ret.Add(color);
            return ret;
        }
    }
}
