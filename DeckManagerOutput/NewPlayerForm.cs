using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeckManager.States;

namespace DeckManagerOutput
{
    public partial class NewPlayerForm : Form
    {
        public Player newPlayer { get; private set; }

        public NewPlayerForm(ListBox characters)
        {
            InitializeComponent();
            characterListBox.BeginUpdate();
            characterListBox.Items.AddRange(characters.Items);
            characterListBox.EndUpdate();
            newPlayer = new Player();
        }

        private void playerNameTextBox_Leave(object sender, EventArgs e)
        {
            newPlayer.PlayerName = this.playerNameTextBox.Text;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void characterListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OKButton.Enabled = true;
            newPlayer.Character = (DeckManager.Characters.Character)this.characterListBox.SelectedItem;
        }
    }
}
