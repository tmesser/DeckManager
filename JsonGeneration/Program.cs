using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
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
    }
}
