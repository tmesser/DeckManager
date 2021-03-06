﻿using DeckManager.Cards.Enums;

namespace DeckManager.Cards
{
    public class SuperCrisisCard : CrisisCard
    {
        /// <summary>
        /// Reports that this is a super crisis card.
        /// </summary>
        /// <value>
        /// The type of the card.
        /// </value>
        public override CardType CardType
        {
            get { return CardType.SuperCrisis; }
        }
        public override string ToString()
        {
            return Heading + "\n" + AdditionalText;
        }
    }
}
