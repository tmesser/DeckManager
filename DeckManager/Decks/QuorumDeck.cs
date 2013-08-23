using System.Collections.Generic;
using System.Linq;
using DeckManager.Cards;
using log4net;

namespace DeckManager.Decks
{
    public class QuorumDeck : BaseDeck<QuorumCard>
    {
        public QuorumDeck(ILog logger) : base(logger)
        {
            InitDeck();
        }

        private void InitDeck()
        {
            var cardsFromBox = new List<QuorumCard>();
            //TODO: Import the cards via JSON/XML reader - the goddamn NuGet packages aren't working right now.  Fill up the cardsFromBox object.

            Deck = cardsFromBox;
            Deck = Shuffle(Deck);
            Discarded = new List<QuorumCard>();
        }

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
