using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DeckManager.Cards;
using DeckManager.ManagerLogic;
using DeckManager.States;

namespace DeckManagerOutput
{
    public partial class PlayCrisisForm : Form
    {
        private readonly IEnumerable<Player> _players;
        private readonly CrisisCard _crisis;
        private readonly IEnumerable<SkillCard> _destinyCards;

        private IList<Tuple<SkillCard, string>> _crisisContributions;

        private const string ResultFormat = @"\b {0} \b0 - {1} ({2})";

        public PlayCrisisForm(IEnumerable<Player> players, CrisisCard crisis, IEnumerable<SkillCard> destinyCards )
        {
            if (crisis.PassLevels.Any() == false)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
            _players = players;
            _crisis = crisis;
            _destinyCards = destinyCards;
            _crisisContributions = new List<Tuple<SkillCard, string>>();
            foreach (var card in _destinyCards)
                _crisisContributions.Add(new Tuple<SkillCard, string>(card, "Destiny"));
            InitializeComponent();

            PlayerDropDown.DataSource = _players;
            PlayerCardListBox.DataSource = _players.First().Cards;
            RefreshResultPane();
        }

        private void RefreshResultPane()
        {
            var crisisResults = SkillCheck.EvalSkillCheck(_crisisContributions.Select(x => x.Item1), _crisis);

            var toDisplay = new StringBuilder();

            var totalPower = 0;
            foreach (var contribution in _crisisContributions)
            {
                var appliedPower = _crisis.PositiveColors.Contains(contribution.Item1.CardColor) ? contribution.Item1.CardPower : contribution.Item1.CardPower*-1;
                toDisplay.AppendLine(string.Format(ResultFormat, appliedPower, contribution.Item1.Heading, contribution.Item2));
                totalPower += appliedPower;
            }
            toDisplay.AppendLine(@"\b--------------------\b0");
            toDisplay.AppendLine(_crisis.ToString());
            toDisplay.AppendLine(@"\b--------------------\b0");
            foreach (var consequence in crisisResults)
            {
                toDisplay.AppendLine(string.Format(ResultFormat, consequence.ConditionText, consequence.Threshold, totalPower));
            }
            toDisplay.Replace(Environment.NewLine, @" \line ");
            toDisplay.Insert(0,@"{\rtf1\ansi ");
            toDisplay.Append(@"}");
            ResultTextBox.Rtf = toDisplay.ToString();

        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void PlayerCardListBoxDataSourceChanged(object sender, EventArgs e)
        {
            PlayerCardListBox.SelectedIndex = -1;
            foreach (var card in PlayerCardListBox.Items.Cast<SkillCard>().Where(y => _crisisContributions.Select(x => x.Item1).Contains(y)))
            {
                PlayerCardListBox.SelectedItems.Add(card);
            }
        }

        private void CommitButtonClick(object sender, EventArgs e)
        {
            var selectedPlayer = (Player)PlayerDropDown.SelectedItem;
            _crisisContributions = _crisisContributions.Where(x => x.Item2 != selectedPlayer.PlayerName).ToList();
            foreach (SkillCard card in PlayerCardListBox.SelectedItems)
            {
                _crisisContributions.Add(new Tuple<SkillCard, string>(card, selectedPlayer.PlayerName));
            }

            RefreshResultPane();
        }

        private void PlayerDropDownSelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedPlayer = (Player)PlayerDropDown.SelectedItem;
            PlayerCardListBox.DataSource = selectedPlayer.Cards;
        }
    }
}
