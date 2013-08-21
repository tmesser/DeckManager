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
            Array cards = new DeckManager.Cards.BaseCard[this.drawnCardListBox.SelectedItems.Count];
            this.drawnCardListBox.SelectedItems.CopyTo(cards, 0);
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
        private void CrisisTextBox_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            //e.ItemHeight = 50;
            string item = crisisTextListBox.Items[e.Index].ToString();
            int count = item.Count(f=>f=='\n');
            count++;
            e.ItemHeight *= count;
        }

        private void CrisisTextBox_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
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
            this.crisisTextListBox.BeginUpdate();

            // DeckManager.Cards.CrisisCard crisis = Program.gManager.CurrentGameState.CrisisDeck.Draw();

            DeckManager.Cards.CrisisCard crisis = new DeckManager.Cards.CrisisCard();
            crisis.Activation = DeckManager.Cards.Enums.CylonActivations.Raiders;
            crisis.Heading = "Test Crisis";
            crisis.JumpPrep = true;
            crisis.AdditionalText = "A description of the crisis";
            crisis.PositiveColors = new List<DeckManager.Cards.Enums.SkillCardColor>();
            crisis.PositiveColors.Add(DeckManager.Cards.Enums.SkillCardColor.Engineering);
            crisis.PositiveColors.Add(DeckManager.Cards.Enums.SkillCardColor.Politics);

            this.crisisTextListBox.Items.Add(crisis);
            this.crisisTextListBox.EndUpdate();
        }

        private void CrisisCopyTextButtonClick(object sender, EventArgs e)
        {
            Clipboard.SetText(crisisSkillCheckListBox.SelectedItem.ToString());
        }

        private void AddDestinyCardsButtonClick(object sender, EventArgs e)
        {
            DeckManager.Cards.SkillCard dest1 =  Program.gManager.CurrentGameState.DestinyDeck.Draw();
            DeckManager.Cards.SkillCard dest2 = Program.gManager.CurrentGameState.DestinyDeck.Draw();

            this.crisisSkillCheckListBox.BeginUpdate();
            this.crisisSkillCheckListBox.Items.Add(dest1);            
            this.crisisSkillCheckListBox.Items.Add(dest2);
            this.crisisSkillCheckListBox.EndUpdate();
        }

        private void AddPlayerButtonClick(object sender, EventArgs e)
        {
            
        }

        private void BeginGameButtonClick(object sender, EventArgs e)
        {
            this.addPlayerButton.Enabled = false;
        }

        private void EvalSkillCheckButtonClick(object sender, EventArgs e)
        {

        }

        private void PlayIntoCrisisButtonClick(object sender, EventArgs e)
        {
            DeckManager.Cards.SkillCard card = (DeckManager.Cards.SkillCard)this.characterSkillHandListBox.SelectedItem;
            this.crisisSkillCheckListBox.Items.Add(card);
            ((DeckManager.Characters.Character)this.characterListBox.SelectedItem).discard(card);
            this.characterSkillHandListBox.Items.Remove(card);
        }

        private void DiscardSkillCardButtonClick(object sender, EventArgs e)
        {
            Array cards = new DeckManager.Cards.SkillCard[this.characterSkillHandListBox.SelectedItems.Count];
            this.characterSkillHandListBox.SelectedItems.CopyTo(cards, 0);

            foreach (DeckManager.Cards.SkillCard card in cards)
            {
                Program.gManager.discardCard(card);
                currentCharacter.discard(card);
                this.characterSkillHandListBox.Items.Remove(card);
            }
        }

        private void DrawQuorumButtonClick(object sender, EventArgs e)
        {
            DeckManager.Cards.QuorumCard quorum = (DeckManager.Cards.QuorumCard)Program.gManager.CurrentGameState.QuorumDeck.Draw();
            this.drawnCardListBox.Items.Add(quorum);
        }

        private void DiscardQuorumCardButtonClick(object sender, EventArgs e)
        {
            Array cards = new DeckManager.Cards.QuorumCard[this.characterSkillHandListBox.SelectedItems.Count];
            this.characterSkillHandListBox.SelectedItems.CopyTo(cards, 0);
            DeckManager.Characters.Character currentCharacter = (DeckManager.Characters.Character)this.characterListBox.SelectedItem;

            foreach (DeckManager.Cards.QuorumCard card in cards)
            {
                Program.gManager.discardCard(card);
                currentCharacter.discard(card);
                this.characterQuorumHandListBox.Items.Remove(card);
            }

        }

        private void DestinationCountUpDownValueChanged(object sender, EventArgs e)
        {
            // number of destination cards to draw
        }

        private void ReturnToDeckButtonClick(object sender, EventArgs e)
        {
            Array cards = new DeckManager.Cards.BaseCard[this.drawnCardListBox.SelectedItems.Count];
            this.drawnCardListBox.SelectedItems.CopyTo(cards, 0);

            foreach (DeckManager.Cards.BaseCard card in cards)
            {
                Program.gManager.discardCard(card);
                this.drawnCardListBox.Items.Remove(card);
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

        private void removeFromHandButton_Click(object sender, EventArgs e)
        {
            // move character's currently selected card into the drawn card window. can use this to transfer cards between players
        }

        private void copyGameButton_Click(object sender, EventArgs e)
        {
            // this button click copies an entire post update to the clipboard
            // e.g. http://forums.somethingawful.com/showthread.php?threadid=3563154&userid=0&perpage=40&pagenumber=2#post418151171

        }

        private void drawMissionButton_Click(object sender, EventArgs e)
        {

        }

        private void FuelUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void FoodUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void MoraleUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void PopulationUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void copyDestinationsButton_Click(object sender, EventArgs e)
        {
            // copies drawn destination cards to clipboard, used to send PM to destination chooser
        }






    }
}
