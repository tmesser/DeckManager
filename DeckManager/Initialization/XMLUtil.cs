using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Text.RegularExpressions;

namespace DeckManager.Initialization
{
    class XMLUtil
    {
        static string filepath { get; set; }
        private static XmlDocument doc;

        public static List<Cards.SkillCard> GetSkillCardList(Cards.Enums.SkillCardColor color)
        {
            if (doc == null)
                XMLUtil.OpenXmlFile();
            else if (doc.BaseURI != filepath)
                XMLUtil.OpenXmlFile();


            List<Cards.SkillCard> cardList = new List<Cards.SkillCard>();
            XmlNodeList xmlDeck = null;
            switch (color)
            { 
                case Cards.Enums.SkillCardColor.Politics:
                    xmlDeck = GetNode("POLdeck");
                    break;
                case Cards.Enums.SkillCardColor.Leadership:
                    xmlDeck = GetNode("LEAdeck");
                    break;
                case Cards.Enums.SkillCardColor.Tactics:
                    xmlDeck = GetNode("TACdeck");
                    break;
                case Cards.Enums.SkillCardColor.Piloting:
                    xmlDeck = GetNode("PILdeck");
                    break;
                case Cards.Enums.SkillCardColor.Engineering:
                    xmlDeck = GetNode("ENGdeck");
                    break;
                case Cards.Enums.SkillCardColor.Treachery:
                    xmlDeck = GetNode("TREdeck");
                    break;
                default:
                    break;
            }

            if (xmlDeck != null)
            {
                XmlNodeList cards = xmlDeck[0].ChildNodes;
                foreach (XmlNode card in cards)
                {
                    string text = card.ChildNodes[0].InnerText;

                    Cards.SkillCard newCard = new Cards.SkillCard();
                    newCard.CardColor = color;  // todo check this matches XML card type
                    newCard.CardPower = GetCardStrength(text);
                    newCard.Heading = GetCardName(text);
                    cardList.Add(newCard);
                }
                return cardList;
            }
            else ; // throw exception

            return null;
        }
        public static List<Cards.BaseCard> GetCardList(Cards.Enums.CardType type)
        {
            if (doc == null)
                XMLUtil.OpenXmlFile();
            else if (doc.Name != filepath)
                XMLUtil.OpenXmlFile();

            List<Cards.BaseCard> cardList = new List<Cards.BaseCard>();
            XmlNodeList cards = null;
            switch (type)
            { 
                case Cards.Enums.CardType.Crisis:
                    cards = GetNode("CRISISdeck");
                    break;
                case Cards.Enums.CardType.Destination:
                    cards = GetNode("DESTINATIONdeck");
                    return GetDestinationList(cards);
                case Cards.Enums.CardType.Loyalty:
                    //cards = GetNode("");    // todo - not in XML file
                    return GetLoyaltyList();
                    break;
                case Cards.Enums.CardType.Mission:
                    cards = GetNode("");    // todo - not in XML file
                    break;
                case Cards.Enums.CardType.Quorum:
                    cards = GetNode("QUORUMdeck");
                    return GetQuorumList(cards);
                case Cards.Enums.CardType.SuperCrisis:
                    cards = GetNode("SUPERCRISISdeck");
                    break;
                default:
                    break;
            }
            foreach (XmlNode card in cards)
            {
                string text = card.ChildNodes[0].InnerText;
                string[] lines = Regex.Split(text, "\r\n");
                string name = lines[0].Trim();

            }

            return cardList;
        }

        public static void SetSourceFile(string file)
        {
            filepath = file;
        }
        private static void OpenXmlFile()
        {
            doc = new XmlDocument();

            if (filepath == null)
                filepath = @"E:\My Documents\Dropbox\DeckManager\DeckManager\Content\Pegasus.xml";
            doc.Load(filepath);
        }
        private static XmlNodeList GetNode(string nodename)
        {
            return doc.GetElementsByTagName(nodename);
        }
        private static int GetCardStrength(string text)
        {
            Regex pattern = new Regex(@"[A-z]+-(\d) ");
            Match power = pattern.Match(text);
            if (power.Success)
            {
                return Convert.ToInt32(power.Groups[1].Value);
            }
            return -1;  // error case
        }
        private static string GetCardName(string text)
        {
            Regex pattern = new Regex(@"\((.+)\)");
            Match name = pattern.Match(text);
            if (name.Success)
                return name.Groups[1].ToString();   // groups start indexing at 1 apparently
            else
                return "ERROR unable to get skill card name";
        }

        private static List<Cards.BaseCard> GetQuorumList(XmlNodeList cards)
        {
            List<Cards.BaseCard> quorums = new List<Cards.BaseCard>();
            foreach (XmlNode card in cards)
            {
                string text = card.ChildNodes[0].InnerText;
                string[] tokens = Regex.Split(text, "\r\n");
                Cards.QuorumCard quorum = new Cards.QuorumCard();
                quorum.Heading = tokens[0].Trim();
                quorum.AdditionalText = tokens[tokens.Length - 1].Trim();   // last line
                quorums.Add((Cards.BaseCard)quorum);
            }

            return quorums;
        }
        private static List<Cards.BaseCard> GetDestinationList(XmlNodeList cards)
        {
            List<Cards.BaseCard> destinations = new List<Cards.BaseCard>();
            foreach (XmlNode card in cards)
            {
                string text = card.ChildNodes[0].InnerText;
                string[] tokens = Regex.Split(text, "\r\n");
                Cards.DestinationCard dest = new Cards.DestinationCard();
                dest.Heading = tokens[0].Trim();
                dest.Distance = Convert.ToInt32((tokens[1].Split(" ".ToCharArray()))[1]);
                dest.AdditionalText = tokens[tokens.Length-1].Trim();   // last line
                destinations.Add((Cards.BaseCard)dest);
            }

            return destinations;
        }
        private static List<Cards.BaseCard> GetCrisisList(XmlNodeList cards)
        {
            List<Cards.BaseCard> crisises = new List<Cards.BaseCard>();
            foreach (XmlNode card in cards)
            {
                string text = card.ChildNodes[0].InnerText;
                string[] tokens = Regex.Split(text, "\r\n");
                Cards.CrisisCard crisis = new Cards.CrisisCard();

                string heading = tokens[0].Trim();
                heading = heading.Remove(0,8);  // consume "CRISIS: "
                crisis.Heading = heading;

                crisis.AdditionalText = tokens[tokens.Length - 1].Trim();   // last line
                crisises.Add((Cards.BaseCard)crisis);
            }

            return crisises;
        }
        private static List<Cards.BaseCard> GetLoyaltyList(XmlNodeList cards)
        { return null; }

        // stub function, testing only
        private static List<Cards.BaseCard> GetLoyaltyList()
        {
            List<Cards.BaseCard> cards = new List<Cards.BaseCard>();
            Cards.LoyaltyCard card = new Cards.LoyaltyCard();
            card.Loyalty = Cards.Enums.Loyalty.Cylon;
            cards.Add((Cards.BaseCard)card);
            card = new Cards.LoyaltyCard();
            card.Loyalty = Cards.Enums.Loyalty.NotACylon;
            cards.Add((Cards.BaseCard)card);
            card = new Cards.LoyaltyCard();
            card.Loyalty = Cards.Enums.Loyalty.NotACylon;
            cards.Add((Cards.BaseCard)card);
            return cards;
        }
    }
}
