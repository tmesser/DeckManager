using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DeckManager.Boards.Dradis;
using DeckManager.Boards.Enums;
using DeckManagerOutput.Properties;

namespace DeckManagerOutput
{
    public partial class GameWindow : Form
    {
        public GameWindow()
        {
            InitializeComponent();
        }

        private void NewGameStripMenuItemClick(object sender, EventArgs e)
        {
            var characters = Program.GManager.CharacterList;
            var rosterForm = new PlayerRosterForm(characters);
            rosterForm.ShowDialog();
            if (rosterForm.DialogResult != DialogResult.OK)
                return;
            
            var optionalRulesForm = new OptionalRulesForm();
            optionalRulesForm.ShowDialog();
            if (optionalRulesForm.DialogResult != DialogResult.OK)
                return;

            Program.GManager.NewGame(rosterForm.Players, optionalRulesForm.ExtraLoyaltyCards, optionalRulesForm.UsingSympathizer);

            PlayerReadonlyListBox.BeginUpdate();
            PlayerReadonlyListBox.DataSource = Program.GManager.CurrentGameState.Players;
            PlayerReadonlyListBox.SelectedIndex = 0;
            PlayerReadonlyListBox.EndUpdate();

            AlphaDradisListBox.DataSource = Program.GManager.CurrentGameState.Dradis.Nodes.First(x => x.Name == DradisNodeName.Alpha).Components;
            BravoDradisListBox.DataSource = Program.GManager.CurrentGameState.Dradis.Nodes.First(x => x.Name == DradisNodeName.Bravo).Components;
            CharlieDradisListBox.DataSource = Program.GManager.CurrentGameState.Dradis.Nodes.First(x => x.Name == DradisNodeName.Charlie).Components;
            DeltaDradisListBox.DataSource = Program.GManager.CurrentGameState.Dradis.Nodes.First(x => x.Name == DradisNodeName.Delta).Components;
            EchoDradisListBox.DataSource = Program.GManager.CurrentGameState.Dradis.Nodes.First(x => x.Name == DradisNodeName.Echo).Components;
            FoxtrotDradisListBox.DataSource = Program.GManager.CurrentGameState.Dradis.Nodes.First(x => x.Name == DradisNodeName.Foxtrot).Components;

            AlphaDradisListBox.SelectedIndex = -1;
            BravoDradisListBox.SelectedIndex = -1;
            CharlieDradisListBox.SelectedIndex = -1;
            DeltaDradisListBox.SelectedIndex = -1;
            EchoDradisListBox.SelectedIndex = -1;
            FoxtrotDradisListBox.SelectedIndex = -1;

            GalacticaBoardListBox.DataSource = Program.GManager.CurrentGameState.Boards.First(x => x.Name == BoardName.Galactica).Locations;
            ColonialOneListBox.DataSource = Program.GManager.CurrentGameState.Boards.First(x => x.Name == BoardName.ColonialOne).Locations;
            CylonBoardListBox.DataSource = Program.GManager.CurrentGameState.Boards.First(x => x.Name == BoardName.Cylon).Locations;

            GalacticaBoardListBox.SelectedIndex = -1;
            ColonialOneListBox.SelectedIndex = -1;
            CylonBoardListBox.SelectedIndex = -1;

            FoodUpDown.Value = Program.GManager.CurrentGameState.Food;
            FuelUpDown.Value = Program.GManager.CurrentGameState.Fuel;
            MoraleUpDown.Value = Program.GManager.CurrentGameState.Morale;
            PopUpDown.Value = Program.GManager.CurrentGameState.Population;

            JumpPrepChanged(sender, e);

            /*UpdateDradis(DradisNodeName.Alpha);
            UpdateDradis(DradisNodeName.Bravo);
            UpdateDradis(DradisNodeName.Charlie);
            UpdateDradis(DradisNodeName.Delta);
            UpdateDradis(DradisNodeName.Echo);
            UpdateDradis(DradisNodeName.Foxtrot);*/
        }

        private void ShowHandMenuItemClick(object sender, EventArgs e)
        {
            var playerHand = Program.GManager.CurrentGameState.Players[PlayerReadonlyListBox.SelectedIndex].Cards;
            var handString = new StringBuilder();
            foreach (var card in playerHand)
            {
                handString.Append(card);
                handString.Append(Environment.NewLine);
            }
            var form = new HelpForm(handString.ToString(), Resources.GameWindow_ShowHandMenuItemClick_HelpForm_Title);
            form.ShowDialog();
        }

