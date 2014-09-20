using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DeckManager.Cards;
using DeckManager.Cards.Enums;
using Newtonsoft.Json;
using log4net;

namespace DeckManager.Decks
{
    /// <summary>
    /// The deck of Loyalty cards
    /// </summary>
    public class LoyaltyDeck : BaseDeck<LoyaltyCard>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyDeck"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="players">The players.</param>
        /// <param name="extraCards">The extra cards.</param>
        /// <param name="sympathizer">if set to <c>true</c> [sympathizer].</param>
        /// <param name="fileLocation">The file location.</param>
        public LoyaltyDeck(ILog logger, int players, int extraCards, bool sympathizer, string fileLocation)
            : base(logger)
        {
            InitDeck(players, extraCards, sympathizer, fileLocation);
        }

        /// <summary>
        /// Initializes the deck.
        /// </summary>
        /// <param name="players">The number of players in the game.</param>
        /// <param name="extraCards">The extra cards. (For cases like Baltar and Boomer)</param>
        /// <param name="sympathizer">Add the Sympathizer card.</param>
        /// <param name="fileLocation">The location of the cards to deserialize.</param>
        private void InitDeck(int players, int extraCards, bool sympathizer, string fileLocation)
        {
            if (extraCards < 0)
                throw new ArgumentException("ExtraCards must be positive");

            var usedLoyaltyCards = new List<LoyaltyCard>();
            if (fileLocation != null)
            {
                List<LoyaltyCard> cardsFromBox;
                using (var sr = new StreamReader(fileLocation))
                {
                    var jsonText = sr.ReadToEnd();
                    cardsFromBox = JsonConvert.DeserializeObject<List<LoyaltyCard>>(jsonText);
                }


                try
                {
                    cardsFromBox = Shuffle(cardsFromBox);                   

                    switch (players)
                    {
                        case 3:
                            usedLoyaltyCards.AddRange(cardsFromBox.Where(x => x.Loyalty == Loyalty.NotACylon).Take(5));
                            usedLoyaltyCards.Add(cardsFromBox.First(x => x.Loyalty == Loyalty.Cylon));
                            break;
                        case 4:
                            usedLoyaltyCards.AddRange(cardsFromBox.Where(x => x.Loyalty == Loyalty.NotACylon).Take(6));
                            usedLoyaltyCards.Add(cardsFromBox.First(x => x.Loyalty == Loyalty.Cylon));
                            break;
                        case 5:
                            usedLoyaltyCards.AddRange(cardsFromBox.Where(x => x.Loyalty == Loyalty.Cylon).Take(2));
                            usedLoyaltyCards.AddRange(cardsFromBox.Where(x => x.Loyalty == Loyalty.NotACylon).Take(8));
                            break;
                        case 6:
                            usedLoyaltyCards.AddRange(cardsFromBox.Where(x => x.Loyalty == Loyalty.Cylon).Take(2));
                            usedLoyaltyCards.AddRange(cardsFromBox.Where(x => x.Loyalty == Loyalty.NotACylon).Take(9));
                            break;
                        case 7:
                            usedLoyaltyCards.AddRange(cardsFromBox.Where(x => x.Loyalty == Loyalty.Cylon).Take(3));
                            usedLoyaltyCards.AddRange(cardsFromBox.Where(x => x.Loyalty == Loyalty.NotACylon).Take(11));
                            break;
                    }

                    if (extraCards > 0)
                    {
                        usedLoyaltyCards.AddRange(
                            cardsFromBox.Where(x => x.Loyalty == Loyalty.NotACylon).Take(extraCards));
                    }

                    if (sympathizer)
                        usedLoyaltyCards.Add(cardsFromBox.First(x => x.Loyalty == Loyalty.Sympathizer));

                }
                catch (Exception e)
                {
                    Logger.Error(
                        String.Format("Error in LoyaltyDeck.InitDeck.  Paramaters: {0},{1},{2}", players, extraCards,
                            sympathizer), e);
                    throw;
                }
            }
            Deck = usedLoyaltyCards;
            Discarded = new List<LoyaltyCard>();
        }
        public override string ToString()
        {
            return "Loyalty Deck";
        }
    }
}
