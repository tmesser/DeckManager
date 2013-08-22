using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeckManagerOutput
{
    public partial class NewPlayerForm : Form
    {
        public NewPlayerForm(ListBox characters)
        {
            InitializeComponent();
            characterListBox = characters;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {

        }

        private void characterListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
