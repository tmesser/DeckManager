using System;
using System.Collections.Generic;
using System.Linq;
using DeckManager.Cards;
using DeckManager.Cards.Enums;
using log4net;

namespace DeckManager.Decks
{
    /// <summary>
    /// The deck of Loyalty cards
    /// </summary>
    public class LoyaltyDeck : BaseDeck<LoyaltyCard>
    {
        public LoyaltyDeck(ILog logger, int players, int extraCards, bool sympathizer)
            : base(logger)
        {
            InitDeck(players, extraCards, sympathizer);
        }

        /// <summary>
        /// Initializes the deck.
        /// </summary>
        /// <param name="players">The number of players in the game.</param>
        /// <param name="extraCards">The extra cards. (For cases like Baltar and Boomer)</param>
        /// <param name="sympathizer">Add the Sympathizer card.</param>
        private void InitDeck(int players, int extraCards, bool sympathizer)
        {
            if (players < 3 || players > 6)
                throw new ArgumentException("Invalid player count.  Must be between 3 and 6.");

            if (extraCards < 0)
                throw new ArgumentException("You think you're funny by sending a negative number of extra cards.  But you're really not.");

            var cardsFromBox = new List<LoyaltyCard>();
            //TODO: Import the cards via JSON/XML reader - the goddamn NuGet packages aren't working right now.  Fill up the cardsFromBox object.
            var  cardList = Initialization.XmlUtil.GetCardList(CardType.Loyalty);
            foreach(BaseCard card in cardList)
            {
                cardsFromBox.Add((LoyaltyCard)card);
            }



            var usedLoyaltyCards = new List<LoyaltyCard>();
            try
            {
                cardsFromBox = Shuffle(cardsFromBox);
                usedLoyaltyCards.AddRange(cardsFromBox.Where(x => x.Loyalty == Loyalty.NotACylon).Take(5));
                usedLoyaltyCards.Add(cardsFromBox.First(x => x.Loyalty == Loyalty.Cylon));

                switch (players)
                {
                    case 4:
                        usedLoyaltyCards.Add(cardsFromBox.First(x => x.Loyalty == Loyalty.NotACylon));
                        break;
                    case 5:
                        usedLoyaltyCards.Add(cardsFromBox.First(x => x.Loyalty == Loyalty.Cylon));
                        usedLoyaltyCards.AddRange(cardsFromBox.Where(x => x.Loyalty == Loyalty.NotACylon).Take(3));
                        break;
                    case 6:
                        usedLoyaltyCards.Add(cardsFromBox.First(x => x.Loyalty == Loyalty.Cylon));
                        usedLoyaltyCards.AddRange(cardsFromBox.Where(x => x.Loyalty == Loyalty.NotACylon).Take(4));
                        break;
                }

                if (extraCards > 0)
                {
                    usedLoyaltyCards.AddRange(cardsFromBox.Where(x => x.Loyalty == Loyalty.NotACylon).Take(extraCards));
                }

                if (sympathizer)
                    usedLoyaltyCards.Add(cardsFromBox.First(x => x.Loyalty == Loyalty.Sympathizer));

            }
            catch (Exception e)
            {
                Logger.Error(String.Format("Error in LoyaltyDeck.InitDeck.  Paramaters: {0},{1},{2}",players, extraCards, sympathizer), e);
                throw;
            }
            Deck = usedLoyaltyCards;
            Discarded = new List<LoyaltyCard>();
        }

    }
}
