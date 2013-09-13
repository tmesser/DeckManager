using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckManager.Cards
{
    public class MutinyCard : BaseCard
    {
        public string AdditionalText { get; set; }
        public string Heading { get; set; }

        public override Enums.CardType CardType
        {
            get { return Enums.CardType.Mutiny; }
        }

        public override string ToBBCode()
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return Heading + " (" + AdditionalText + ")";
        }
    }
}
