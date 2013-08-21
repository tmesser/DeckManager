﻿using DeckManager.Cards.Enums;

namespace DeckManager.Cards
{
    public class LoyaltyCard : BaseCard
    {
        /// <summary>
        /// Gets or sets the loyalty the card represents.
        /// </summary>
        /// <value>
        /// The loyalty.
        /// </value>
        public Loyalty Loyalty { get; set; }
        /// <summary>
        /// Gets or sets additional text, for stuff like Cylon reveal effects and Final Five consequences.
        /// </summary>
        /// <value>
        /// The additional text.
        /// </value>
        public string AdditionalText { get; set; }

        /// <summary>
        /// Returns that this is a Loyalty card.
        /// </summary>
        /// <value>
        /// The type of the card.
        /// </value>
        public override CardType CardType
        {
            get { return CardType.Loyalty; }
        }

        /// <summary>
        /// Outputs a BBCode representation of the card
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override string ToBBCode()
        {
            throw new System.NotImplementedException();
        }
    }
}
