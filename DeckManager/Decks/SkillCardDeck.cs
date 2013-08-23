﻿using System.Collections.Generic;
using DeckManager.Cards;
using DeckManager.Cards.Enums;
using log4net;

namespace DeckManager.Decks
{
    public class SkillCardDeck : BaseDeck<SkillCard>
    {
        public SkillCardDeck(ILog logger, SkillCardColor color) : base(logger)
        {
            InitDeck(color);
        }

        public SkillCardColor DeckColor { get; private set; }

        private void InitDeck(SkillCardColor color)
        {
            var cardsFromBox = new List<SkillCard>();
            //TODO: Import the cards via JSON/XML reader - the goddamn NuGet packages aren't working right now.  Fill up the cardsFromBox object.

            List<Cards.SkillCard> cards = Initialization.XMLUtil.GetSkillCardList(color);

            foreach (Cards.SkillCard card in cards)
            {
                if (card.CardColor == color)
                    cardsFromBox.Add(card);
                else ; // throw exception
            }

            Deck = cardsFromBox;
            Deck = Shuffle(Deck);
            DeckColor = color;
            Discarded = new List<SkillCard>();
        }
    }
}
