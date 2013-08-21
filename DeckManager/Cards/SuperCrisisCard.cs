using DeckManager.Cards.Enums;

namespace DeckManager.Cards
{
    public class SuperCrisisCard : CrisisCard
    {
        /// <summary>
        /// Reports that this is a crisis card.
        /// </summary>
        /// <value>
        /// The type of the card.
        /// </value>
        public override CardType CardType
        {
            get { return CardType.SuperCrisis; }
        }
    }
}
