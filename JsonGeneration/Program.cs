using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using DeckManager.Boards;
using DeckManager.Boards.Enums;
using DeckManager.Cards;
using DeckManager.Cards.Enums;
using DeckManager.Extensions;
using DeckManager.ManagerLogic.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Formatting = Newtonsoft.Json.Formatting;

namespace JsonGeneration
{
    public class Program
    {
        private static void Main()
        {
            GenerateLoyaltyCards();
            GenerateCivilianComponents();
            GenerateCrisisDeck();
            GenerateDestinationDeck();
            GenerateQuorumDeck();
            GenerateSkillCardDeck(SkillCardColor.Engineering);
            GenerateSkillCardDeck(SkillCardColor.Leadership);
            GenerateSkillCardDeck(SkillCardColor.Piloting);
            GenerateSkillCardDeck(SkillCardColor.Politics);
            GenerateSkillCardDeck(SkillCardColor.Tactics);
            GenerateSuperCrisisDeck();
            GenerateLocations();
        }

        private static void GenerateSuperCrisisDeck()
        {
            var baseDocument = new XmlDocument();
            baseDocument.Load(@"..\..\Core.xml");
            var cardsFromBox = new List<SuperCrisisCard>();

            var jo = JObject.Parse(JsonConvert.SerializeXmlNode(baseDocument));
            var token = jo["ROOT"]["SUPERCRISISdeck"];

            foreach (var crisisCard in token["card"].Children())
            {
                var cardReader = new StringReader(crisisCard.Value<string>("text"));

                var crisisHeading = cardReader.ReadLine();
                var crisisAdditionalText = cardReader.ReadToEnd();

                if (string.IsNullOrEmpty(crisisHeading) || string.IsNullOrEmpty(crisisAdditionalText))
                    throw new ArgumentException("Error in SuperCrisis XML reading.");

                // Normal crisis card
                crisisAdditionalText = crisisAdditionalText.Trim();

                var positiveColors = new List<SkillCardColor>();
                if (crisisAdditionalText.Contains("LEA"))
                    positiveColors.Add(SkillCardColor.Leadership);
                if (crisisAdditionalText.Contains("TAC"))
                    positiveColors.Add(SkillCardColor.Tactics);
                if (crisisAdditionalText.Contains("POL"))
                    positiveColors.Add(SkillCardColor.Politics);
                if (crisisAdditionalText.Contains("ENG"))
                    positiveColors.Add(SkillCardColor.Engineering);
                if (crisisAdditionalText.Contains("PIL"))
                    positiveColors.Add(SkillCardColor.Piloting);

                var strengthRegex = new Regex(@"=\s(?<strength>\d{1,2})");
                var tierRegex = new Regex(@"^((?<strength>[A-Za-z0-9]{1,4})\+?:)(?<effect>.{1,})", RegexOptions.Multiline);
                var strengthResult = strengthRegex.Match(crisisAdditionalText);
                var strength = strengthResult.Groups["strength"].Value.ParseAs<int>();
                var tierResult = tierRegex.Matches(crisisAdditionalText);
                var passLevels = new List<Tuple<int, string>>();
                foreach (Match match in tierResult)
                {
                    switch (match.Groups["strength"].Value.ToUpper())
                    {
                        case "PASS":
                            passLevels.Add(new Tuple<int, string>(strength, match.Groups["effect"].Value));
                            break;
                        case "FAIL":
                            passLevels.Add(new Tuple<int, string>(0, match.Groups["effect"].Value));
                            break;
                        default: // partial pass
                            passLevels.Add(new Tuple<int, string>(match.Groups["strength"].Value.ParseAs<int>(), match.Groups["effect"].Value));
                            break;
                    }
                }

                cardsFromBox.Add(new SuperCrisisCard
                {
                    Activation = CylonActivations.None,
                    AdditionalText = crisisAdditionalText,
                    Heading = crisisHeading,
                    JumpPrep = false,
                    PositiveColors = positiveColors,
                    PassLevels = passLevels
                });

            }

            var jsonSettings = new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore, Converters = new List<JsonConverter> { new Newtonsoft.Json.Converters.StringEnumConverter() } };
            var json = JsonConvert.SerializeObject(cardsFromBox, Formatting.Indented, jsonSettings);
            using (var sr = new StreamWriter(@"..\..\GeneratedJson\Decks\SuperCrisisDeck.json"))
            {
                sr.Write(json);
            }
        }

