using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DeckManager.ManagerLogic;

namespace DeckManagerOutput
{
    public partial class CrisisRulesForm : Form
    {
        private readonly IList<SkillCheckRule> _rules;
        public IList<SkillCheckRule> SelectedRules { get; private set; }

        public CrisisRulesForm(IEnumerable<SkillCheckRule> rules )
        {
            InitializeComponent();
            _rules = rules.OrderBy(x => x.RuleDescription).ToList();
            SelectedRules = new List<SkillCheckRule>();
            var boxSize = new Size { Width = 465 };
            foreach (var rule in _rules)
            {
                var ruleControl = new CheckBox {Text = rule.RuleDescription};
                contentPanel.Controls.Add(ruleControl);
                boxSize.Height += ruleControl.Size.Height;
            }
            boxSize.Height += 100;
            if (boxSize.Height > 1000)
                boxSize.Height = 1000;
            Size = boxSize;
        }

        private void AccceptButtonClick(object sender, EventArgs e)
        {
            foreach (CheckBox control in contentPanel.Controls)
            {
                if (!control.Checked) continue;
                var selectedRule = _rules.FirstOrDefault(x => x.RuleDescription == control.Text);
                if (selectedRule != default(SkillCheckRule))
                {
                    SelectedRules.Add(selectedRule);
                }
            }
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
