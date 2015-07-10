using System;
using System.Collections.Generic;
using System.Linq;
using DeckManager.Cards;
using DeckManager.Cards.Enums;
using DeckManager.ManagerLogic.Enums;
using log4net;

namespace DeckManager.ManagerLogic
{
    public class SkillCheck
    {
        /// <summary>
        /// Evaluates the skill check after all cards have been played.
        /// </summary>
        /// <returns>
        /// List of all consequences that occur as a result of the skill check's outcome.
        /// output variable also returns the skill cards as they were computed after applying rules.
        /// </returns>
        public static List<Consequence> EvalSkillCheck(IEnumerable<SkillCard> playedCards, CrisisCard crisisCard, IEnumerable<SkillCheckRule> specialRules, out IEnumerable<SkillCard> computedCards )
        {
            var logger = LogManager.GetLogger(typeof(SkillCheck));
            var results = new List<Consequence>();

            // We can be messing around with these cards a lot inside here due to the special rules, so it is prudent to edit local copies.
            var internalPlayedCards = playedCards == null ? new List<SkillCard>() : playedCards.ToList();
            var internalCrisisCard = crisisCard ?? new CrisisCard();

            try
            {
                foreach (var rule in specialRules ?? new List<SkillCheckRule>())
                {
                    switch (rule.RuleType)
                    {
                        case SkillCheckRuleType.ModifyCheckDifficulty:
                            if (rule.RuleInt.HasValue == false)
                                break;
                            var ruleStrength = rule.RuleInt.Value;
                            var newPassLevels = internalCrisisCard.PassLevels.Select(passLevel => new Tuple<int, string>(passLevel.Item1 + ruleStrength, passLevel.Item2)).ToList();
                            internalCrisisCard.PassLevels = newPassLevels;
                            break;
                        case SkillCheckRuleType.SkillCardColorSignChange:
                            if (rule.RuleColor.HasValue == false || rule.RuleColor.Value == SkillCardColor.Unknown || rule.RuleFlagEnum == null)
                                break;
                            var ruleColor = rule.RuleColor.Value;
                            var ruleSign = (SkillCheckCardSign)rule.RuleFlagEnum;
                            foreach(var card in internalPlayedCards.Where(x => x.CardColor == ruleColor))
                                card.CardPower = 
                                    ruleSign == SkillCheckCardSign.Zero ? 
                                        (ruleSign == SkillCheckCardSign.Positive ? Math.Abs(card.CardPower) : 
                                        Math.Abs(card.CardPower)*-1) :  // implies ruleSign == SkillCheckCardSign.Negative
                                    0;
                            break;
                        case SkillCheckRuleType.SkillCardStrengthChange:
                            if (rule.RuleInt.HasValue == false)
                                break;
                            foreach (var card in internalPlayedCards)
                                card.CardPower += rule.RuleInt.Value;
                            break;
                        case SkillCheckRuleType.SkillCardStrengthSignChange:
                            if (rule.RuleColor.HasValue == false || rule.RuleColor.Value == SkillCardColor.Unknown || rule.RuleFlagEnum == null || rule.RuleInt.HasValue == false)
                                break;
                            var ruleStrengthColor = rule.RuleColor.Value;
                            var ruleInt = rule.RuleInt.Value;
                            var ruleStrengthSign = (SkillCheckCardSign)rule.RuleFlagEnum;
                            foreach (var card in internalPlayedCards.Where(x => x.CardColor == ruleStrengthColor && x.CardPower == ruleInt))
                                card.CardPower =
                                    ruleStrengthSign == SkillCheckCardSign.Zero ?
                                        (ruleStrengthSign == SkillCheckCardSign.Positive ? Math.Abs(card.CardPower) :
                                        Math.Abs(card.CardPower) * -1) :  // implies ruleSign == SkillCheckCardSign.Negative
                                    0;
                            break;
                    }
                }

                var strength = 0;

                foreach (var card in internalPlayedCards)
                {
                    if (card.CardPower > 0)
                    {
                        if (crisisCard.PositiveColors.Contains(card.CardColor))
                            strength += card.CardPower;
                        else
                            strength -= card.CardPower;
                    }
                }
                if (strength < 0)
                    strength = 0;
                var checkResult = crisisCard.PassLevels.OrderByDescending(x => x.Item1).First(result => strength >= result.Item1);
                results.Add(new Consequence(checkResult.Item1, checkResult.Item2));
            }
            catch (Exception e)
            {
                logger.Error("Error while computing skill check.", e);
                throw;
            }
            computedCards = internalPlayedCards;
            return results;
        }

    }
}
