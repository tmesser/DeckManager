using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DeckManager.Cards;
using DeckManager.Extensions;
using DeckManager.ManagerLogic;
using DeckManager.States;

namespace DeckManagerOutput
{
    public partial class PlayCrisisForm : Form
    {
        private readonly IEnumerable<Player> _players;
        private readonly CrisisCard _crisis;
        private readonly IEnumerable<SkillCard> _destinyCards;

        

        private const string ResultFormat = @"\b {0} \b0 - {1} ({2})";
        private const string FinalFormat = @"\b {0} \b0 - {1}";
        private const string OutputResultFormat = @"\b {0} ({1}) \b0 - {2}";

        public string Result { get; private set; }
        public IList<Tuple<SkillCard, string>> CrisisContributions { get; set; }

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
            CrisisContributions = new List<Tuple<SkillCard, string>>();
            foreach (var card in _destinyCards)
                CrisisContributions.Add(new Tuple<SkillCard, string>(card, "Destiny"));
            InitializeComponent();

            PlayerDropDown.DataSource = _players;
            PlayerCardListBox.DataSource = _players.First().Cards;
            RefreshResultPane();
        }

        private void RefreshResultPane()
        {
            var crisisResults = SkillCheck.EvalSkillCheck(CrisisContributions.Select(x => x.Item1), _crisis);

            var toDisplay = new StringBuilder();
            
            var totalPower = 0;

            CrisisContributions.Shuffle();
            foreach (var contribution in CrisisContributions)
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

        private void CommitButtonClick(object sender, EventArgs e)
        {
            var selectedPlayer = (Player)PlayerDropDown.SelectedItem;
            CrisisContributions = CrisisContributions.Where(x => x.Item2 != selectedPlayer.PlayerName).ToList();
            foreach (SkillCard card in PlayerCardListBox.SelectedItems)
            {
                CrisisContributions.Add(new Tuple<SkillCard, string>(card, selectedPlayer.PlayerName));
            }

            RefreshResultPane();
        }

        private void PlayerDropDownSelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedPlayer = (Player)PlayerDropDown.SelectedItem;
            PlayerCardListBox.DataSource = selectedPlayer.Cards;
            PlayerCardListBox.SelectedIndex = -1;
            var playerCards = PlayerCardListBox.Items.Cast<SkillCard>().ToList();
            var contributedCards = CrisisContributions.Select(x => x.Item1);
            foreach (var card in playerCards.Where(contributedCards.Contains))
            {
                PlayerCardListBox.SelectedItems.Add(card);
            }
        }

        private void SubmitButtonClick(object sender, EventArgs e)
        {
            var crisisResults = SkillCheck.EvalSkillCheck(CrisisContributions.Select(x => x.Item1), _crisis);

            var resultOutput = new StringBuilder();

            var totalPower = 0;
            foreach (var contribution in CrisisContributions)
            {
                var appliedPower = _crisis.PositiveColors.Contains(contribution.Item1.CardColor) ? contribution.Item1.CardPower : contribution.Item1.CardPower * -1;
                resultOutput.AppendLine(string.Format(FinalFormat, appliedPower, contribution.Item1.Heading));
                totalPower += appliedPower;
            } 
            resultOutput.AppendLine(@"\b--------------------\b0");
            foreach (var consequence in crisisResults)
            {
                resultOutput.AppendLine(string.Format(OutputResultFormat, totalPower, consequence.Threshold,consequence.ConditionText));
            }
            resultOutput.Replace(Environment.NewLine, @" \line ");
            resultOutput.Insert(0, @"{\rtf1\ansi ");
            resultOutput.Append(@"}");

            Result = resultOutput.ToString();

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
