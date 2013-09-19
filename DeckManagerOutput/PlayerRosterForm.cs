using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DeckManager.Cards.Enums;
using DeckManager.Characters;
using DeckManager.States;
using DeckManagerOutput.Properties;

namespace DeckManagerOutput
{
    public partial class PlayerRosterForm : Form
    {
        public override sealed string Text
        {
            get { return base.Text; } // This is allowing safe internationalization/abstraction of the form name.
            set { base.Text = value; }
        }

        private IList<Player> _players;
        public IList<Player> Players
        {
            get { return _players ?? (_players = new List<Player>()); }
        }

        public PlayerRosterForm(IEnumerable<Character> characters)
        {
            InitializeComponent();

            Text = Resources.PlayerRosterForm_FormName;

            playerNameLabel.Text = Resources.PlayerRosterForm_PlayerName_Text;
            initialDrawGroupBox.Text = Resources.PlayerRosterForm_InitialDrawGroupBox_Text;
            characterListBoxLabel.Text = Resources.PlayerRosterForm_CharacterListBoxLabel_Text;
            characterDetailButton.Text = Resources.PlayerRosterForm_CharacterDetailButton_Text;
            addPlayerButton.Text = Resources.PlayerRosterForm_AddPlayerButton_Text;
            cancelButton.Text = Resources.Button_Cancel;
            doneButton.Text = Resources.Button_Done;

            characterListBox.BeginUpdate();
            foreach (var character in characters)
                characterListBox.Items.Add(character);
            //characterListBox.DataSource = characters;
            characterListBox.EndUpdate();
        }


        private void CancelButtonClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OkButtonClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void PopulateSkillColorListBoxes(Character character)
        {
            if (character == null)
                return;

            initialDrawComboBox1.BeginUpdate();
            initialDrawComboBox2.BeginUpdate();
            initialDrawComboBox3.BeginUpdate();

            initialDrawComboBox1.Items.Clear();
            initialDrawComboBox2.Items.Clear();
            initialDrawComboBox3.Items.Clear();

            if (Players.Count == 0)
            {
                initialDrawComboBox1.Enabled = false;
                initialDrawComboBox2.Enabled = false;
                initialDrawComboBox3.Enabled = false;
            }
            else
            {
                initialDrawComboBox1.Enabled = true;
                initialDrawComboBox2.Enabled = true;
                initialDrawComboBox3.Enabled = true;
                foreach (var color in character.UniqueColors)
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

        private void CharacterListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            addPlayerButton.Enabled = true;
            characterDetailButton.Enabled = true;
            PopulateSkillColorListBoxes((Character)characterListBox.SelectedItem);
        }

        private void CharacterDetailButtonClick(object sender, EventArgs e)
        {
            var character = (Character) characterListBox.SelectedItem;

            if (character == null)
            {
                MessageBox.Show(Resources.PlayerRosterForm_CharacterDetailButtonClick_No_Character_selected, Resources.PlayerRosterForm_CharacterDetailButton_Text);
                characterDetailButton.Enabled = false;
                return;
            }

            var characterDetail = string.Format("{0} ({1})\r\n\r\n{2}\r\n\r\n{3}",character.CharacterName, character.Role, character.GetHumanReadableDraw(), character.AdditionalText);

            new HelpForm(characterDetail, Resources.PlayerRosterForm_CharacterDetailButton_Text).ShowDialog();
        }

        private void AddPlayerButtonClick(object sender, EventArgs e)
        {
            var character = (Character) characterListBox.SelectedItem;

            if (character == null)
            {
                MessageBox.Show(Resources.PlayerRosterForm_CharacterDetailButtonClick_No_Character_selected, Resources.PlayerRosterForm_AddPlayerButton_Text);
                return;
            }

            var playerName = playerNameTextBox.Text;
            if (string.IsNullOrWhiteSpace(playerName) || default(Player) != Players.FirstOrDefault(x => x.PlayerName == playerName))
            {
                MessageBox.Show(Resources.PlayerRosterForm_AddPlayerButtonClick_NoPlayerName, Resources.PlayerRosterForm_AddPlayerButton_Text);
                return;
            }
            

            var colorDraw = character.DefaultDrawColors.First();
            if (Players.Count != 0)
            {
                if (initialDrawComboBox1.SelectedItem == null || initialDrawComboBox2.SelectedItem == null || initialDrawComboBox3.SelectedItem == null)
                {
                    MessageBox.Show(Resources.PlayerRosterForm_AddPlayerButtonClick_NoDrawSelected, Resources.PlayerRosterForm_AddPlayerButton_Text);
                    return;
                }
                colorDraw = new List<SkillCardColor>
                    {
                        (SkillCardColor) initialDrawComboBox1.SelectedItem,
                        (SkillCardColor) initialDrawComboBox2.SelectedItem,
                        (SkillCardColor) initialDrawComboBox3.SelectedItem
                    };
                foreach (var color in colorDraw.Distinct().Where(color => character.ColorMax(color) < colorDraw.Count(x => x == color)))
                {
                    MessageBox.Show(string.Format( Resources.PlayerRosterForm_AddPlayerButtonClick_InvalidColors, color), Resources.PlayerRosterForm_AddPlayerButton_Text);
                    return;
                }
            }

            var player = new Player {Character = character, PlayerName = playerName, CustomDraws = new List<List<SkillCardColor>>{colorDraw}, TurnPosition = Players.Count+1};
            playerRosterListBox.Items.Add(player);
            Players.Add(player);
            this.characterListBox.Items.Remove(character);
            if (Players.Count > 2)
                doneButton.Enabled = true;

            playerNameTextBox.Text = string.Empty;
            characterListBox.ClearSelected();
            initialDrawComboBox1.SelectedIndex = -1;
            initialDrawComboBox2.SelectedIndex = -1;
            initialDrawComboBox3.SelectedIndex = -1;
            playerNameTextBox.Focus();
        }
    }
}
