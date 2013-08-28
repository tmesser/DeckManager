﻿using System;
using DeckManager.Cards.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DeckManager.Cards
{
    /// <summary>
    /// A common base class for all the cards, to provide easier control over logical flow
    /// </summary>
    public abstract class BaseCard
    {
        /// <summary>
        /// Gets or sets the id unique to this card.  This changes if the card is in a deck that's shuffled.
        /// </summary>
        /// <value>
        /// The unique id.
        /// </value>
        public Guid UniqueId { get; set; }

        /// <summary>
        /// Gets or sets the permanent unique identifier.
        /// </summary>
        /// <value>
        /// The permanent unique identifier.
        /// </value>
        internal Guid PermanentId { get; set; }

        /// <summary>
        /// Gets or sets the type of the card.
        /// </summary>
        /// <value>
        /// The type of the card.
        /// </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public abstract CardType CardType { get; }

        /// <summary>
        /// Returns a representation of the card in BBCode.
        /// </summary>
        /// <returns></returns>
        public abstract string ToBBCode();
    }
}
