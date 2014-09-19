using System;
using System.Collections.Generic;
using System.Linq;
using DeckManager.Cards;
using DeckManager.Cards.Enums;
using DeckManager.ManagerLogic;
using NUnit.Framework;

namespace DeckManagerTests
{
    [TestFixture]
    public class SkillCheckTests
    {
        [Test]
        public void Should_Pass_Skill_Check_Correctly()
        {
            var crisisCard =
                new CrisisCard
                    {
                        Heading = "ExampleCrisis",
                        PositiveColors = new List<SkillCardColor> {SkillCardColor.Leadership, SkillCardColor.Tactics},
                        PassLevels =
                            new List<Tuple<int, string>>
                                {
                                    new Tuple<int, string>(12, "pass"),
                                    new Tuple<int, string>(0, "fail")
                                }
                    };
            var playedCards = new List<SkillCard>
                {
                    new SkillCard {CardPower = 5, CardColor = SkillCardColor.Leadership},
                    new SkillCard {CardPower = 5, CardColor = SkillCardColor.Tactics},
                    new SkillCard {CardPower = 3, CardColor = SkillCardColor.Leadership}
                };

            var ret = SkillCheck.EvalSkillCheck(playedCards, crisisCard, null);

            Assert.AreEqual(1, ret.Count());
            Assert.AreEqual("pass", ret.ElementAt(0).ConditionText);
            Assert.AreEqual(12, ret.ElementAt(0).Threshold);
        }

        [Test]
        public void Should_Fail_Skill_Check_Correctly()
        {
            var crisisCard =
                new CrisisCard
                    {
                        Heading = "ExampleCrisis",
                        PositiveColors = new List<SkillCardColor> {SkillCardColor.Leadership, SkillCardColor.Tactics},
                        PassLevels =
                            new List<Tuple<int, string>>
                                {
                                    new Tuple<int, string>(12, "pass"),
                                    new Tuple<int, string>(0, "fail")
                                }
                    };
            var playedCards = new List<SkillCard>
                {
                    new SkillCard {CardPower = 5, CardColor = SkillCardColor.Leadership},
                    new SkillCard {CardPower = 5, CardColor = SkillCardColor.Tactics},
                    new SkillCard {CardPower = 3, CardColor = SkillCardColor.Engineering}
                };

            var ret = SkillCheck.EvalSkillCheck(playedCards, crisisCard, null);

            Assert.AreEqual(1, ret.Count());
            Assert.AreEqual("fail", ret.ElementAt(0).ConditionText);
            Assert.AreEqual(0, ret.ElementAt(0).Threshold);
        }

        [Test]
        public void Should_PartialPass_Skill_Check_Correctly()
        {
            var crisisCard =
                new CrisisCard
                    {
                        Heading = "ExampleCrisis",
                        PositiveColors = new List<SkillCardColor> {SkillCardColor.Leadership, SkillCardColor.Tactics},
                        PassLevels =
                            new List<Tuple<int, string>>
                                {
                                    new Tuple<int, string>(12, "pass"),
                                    new Tuple<int, string>(0, "fail"),
                                    new Tuple<int, string>(6, "partialpass")
                                }
                    };
            var playedCards = new List<SkillCard>
                {
                    new SkillCard {CardPower = 5, CardColor = SkillCardColor.Leadership},
                    new SkillCard {CardPower = 5, CardColor = SkillCardColor.Tactics},
                    new SkillCard {CardPower = 3, CardColor = SkillCardColor.Engineering}
                };

            var ret = SkillCheck.EvalSkillCheck(playedCards, crisisCard, null);

            Assert.AreEqual(1, ret.Count());
            Assert.AreEqual("partialpass", ret.ElementAt(0).ConditionText);
            Assert.AreEqual(6, ret.ElementAt(0).Threshold);
        }
    }
}
