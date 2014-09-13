using DeckManager.Cards;
using DeckManagerOutput.CustomControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DeckManagerOutput.Properties;

namespace DeckManagerOutput
{
    public partial class CrisisManagementForm : Form
    {
        public IEnumerable<CrisisDecision> Decisions { get; private set; } 

        public CrisisManagementForm(IEnumerable<CrisisCard> crises)
        {
            InitializeComponent();
            var count = 1;
            System.Drawing.Size boxSize = new System.Drawing.Size();
            boxSize.Width = 465;
            foreach (var crisis in crises)
            {
                var crisisControl = new CrisisManagementControl(crisis, count);
                contentPanel.Controls.Add(crisisControl);
                boxSize.Height += crisisControl.Size.Height;
                count++;
            }
            boxSize.Height += 100;
            if (boxSize.Height > 1000)
                boxSize.Height = 1000;
            this.Size = boxSize;
        }

        private void SubmitButtonClick(object sender, EventArgs e)
        {
            var decisions = (from CrisisManagementControl control in contentPanel.Controls select control.CrisisDecision).ToList();
            
            if (decisions.Count(x => x.Action == CrisisAction.Draw) > 1)
            {
                MessageBox.Show(Resources.CrisisManagementForm_TooManyCrisesSetAsActive);
                return;
            }

            if (decisions.Count(x => x.Action == CrisisAction.Replace) !=
                (from decision in decisions select decision.Order).Distinct().Count())
            {
                MessageBox.Show(Resources.CrisisManagementForm_BadReplacementOrder);
                return;
            }

            Decisions = decisions;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
