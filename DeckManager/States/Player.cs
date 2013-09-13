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
        public List<MutinyCard> MutinyHand { get; set; }
        public List<LoyaltyCard> LoyaltyCards { get; set; }
        public List<List<SkillCardColor>> CustomDraws { get; set; }
        public List<SuperCrisisCard> SuperCrisisCards { get; set; }
        public List<Titles> Titles { get; set; }
        public int MiracleTokens { get; set; }
        public int DefaultDrawIndex { get; set; }
        /// <summary>
        /// Gets or sets whether the player has revealed themselves to be a cylon. 
        /// todo maybe make sure player has cylon loyalty in setter
        /// </summary>
        public bool RevealedCylon { get; set; }

        public Player()
        {
            // make sure these don't start uninitialized
            Cards = new List<SkillCard>();
            LoyaltyCards = new List<LoyaltyCard>();
            CustomDraws  = new List<List<SkillCardColor>>();
            Titles  = new List<Titles>();
            Character = new Characters.Character();
        }

        public override string ToString()
        {
            // MetricUnit (President Roslin [1], 6Q)
            // var titles = Titles.Count > 0 ? string.Join(" ", Titles) + " " : "";
            return PlayerName + " (" + Character.CharacterName+")";
            //return PlayerName + " (" + titles + Character.CharacterName + ") [" + Cards.Count + "] " + (QuorumHand.Count > 0 ? QuorumHand.Count.ToString() + "Q" : "");
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
        public bool Discard(MutinyCard card)
        {
            return MutinyHand.Remove(card);
        }

        public bool Discard(IEnumerable<SkillCard> cards)
        {
            var removed = Cards.RemoveAll(cards.Contains);
            return removed > 0;
        }
        public bool Discard(IEnumerable<QuorumCard> cards)
        {
            var removed = QuorumHand.RemoveAll(cards.Contains);
            return removed > 0;
        }
        public bool Discard(IEnumerable<MutinyCard > cards)
        {
            var removed = MutinyHand.RemoveAll(cards.Contains);
            return removed > 0;
        }

        public static bool operator ==(Player x, Player y)
        {
            if (ReferenceEquals(x, null) && ReferenceEquals(y, null))
                return true;
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;
            return x.PlayerName == y.PlayerName;
        }

        public static bool operator !=(Player x, Player y)
        {
            return !(x == y);
        }

        protected bool Equals(Player other)
        {
            return string.Equals(PlayerName, other.PlayerName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Player)obj);
        }

        public override int GetHashCode()
        {
            return (PlayerName != null ? PlayerName.GetHashCode() : 0);
        }

        internal bool Discard(BaseCard card)
        {
            switch (card.CardType)
            { 
                case CardType.Mutiny:
                    return Discard((MutinyCard)card);
                case CardType.Quorum:
                    return Discard((QuorumCard)card);
                case CardType.Skill:
                    return Discard((SkillCard)card);
                case CardType.SuperCrisis:
                    return Discard((SuperCrisisCard)card);
                default:
                    // error case
                    throw new System.Exception("Player's can't discard CardTypes they cannot hold:"+card.CardType);
            }
        }
    }
}
