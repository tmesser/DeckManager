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
    /* Useful little code snippet for writing out json
     * 
            using(var sr = new StreamWriter(@"..\..\TestContent\Destination.json"))
            {
                sr.Write(constructedDeck.PristineDeck);
            }
     */

    [TestFixture]
    public class DeckTests
    {
        /* The reading tests are not true unit tests, since they depend upon a resource outside of the tested classes (in this case, xml/json files - and by extension, Json.NET itself).
         * However, since this isn't an enterprise project, this problem has been determined less important than building something functional at this time.  
         * Further, due to the current small scope of the project, Json.NET is unlikely to EVER be replaced as the serializer, so arguably we would want the tests to break horribly if it ever changed.
         */


        [Test]
        public void Should_Read_SuperCrisis_Xml()
        {
            var constructedDeck = new SuperCrisisDeck(null, @"..\..\TestContent\Core.xml", true);
            Assert.AreEqual(constructedDeck.Deck.Count, 5);
        }

        [Test]
        public void Should_Read_SuperCrisis_Json()
        {
            var constructedDeck = new SuperCrisisDeck(null, @"..\..\TestContent\SuperCrisisDeck.json", false);
            Assert.AreEqual(constructedDeck.Deck.Count, 5);
        }

        [Test]
        public void Should_Read_Quorum_Xml()
        {
            var constructedDeck = new QuorumDeck(null, @"..\..\TestContent\Core.xml", true);

            Assert.AreEqual(constructedDeck.Deck.Count, 17);
        }

        [Test]
        public void Should_Read_Quorum_Json()
        {
            var constructedDeck = new QuorumDeck(null, @"..\..\TestContent\QuorumDeck.json", false);
            Assert.AreEqual(constructedDeck.Deck.Count, 17);
        }

        [Test]
        public void Should_Read_Destination_Xml()
        {
            var constructedDeck = new DestinationDeck(null, @"..\..\TestContent\Core.xml", true);
            Assert.AreEqual(constructedDeck.Deck.Count, 22);
        }

        [Test]
        public void Should_Read_Destination_Json()
        {
            var constructedDeck = new CrisisDeck(null, @"..\..\TestContent\DestinationDeck.json", false);
            Assert.AreEqual(constructedDeck.Deck.Count, 22);
        }

        [Test]
        public void Should_Read_Crisis_Xml()
        {
            var constructedDeck = new CrisisDeck(null, @"..\..\TestContent\Core.xml", true);
            Assert.AreEqual(constructedDeck.Deck.Count, 70);
        }

        [Test]
        public void Should_Read_Crisis_Json()
        {
            var constructedDeck = new CrisisDeck(null, @"..\..\TestContent\Crisis.json", false);
            Assert.AreEqual(constructedDeck.Deck.Count, 70);
        }

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

        [Test]
        public void Should_Read_Engineering_Json()
        {
            var constructedDeck = new SkillCardDeck(null, SkillCardColor.Engineering, @"..\..\TestContent\EngineeringDeck.json", false);
            Assert.AreEqual(constructedDeck.Deck.Count, 21);
        }

        [Test]
        public void Should_Read_Leadership_Json()
        {
            var constructedDeck = new SkillCardDeck(null, SkillCardColor.Leadership, @"..\..\TestContent\EngineeringDeck.json", false);
            Assert.AreEqual(constructedDeck.Deck.Count, 21);
        }

        [Test]
        public void Should_Read_Politics_Json()
        {
            var constructedDeck = new SkillCardDeck(null, SkillCardColor.Politics, @"..\..\TestContent\EngineeringDeck.json", false);
            Assert.AreEqual(constructedDeck.Deck.Count, 21);
        }

        [Test]
        public void Should_Read_Piloting_Json()
        {
            var constructedDeck = new SkillCardDeck(null, SkillCardColor.Piloting, @"..\..\TestContent\EngineeringDeck.json", false);
            Assert.AreEqual(constructedDeck.Deck.Count, 21);
        }

        [Test]
        public void Should_Read_Tactics_Json()
        {
            var constructedDeck = new SkillCardDeck(null, SkillCardColor.Tactics, @"..\..\TestContent\EngineeringDeck.json", false);
            Assert.AreEqual(constructedDeck.Deck.Count, 21);
        }
    }
}
