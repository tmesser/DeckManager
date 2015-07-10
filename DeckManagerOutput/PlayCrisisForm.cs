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
        private readonly List<Player> _playerCloneList;
        private readonly CrisisCard _crisis;
        private readonly IEnumerable<SkillCard> _destinyCards;
        private readonly IEnumerable<SkillCheckRule> _rules;
        

        private const string ResultFormat = @"\b {0} \b0 - {1} ({2})";
        private const string FinalFormat = @"\b {0} \b0 - {1}";
        private const string OutputResultFormat = @"\b {0} ({1}) \b0 - {2}";

        public string Result { get; private set; }
        public IList<Tuple<SkillCard, string>> CrisisContributions { get; set; }
        public IList<SkillCheckRule> Rules { get; set; }

        public Player PlayerTakingCards { get; private set; }

        public PlayCrisisForm(IEnumerable<Player> players, CrisisCard crisis, IEnumerable<SkillCard> destinyCards, IEnumerable<SkillCheckRule> rules )
        {
            if (crisis.PassLevels.Any() == false)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
            _players = players.ToList();
            _crisis = crisis;
            _destinyCards = destinyCards;
            _rules = rules.OrderBy(x => x.RuleDescription).ToList();
            CrisisContributions = new List<Tuple<SkillCard, string>>();
            foreach (var card in _destinyCards)
                CrisisContributions.Add(new Tuple<SkillCard, string>(card, "Destiny"));
            InitializeComponent();

            PlayerDropDown.DataSource = _players;
            _players.ToList().ForEach(x => x.Cards.Sort());
            PlayerCardListBox.DataSource = _players.First().Cards;

            _playerCloneList = _players.ToList();
            PlayerTakeCardsDropdown.DataSource = _playerCloneList;            

            RefreshResultPane();

            foreach (var rule in _rules)
            {
                var ruleControl = new CheckBox { Text = rule.RuleDescription };
                crisisRuleContentForm.Controls.Add(ruleControl);
            }
        }

        private void RefreshResultPane()
        {
            IEnumerable<SkillCard> effectiveContributions;
            var crisisResults = SkillCheck.EvalSkillCheck(CrisisContributions.Select(x => x.Item1), _crisis, Rules, out effectiveContributions);

            var toDisplay = new StringBuilder();
            
            var totalPower = 0;

            var index = 0;
            foreach (var contribution in effectiveContributions)
            {
                toDisplay.AppendLine(string.Format(ResultFormat, contribution.CardPower, contribution.Heading, CrisisContributions[index].Item2));
                totalPower += contribution.CardPower;
                index++;
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

        private void CommitRuleButtonClick(object sender, EventArgs e)
        {
            Rules = new List<SkillCheckRule>();
            foreach (CheckBox control in crisisRuleContentForm.Controls)
            {
                if (!control.Checked) continue;
                var selectedRule = _rules.FirstOrDefault(x => x.RuleDescription == control.Text);
                if (selectedRule != default(SkillCheckRule))
                {
                    Rules.Add(selectedRule);
                }
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
            IEnumerable<SkillCard> effectiveContributions;
            var crisisResults = SkillCheck.EvalSkillCheck(CrisisContributions.Select(x => x.Item1), _crisis, Rules, out effectiveContributions);

            var resultOutput = new StringBuilder();

            var totalPower = 0;
            foreach (var contribution in effectiveContributions.OrderBy(x => x.CardColor))
            {
                resultOutput.AppendLine(string.Format(FinalFormat, contribution.CardPower, contribution.Heading));
                totalPower += contribution.CardPower;
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

            if (PlayerTakeCardsCheckBox.Checked)
                PlayerTakingCards = (Player)PlayerTakeCardsDropdown.SelectedItem;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
