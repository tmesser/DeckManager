using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                return new CrisisDecision { Crisis = Card, Action = ReadRadioButtons() };
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
        /// <remarks>Adding this Control to a form via the designer is gonna end in sorrow.</remarks>
        public CrisisManagementControl(DeckManager.Cards.CrisisCard crisisCard)
        {
            Card = crisisCard;
            InitializeComponent();
        }
    }
}
