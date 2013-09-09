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
            PopulateSkillColorListBoxes(newPlayer.Character);
        }

        private void PopulateSkillColorListBoxes(DeckManager.Characters.Character character)
        {
            initialDrawComboBox1.BeginUpdate();
            initialDrawComboBox2.BeginUpdate();
            initialDrawComboBox3.BeginUpdate();

            initialDrawComboBox1.Items.Clear();
            initialDrawComboBox2.Items.Clear();
            initialDrawComboBox3.Items.Clear();
            
            // todo can't draw more of one color than you can draw - need to account for that
            //foreach (DeckManager.Cards.Enums.SkillCardColor color in character.UniqueColors)
            foreach (List<DeckManager.Cards.Enums.SkillCardColor> draw in character.DefaultDrawColors)
            {
                foreach (DeckManager.Cards.Enums.SkillCardColor color in draw)
                {
                    initialDrawComboBox1.Items.Add(color);
                    initialDrawComboBox2.Items.Add(color);
                    initialDrawComboBox3.Items.Add(color);
                }
            }
            initialDrawComboBox3.EndUpdate();
            initialDrawComboBox2.EndUpdate();
            initialDrawComboBox1.EndUpdate();
        }

        private void initialDrawComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void initialDrawComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void initialDrawComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
