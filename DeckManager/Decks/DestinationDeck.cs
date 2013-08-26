using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using DeckManager.Cards;
using DeckManager.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using log4net;

namespace DeckManager.Decks
{
    public class DestinationDeck : BaseDeck<DestinationCard>
    {
        public DestinationDeck(ILog logger, string fileLocation, bool useXml)
            : base(logger)
        {
            InitDeck(fileLocation, useXml);
        }

        private void InitDeck(string fileLocation, bool useXml)
        {
            var cardsFromBox = new List<DestinationCard>();
            if (useXml)
            {
                var baseDocument = new XmlDocument();
                baseDocument.Load(fileLocation);

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
            }
            else
            {
                // At this point we should be working with JSON, which is the superior option anyway.
                using (var sr = new StreamReader(fileLocation))
                {
                    var jsonText = sr.ReadToEnd();
                    cardsFromBox = JsonConvert.DeserializeObject<List<DestinationCard>>(jsonText);
                }
            }

            Deck = cardsFromBox;
            Deck = Shuffle(Deck);
            Discarded = new List<DestinationCard>();
        }
    }
}
