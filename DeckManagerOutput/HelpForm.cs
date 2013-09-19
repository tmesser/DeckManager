using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DeckManagerOutput
{
    public sealed partial class HelpForm : Form
    {
        public HelpForm(string toDisplay, string title)
        {
            InitializeComponent();
            var displayLines = toDisplay.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            var widthList = new List<int>();
            using (var g = CreateGraphics())
            {
                widthList.AddRange(displayLines.Select(line => (int) g.MeasureString(line, MessageRichTextBox.Font).Width));
            }
            Width = (int)widthList.Average()+50;

            toDisplay = toDisplay.Replace(Environment.NewLine, @" \line "); //Flattening carriage returns from string input to rtf.

            var text = new StringBuilder();

            text.Append(@"{\rtf1\ansi ");
            text.Append(toDisplay);
            text.Append(@"}");
            MessageRichTextBox.Rtf = text.ToString();
            Text = title;
            using (var g = CreateGraphics())
            {
                Height = (int)g.MeasureString(MessageRichTextBox.Text,
                    MessageRichTextBox.Font, MessageRichTextBox.Width).Height+80;
            }
            
        }

        private void OkButtonClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
