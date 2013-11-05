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
    public partial class CrisisManagementControl : UserControl
    {
        private DeckManager.Cards.CrisisCard Card { get; set; }
        public CrisisDecision CrisisDecision
        {
            get
            {
                return new CrisisDecision { Crisis = Card, Action = ReadRadioButtons() };
            }
        }

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

        public CrisisManagementControl(DeckManager.Cards.CrisisCard crisisCard)
        {
            Card = crisisCard;
            InitializeComponent();
        }
    }
}
