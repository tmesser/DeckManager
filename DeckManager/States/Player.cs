using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeckManager.Cards;
using DeckManager.Cards.Enums;
using DeckManager.Characters.Enums;
using DeckManager.Extensions;

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
            MutinyHand = new List<MutinyCard>();
            SuperCrisisCards = new List<SuperCrisisCard>();
            QuorumHand = new List<QuorumCard>();
            Titles  = new List<Titles>();
            Character = new Characters.Character();
        }

        public override string ToString()
        {
            // MetricUnit (President Roslin [1], 6Q)
            return PlayerName + " (" + Titles.ToSingleString() + Character.CharacterName + ") [" + Cards.Count + "] " + ((QuorumHand != null && QuorumHand.Count > 0) ? QuorumHand.Count + "Q" : string.Empty);
        }

        public IEnumerable<IEnumerable<SkillCardColor>> SkillCardDraws
        {
            get
            {
                var ret = new List<List<SkillCardColor>>();
                ret.AddRange(CustomDraws);
                ret.AddRange(Character.DefaultDrawColors);
                return ret;
            }
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

        internal bool Discard(IEnumerable<BaseCard> cards)
        {
            return cards.Aggregate(true, (current, card) => current && Discard(card));
        }

        internal bool Discard(BaseCard card)
        {
            switch (card.CardType)
            { 
                case CardType.Mutiny:
                    return MutinyHand.Remove((MutinyCard)card);
                case CardType.Quorum:
                    return QuorumHand.Remove((QuorumCard)card);
                case CardType.Skill:
                    return Cards.Remove((SkillCard)card);
                case CardType.SuperCrisis:
                    return SuperCrisisCards.Remove((SuperCrisisCard) card);
                case CardType.Loyalty:
                    LoyaltyCards.Remove((LoyaltyCard)card);
                    break;
            }
            return false;
        }

        internal void TakeCard(IEnumerable<BaseCard> cards)
        {
            foreach (var card in cards)
                TakeCard(card);
        }

        internal void TakeCard(BaseCard card)
        {
            switch (card.CardType)
            {
                case CardType.Mutiny:
                    MutinyHand.Add((MutinyCard)card);
                    break;
                case CardType.Quorum:
                    QuorumHand.Add((QuorumCard)card);
                    break;
                case CardType.Skill:
                    Cards.Add((SkillCard)card);
                    break;
                case CardType.SuperCrisis:
                    SuperCrisisCards.Add((SuperCrisisCard)card);
                    break;
                case CardType.Loyalty:
                    LoyaltyCards.Add((LoyaltyCard) card);
                    break;
            }
        }

        internal string SkillCardString(IEnumerable<SkillCardColor> playerDraw)
        {
            var draw = playerDraw.ToList();
            var ret = new StringBuilder();
            foreach (var color in draw.Distinct())
            {
                ret.Append(draw.Count(x => x == color) + " " + color + ", ");
            }
            return ret.ToString(0, ret.Length - 2);
        }
    }
}
