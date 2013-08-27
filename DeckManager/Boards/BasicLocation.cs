using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckManager.Boards
{
    public class BasicLocation : BaseNode
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the location information, such as activation effects.
        /// </summary>
        /// <value>
        /// The location information.
        /// </value>
        public string LocationInfo { get; set; }

        /// <summary>
        /// Gets or sets the name of the board the location is on.
        /// </summary>
        /// <value>
        /// The name of the board.
        /// </value>
        public string BoardName { get; set; }
    }
}
