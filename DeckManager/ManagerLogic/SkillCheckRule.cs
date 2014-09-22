using DeckManager.Cards.Enums;
using DeckManager.ManagerLogic.Enums;

namespace DeckManager.ManagerLogic
{
    public class SkillCheckRule
    {
        /// <summary>
        /// The general rule type.
        /// </summary>
        public SkillCheckRuleType RuleType { get; set; }

        /// <summary>
        /// The human-readable description of the rule, such as "Friends in Low Places", or "Scientific Research Play Effect"
        /// </summary>
        public string RuleDescription { get; set; }

        /// <summary>
        /// The skill card color the rule affects, if applicable.
        /// </summary>
        public SkillCardColor? RuleColor { get; set; }

        /// <summary>
        /// The integer magnitude of the rule, if applicable.
        /// </summary>
        public int? RuleInt { get; set; }

        /// <summary>
        /// The boolean sign associated with the rule, if applicable.
        /// </summary>
        public bool? RuleBool { get; set; }

        /// <summary>
        /// The enum flag associated with the rule, if applicable.  CAN be null.
        /// </summary>
        public System.Enum RuleFlagEnum { get; set; }

        /// <summary>
        /// A dumping ground for any other random crap I've failed to account for at this point in time.
        /// </summary>
        public object RuleObject { get; set; }
    }
}
