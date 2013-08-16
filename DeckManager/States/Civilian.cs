using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckManager.States
{
    public class Civilian
    {
        /// <summary>
        /// Civ A, B, C etc that is publicly assigned whenever a civilian ship is deployed.
        /// </summary>
        /// <value>
        /// The public designation.
        /// </value>
        public string PublicDesignation { get; set; }

        /// <summary>
        /// A system-internal for the civilian ship to randomize their deployment.  Changes whenever the civilian pile is shuffled.
        /// </summary>
        /// <value>
        /// The internal designation.
        /// </value>
        public string InternalDesignation { get; set; }

        /// <summary>
        /// Gets or sets what the civ is carrying, e.g. 1 Pop or 1 Pop 1 Fuel, etc.
        /// </summary>
        /// <value>
        /// The load.
        /// </value>
        public string Load { get; set; }
    }
}
