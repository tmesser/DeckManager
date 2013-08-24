using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using DeckManager.Cards;
using DeckManager.Cards.Enums;
using DeckManager.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using log4net;

namespace DeckManager.Decks
{
    public class CrisisDeck : BaseDeck<CrisisCard>
    {
        public CrisisDeck(ILog logger, string fileLocation, bool isXml) : base(logger)
        {
            InitDeck(fileLocation, isXml);
        }

        private void InitDeck(string fileLocation, bool isXml)
        {
            var cardsFromBox = new List<CrisisCard>();

            if (isXml)
            {
                var baseDocument = new XmlDocument();
                baseDocument.Load(fileLocation);
                
                var jo = JObject.Parse(JsonConvert.SerializeXmlNode(baseDocument));
                var token = jo["ROOT"]["CRISISdeck"];

                foreach (var crisisCard in token["card"].Children())
                {
                    var cardReader = new StringReader(crisisCard.Value<string>("text"));
                    
                    var crisisHeading = cardReader.ReadLine();
                    var crisisAdditionalText = cardReader.ReadToEnd();
                    
                    if(string.IsNullOrEmpty(crisisHeading) || string.IsNullOrEmpty(crisisAdditionalText))
                        throw new ArgumentException("Error in Crisis XML reading.");

                    if (crisisHeading.Contains("CYLON ATTACK:"))
                    {
                        cardsFromBox.Add(new CrisisCard
                            {
                                Activation = CylonActivations.None,
                                AdditionalText = crisisAdditionalText.Trim(),
                                Heading = crisisHeading,
                                JumpPrep = false,
                                PassLevels = new List<Tuple<int, string>>(),
                                PositiveColors = new List<SkillCardColor>()
                            });
                    }
                    else
                    {
                        // Normal crisis card
                        crisisAdditionalText = crisisAdditionalText.Trim();
                        var jumpPrep = crisisAdditionalText.Contains("+1 Jump Prep");
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

                        cardsFromBox.Add(new CrisisCard
                            {
                                Activation = activations,
                                AdditionalText = crisisAdditionalText,
                                Heading = crisisHeading,
                                JumpPrep = jumpPrep,
                                PositiveColors = positiveColors,
                                PassLevels = passLevels
                            });

                    }
                }
            }
            else
            {
                // At this point we should be working with JSON, which is the superior option anyway.
                using (var sr = new StreamReader(fileLocation))
                {
                    var jsonText = sr.ReadToEnd();
                    cardsFromBox = JsonConvert.DeserializeObject<List<CrisisCard>>(jsonText);
                }
            }
            Deck = cardsFromBox;
            Deck = Shuffle(Deck);
            Discarded = new List<CrisisCard>();
        }
    }
}
