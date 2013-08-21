using System;
using System.Collections.Generic;
using DeckManager.Cards.Enums;

namespace DeckManager.Cards
{
    public class MisisonCard : BaseCard
    {


        /// <summary>
        /// Reports that this is a crisis card.
        /// </summary>
        /// <value>
        /// The type of the card.
        /// </value>
        public override CardType CardType
        {
            get { return CardType.Mission; }
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
        /// Gets or sets the positive card colors.
        /// </summary>
        /// <value>
        /// The positive colors.
        /// </value>
        public List<SkillCardColor> PositiveColors { get; set; }

        /// <summary>
        /// Gets or sets whether the Crisis has Jump Prep
        /// </summary>
        public bool JumpPrep { get; set; }

        /// <summary>
        /// Gets or Sets the Crisis' cylon activation
        /// </summary>
        public CylonActivations Activation { get; set; }

        /// <summary>
        /// This crisis' skill check (can be null)
        /// </summary>
        public List<Tuple<int, string>> PassLevels { get; set; }

        /// <summary>
        /// Formats the object for posts on BBCode forums
        /// </summary>
        /// <returns></returns>
        public string toBBCode()
        {
            return "not implemented";
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
