using System.Collections.Generic;
using System.IO;
using DeckManager.Cards;
using DeckManager.Cards.Enums;
using Newtonsoft.Json;
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
        public SkillCardDeck(ILog logger, SkillCardColor color, string fileLocation) : base(logger)
        {
            InitDeck(color, fileLocation);
        }
        
        public SkillCardColor DeckColor { get; private set; }
        
        /// <summary>
        /// Initializes the deck.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="fileLocation">The file location.</param>
        private void InitDeck(SkillCardColor color, string fileLocation)
        {
            List<SkillCard> cardsFromBox;

            using (var sr = new StreamReader(fileLocation))
            {
                var jsonText = sr.ReadToEnd();
                cardsFromBox = JsonConvert.DeserializeObject<List<SkillCard>>(jsonText);
            }

            Deck = cardsFromBox;
            Deck = Shuffle(Deck);
            DeckColor = color;
            Discarded = new List<SkillCard>();
        }
    }
}
