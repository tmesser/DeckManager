using System;
using System.Collections.Generic;
using System.Linq;
using DeckManager.Components;
using Newtonsoft.Json;

namespace DeckManager.Boards.Dradis
{
    public class DradisNode : BaseNode
    {

        /// <summary>
        /// Gets the components.
        /// </summary>
        /// <value>
        /// The components.
        /// </value>
        public List<BaseComponent> Components { get; private set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public DradisNodeName Name { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DradisNode"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public DradisNode(DradisNodeName name)
        {
            Name = name;
            Components = new List<BaseComponent>();
        }

        /// <summary>
        /// Wipes the components (used on a jump)
        /// </summary>
        public void WipeComponents()
        {
            Components.Clear();
        }
    }
}
