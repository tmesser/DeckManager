using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckManager.Cards
{
    /// <summary>
    /// Card representing the Allegiance cards dealt to Cylon leaders per the Daybreak rules
    /// </summary>
    class Allegiance : BaseCard
    {
        /// <summary>
        /// True=Cylon, False=Human
        /// </summary>
        public bool IsCylonAllegiance { get; set; }
        /// <summary>
        /// The condition text for revealing the card
        /// </summary>
        public string AdditionalText { get; set; }

    
        public override Enums.CardType CardType
        {
            get { return Enums.CardType.Allegiance; }
        }

        public override string ToBBCode()
        {
 	        throw new NotImplementedException();
        }
    }
}
