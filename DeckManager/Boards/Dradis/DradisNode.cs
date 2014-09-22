using System.Collections.Generic;
using DeckManager.Boards.Dradis.Enums;
using DeckManager.Components;
using System.Linq;

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
        public override string Name
        {
            get { return NodeName.ToString(); }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public DradisNodeName NodeName { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DradisNode"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public DradisNode(DradisNodeName name)
        {
            NodeName = name;
            Components = new List<BaseComponent>();
        }

        /// <summary>
        /// Wipes the components (used on a jump)
        /// </summary>
        public void WipeComponents()
        {
            foreach (var ship in Components)
            {
                if (ship.ComponentType == DeckManager.Components.Enums.ComponentType.Viper)
                {
                    ((Viper)ship).Status = DeckManager.Components.Enums.ComponentStatus.InReserve;
                    ((Viper)ship).Pilot = null;
                }
                if (ship.ComponentType == DeckManager.Components.Enums.ComponentType.Civilian)
                    ((Civilian)ship).Status = DeckManager.Components.Enums.ComponentStatus.InReserve;
            }
            Components.Clear();
        }

        public new List<string> PlayersPresent
        {
            get { return (from ship in Components 
                          where ship.ComponentType == DeckManager.Components.Enums.ComponentType.Viper 
                          && ((Viper)ship).Pilot != null 
                          select ((Viper)ship).Pilot.PlayerName).ToList<string>(); }
        }
    }
}
