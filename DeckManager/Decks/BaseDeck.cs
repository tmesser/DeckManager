using System;
using System.Collections.Generic;
using System.Linq;
using DeckManager.Cards;
using log4net;

namespace DeckManager.Decks
{
    public abstract class BaseDeck<T> where T: BaseCard
    {
        protected readonly ILog Logger;

        protected BaseDeck(ILog logger)
        {
            Logger = logger;
        }

        /// <summary>
        /// The actual deck we're working with.  So the Loyalty deck would be BaseDeck<LoyaltyCard>LoyaltyCard</LoyaltyCard> or whatever
        /// </summary>
        /// <value>
        /// The deck.
        /// </value>
        public List<T> Deck { get; set; }

        /// <summary>
        /// Any cards that have been discarded from the deck, for easy reshuffling later.
        /// </summary>
        /// <value>
        /// The discarded.
        /// </value>
        public List<T> Discarded { get; set; }


        /// <summary>
        /// Shuffles the specified input deck.
        /// </summary>
        /// <param name="inputDeck">The input deck.  If you pass nothing in, it will shuffle the deck associated with the 'game deck'.</param>
        /// <returns>A shuffled list of cards.</returns>
        protected List<T> Shuffle(List<T> inputDeck)
        {
            var deckTemp = inputDeck;
            try
            {
                foreach (var card in inputDeck)
                {
                    card.UniqueId = Guid.NewGuid();
                }

                inputDeck = inputDeck.OrderBy(x => x.UniqueId).ToList();
            }
            catch (Exception e)
            {
                Logger.Error("Error in BaseDeck.Shuffle", e);
                Deck = deckTemp;
                throw;
            }
            return inputDeck;
        }

        /// <summary>
        /// Reshuffles Deck, adding stuff from the Discarded pile.
        /// </summary>
        protected virtual void Reshuffle()
        {
            Deck.AddRange(Discarded);
            Discarded = new List<T>();
            Deck = Shuffle(Deck);
        }

        /// <summary>
        /// Draws a card from Deck, reshuffling if required.
        /// </summary>
        /// <returns></returns>
        public virtual T Draw()
        {
            if (Deck.Count == 0)
                Reshuffle();

            var ret = Deck.ElementAt(0);
            Deck.RemoveAt(0);

            // CPS - removing this call - adding card to discard as they're drawn will create copies of the card: the drawn
            //   object and the discarded one. I've added a Discard method to handle adding Cards back into the Deck
            //Discarded.Add(ret);

            return ret;
        }
        /// <summary>
        /// Places the passed card at the bottom of the deck
        /// </summary>
        /// <param name="card">Card to be buried</param>
        public virtual void Bury(T card)
        {
            this.Deck.Add(card);        // we're drawing at 0, this puts card at the end of the list
        }

        /// <summary>
        /// Adds the passed card to this deck's discard pile
        /// </summary>
        /// <param name="card">The card to be discarded</param>
        public virtual void Discard(T card)
        {
            this.Discarded.Add(card);
        }

        /// <summary>
        /// Draws multiple cards.
        /// </summary>
        /// <param name="cards">How many cards you want.</param>
        /// <returns></returns>
        public virtual IEnumerable<T> DrawMany(int cards)
        {
            if (Deck.Count < cards)
                Reshuffle();

            var ret = Deck.Take(cards).ToList();
            Deck.RemoveRange(0,cards);
            Discarded.AddRange(ret);

            return ret;
        }


    }
}
