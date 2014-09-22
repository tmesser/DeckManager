using DeckManager.Cards;
using DeckManager.Cards.Enums;
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
            //if (_currentDeck.CardType == CardType.Skill)
            //{
            //    this.addToDestinyButton.Visible = true;
            //    this.addToDestinyButton.Enabled = true;
            //}
            //else
            //{
            //    this.addToDestinyButton.Visible = false;
            //    this.addToDestinyButton.Enabled = false;
            //}


            UpdateControls();
        }

        private void determineDeck()
        {
            //Type myObjectType = typeof(this.deckInfoDeckComboBox.SelectedItem);

            //string sType = "System.Int32";
            //object o1 = "123";
            //object o2 = Convert.ChangeType(o1, Type.GetType(sType));
            //Type t = o2.GetType(); // this returns Int32 Type
           _currentDeck = (BaseDeck<BaseCard>)deckInfoDeckComboBox.SelectedItem;
            //Convert.ChangeType(asdf, myObjectType);


            var deck = deckInfoDeckComboBox.SelectedItem as CrisisDeck;
            if (deck != null)
            {
                this.cardsInDeckListBox.BeginUpdate();
                this.cardsInDiscardListBox.BeginUpdate();

                this.cardsInDeckListBox.Items.AddRange(deck.Deck.ToArray());
                this.cardsInDiscardListBox.Items.AddRange(deck.Discarded.ToArray());

                this.cardsInDiscardListBox.EndUpdate();
                this.cardsInDeckListBox.EndUpdate();
            }
            deck = deckInfoDeckComboBox.SelectedItem as CrisisDeck;


            //switch (_currentDeck.CardType)
            //{
            //    case CardType.Skill: 
            //        break;
            //    case CardType.Crisis:
            //        var d = (CrisisDeck)deckInfoDeckComboBox.SelectedItem;
            //        break;
            //    case CardType.Destination:
            //        break;
            //    case CardType.Loyalty:
            //        break;
            //    case CardType.Mission:
            //        break;
            //    case CardType.Mutiny:
            //        break;
            //    case CardType.Quorum:
            //        break;
            //    case CardType.SuperCrisis:
            //        break;

            //}
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

            //this.cardsInDeckListBox.Items.AddRange(_currentDeck.Deck.ToArray());
            //this.cardsInDiscardListBox.Items.AddRange(_currentDeck.Discarded.ToArray());

            this.cardsInDiscardListBox.EndUpdate();
            this.cardsInDeckListBox.EndUpdate();
        }
    }
}
