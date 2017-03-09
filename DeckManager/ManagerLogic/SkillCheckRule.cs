using System;
using DeckManager.Cards.Enums;
using DeckManager.ManagerLogic.Enums;

namespace DeckManager.ManagerLogic
{
    public class SkillCheckRule : IEquatable<SkillCheckRule>
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
        public SkillCheckCardSign? RuleFlagEnum { get; set; }

        /// <summary>
        /// A dumping ground for any other random crap I've failed to account for at this point in time.
        /// </summary>
        public object RuleObject { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// Returns the rule description.
        /// </returns>
        public override string ToString()
        {
            return RuleDescription;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SkillCheckRule) obj);
        }

        public bool Equals(SkillCheckRule other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(RuleDescription, other.RuleDescription);
        }

        public override int GetHashCode()
        {
            return (RuleDescription != null ? RuleDescription.GetHashCode() : 0);
        }

        public static bool operator ==(SkillCheckRule left, SkillCheckRule right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SkillCheckRule left, SkillCheckRule right)
        {
            return !Equals(left, right);
        }
    }
}
