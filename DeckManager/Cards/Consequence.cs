using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckManager.DeckManager.Cards
{
    class Consequence
    {
        /// <summary>
        /// Threshold for consequence to occur. Max value for skill check is pass, 0 is fail, -1 is a skill check ability consequence.
        /// </summary>
        public int threshold { get; set; }

        public string conditionText { get; set; }

        public Consequence(string text, int threshold)
        {
            this.conditionText = text;
            this.threshold = threshold;
        }
    }
}
