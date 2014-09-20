using DeckManager.Cards;
using DeckManager.Decks;
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
    public partial class DeckInfo : Form
    {
        private BaseDeck<BaseCard> _currentDeck;

        public DeckInfo()
        {
            InitializeComponent();
            this.deckInfoDeckComboBox.Items.Add(Program.GManager.CurrentGameState.CrisisDeck);
            this.deckInfoDeckComboBox.Items.Add(Program.GManager.CurrentGameState.DestinyDeck);
            this.deckInfoDeckComboBox.Items.Add(Program.GManager.CurrentGameState.DestinationDeck);
            this.deckInfoDeckComboBox.Items.Add(Program.GManager.CurrentGameState.PoliticsDeck);
            this.deckInfoDeckComboBox.Items.Add(Program.GManager.CurrentGameState.LeadershipDeck);
            this.deckInfoDeckComboBox.Items.Add(Program.GManager.CurrentGameState.TacticsDeck);
            this.deckInfoDeckComboBox.Items.Add(Program.GManager.CurrentGameState.PilotingDeck);
            this.deckInfoDeckComboBox.Items.Add(Program.GManager.CurrentGameState.EngineeringDeck);
            if (Program.GManager.CurrentGameState.TreacheryDeck != null)
                this.deckInfoDeckComboBox.Items.Add(Program.GManager.CurrentGameState.TreacheryDeck);
            this.deckInfoDeckComboBox.Items.Add(Program.GManager.CurrentGameState.Civilians);
            this.deckInfoDeckComboBox.Items.Add(Program.GManager.CurrentGameState.QuorumDeck);
            this.deckInfoDeckComboBox.Items.Add(Program.GManager.CurrentGameState.SuperCrisisDeck);
            this.deckInfoDeckComboBox.Items.Add(Program.GManager.CurrentGameState.LoyaltyDeck);
            //this.deckInfoDeckComboBox.SelectedIndex = 0;
        }

        private void discardButton_Click(object sender, EventArgs e)
        {
            var cards = cardsInDiscardListBox.SelectedItems;

            //var deck = 
        }

        private void buryButton_Click(object sender, EventArgs e)
        {
            Program.GManager.BuryCards(this.cardsInDeckListBox.SelectedItems.Cast<BaseCard>());
            UpdateControls();
        }

        private void deckInfoCancelButton_Click(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void deckInfoSubmitButton_Click(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void deckInfoDeckComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this._currentDeck = (BaseDeck<BaseCard>)deckInfoDeckComboBox.SelectedItem;
            //// TODO if deck selected is skill card deck, enable the add to destiny button
            if (_currentDeck is SkillCardDeck)
            {
                this.addToDestinyButton.Visible = true;
                this.addToDestinyButton.Enabled = true;
            }
            else
            {
                this.addToDestinyButton.Visible = false;
                this.addToDestinyButton.Enabled = false;
            }


            UpdateControls();
        }

        private void reshuffleButton_Click(object sender, EventArgs e)
        {

            UpdateControls();
        }

        private void addToDestinyButton_Click(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void UpdateControls()
        {
            this.cardsInDeckListBox.BeginUpdate();
            this.cardsInDiscardListBox.BeginUpdate();

            cardsInDeckListBox.DataSource = _currentDeck.Deck;
            cardsInDiscardListBox.DataSource = _currentDeck.Discarded;

            this.cardsInDiscardListBox.EndUpdate();
            this.cardsInDeckListBox.EndUpdate();
        }
    }
}
