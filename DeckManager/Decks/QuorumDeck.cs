using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using DeckManager.Cards;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using log4net;
using Formatting = Newtonsoft.Json.Formatting;

namespace DeckManager.Decks
{
    public class QuorumDeck : BaseDeck<QuorumCard>
    {
        public QuorumDeck(ILog logger, string fileLocation, bool isXml)
            : base(logger)
        {
            InitDeck(fileLocation, isXml);
        }

        private void InitDeck(string fileLocation, bool isXml)
        {
            var cardsFromBox = new List<QuorumCard>();

            if (isXml)
            {
                var baseDocument = new XmlDocument();
                baseDocument.Load(fileLocation);

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

            }
            else
            {
                // At this point we should be working with JSON, which is the superior option anyway.
                using (var sr = new StreamReader(fileLocation))
                {
                    var jsonText = sr.ReadToEnd();
                    cardsFromBox = JsonConvert.DeserializeObject<List<QuorumCard>>(jsonText);
                }
            }

            PristineDeck = JsonConvert.SerializeObject(cardsFromBox, Formatting.Indented);
            Deck = cardsFromBox;
            Deck = Shuffle(Deck);
            Discarded = new List<QuorumCard>();
        }

        public string PristineDeck { get; set; }

        public override QuorumCard Draw()
        {
            if (Deck.Count == 0)
                return null;

            var ret = Deck.ElementAt(0);
            Deck.RemoveAt(0);

            return ret;
        }

        public override IEnumerable<QuorumCard> DrawMany(int cards)
        {
            if (Deck.Count < cards)
                return Deck;

            var ret = Deck.Take(cards);
            Deck.RemoveRange(0, cards);
            return ret;
        }

        public void DiscardToQuorum(QuorumCard card)
        {
            Deck.Add(card);
        }
    }
}
