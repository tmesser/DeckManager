using System.Collections.Generic;
using System.Linq;
using DeckManager.Cards.Enums;
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
        /// Gets or sets the additional text -- powers, drawbacks, etc.
        /// </summary>
        /// <value>
        /// The additional text.
        /// </value>
        public string AdditionalText { get; set; }

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

        /// <summary>
        /// returns the character's draw in the form; LEA/3, TAC/2
        /// </summary>
        /// <returns></returns>
        public string GetHumanReadableDraw()
        {
            return "";
        }
        public override string ToString()
        {
            return CharacterName + " " + GetHumanReadableDraw();
        }
    }
}
