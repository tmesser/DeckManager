﻿using DeckManager.Cards;
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
        private CardType _selectedDeck;
        private SkillCardColor _selectedColor;
        
        public DeckInfo()
        {
            InitializeComponent();
            this.deckInfoDeckComboBox.Items.Add(Program.GManager.CurrentGameState.CrisisDeck.CardType);
            this.deckInfoDeckComboBox.Items.Add(Program.GManager.CurrentGameState.DestinyDeck.CardType);
            this.deckInfoDeckComboBox.Items.Add(Program.GManager.CurrentGameState.DestinationDeck.CardType);
            this.deckInfoDeckComboBox.Items.Add(Program.GManager.CurrentGameState.PoliticsDeck.DeckColor);
            this.deckInfoDeckComboBox.Items.Add(Program.GManager.CurrentGameState.LeadershipDeck.DeckColor);
            this.deckInfoDeckComboBox.Items.Add(Program.GManager.CurrentGameState.TacticsDeck.DeckColor);
            this.deckInfoDeckComboBox.Items.Add(Program.GManager.CurrentGameState.PilotingDeck.DeckColor);
            this.deckInfoDeckComboBox.Items.Add(Program.GManager.CurrentGameState.EngineeringDeck.DeckColor);
            if (Program.GManager.CurrentGameState.TreacheryDeck != null)
                this.deckInfoDeckComboBox.Items.Add(Program.GManager.CurrentGameState.TreacheryDeck.DeckColor);
            //this.deckInfoDeckComboBox.Items.Add(Program.GManager.CurrentGameState.Civilians.ElementAt(0);
            this.deckInfoDeckComboBox.Items.Add(Program.GManager.CurrentGameState.QuorumDeck.CardType);
            this.deckInfoDeckComboBox.Items.Add(Program.GManager.CurrentGameState.SuperCrisisDeck.CardType);
            this.deckInfoDeckComboBox.Items.Add(Program.GManager.CurrentGameState.LoyaltyDeck.CardType);
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
            _selectedColor = SkillCardColor.Unknown;
            _selectedDeck = CardType.Unknown;

            if (deckInfoDeckComboBox.SelectedItem is CardType)
                _selectedDeck = (CardType)deckInfoDeckComboBox.SelectedItem;
            else
                _selectedColor = (SkillCardColor)deckInfoDeckComboBox.SelectedItem;

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
            this.cardsInDeckListBox.Items.Clear();
            this.cardsInDiscardListBox.Items.Clear();

            if (_selectedDeck != CardType.Unknown)
                this.cardsInDeckListBox.Items.AddRange(Program.GManager.CurrentGameState.GetDeckDrawPile(_selectedDeck).ToArray());
            else
                this.cardsInDeckListBox.Items.AddRange(Program.GManager.CurrentGameState.GetDeckDrawPile(_selectedColor).ToArray());
            //this.cardsInDiscardListBox.Items.AddRange(_currentDeck.Discarded.ToArray());

            this.cardsInDiscardListBox.EndUpdate();
            this.cardsInDeckListBox.EndUpdate();
        }
    }
}
