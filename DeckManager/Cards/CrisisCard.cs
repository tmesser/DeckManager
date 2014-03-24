using System;
using System.Collections.Generic;
using System.Text;
using DeckManager.Cards.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DeckManager.Cards
{
    public class CrisisCard : BaseCard
    {


        /// <summary>
        /// Reports that this is a crisis card.
        /// </summary>
        /// <value>
        /// The type of the card.
        /// </value>
        public override CardType CardType
        {
            get { return CardType.Crisis; }
        }

        /// <summary>
        /// Gets or sets the list of choices on this crisis card
        /// </summary>
        [JsonIgnore]
        public List<object> Choices { get; set; }  // choices can be skill checks or strings like "-1 Morale and damage Galatica twice"

        /// <summary>
        /// Gets or sets the positive card colors.
        /// </summary>
        /// <value>
        /// The positive colors.
        /// </value>
        public List<SkillCardColor> PositiveColors { get; set; }

        /// <summary>
        /// Gets or sets whether the Crisis has Jump Prep
        /// </summary>
        public bool JumpPrep { get; set; }

        /// <summary>
        /// Gets or Sets the Crisis' cylon activation
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CylonActivations Activation { get; set; }

        /// <summary>
        /// This crisis' skill check (can be null)
        /// </summary>
        public List<Tuple<int, string>> PassLevels { get; set; }

        /// <summary>
        /// Formats the object for posts on BBCode forums
        /// </summary>
        /// <returns></returns>
        public override string ToBBCode()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            // todo this needs to be worked on to account for all the different crisis formats
            var ret = new StringBuilder();
            ret.AppendLine(Heading);
            ret.AppendLine(AdditionalText);
            return ret.ToString();
        }

        /// <summary>
        /// Returns a user-friendly string representing this crisis' skill check, if it has one. Empty string if not.
        /// </summary>
        /// <returns></returns>
        public string GetSkillCheckText()
        {
            return HasSkillCheck() ? AdditionalText : string.Empty;
        }

        public bool HasSkillCheck()
        { 
            return PositiveColors.Count != 0; 
        }
    }
}
