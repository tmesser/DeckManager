using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeckManager;
using DeckManager.States;
using DeckManagerOutput;

namespace DeckManagerOutput
{
    public partial class MainForm : Form
    {
        private readonly MainMenu _mainMenu;

        public MainForm()
        {
            InitializeComponent();
            _mainMenu = new MainMenu();
            _mainMenu.MenuItems.Add(new MenuItem("Game"));
            Menu = _mainMenu;
        }

        private void GiveCardToCurrentCharacterButtonClick(object sender, EventArgs e)
        {
            // give drawn card to currently selected player (skill or quorum)
            var card = (DeckManager.Cards.BaseCard)drawnCardListBox.SelectedItem;
            var currentPlayer = (Player)characterListBox.SelectedItem;

            switch (card.CardType)
            {
                case DeckManager.Cards.Enums.CardType.Skill:
                    currentPlayer.Cards.Add((DeckManager.Cards.SkillCard)card);
                    break;
                case DeckManager.Cards.Enums.CardType.Quorum:
                    // @todo no representation of quorum deck yet
                    break;
            }

            drawnCardListBox.Items.Remove(card);
        }

        private void PolDeckButtonClick(object sender, EventArgs e)
        {

            drawnCardListBox.BeginUpdate();
            //DeckManager.Cards.SkillCard card = Program.gManager.CurrentGameState.PoliticsDeck.Draw();

            var card = new DeckManager.Cards.SkillCard
                {
                    CardColor = DeckManager.Cards.Enums.SkillCardColor.Politics,
                    CardPower = 5,
                    Heading = "test Card"
                };

            drawnCardListBox.Items.Add(card);

            drawnCardListBox.EndUpdate();
        }

        private void LeaDeckButtonClick(object sender, EventArgs e)
        {

        }

        private void TacDeckButtonClick(object sender, EventArgs e)
        {

        }

        private void EngDeckButtonClick(object sender, EventArgs e)
        {

        }

        private void PilDeckButtonClick(object sender, EventArgs e)
        {

        }

        private void TreDeckButtonClick(object sender, EventArgs e)
        {

        }

        private void DrawCrisisButtonClick(object sender, EventArgs e)
        {
            var crisis = Program.GManager.CurrentGameState.CrisisDeck.Draw();

            crisisSkillCheckListBox.Items.Add(crisis);
        }

        private void CrisisCopyTextButtonClick(object sender, EventArgs e)
        {
            Clipboard.SetText(crisisSkillCheckListBox.SelectedItem.ToString());
        }

        private void AddDestinyCardsButtonClick(object sender, EventArgs e)
        {

        }

        private void AddPlayerButtonClick(object sender, EventArgs e)
        {
            
        }

        private void BeginGameButtonClick(object sender, EventArgs e)
        {

        }

        private void EvalSkillCheckButtonClick(object sender, EventArgs e)
        {

        }

        private void PlayIntoCrisisButtonClick(object sender, EventArgs e)
        {

        }

        private void DiscardSkillCardButtonClick(object sender, EventArgs e)
        {
            var currentPlayer = (Player)characterListBox.SelectedItem;
            var card = (DeckManager.Cards.SkillCard)characterSkillHandListBox.SelectedItem;

            bool success = currentPlayer.Cards.Remove(card);
            //TODO: We should probably just assume this will work and skimp on the success/fail, if it fails it's more a problem for a log4net logger anyway.
            /*if (success)
                ; // update character skill box with character's skill hand info*/
        }

        private void DrawQuorumButtonClick(object sender, EventArgs e)
        {

        }

        private void DiscardQuorumCardButtonClick(object sender, EventArgs e)
        {

        }

        private void DestinationCountUpDownValueChanged(object sender, EventArgs e)
        {

        }

        private void ReturnToDeckButtonClick(object sender, EventArgs e)
        {
            // return the selected card to the appropriate deck
            // should probably move these switches elsewhere, outside of gui code.
            var card = (DeckManager.Cards.BaseCard)drawnCardListBox.SelectedItem;
            switch (card.CardType)
            {
                case DeckManager.Cards.Enums.CardType.Quorum:
                    Program.GManager.CurrentGameState.QuorumDeck.Bury((DeckManager.Cards.QuorumCard)card);
                    break;
                case DeckManager.Cards.Enums.CardType.Skill:
                    switch (((DeckManager.Cards.SkillCard)card).CardColor)
                    {
                        case DeckManager.Cards.Enums.SkillCardColor.Politics:
                            Program.GManager.CurrentGameState.PoliticsDeck.Bury((DeckManager.Cards.SkillCard)card);
                            break;
                        case DeckManager.Cards.Enums.SkillCardColor.Leadership:
                            Program.GManager.CurrentGameState.LeadershipDeck.Bury((DeckManager.Cards.SkillCard)card);
                            break;
                        case DeckManager.Cards.Enums.SkillCardColor.Tactics:
                            Program.GManager.CurrentGameState.TacticsDeck.Bury((DeckManager.Cards.SkillCard)card);
                            break;
                        case DeckManager.Cards.Enums.SkillCardColor.Engineering:
                            Program.GManager.CurrentGameState.EngineeringDeck.Bury((DeckManager.Cards.SkillCard)card);
                            break;
                        case DeckManager.Cards.Enums.SkillCardColor.Piloting:
                            Program.GManager.CurrentGameState.PilotingDeck.Bury((DeckManager.Cards.SkillCard)card);
                            break;
                        case DeckManager.Cards.Enums.SkillCardColor.Treachery:
                            Program.GManager.CurrentGameState.TreacheryDeck.Bury((DeckManager.Cards.SkillCard)card);
                            break;
                    }
                    break;
            }
            drawnCardListBox.Items.Remove(card);
        }

        private void DrawDestinationsButtonClick(object sender, EventArgs e)
        {
            var count = (int)destinationCountUpDown.Value;
            destinationsListBox.Items.Add(Program.GManager.CurrentGameState.DestinationDeck.DrawMany(count));
        }

        private void CharacterListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            // update skill card list box
            // update quorum card list box if current character is president
        }





    }
}
