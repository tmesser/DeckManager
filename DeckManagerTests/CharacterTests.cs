using System.Collections.Generic;
using DeckManager.Cards.Enums;
using DeckManager.Characters;
using DeckManager.Characters.Enums;
using NUnit.Framework;

namespace DeckManagerTests
{
    [TestFixture]
    public class CharacterTests
    {
        private Character Adama 
        {
            get
            {
                return new Character
                    {
                        CharacterName = @"William Adama",
                        DefaultDrawColors =
                            {
                                new List<SkillCardColor>
                                    {
                                        SkillCardColor.Leadership,
                                        SkillCardColor.Leadership,
                                        SkillCardColor.Leadership,
                                        SkillCardColor.Tactics,
                                        SkillCardColor.Tactics
                                    }
                            },
                        Role = Roles.Military,
                        SetupLocation = @"Admiral's Quarters",
                        AdditionalText =
                            @"Inspirational Leader -- When you draw a Crisis Card, all 1 strength Skill Cards count positive for the skill check.
Command Authority -- Once per game, after resolving a skill check, instead of discarding the used Skill Cards, draw them into your hand.
Emotionally Attached -- You may not activate the Admiral's Quarters location."
                    };
            }
        }

        private Character Starbuck {
            get
            {
                return new Character
                    {
                        CharacterName = @"Kara ""Starbuck"" Thrace",
                        DefaultDrawColors =
                            {
                                new List<SkillCardColor>
                                    {
                                        SkillCardColor.Piloting,
                                        SkillCardColor.Piloting,
                                        SkillCardColor.Tactics,
                                        SkillCardColor.Tactics,
                                        SkillCardColor.Leadership
                                    },
                                new List<SkillCardColor>
                                    {
                                        SkillCardColor.Piloting,
                                        SkillCardColor.Piloting,
                                        SkillCardColor.Tactics,
                                        SkillCardColor.Tactics,
                                        SkillCardColor.Engineering
                                    }
                            },
                        Role = Roles.Pilot,
                        SetupLocation = @"Hangar Deck",
                        AdditionalText =
                            @"Expert Pilot -- When you start your turn piloting a Viper, you may take 2 Actions during your Action Step (instead of 1).
Secret Destiny -- Once per game, immediately after a Crisis Card is revealed, discard it and draw a new one.
Insubordinate -- When a player chooses you with the Admiral's Quarters location, reduce the difficulty by 3."
                    };
            }
        }

        [Test]
        public void Should_Return_Appropriate_Human_Readable_Draw()
        {
            var adamaDraw = Adama.GetHumanReadableDraw();
            var starbuckDraw = Starbuck.GetHumanReadableDraw();

            Assert.AreEqual(@"[Leadership/3, Tactics/2]", adamaDraw);
            Assert.AreEqual(@"[Piloting/2, Tactics/2, Leadership/1] [Piloting/2, Tactics/2, Engineering/1]", starbuckDraw);
        }

        [Test]
        public void Should_Return_Correct_Maximum_Colors()
        {
            var adamaLeadership = Adama.ColorMax(SkillCardColor.Leadership);
            var adamaTactics = Adama.ColorMax(SkillCardColor.Tactics);
            var adamaPiloting = Adama.ColorMax(SkillCardColor.Piloting);

            var starbuckLeadership = Starbuck.ColorMax(SkillCardColor.Leadership);
            var starbuckTactics = Starbuck.ColorMax(SkillCardColor.Tactics);
            var starbuckPiloting = Starbuck.ColorMax(SkillCardColor.Piloting);
            var starbuckEngineering = Starbuck.ColorMax(SkillCardColor.Engineering);

            Assert.AreEqual(3, adamaLeadership);
            Assert.AreEqual(2, adamaTactics);
            Assert.AreEqual(0, adamaPiloting);

            Assert.AreEqual(1, starbuckLeadership);
            Assert.AreEqual(2, starbuckTactics);
            Assert.AreEqual(2, starbuckPiloting);
            Assert.AreEqual(1, starbuckEngineering);

        }
    }
}
