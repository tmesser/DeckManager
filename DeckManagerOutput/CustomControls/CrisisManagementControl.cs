using System;
using System.Globalization;
using System.Windows.Forms;
using DeckManager.Extensions;

namespace DeckManagerOutput.CustomControls
{
    /// <summary>
    /// Encapsulates a single Crisis for management in the Crisis Management Form.
    /// </summary>
    public partial class CrisisManagementControl : UserControl
    {
        /// <summary>
        /// Gets or sets the card.
        /// </summary>
        /// <value>
        /// The card.
        /// </value>
        private DeckManager.Cards.CrisisCard Card { get; set; }
        /// <summary>
        /// Gets the crisis decision.
        /// </summary>
        /// <value>
        /// The crisis decision.
        /// </value>
        public CrisisDecision CrisisDecision
        {
            get
            {
                return new CrisisDecision { Crisis = Card, Action = ReadRadioButtons(), Order = (ReadRadioButtons() == CrisisAction.Replace) ? orderTextBox.Text.ParseAs<int>() : -1};
            }
        }

        /// <summary>
        /// Reads the radio buttons.
        /// </summary>
        /// <returns></returns>
        private CrisisAction ReadRadioButtons()
        {
            if (replaceRadioButton.Checked)
                return CrisisAction.Replace;
            if (buryRadioButton.Checked)
                return CrisisAction.Bury;
            if (drawToActiveRadioButton.Checked) 
                return CrisisAction.Draw;
            return CrisisAction.Undefined;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CrisisManagementControl"/> class.
        /// </summary>
        /// <param name="crisisCard">The crisis card.</param>
        /// <param name="order">The order this crisis was drawn.</param>
        /// <remarks>Adding this Control to a form via the designer is gonna end in sorrow.</remarks>
        public CrisisManagementControl(DeckManager.Cards.CrisisCard crisisCard, int order)
        {
            Card = crisisCard;
            InitializeComponent();
            orderTextBox.Text = order.ToString(CultureInfo.InvariantCulture);
            CrisisDisplayTextBox.Text = Card.Heading + Environment.NewLine + Card.AdditionalText;
            
        }
    }
}
