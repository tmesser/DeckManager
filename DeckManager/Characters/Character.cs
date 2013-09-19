using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public Enums.Roles Role { get; set; }

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
        /// Returns the maximum number of cards the character can draw of this color.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns></returns>
        public int ColorMax(SkillCardColor color)
        {
            return DefaultDrawColors.Select(draw => draw.Count(x => x == color)).Concat(new[] {0}).Max();
        }

        /// <summary>
        /// returns the character's draw in the form; LEA/3, TAC/2
        /// </summary>
        /// <returns></returns>
        public string GetHumanReadableDraw()
        {
            var ret = new StringBuilder();
            foreach(var draw in DefaultDrawColors)
            {
                ret.Append("[");
                foreach (var color in UniqueColors)
                {
                    var colorCount = draw.Count(x => x == color);
                    if(colorCount > 0)
                        ret.Append(string.Format("{0}/{1}, ", color, colorCount));
                }
                ret.Length -= 2; // gets rid of the last ", "
                ret.Append("] ");
            }

            return ret.ToString().Trim();
        }
        public override string ToString()
        {
            return string.Format("{0} ({1})", CharacterName, Role);
        }
    }
}
