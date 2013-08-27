using System;
using DeckManager.Components.Enums;

namespace DeckManager.Components
{
    public abstract class BaseComponent
    {
        /// <summary>
        /// Component A, B, C etc that is publicly assigned whenever a ship is deployed.
        /// </summary>
        /// <value>
        /// The public designation.
        /// </value>
        public string PublicDesignation { get; set; }

        /// <summary>
        /// Gets or sets the permanent designation for this civilian ship.
        /// </summary>
        /// <value>
        /// The permanent designation.
        /// </value>
        internal Guid PermanentDesignation { get; set; }

        /// <summary>
        /// A system-internal for the component to randomize their deployment.  Changes whenever the pile is shuffled.
        /// </summary>
        /// <value>
        /// The internal designation.
        /// </value>
        public Guid InternalDesignation { get; set; }

        /// <summary>
        /// Gets the type of the component.
        /// </summary>
        /// <value>
        /// The type of the component.
        /// </value>
        public abstract ComponentType ComponentType { get; }

        public static bool operator ==(BaseComponent x, BaseComponent y)
        {
            if (ReferenceEquals(x, null) && ReferenceEquals(y, null))
                return true;
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;
            return x.PermanentDesignation == y.PermanentDesignation;
        }

        public static bool operator !=(BaseComponent x, BaseComponent y)
        {
            return !(x == y);
        }

        protected bool Equals(BaseComponent other)
        {
            return string.Equals(PermanentDesignation, other.PermanentDesignation);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((BaseComponent)obj);
        }

        public override int GetHashCode()
        {
            return (PermanentDesignation != null ? PermanentDesignation.GetHashCode() : 0);
        }
    }
}
