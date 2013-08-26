using System.Collections.Generic;
using DeckManager.ManagerLogic.Enums;

namespace DeckManager.Components
{
    public class Civilian : BaseComponent
    {

        /// <summary>
        /// Gets or sets what the civ is carrying, e.g. 1 Pop or 1 Pop 1 Fuel, etc.
        /// </summary>
        /// <value>
        /// The load.
        /// </value>
        public List<Resource> Load { get; set; }
    }
}
