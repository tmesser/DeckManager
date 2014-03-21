using System;
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
            InitializeComponent();
            _playerToManage = playerToManage;
            PlayerNameLabel.Text = _playerToManage.PlayerName;
            CharacterNameLabel.Text = _playerToManage.Character.CharacterName;
            PlayerCardListBox.DataSource = _playerToManage.Cards;
            PlayerCardListBox.SelectedIndex = -1;
            var specialCards = new List<BaseCard>();
            specialCards.AddRange(_playerToManage.QuorumHand ?? new List<QuorumCard>());
            specialCards.AddRange(_playerToManage.SuperCrisisCards ?? new List<SuperCrisisCard>());
            specialCards.AddRange(_playerToManage.LoyaltyCards ?? new List<LoyaltyCard>());
            SpecialCardListBox.DataSource = specialCards;
            SpecialCardListBox.SelectedIndex = -1;
            LocationComboBox.DataSource = validLocations;
            LocationComboBox.SelectedItem = currentPlayerLocation;
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

            RequestedLocation = LocationComboBox.Text;

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
