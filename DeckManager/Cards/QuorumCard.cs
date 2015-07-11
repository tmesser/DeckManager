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

        public override Expansion ExpansionSource
        {
            get { return Expansion.Base; }
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
    }
}
