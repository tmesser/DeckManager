using System.Collections.Generic;
using System.IO;
using DeckManager.Cards;
using Newtonsoft.Json;
using log4net;

namespace DeckManager.Decks
{
    public class CrisisDeck : BaseDeck<CrisisCard>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CrisisDeck"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="fileLocation">The file location.</param>
        public CrisisDeck(ILog logger, string fileLocation) : base(logger)
        {
            InitDeck(fileLocation);
        }

        /// <summary>
        /// Initializes the deck.
        /// </summary>
        /// <param name="fileLocation">The file location.</param>
        private void InitDeck(string fileLocation)
        {
            List<CrisisCard> cardsFromBox;
            
            using (var sr = new StreamReader(fileLocation))
            {
                var jsonText = sr.ReadToEnd();
                cardsFromBox = JsonConvert.DeserializeObject<List<CrisisCard>>(jsonText, new Newtonsoft.Json.Converters.StringEnumConverter());
            }
            
            Deck = cardsFromBox;
            Deck = Shuffle(Deck);
            Discarded = new List<CrisisCard>();
        }
    }
}
