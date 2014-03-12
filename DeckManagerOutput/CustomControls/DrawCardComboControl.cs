using System;
using System.Windows.Forms;
using DeckManager.Cards.Enums;

namespace DeckManagerOutput.CustomControls
{
    public partial class DrawCardComboControl : UserControl
    {
        public int NumCardsRequested
        {
            get { return DrawCardsCheckBox.Enabled ? (int) DrawAmountComboBox.SelectedValue : 0; }
        }

        public SkillCardColor CardColorRequested 
        {
            get { return DrawCardsCheckBox.Enabled ? (SkillCardColor)Enum.Parse(typeof(SkillCardColor), (string)DrawTypeComboBox.SelectedValue) : 0; }
        }

        public DrawCardComboControl()
        {
            InitializeComponent();
        }

        private void DrawCardsCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            DrawAmountComboBox.Enabled = DrawCardsCheckBox.Checked;
            DrawTypeComboBox.Enabled = DrawCardsCheckBox.Checked;
        }
    }
}
