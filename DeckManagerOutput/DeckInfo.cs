using DeckManager.Cards;
using DeckManager.Components;
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
        private CrisisDeck _crisisDeck;
        private SkillCardDeck _skillDeck;
        private QuorumDeck _quorumDeck;
        private SuperCrisisDeck _scDeck;
        private LoyaltyDeck _loyaltyDeck;
        private DestinationDeck _destinationDeck;
        private DestinyDeck _destinyDeck;
        private List<Civilian> _civilians;

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
            var cards = (IEnumerable<BaseCard>) cardsInDiscardListBox.SelectedItems;
            Program.GManager.DiscardCards(cards);
            //var deck = 
            UpdateControls();
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
            determineDeck();
            //// if deck selected is skill card deck, enable the add to destiny button
            if (_skillDeck != null)
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

        private void determineDeck()
        {
            this._crisisDeck = null;
            this._skillDeck = null;
            this._quorumDeck = null;
            this._scDeck = null;
            this._loyaltyDeck = null;
            this._destinationDeck = null;
            this._destinyDeck = null;
            this._civilians = null;

            if (deckInfoDeckComboBox.SelectedItem is CrisisDeck)
            {
                this._crisisDeck = (CrisisDeck)deckInfoDeckComboBox.SelectedItem;
            }

            if (deckInfoDeckComboBox.SelectedItem is SkillCardDeck)
            {
                this._skillDeck = (SkillCardDeck)deckInfoDeckComboBox.SelectedItem;
            }
            if (deckInfoDeckComboBox.SelectedItem is DestinationDeck)
            {
                this._destinationDeck = (DestinationDeck)deckInfoDeckComboBox.SelectedItem;
            }

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

            if (this._crisisDeck != null)
            {
                cardsInDeckListBox.DataSource = _crisisDeck.Deck;
                cardsInDiscardListBox.DataSource = _crisisDeck.Discarded;
            }
            if (this._skillDeck != null)
            {
                cardsInDeckListBox.DataSource = _skillDeck.Deck;
                cardsInDiscardListBox.DataSource = _skillDeck.Discarded;
            }
            if (this._destinationDeck != null)
            {
                cardsInDeckListBox.DataSource = _destinationDeck.Deck;
                cardsInDiscardListBox.DataSource = _destinationDeck.Discarded;
            }
            this.cardsInDiscardListBox.EndUpdate();
            this.cardsInDeckListBox.EndUpdate();
        }
    }
}
