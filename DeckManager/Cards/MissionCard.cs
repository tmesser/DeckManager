using System;
using System.Collections.Generic;
using DeckManager.Cards.Enums;

namespace DeckManager.Cards
{
    public class MissionCard : BaseCard
    {
        /// <summary>
        /// Reports that this is a Mission card.
        /// </summary>
        /// <value>
        /// The type of the card.
        /// </value>
        public override CardType CardType
        {
            get { return CardType.Mission; }
        }

        /// <summary>
        /// Returns a representation of the card in BBCode.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override string ToBBCode()
        {
            throw new NotImplementedException();
        }
        
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
    }
}
