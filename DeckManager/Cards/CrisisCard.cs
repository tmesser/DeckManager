using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeckManager.Cards.Enums;

namespace DeckManager.Cards
{
    public class CrisisCard : BaseCard
    {
        /// <summary>
        /// Reports that this is a crisis card.
        /// </summary>
        /// <value>
        /// The type of the card.
        /// </value>
        public override CardType CardType
        {
            get { return CardType.Crisis; }
        }

        /// <summary>
        /// Title of the crisis.
        /// </summary>
        /// <value>
        /// The heading.
        /// </value>
        public string Heading { get; set; }

        /// <summary>
        /// Gets or sets the additional text, description of the crisis, etc
        /// </summary>
        /// <value>
        /// The additional text.
        /// </value>
        public string AdditionalText { get; set; }
        
        /// <summary>
        /// A list of skill card colors that are positive for this crisis.
        /// </summary>
        /// <value>
        /// The positive colors.
        /// </value>
        public List<SkillCardColor> PositiveColors { get; set; }

        /// <summary>
        /// Gets or sets the crisis strength.
        /// </summary>
        /// <value>
        /// The crisis strength.
        /// </value>
        public int CrisisStrength { get; set; }

        /// <summary>
        /// Gets or sets the partial pass strength (if it exists).
        /// </summary>
        /// <value>
        /// The partial pass.
        /// </value>
        public int? PartialPass { get; set; }

        /// <summary>
        /// Gets or sets the post crisis text - Basestars attack, raiders activate, jump prep increases, etc.
        /// </summary>
        /// <value>
        /// The post crisis.
        /// </value>
        public string PostCrisis { get; set; }
    }
}
