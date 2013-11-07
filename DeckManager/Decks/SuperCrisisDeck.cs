using System.Collections.Generic;
using System.IO;
using DeckManager.Cards;
using Newtonsoft.Json;
using log4net;

namespace DeckManager.Decks
{
    public class SuperCrisisDeck : BaseDeck<SuperCrisisCard>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SuperCrisisDeck"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="fileLocation">The file location.</param>
        public SuperCrisisDeck(ILog logger, string fileLocation) : base(logger)
        {
            InitDeck(fileLocation);
        }

        /// <summary>
        /// Initializes the deck.
        /// </summary>
        /// <param name="fileLocation">The file location.</param>
        public void InitDeck(string fileLocation)
        {
            var cardsFromBox = new List<SuperCrisisCard>();

            if (fileLocation != null)
            {
                using (var sr = new StreamReader(fileLocation))
                {
                    var jsonText = sr.ReadToEnd();
                    cardsFromBox = JsonConvert.DeserializeObject<List<SuperCrisisCard>>(jsonText);
                }
            }

            Deck = cardsFromBox;
            Deck = Shuffle(Deck);
            Discarded = new List<SuperCrisisCard>();
        }

    }
}
