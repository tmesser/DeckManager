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

            foreach (var crisis in crises)
            {
                contentPanel.Controls.Add(new CrisisManagementControl(crisis));
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            var decisions = (from CrisisManagementControl control in contentPanel.Controls select control.CrisisDecision).ToList();
            if (decisions.Count(x => x.Action == CrisisAction.Draw) > 1)
            {
                MessageBox.Show(Resources.CrisisManagementForm_TooManyCrisesSetAsActive);
                return;
            }
            Decisions = decisions;
            Close();
        }
    }
}
