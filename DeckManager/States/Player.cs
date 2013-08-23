using System.Collections.Generic;
using System.Linq;
using DeckManager.Cards;
using DeckManager.Cards.Enums;
using DeckManager.Characters.Enums;

namespace DeckManager.States
{
    public class Player
    {
        public string PlayerName { get; set; }
        public int TurnPosition { get; set; }
        public Characters.Character Character { get; set; }
        public List<SkillCard> Cards { get; set; }
        public List<QuorumCard> QuorumHand { get; set; }
        public List<LoyaltyCard> LoyaltyCards { get; set; }
        public List<List<SkillCardColor>> CustomDraws { get; set; }
        public List<Titles> Titles { get; set; }
        public int MiracleTokens { get; set; }
        public int DefaultDrawIndex { get; set; }

        public override string ToString()
        {
            // MetricUnit (President Roslin [1], 6Q)
            var titles = Titles.Count > 0 ? string.Join(" ", Titles) + " " : "";
            return PlayerName + " (" + titles + Character.CharacterName + ") [" + Cards.Count + "] " + (QuorumHand.Count > 0 ? QuorumHand.Count + "Q" : "");
        }

        public IEnumerable<IEnumerable<SkillCardColor>> SkillCardDraws
        {
            get { return Character.DefaultDrawColors.Union(CustomDraws); }
        }

        public bool Discard(SkillCard card)
        {
            return Cards.Remove(card);
        }

        public bool Discard(QuorumCard card)
        {
            return QuorumHand.Remove(card);
        }
    }
}
