using System;
using DeckManager.Cards.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DeckManager.Cards
{
    /// <summary>
    /// A common base class for all the cards, to provide easier control over logical flow
    /// </summary>
    public abstract class BaseCard : IEquatable<BaseCard>
    {
        /// <summary>
        /// Gets or sets the heading. Basic display stuff, like Inspirational Speech or whatever
        /// </summary>
        /// <value>
        /// The heading.
        /// </value>
        public virtual string Heading { get; set; }

        /// <summary>
        /// Gets or sets the additional text, for flavor text, card descriptions, etc.
        /// </summary>
        /// <value>
        /// The additional text.
        /// </value>
        public virtual string AdditionalText { get; set; }

        /// <summary>
        /// Gets or sets the permanent unique identifier.
        /// </summary>
        /// <value>
        /// The permanent unique identifier.
        /// </value>
        private Guid _permanentId;

        internal virtual Guid PermanentId {
            get 
            {
                if (_permanentId == default(Guid))
                {
                    _permanentId = Guid.NewGuid();
                }
                return _permanentId;
            }
            set { _permanentId = value; }
        }

        /// <summary>
        /// Gets or sets the type of the card.
        /// </summary>
        /// <value>
        /// The type of the card.
        /// </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public abstract CardType CardType { get; }

        /// <summary>
        /// Gets or sets which expansion this card came from.
        /// </summary>
        public virtual Expansion ExpansionSource { get; set; }

        /// <summary>
        /// Returns a representation of the card in BBCode.
        /// </summary>
        /// <returns></returns>
        public abstract string ToBBCode();

        public static BaseCard ReturnBaseCardFromCardType(CardType cardType)
        {
            switch (cardType)
            {
                case CardType.Crisis:
                    return new CrisisCard();
                case CardType.Quorum:
                    return new QuorumCard();
                case CardType.SuperCrisis:
                    return new SuperCrisisCard();
                case CardType.Skill:
                    return new SkillCard();
                case CardType.Mutiny:
                    return new MutinyCard();
                case CardType.Mission:
                    return new MissionCard();
                case CardType.Loyalty:
                    return new LoyaltyCard();
                case CardType.Destination:
                    return new DestinationCard();
                default:
                    return null;
            }
        }

        public static bool operator ==(BaseCard x, BaseCard y)
        {
            if (ReferenceEquals(x, null) || ReferenceEquals(y,null))
            {
                return ReferenceEquals(x, null) && ReferenceEquals(y, null);
            }
            return x.PermanentId == y.PermanentId;
        }

        public static bool operator !=(BaseCard x, BaseCard y)
        {
            return !(x == y);
        }

        public bool Equals(BaseCard other)
        {
            if (ReferenceEquals(null, other)) return false;
            return ReferenceEquals(this, other) || PermanentId.Equals(other.PermanentId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((BaseCard)obj);
        }

        public override int GetHashCode()
        {
            return PermanentId.GetHashCode();
        }
    }
}
