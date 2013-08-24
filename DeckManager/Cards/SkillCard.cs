using DeckManager.Cards.Enums;

namespace DeckManager.Cards
{
    public class SkillCard : BaseCard
    {
        /// <summary>
        /// Name of the Card (e.g. "Executive Order")
        /// </summary>
        /// <value>
        /// The heading.
        /// </value>
        public string Heading { get; set; }

        /// <summary>
        /// Gets or sets the color of the card.
        /// </summary>
        /// <value>
        /// The color of the card.
        /// </value>
        public SkillCardColor CardColor { get; set; }
        
        /// <summary>
        /// Gets or sets the card power.
        /// </summary>
        /// <value>
        /// The card power.
        /// </value>
        public int CardPower { get; set; }


        /// <summary>
        /// Gets or sets the additional text, for flavor text, card descriptions, etc.
        /// </summary>
        /// <value>
        /// The additional text.
        /// </value>
        public string AdditionalText { get; set; }

        /// <summary>
        /// Returns that this is a skill card.
        /// </summary>
        /// <value>
        /// The type of the card.
        /// </value>
        public override CardType CardType
        {
            get { return CardType.Skill; }
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
        /// <summary>
        /// Returns card summary for ListBox controls (e.g. "LEA-2 Executive Order")
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return CardColor + " " + CardPower + " " + Heading;
        }
    }
}