        private void UpdateDradis(DradisNodeName input)
        {
            if (input == DradisNodeName.Unknown)
                return;
            var alphaComponents = Program.GManager.CurrentGameState.Dradis.GetComponents(input);
            foreach(var component in alphaComponents)
                AlphaDradisListBox.Items.Add(component);
        }

        private void JumpPrepChanged(object sender, EventArgs e)
        {
            if (Red1RadioButton.Checked || Red2RadioButton.Checked || Red3RadioButton.Checked)
            {
                JumpPrepGroupBox.ForeColor = Color.Red;
                JumpPrepGroupBox.Text = Resources.GameWindow_JumpPrepChanged_NoJumping;
            }
            else if (Risk3RadioButton.Checked)
            {
                JumpPrepGroupBox.ForeColor = Color.Goldenrod;
                JumpPrepGroupBox.Text = Resources.GameWindow_JumpPrepChanged_Risk3;
            }
            else if (Risk1RadioButton.Checked)
            {
                JumpPrepGroupBox.ForeColor = Color.Goldenrod;
                JumpPrepGroupBox.Text = Resources.GameWindow_JumpPrepChanged_Risk1;
            }
            else if (JumpNowRadioButton.Checked)
            {
                JumpPrepGroupBox.ForeColor = Color.Green;
                JumpPrepGroupBox.Text = Resources.GameWindow_JumpPrepChanged_JumpNow;
            }
        }

        private void IncreaseJumpPrepToolStripMenuItemClick(object sender, EventArgs e)
        {
            Program.GManager.CurrentGameState.JumpPrep += 1;
            Program.GManager.CurrentGameState.TurnLog += GetJumpPrepString(true);

            Red1RadioButton.Checked = false;
            Red2RadioButton.Checked = false;
            Red3RadioButton.Checked = false;
            Risk3RadioButton.Checked = false;
            Risk1RadioButton.Checked = false;
            JumpNowRadioButton.Checked = false;

            switch (Program.GManager.CurrentGameState.JumpPrep)
            {
                case 0:
                    Red1RadioButton.Checked = true;
                    break;
                case 1:
                    Red2RadioButton.Checked = true;
                    break;
                case 2:
                    Red3RadioButton.Checked = true;
                    break;
                case 3:
                    Risk3RadioButton.Checked = true;
                    break;
                case 4:
                    Risk1RadioButton.Checked = true;
                    break;
                case 5:
                    JumpNowRadioButton.Checked = true;
                    break;
            }
        }

        private void DecreaseJumpPrepToolStripMenuItemClick(object sender, EventArgs e)
        {
            Program.GManager.CurrentGameState.JumpPrep -= 1;
            Program.GManager.CurrentGameState.TurnLog += GetJumpPrepString(true);

            Red1RadioButton.Checked = false;
            Red2RadioButton.Checked = false;
            Red3RadioButton.Checked = false;
            Risk3RadioButton.Checked = false;
            Risk1RadioButton.Checked = false;
            JumpNowRadioButton.Checked = false;

            switch (Program.GManager.CurrentGameState.JumpPrep)
            {
                case 0:
                    Red1RadioButton.Checked = true;
                    break;
                case 1:
                    Red2RadioButton.Checked = true;
                    break;
                case 2:
                    Red3RadioButton.Checked = true;
                    break;
                case 3:
                    Risk3RadioButton.Checked = true;
                    break;
                case 4:
                    Risk1RadioButton.Checked = true;
                    break;
                case 5:
                    JumpNowRadioButton.Checked = true;
                    break;
            }
        }

        private static string GetJumpPrepString(bool increase)
        {
            var status = string.Empty;
            switch (Program.GManager.CurrentGameState.JumpPrep)
            {
                case 0:
                    status = Resources.JumpPrep_Red1;
                    break;
                case 1:
                    status = Resources.JumpPrep_Red2;
                    break;
                case 2:
                    status = Resources.JumpPrep_Red3;
                    break;
                case 3:
                    status = Resources.JumpPrep_Risk3;
                    break;
                case 4:
                    status = Resources.JumpPrep_Risk1;
                    break;
                case 5:
                    status = Resources.JumpPrep_AutoJump;
                    break;
            }
            return string.Format(Resources.JumpPrep_Base, ((increase) ? Resources.JumpPrep_Increase : Resources.JumpPrep_Decrease), status);
        }
    }
}
