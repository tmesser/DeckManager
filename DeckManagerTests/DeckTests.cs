using System.IO;
using DeckManager.Cards.Enums;
using DeckManager.Decks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckManagerTests
{
    [TestFixture]
    public class DeckTests
    {
        [Test]
        public void Should_Read_Engineering_Xml()
        {
            var constructedDeck = new SkillCardDeck(null, SkillCardColor.Engineering, @"..\..\TestContent\Core.xml", true);
            Assert.AreEqual(constructedDeck.Deck.Count, 21);
        }
        [Test]
        public void Should_Read_Leadership_Xml()
        {
            var constructedDeck = new SkillCardDeck(null, SkillCardColor.Leadership, @"..\..\TestContent\Core.xml", true);
            Assert.AreEqual(constructedDeck.Deck.Count, 21);
        }
        [Test]
        public void Should_Read_Politics_Xml()
        {
            var constructedDeck = new SkillCardDeck(null, SkillCardColor.Politics, @"..\..\TestContent\Core.xml", true);
            Assert.AreEqual(constructedDeck.Deck.Count, 21);
        }
        [Test]
        public void Should_Read_Piloting_Xml()
        {
            var constructedDeck = new SkillCardDeck(null, SkillCardColor.Piloting, @"..\..\TestContent\Core.xml", true);
            Assert.AreEqual(constructedDeck.Deck.Count, 21);
        }
        [Test]
        public void Should_Read_Tactics_Xml()
        {
            var constructedDeck = new SkillCardDeck(null, SkillCardColor.Tactics, @"..\..\TestContent\Core.xml", true);
            Assert.AreEqual(constructedDeck.Deck.Count, 21);
        }
    }
}
