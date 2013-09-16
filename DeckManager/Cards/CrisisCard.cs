using System;
using System.Collections.Generic;
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
        /// Title of the crisis.
        /// </summary>
        /// <value>
        /// The heading.
        /// </value>
        public string Heading { get; set; }

        /// <summary>
        /// Gets or sets the additional text, description of the crisis, etc
        /// </summary>
        /// <value>
        /// The additional text.
        /// </value>
        public string AdditionalText { get; set; }

        /// <summary>
        /// Gets or sets the list of choices on this crisis card
        /// </summary>
        [JsonIgnore]
        public List<object> Choices { get; set; }  // choices can be skill checks or strings like "-1 Morale and damage Galatica twice"
        /// <summary>
        /// Gets or sets the chooser on this crisis card
        /// </summary>
        [JsonIgnore]
        public Characters.Enums.Titles Chooser {get;set;}

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
            string ret = Heading+"\n";
            if (Chooser != Characters.Enums.Titles.Unknown)
            {
                ret += Chooser + " Chooses:";
                ret += string.Join("\n OR\n", Choices);
            }
            else
                ret += AdditionalText;
            //return Heading + "\n" + AdditionalText + "\n";

            ret += "\nActivate: " + Activation + " " + (JumpPrep ? "+1 Jump Prep" : "NO JUMP PREP");
            return ret;
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
