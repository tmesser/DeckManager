using System;
using System.Collections.Generic;
using System.Linq;
using DeckManager.Components;

namespace DeckManager.Boards.Dradis
{
    public class DradisNode : BaseNode
    {
        /// <summary>
        /// Gets the next node.
        /// </summary>
        /// <value>
        /// The next node.
        /// </value>
        public DradisNode NextNode { get; private set; }

        /// <summary>
        /// Gets the previous node.
        /// </summary>
        /// <value>
        /// The previous node.
        /// </value>
        public DradisNode PrevNode { get; private set; }

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
        /// Sets the node position.
        /// </summary>
        /// <param name="next">The next node (clockwise).</param>
        /// <param name="prev">The previous node (counterclockwise).</param>
        public void SetNodePosition(DradisNode next, DradisNode prev)
        {
            NextNode = next;
            PrevNode = prev;
        }

        /// <summary>
        /// Moves the components to a new DRADIS sector.
        /// </summary>
        /// <param name="components">The components.</param>
        /// <param name="destination">The destination.</param>
        public void MoveComponents(IEnumerable<BaseComponent> components, DradisNodeName destination)
        {
            MoveComponents(components.Select(component => component.PermanentDesignation), destination);
        }

        /// <summary>
        /// Moves the components to a new DRADIS sector.
        /// </summary>
        /// <param name="components">The components.</param>
        /// <param name="destination">The destination.</param>
        public void MoveComponents(IEnumerable<Guid> components, DradisNodeName destination)
        {
            DradisNode moveTo = null;
            if (PrevNode.Name == destination)
                moveTo = PrevNode;
            else if (NextNode.Name == destination)
                moveTo = NextNode;
            if (moveTo == null)
                return;

            var movedComponents = Components.Where(x => components.Contains(x.PermanentDesignation)).ToList();
            moveTo.Components.AddRange(movedComponents);
            foreach (var component in movedComponents)
                Components.Remove(component);
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
