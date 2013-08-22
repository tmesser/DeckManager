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
            Array cards = new DeckManager.Cards.BaseCard[drawnCardListBox.SelectedItems.Count];
            drawnCardListBox.SelectedItems.CopyTo(cards, 0);
            var currentPlayer = (Player)characterListBox.SelectedItem;

            // give selected cards to currently selected player (skill or quorum)
            foreach (DeckManager.Cards.BaseCard card in cards)
            {
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
        private void CrisisTextBoxMeasureItem(object sender, MeasureItemEventArgs e)
        {
            //e.ItemHeight = 50;
            string item = crisisTextListBox.Items[e.Index].ToString();
            int count = item.Count(f=>f=='\n');
            count++;
            e.ItemHeight *= count;
        }

        private void CrisisTextBoxDrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            Rectangle itemBounds = e.Bounds;

            e.Graphics.DrawString(crisisTextListBox.Items[e.Index].ToString(),
                e.Font,
                Brushes.Black,
                itemBounds,
                StringFormat.GenericDefault);
            e.DrawFocusRectangle();

        }

        private void DrawCrisisButtonClick(object sender, EventArgs e)
        {
            crisisTextListBox.BeginUpdate();

            // DeckManager.Cards.CrisisCard crisis = Program.gManager.CurrentGameState.CrisisDeck.Draw();
            // TODO: This sort of stuff should really be done in the TESTS project.  See my example in there.
            var crisis = new DeckManager.Cards.CrisisCard
                {
                    Activation = DeckManager.Cards.Enums.CylonActivations.Raiders,
                    Heading = "Test Crisis",
                    JumpPrep = true,
                    AdditionalText = "A description of the crisis",
                    PositiveColors =
                        new List<DeckManager.Cards.Enums.SkillCardColor>
                            {
                                DeckManager.Cards.Enums.SkillCardColor.Engineering,
                                DeckManager.Cards.Enums.SkillCardColor.Politics
                            }
                };

            crisisTextListBox.Items.Add(crisis);
            crisisTextListBox.EndUpdate();
        }

        private void CrisisCopyTextButtonClick(object sender, EventArgs e)
        {
            Clipboard.SetText(crisisSkillCheckListBox.SelectedItem.ToString());
        }

        private void AddDestinyCardsButtonClick(object sender, EventArgs e)
        {
            var dest1 =  Program.GManager.CurrentGameState.DestinyDeck.Draw();
            var dest2 = Program.GManager.CurrentGameState.DestinyDeck.Draw();

            crisisSkillCheckListBox.BeginUpdate();
            crisisSkillCheckListBox.Items.Add(dest1);            
            crisisSkillCheckListBox.Items.Add(dest2);
            crisisSkillCheckListBox.EndUpdate();
        }

        private void AddPlayerButtonClick(object sender, EventArgs e)
        {
            
        }

        private void BeginGameButtonClick(object sender, EventArgs e)
        {
            addPlayerButton.Enabled = false;
        }

        private void EvalSkillCheckButtonClick(object sender, EventArgs e)
        {

        }

        private void PlayIntoCrisisButtonClick(object sender, EventArgs e)
        {
            var card = (DeckManager.Cards.SkillCard)characterSkillHandListBox.SelectedItem;
            crisisSkillCheckListBox.Items.Add(card);
            ((Player)characterListBox.SelectedItem).Cards.Remove(card);
            characterSkillHandListBox.Items.Remove(card);
        }

        private void DiscardSkillCardButtonClick(object sender, EventArgs e)
        {
            Array cards = new DeckManager.Cards.SkillCard[characterSkillHandListBox.SelectedItems.Count];
            characterSkillHandListBox.SelectedItems.CopyTo(cards, 0);

            foreach (DeckManager.Cards.SkillCard card in cards)
            {
                Program.GManager.DiscardCard(card);
                characterSkillHandListBox.Items.Remove(card);
            }
        }

        private void DrawQuorumButtonClick(object sender, EventArgs e)
        {
            var quorum = Program.GManager.CurrentGameState.QuorumDeck.Draw();
            drawnCardListBox.Items.Add(quorum);
        }

        private void DiscardQuorumCardButtonClick(object sender, EventArgs e)
        {
            Array cards = new DeckManager.Cards.QuorumCard[characterSkillHandListBox.SelectedItems.Count];
            characterSkillHandListBox.SelectedItems.CopyTo(cards, 0);
            var currentCharacter = (Player)characterListBox.SelectedItem;

            foreach (DeckManager.Cards.QuorumCard card in cards)
            {
                Program.GManager.DiscardCard(card);
                currentCharacter.Discard(card);
                characterQuorumHandListBox.Items.Remove(card);
            }

        }

        private void DestinationCountUpDownValueChanged(object sender, EventArgs e)
        {
            // number of destination cards to draw
        }

        private void ReturnToDeckButtonClick(object sender, EventArgs e)
        {
            Array cards = new DeckManager.Cards.BaseCard[drawnCardListBox.SelectedItems.Count];
            drawnCardListBox.SelectedItems.CopyTo(cards, 0);

            foreach (DeckManager.Cards.BaseCard card in cards)
            {
                Program.GManager.DiscardCard(card);
                drawnCardListBox.Items.Remove(card);
            }
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

        private void RemoveFromHandButtonClick(object sender, EventArgs e)
        {
            // move character's currently selected card into the drawn card window. can use this to transfer cards between players
        }

        private void CopyGameButtonClick(object sender, EventArgs e)
        {
            // this button click copies an entire post update to the clipboard
            // e.g. http://forums.somethingawful.com/showthread.php?threadid=3563154&userid=0&perpage=40&pagenumber=2#post418151171

        }

        private void DrawMissionButtonClick(object sender, EventArgs e)
        {

        }

        private void FuelUpDownValueChanged(object sender, EventArgs e)
        {

        }

        private void FoodUpDownValueChanged(object sender, EventArgs e)
        {

        }

        private void MoraleUpDownValueChanged(object sender, EventArgs e)
        {

        }

        private void PopulationUpDownValueChanged(object sender, EventArgs e)
        {

        }

        private void CopyDestinationsButtonClick(object sender, EventArgs e)
        {
            // copies drawn destination cards to clipboard, used to send PM to destination chooser
        }






    }
}
