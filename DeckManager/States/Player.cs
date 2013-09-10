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
        public List<Titles> Titles { get; set; }
        public int MiracleTokens { get; set; }
        public int DefaultDrawIndex { get; set; }

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
            var titles = Titles.Count > 0 ? string.Join(" ", Titles) + " " : "";
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
            int removed = Cards.RemoveAll(card => cards.Contains(card));
            if (removed > 0)
                return true;
            return false;
        }
        public bool Discard(IEnumerable<QuorumCard> cards)
        {
            int removed = QuorumHand.RemoveAll(card => cards.Contains(card));
            if (removed > 0)
                return true;
            return false;
        }
        public bool Discard(IEnumerable<MutinyCard > cards)
        {
            int removed = MutinyHand.RemoveAll(card => cards.Contains(card));
            if (removed > 0)
                return true;
            return false;
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
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Player)obj);
        }

        public override int GetHashCode()
        {
            return (PlayerName != null ? PlayerName.GetHashCode() : 0);
        }
    }
}
