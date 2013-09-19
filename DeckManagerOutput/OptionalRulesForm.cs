using System;
using System.Windows.Forms;
using DeckManager.Extensions;
using DeckManagerOutput.Properties;

namespace DeckManagerOutput
{
    public partial class OptionalRulesForm : Form
    {
        //sealing this so we can set the form name from Resources.
        public int ExtraLoyaltyCards { get; private set; }
        public bool UsingSympathizer { get; private set; }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        public OptionalRulesForm()
        {
            InitializeComponent();
            Text = Resources.OptionalRulesForm_FormName;
            ExtraLoyaltyCardsLabel.Text = Resources.OptionalRulesForm_OptionalRulesForm_ExtraLoyaltyCardsLabel_Text;
            SympathizerLabel.Text = Resources.OptionalRulesForm_OptionalRulesForm_SympathizerLabel_Text;
            SympathizerCheckBox.Text = Resources.OptionalRulesForm_SympathizerCheckBoxCheckedChanged_Sympathizer_False;
            ExtraLoyaltyCardsComboBox.SelectedIndex = 0;
        }

        private void ExtraLoyaltyCardsHelpLabelClick(object sender, EventArgs e)
        {
            var helpForm = new HelpForm(Resources.OptionalRulesForm_ExtraLoyaltyCards_Text, Resources.OptionalRulesForm_FormName);
            helpForm.Show();

        }

        private void UsingSympathizerHelpLabelClick(object sender, EventArgs e)
        {
            var helpForm = new HelpForm(Resources.OptionalRulesForm_Sympathizer_Text, Resources.OptionalRulesForm_FormName);
            helpForm.Show();
        }

        private void HelpLabelMouseHover(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void HelpLabelMouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void SympathizerCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            SympathizerCheckBox.Text = SympathizerCheckBox.Checked ? 
                Resources.OptionalRulesForm_SympathizerCheckBoxCheckedChanged_Sympathizer_True : 
                Resources.OptionalRulesForm_SympathizerCheckBoxCheckedChanged_Sympathizer_False;
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OkButtonClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            ExtraLoyaltyCards = ExtraLoyaltyCardsComboBox.SelectedText.ParseAs<int>();
            UsingSympathizer = SympathizerCheckBox.Checked;
            Close();
        }
    }
}
