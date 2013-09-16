using DeckManager.Cards.Enums;

namespace DeckManager.Cards
{
    public class QuorumCard : BaseCard
    {
        /// <summary>
        /// Notes that this is a Quorum card.
        /// </summary>
        /// <value>
        /// The type of the card.
        /// </value>
        public override CardType CardType
        {
            get { return CardType.Quorum; }
        }

        /// <summary>
        /// Outputs a BBCode representation for the card.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override string ToBBCode()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return Heading + "\n" + AdditionalText;
        }

        /// <summary>
        /// Gets or sets the heading. Basic display stuff, like Inspirational Speech or whatever
        /// </summary>
        /// <value>
        /// The heading.
        /// </value>
        public string Heading { get; set; }

        /// <summary>
        /// Gets or sets the additional text, for flavor text, card descriptions, etc.
        /// </summary>
        /// <value>
        /// The additional text.
        /// </value>
        public string AdditionalText { get; set; }

    }
}
