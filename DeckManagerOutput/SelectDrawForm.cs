using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DeckManager.Cards.Enums;

namespace DeckManagerOutput
{
    public partial class SelectDrawForm : Form
    {
        public int? SelectedSkillCardDrawIndex { get; private set; }

        public SelectDrawForm(IEnumerable<IEnumerable<SkillCardColor>> draws)
        {
            SelectedSkillCardDrawIndex = null;
            InitializeComponent();
            var items = new List<ListItem>();
            var index = 1;
            foreach (var draw in draws)
            {
                var text = new StringBuilder();
                foreach (var color in draw)
                {
                    text.Append(color + ", ");
                }
                text.Length -= 2; //Getting rid of the last comma.
                items.Add(new ListItem{Text = text.ToString(), Value = index});
                index++;
            }
            items.Add(new ListItem {Text = "Do Manual Draw", Value = null});

            DrawSelectComboBox.DataSource = items;
            DrawSelectComboBox.DisplayMember = "Text";
            DrawSelectComboBox.ValueMember = "Value";
        }

        private void SubmitButtonClick(object sender, EventArgs e)
        {
            SelectedSkillCardDrawIndex = (int?) DrawSelectComboBox.SelectedValue;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private class ListItem
        {
            public string Text { get; set; }
            public int? Value { get; set; }
        }
    }
}
