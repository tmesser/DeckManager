﻿using DeckManager.Cards.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DeckManager.Cards
{
    public class SkillCard : BaseCard
    {
        /// <summary>
        /// Gets or sets the color of the card.
        /// </summary>
        /// <value>
        /// The color of the card.
        /// </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public SkillCardColor CardColor { get; set; }
        
        /// <summary>
        /// Gets or sets the card power.
        /// </summary>
        /// <value>
        /// The card power.
        /// </value>
        public int CardPower { get; set; }
        
        /// <summary>
        /// Returns that this is a skill card.
        /// </summary>
        /// <value>
        /// The type of the card.
        /// </value>
        public override CardType CardType
        {
            get { return CardType.Skill; }
        }

        /// <summary>
        /// Outputs a BBCode representation for the card.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override string ToBBCode()
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// Returns card summary for ListBox controls (e.g. "LEA-2 Executive Order")
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Heading;
        }
    }
}
