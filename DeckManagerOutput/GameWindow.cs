using System;
using System.Text;
using System.Windows.Forms;

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
            var form = new HelpForm(handString.ToString(), "Player Skill Cards");
            form.ShowDialog();

        }
    }
}
