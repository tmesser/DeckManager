using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeckManager.Cards.Enums;
using DeckManager.Cards;
using Newtonsoft.Json;

namespace DeckManager.Characters
{
    public class Character
    {
        public Character()
        {
            DefaultDrawColors = new List<List<SkillCardColor>>();
        }

        public string CharacterName { get; set; }

        public string SetupLocation { get; set; }

        public DeckManager.Characters.Enums.Roles Role { get; set; }

        /// <summary>
        /// Set of draw colors. Each inner list represents mixed draws.
        /// </summary>
        public List<List<SkillCardColor>> DefaultDrawColors { get; set; }
        
        /// <summary>
        /// Unique Skill Colors this character draws
        /// </summary>
        [JsonIgnore]
        public IEnumerable<SkillCardColor> UniqueColors
        {
            get
            {
                return DefaultDrawColors.SelectMany(draw => draw).Distinct();
            }
        }
    }
}
