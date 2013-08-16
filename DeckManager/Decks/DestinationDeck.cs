using System.Collections.Generic;
using DeckManager.Cards;
using log4net;

namespace DeckManager.Decks
{
    public class DestinationDeck : BaseDeck<DestinationCard>
    {
        public DestinationDeck(ILog logger) : base(logger)
        {
            InitDeck();
        }

        private void InitDeck()
        {
            var cardsFromBox = new List<DestinationCard>();
            //TODO: Import the cards via JSON/XML reader - the goddamn NuGet packages aren't working right now.  Fill up the cardsFromBox object.

            Deck = cardsFromBox;
            Deck = Shuffle(Deck);
        }
    }
}
