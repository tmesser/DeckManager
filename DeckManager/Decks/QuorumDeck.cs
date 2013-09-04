using System.Collections.Generic;
using System.IO;
using System.Linq;
using DeckManager.Cards;
using Newtonsoft.Json;
using log4net;

namespace DeckManager.Decks
{
    public class QuorumDeck : BaseDeck<QuorumCard>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuorumDeck"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="fileLocation">The file location.</param>
        public QuorumDeck(ILog logger, string fileLocation)
            : base(logger)
        {
            InitDeck(fileLocation);
        }

        /// <summary>
        /// Initializes the deck.
        /// </summary>
        /// <param name="fileLocation">The file location.</param>
        private void InitDeck(string fileLocation)
        {
            List<QuorumCard> cardsFromBox;

            using (var sr = new StreamReader(fileLocation))
            {
                var jsonText = sr.ReadToEnd();
                cardsFromBox = JsonConvert.DeserializeObject<List<QuorumCard>>(jsonText);
            }

            Deck = cardsFromBox;
            Deck = Shuffle(Deck);
            Discarded = new List<QuorumCard>();
        }

        /// <summary>
        /// Draws a card.
        /// </summary>
        /// <returns></returns>
        public override QuorumCard Draw()
        {
            if (Deck.Count == 0)
                return null;

            var ret = Deck.ElementAt(0);
            Deck.RemoveAt(0);

            return ret;
        }

        /// <summary>
        /// Draws multiple cards.
        /// </summary>
        /// <param name="cards">The cards.</param>
        /// <returns></returns>
        public override IEnumerable<QuorumCard> DrawMany(int cards)
        {
            if (Deck.Count < cards)
                return Deck;

            var ret = Deck.Take(cards);
            Deck.RemoveRange(0, cards);
            return ret;
        }

        /// <summary>
        /// Discards back to the Quorum deck.
        /// </summary>
        /// <param name="card">The card.</param>
        public void DiscardToQuorum(QuorumCard card)
        {
            Deck.Add(card);
        }
    }
}