        private static void GenerateSkillCardDeck(SkillCardColor color)
        {
            var baseDocument = new XmlDocument();
            baseDocument.Load(@"..\..\Core.xml");
            var cardsFromBox = new List<SkillCard>();
            string deckName = null;
            switch (color)
            {
                case SkillCardColor.Engineering:
                    deckName = "ENGdeck";
                    break;
                case SkillCardColor.Leadership:
                    deckName = "LEAdeck";
                    break;
                case SkillCardColor.Piloting:
                    deckName = "PILdeck";
                    break;
                case SkillCardColor.Politics:
                    deckName = "POLdeck";
                    break;
                case SkillCardColor.Tactics:
                    deckName = "TACdeck";
                    break;
            }
            var jo = JObject.Parse(JsonConvert.SerializeXmlNode(baseDocument));
            var token = jo["ROOT"][deckName];
            cardsFromBox.AddRange(
                token["card"].Children().Select(
                    element => element.Value<string>("text"))
                             .Select(
                                 headerText => new SkillCard
                                 {
                                     Heading = headerText,
                                     CardColor = color,
                                     CardPower =
                                         headerText[headerText.IndexOfAny(new[] { '0', '1', '2', '3', '4', '5' })]
                                               .ToString(CultureInfo.InvariantCulture).ParseAs<int>()
                                 }
                    )
                );

            var jsonSettings = new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore, Converters = new List<JsonConverter> { new Newtonsoft.Json.Converters.StringEnumConverter() } };
            var json = JsonConvert.SerializeObject(cardsFromBox, Formatting.Indented, jsonSettings);
            using (var sr = new StreamWriter(@"..\..\GeneratedJson\Decks\"+color+"Deck.json"))
            {
                sr.Write(json);
            }
        }

        private static void GenerateQuorumDeck()
        {
            var baseDocument = new XmlDocument();
            baseDocument.Load(@"..\..\Core.xml");
            var cardsFromBox = new List<QuorumCard>();

            var jo = JObject.Parse(JsonConvert.SerializeXmlNode(baseDocument));
            var token = jo["ROOT"]["QUORUMdeck"];
            cardsFromBox.AddRange(from crisisCard in token["card"].Children()
                                  select new StringReader(crisisCard.Value<string>("text"))
                                      into cardReader
                                      let cardHeading = cardReader.ReadLine()
                                      let cardText = cardReader.ReadToEnd()
                                      select new QuorumCard
                                      {
                                          Heading = cardHeading.Trim(),
                                          AdditionalText = cardText.Trim()
                                      });

            var jsonSettings = new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore, Converters = new List<JsonConverter> { new Newtonsoft.Json.Converters.StringEnumConverter() } };
            var json = JsonConvert.SerializeObject(cardsFromBox, Formatting.Indented, jsonSettings);
            using (var sr = new StreamWriter(@"..\..\GeneratedJson\Decks\QuorumDeck.json"))
            {
                sr.Write(json);
            }
        }

