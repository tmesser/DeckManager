﻿using System.Collections.Generic;
using System.IO;
using DeckManager.Cards;
using Newtonsoft.Json;
using log4net;
using DeckManager.Cards.Enums;

namespace DeckManager.Decks
{
    public class DestinationDeck : BaseDeck<DestinationCard>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DestinationDeck"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="fileLocation">The file location.</param>
        public DestinationDeck(ILog logger, string fileLocation)
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
            var cardsFromBox = new List<DestinationCard>();

            if(fileLocation!=null)
            { 
                using (var sr = new StreamReader(fileLocation))
                {
                    var jsonText = sr.ReadToEnd();
                    cardsFromBox = JsonConvert.DeserializeObject<List<DestinationCard>>(jsonText);
                }
            }

            Deck = cardsFromBox;
            Deck = Shuffle(Deck);
            Discarded = new List<DestinationCard>();
        }
        public override string ToString()
        {
            return "Destination Deck";
        }

        public override CardType CardType
        {
            get { return CardType.Destination; }
        }
    }
}
