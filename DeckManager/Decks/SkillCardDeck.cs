using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml;
using DeckManager.Cards;
using DeckManager.Cards.Enums;
using DeckManager.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using log4net;

namespace DeckManager.Decks
{
    public class SkillCardDeck : BaseDeck<SkillCard>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SkillCardDeck"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="color">The color.</param>
        /// <param name="fileLocation">The file location.</param>
        /// <param name="isXml">if set to <c>true</c> if the source file is in XML (as opposed to JSON).</param>
        public SkillCardDeck(ILog logger, SkillCardColor color, string fileLocation, bool isXml) : base(logger)
        {
            InitDeck(color, fileLocation, isXml);
        }
        
        public SkillCardColor DeckColor { get; private set; }
        
        /// <summary>
        /// Initializes the deck.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="fileLocation">The file location.</param>
        /// <param name="isXml">if set to <c>true</c> the source file is in XML (as opposed to JSON).</param>
        private void InitDeck(SkillCardColor color, string fileLocation, bool isXml)
        {
            var cardsFromBox = new List<SkillCard>();

            if (isXml)
            {
                var baseDocument = new XmlDocument();
                baseDocument.Load(fileLocation);
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
                                                 headerText[headerText.IndexOfAny(new[] {'0', '1', '2', '3', '4', '5'})]
                                                       .ToString(CultureInfo.InvariantCulture).ParseAs<int>()
                                         }
                        )
                    );
            }
            else
            {
                // At this point we should be working with JSON, which is the superior option anyway.
                using (var sr = new StreamReader(fileLocation))
                {
                    var jsonText = sr.ReadToEnd();
                    cardsFromBox = JsonConvert.DeserializeObject<List<SkillCard>>(jsonText);
                }
            }

            Deck = cardsFromBox;
            Deck = Shuffle(Deck);
            DeckColor = color;
            Discarded = new List<SkillCard>();
        }
    }
}
