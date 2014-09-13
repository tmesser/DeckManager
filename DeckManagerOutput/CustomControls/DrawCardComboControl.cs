using System;
using System.Windows.Forms;
using DeckManager.Cards.Enums;
using DeckManager.Extensions;

namespace DeckManagerOutput.CustomControls
{
    public partial class DrawCardComboControl : UserControl
    {
        public int NumCardsRequested
        {
            get { return DrawCardsCheckBox.Checked ? DrawAmountComboBox.Text.ParseAs<int>() : 0; }
        }

        public SkillCardColor CardColorRequested 
        {
            get { return DrawCardsCheckBox.Checked ? (SkillCardColor)Enum.Parse(typeof(SkillCardColor), (string)DrawTypeComboBox.SelectedItem) : 0; }
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