        private static void GenerateDestinationDeck()
        {
            var baseDocument = new XmlDocument();
            baseDocument.Load(@"..\..\Core.xml");
            var cardsFromBox = new List<DestinationCard>();

            var jo = JObject.Parse(JsonConvert.SerializeXmlNode(baseDocument));
            var token = jo["ROOT"]["DESTINATIONdeck"];
            cardsFromBox.AddRange(from crisisCard in token["card"].Children()
                                  select new StringReader(crisisCard.Value<string>("text"))
                                      into cardReader
                                      let cardHeading = cardReader.ReadLine()
                                      let cardText = cardReader.ReadToEnd()
                                      let distanceRegex = new Regex(@"Distance\s(?<number>\d{1})")
                                      let distanceResult =
                                          distanceRegex.Match(cardText ?? string.Empty).Groups["number"].Value
                                                                                                        .ParseAs<int>()
                                      select new DestinationCard
                                      {
                                          Heading = cardHeading.Trim(),
                                          AdditionalText = cardText.Trim(),
                                          Distance = distanceResult
                                      });

            var jsonSettings = new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore, Converters = new List<JsonConverter> { new Newtonsoft.Json.Converters.StringEnumConverter() } };
            var json = JsonConvert.SerializeObject(cardsFromBox, Formatting.Indented, jsonSettings);
            using (var sr = new StreamWriter(@"..\..\GeneratedJson\Decks\DestinationDeck.json"))
            {
                sr.Write(json);
            }
        }

        private static void GenerateCrisisDeck()
        {
            var baseDocument = new XmlDocument();
            baseDocument.Load(@"..\..\Core.xml");
            var cardsFromBox = new List<CrisisCard>();

            var jo = JObject.Parse(JsonConvert.SerializeXmlNode(baseDocument));
            var token = jo["ROOT"]["CRISISdeck"];

            foreach (var crisisCard in token["card"].Children())
            {
                var cardReader = new StringReader(crisisCard.Value<string>("text"));

                var crisisHeading = cardReader.ReadLine();
                var crisisAdditionalText = cardReader.ReadToEnd();

                if (string.IsNullOrEmpty(crisisHeading) || string.IsNullOrEmpty(crisisAdditionalText))
                    throw new ArgumentException("Error in Crisis XML reading.");

                if (crisisHeading.Contains("CYLON ATTACK:"))
                {
                    cardsFromBox.Add(new CrisisCard
                    {
                        Activation = CylonActivations.None,
                        AdditionalText = crisisAdditionalText.Trim(),
                        Heading = crisisHeading.Trim(),
                        JumpPrep = false,
                        PassLevels = new List<Tuple<int, string>>(),
                        PositiveColors = new List<SkillCardColor>()
                    });
                }
                else
                {
                    // Normal crisis card
                    crisisAdditionalText = crisisAdditionalText.Trim();
                    var jumpPrep = crisisAdditionalText.ToUpper().Contains("+1 JUMP PREP");
                    var activations = CylonActivations.None;
                    if (crisisAdditionalText.Contains("Activate Raiders"))
                        activations = CylonActivations.Raiders;
                    else if (crisisAdditionalText.Contains("Launch Nukes"))
                        activations = CylonActivations.BasestarAttack;
                    else if (crisisAdditionalText.Contains("Activate Heavies"))
                        activations = CylonActivations.HeavyRaiders;
                    else if (crisisAdditionalText.Contains("Launch Raiders"))
                        activations = CylonActivations.LaunchRaiders;

                    var positiveColors = new List<SkillCardColor>();
                    if (crisisAdditionalText.Contains("LEA"))
                        positiveColors.Add(SkillCardColor.Leadership);
                    if (crisisAdditionalText.Contains("TAC"))
                        positiveColors.Add(SkillCardColor.Tactics);
                    if (crisisAdditionalText.Contains("POL"))
                        positiveColors.Add(SkillCardColor.Politics);
                    if (crisisAdditionalText.Contains("ENG"))
                        positiveColors.Add(SkillCardColor.Engineering);
                    if (crisisAdditionalText.Contains("PIL"))
                        positiveColors.Add(SkillCardColor.Piloting);

                    var strengthRegex = new Regex(@"=\s(?<strength>\d{1,2})");
                    var tierRegex = new Regex(@"^((?<strength>[A-Za-z0-9]{1,4})\+?:)(?<effect>.{1,})", RegexOptions.Multiline);
                    var strengthResult = strengthRegex.Match(crisisAdditionalText);
                    var strength = strengthResult.Groups["strength"].Value.ParseAs<int>();
                    var tierResult = tierRegex.Matches(crisisAdditionalText);
                    var passLevels = new List<Tuple<int, string>>();
                    foreach (Match match in tierResult)
                    {
                        switch (match.Groups["strength"].Value.ToUpper())
                        {
                            case "PASS":
                                passLevels.Add(new Tuple<int, string>(strength, match.Groups["effect"].Value.Trim()));
                                break;
                            case "FAIL":
                                passLevels.Add(new Tuple<int, string>(0, match.Groups["effect"].Value.Trim()));
                                break;
                            default: // partial pass
                                passLevels.Add(new Tuple<int, string>(match.Groups["strength"].Value.ParseAs<int>(), match.Groups["effect"].Value.Trim()));
                                break;
                        }
                    }

                    cardsFromBox.Add(new CrisisCard
                    {
                        Activation = activations,
                        AdditionalText = crisisAdditionalText.Trim(),
                        Heading = crisisHeading.Trim(),
                        JumpPrep = jumpPrep,
                        PositiveColors = positiveColors,
                        PassLevels = passLevels
                    });

                }
            }
            var jsonSettings = new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore, Converters = new List<JsonConverter> { new Newtonsoft.Json.Converters.StringEnumConverter() } };
            var json = JsonConvert.SerializeObject(cardsFromBox, Formatting.Indented, jsonSettings);
            using (var sr = new StreamWriter(@"..\..\GeneratedJson\Decks\CrisisDeck.json"))
            {
                sr.Write(json);
            }

        }

        private static void GenerateCivilianComponents()
        {
            var dong = new List<List<Resource>>
                {
                    new List<Resource> {Resource.Population, Resource.Population},
                    new List<Resource> {Resource.Population, Resource.Population},
                    new List<Resource> {Resource.Population},
                    new List<Resource> {Resource.Population},
                    new List<Resource> {Resource.Population},
                    new List<Resource> {Resource.Population},
                    new List<Resource> {Resource.Population},
                    new List<Resource> {Resource.Population},
                    new List<Resource> {Resource.Population, Resource.Morale},
                    new List<Resource> {Resource.Population, Resource.Fuel},
                    new List<Resource>(),
                    new List<Resource>()
                };

            var json = JsonConvert.SerializeObject(dong, Formatting.Indented, new Newtonsoft.Json.Converters.StringEnumConverter());
            using (var sr = new StreamWriter(@"..\..\GeneratedJson\Components\CivilianPile.json"))
            {
                sr.Write(json);
            }
        }

        private static void GenerateLoyaltyCards()
        {
            var loyaltyDeck = new List<LoyaltyCard> 
            { 
                new LoyaltyCard{Loyalty = Loyalty.NotACylon},
                new LoyaltyCard{Loyalty = Loyalty.NotACylon},
                new LoyaltyCard{Loyalty = Loyalty.NotACylon},
                new LoyaltyCard{Loyalty = Loyalty.NotACylon},
                new LoyaltyCard{Loyalty = Loyalty.NotACylon},
                new LoyaltyCard{Loyalty = Loyalty.NotACylon},
                new LoyaltyCard{Loyalty = Loyalty.NotACylon},
                new LoyaltyCard{Loyalty = Loyalty.NotACylon},
                new LoyaltyCard{Loyalty = Loyalty.NotACylon},
                new LoyaltyCard{Loyalty = Loyalty.NotACylon},
                new LoyaltyCard{Loyalty = Loyalty.Cylon, AdditionalText = "Reveal: Target a player on Galactica and send them to the Brig"},
                new LoyaltyCard{Loyalty = Loyalty.Cylon, AdditionalText = "Reveal: Target a player on Galactica and send them to the Sickbay.  That player discards 5 Skill Cards."},
                new LoyaltyCard{Loyalty = Loyalty.Cylon, AdditionalText = "Reveal: Draw 5 Galactica damage tokens and choose 2 of them to resolve."},
                new LoyaltyCard{Loyalty = Loyalty.Cylon, AdditionalText = "Reveal: Reduce Morale by 1."},
                new LoyaltyCard{Loyalty = Loyalty.Cylon, AdditionalText = "Reveal: Each human player randomly discards a card and draws 1 Treachery.  You draw 2 Treachery (after discarding to 3)."},
                new LoyaltyCard{Loyalty = Loyalty.Cylon, AdditionalText = "Reveal: Reduce Jump Prep by 2."},
                new LoyaltyCard{Loyalty = Loyalty.Cylon, AdditionalText = "Reveal: Place a Centurion at the start of the Boarding Track."},
                new LoyaltyCard{Loyalty = Loyalty.Sympathizer},
            };

            var jsonSettings = new JsonSerializerSettings {DefaultValueHandling = DefaultValueHandling.Ignore};

            var json = JsonConvert.SerializeObject(loyaltyDeck, Formatting.Indented, jsonSettings);

            using (var sw = new StreamWriter(@"..\..\GeneratedJson\Decks\LoyaltyDeck.json"))
            {
                sw.Write(json);
            }

        }

        private static void GenerateLocations()
        {
            var locations = new List<BasicLocation>
            {
                new BasicLocation {BoardName = BoardName.Galactica, Name = @"Hangar Deck", LocationInfo = @"Action: Launch yourself in a Viper.  You may then take 1 more action.  You must be in the Hangar Deck to use a ""Repair"" skill card action on damaged Vipers."},
                new BasicLocation {BoardName = BoardName.Galactica, Name = @"FTL Control", LocationInfo = @"Action: Jump the fleet if the jump preparation track is not in the red zone.  Roll a die; if the result is 1-6, lose a number of population indicated on the fleet's space on the jump preparation track."},
                new BasicLocation {BoardName = BoardName.Galactica, Name = @"Weapons Control", LocationInfo = @"Action: Attack one Cylon ship with Galactica.  Roll 3-8 to hit a raider, 7-8 to hit a heavy raider, and 5-8 to hit a basestar."},
                new BasicLocation {BoardName = BoardName.Galactica, Name = @"Command", LocationInfo = @"Action: Activate up to two unmanned vipers.  An activation can be used to a.) launch a viper from either of the two launch zones, b.) move an unammend viper to an adjacent space area, or c.) fire an unmanned viper's weapons (3-8 to hit a raider, 7-8 to hit a heavy raider, 8 to hit a basestar)."},
                new BasicLocation {BoardName = BoardName.Galactica, Name = @"Communications", LocationInfo = @"Action: Look at the back of 2 civilian ships.  You may then move them to adjacent area(s).  Only the player taking the action may look at the ships."},
                new BasicLocation {BoardName = BoardName.Galactica, Name = @"Admiral's Quarters", LocationInfo = @"Action: Choose a character; then pass a Tactics/Leadership Skill Check of 7 to send him/her to the ""Brig"". Characters in the ""Brig"" can only add 1 skill card to skill checks, and being in the Brig prevents a Cylon from doing any damage upon reveal."},
                new BasicLocation {BoardName = BoardName.Galactica, Name = @"Research Lab", LocationInfo = @"Action: Draw 1 Engineering OR 1 Tactics skill card."},
                new BasicLocation {BoardName = BoardName.Galactica, Name = @"Armory", LocationInfo = @"Action: Attack a Centurion on the Boarding Party track (destroyed on a roll of 7-8)."},
                new BasicLocation {BoardName = BoardName.Galactica, Name = @"Sickbay", LocationInfo = @"You may only draw 1 Skill Card during the Receive Skills step of your turn. A character can (and should) move out of Sickbay during the Movement step of his/her turn."},
                new BasicLocation {BoardName = BoardName.Galactica, Name = @"Brig", LocationInfo = @"You may not move, draw Crisis Cards, or add more than 1 card to any Skill Check.  Action: Pass a Politics/Tactics Skill Check of 7 to move to any location."},

                new BasicLocation {BoardName = BoardName.ColonialOne, Name = @"Press Room", LocationInfo = @"Action: Draw 2 Politics skill cards."},
                new BasicLocation {BoardName = BoardName.ColonialOne, Name = @"President's Office", LocationInfo = @"Action: If you are President, draw 1 Quorum Card.  You may then draw 1 additional Quorum card or play 1 from your hand."},
                new BasicLocation {BoardName = BoardName.ColonialOne, Name = @"Administration", LocationInfo = @"Action: Choose a character; then pass a Politics/Leadership Skill Check of 5 to give him/her the President title. Revealed Cylons may not be given the President title."},

                new BasicLocation {BoardName = BoardName.Cylon, Name = @"Caprica", LocationInfo = @"Action: Play 1 of your Super Crisis Cards or draw 2 Crisis Cards, choose 1 to resolve, and bury the other at the bottom of the deck.  Cylon Activations and the Prepare for Jump step are not triggered after this Crisis."},
                new BasicLocation {BoardName = BoardName.Cylon, Name = @"Cylon Fleet", LocationInfo = @"Action: Activate all Cylon ships of one type, or launch 2 raiders and 1 heavy raider from each basestar.  Activating heavy raiders will advance the centurions one step on the boarding party track, even if there are no heavy raiders on the board."},
                new BasicLocation {BoardName = BoardName.Cylon, Name = @"Human Fleet", LocationInfo = @"Action: Looc at any player's hand, and steal 1 Skill Card by placing it in your hand.  Then roll a die, and if 5+, damage Galactica."},
                new BasicLocation {BoardName = BoardName.Cylon, Name = @"Resurrection Ship", LocationInfo = @"You may discard your Super Crisis Card to draw a new one.  Then, if the distance is 7 or less, give your unrevealed Loyalty Card(s) to any other player."},
            };

            var jsonSettings = new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore, Converters = new List<JsonConverter> { new Newtonsoft.Json.Converters.StringEnumConverter() } };
            var json = JsonConvert.SerializeObject(locations, Formatting.Indented, jsonSettings);
            using (var sr = new StreamWriter(@"..\..\GeneratedJson\Boards\Locations.json"))
            {
                sr.Write(json);
            }
        }
    }
}
