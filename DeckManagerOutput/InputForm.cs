using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DeckManagerOutput
{
    public partial class InputForm : Form
    {
        public string UserInput { get; private set; }
        public InputForm(string toDisplay, string title)
        {
            InitializeComponent();
            var displayLines = toDisplay.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var widthList = new List<int>();
            using (var g = CreateGraphics())
            {
                widthList.AddRange(displayLines.Select(line => (int)g.MeasureString(line, MessageRichTextBox.Font).Width));
            }
            Width = 50;
            if(widthList.Count > 0)
                Width = ((int)widthList.Average() + 50 < 500) ? (int)widthList.Average() + 50 : 500;

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
                    MessageRichTextBox.Font, MessageRichTextBox.Width).Height + 80;
            }            
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            UserInput = InputTextBox.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
