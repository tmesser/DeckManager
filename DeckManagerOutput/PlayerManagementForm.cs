﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DeckManager.Cards;
using DeckManager.Cards.Enums;
using DeckManager.States;

namespace DeckManagerOutput
{
    public partial class PlayerManagementForm : Form
    {
        private readonly Player _playerToManage;

        public Tuple<SkillCardColor, int> RequestedSkillCards { get; private set; }
        public Tuple<CardType, int> RequestedSpecialCards { get; private set; }
        public string RequestedLocation { get; private set; }
        public List<BaseCard> CardsToDiscard { get; private set; }

        public PlayerManagementForm(Player playerToManage, IEnumerable<string> validLocations, string currentPlayerLocation )
        {
            _playerToManage = playerToManage;
            PlayerCardListBox.DataSource = _playerToManage.Cards;
            var specialCards = new List<BaseCard>();
            specialCards.AddRange(_playerToManage.QuorumHand);
            specialCards.AddRange(_playerToManage.SuperCrisisCards);
            specialCards.AddRange(_playerToManage.LoyaltyCards);
            SpecialCardListBox.DataSource = specialCards;
            LocationComboBox.DataSource = validLocations;
            LocationComboBox.SelectedText = currentPlayerLocation;

            InitializeComponent();
        }

        private void SubmitButtonClick(object sender, EventArgs e)
        {
            RequestedSkillCards = new Tuple<SkillCardColor, int>(SkillCardColor.Unknown, 0);
            RequestedSpecialCards = new Tuple<CardType, int>(CardType.Unknown, 0);
            CardsToDiscard = new List<BaseCard>();

            if (DiscardSelectedCheckBox.Checked)
            {
                CardsToDiscard.AddRange(PlayerCardListBox.SelectedItems.OfType<BaseCard>());
            }
            if (DiscardSpecialTextBox.Checked)
            {
                CardsToDiscard.AddRange(SpecialCardListBox.SelectedItems.OfType<BaseCard>());
            }

            if (DrawCardComboControl.NumCardsRequested > 0)
            {
                RequestedSkillCards = new Tuple<SkillCardColor, int>(DrawCardComboControl.CardColorRequested, DrawCardComboControl.NumCardsRequested);
            }

            if (DrawSpecialComboControl.NumCardsRequested > 0)
            {
                RequestedSpecialCards =  new Tuple<CardType, int>(DrawSpecialComboControl.CardTypeRequested, DrawSpecialComboControl.NumCardsRequested);
            }

            RequestedLocation = LocationComboBox.SelectedText;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
