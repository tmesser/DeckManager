using System;
using System.Collections.Generic;
using System.Linq;
using DeckManager.Boards.Dradis.Enums;
using DeckManager.Components;

namespace DeckManager.Boards.Dradis
{
    /// <summary>
    /// An object representing the DRADIS board.
    /// </summary>
    public class DradisBoard
    {
        /// <summary>
        /// Gets or sets the nodes.
        /// </summary>
        /// <value>
        /// The nodes.
        /// </value>
        public IEnumerable<DradisNode> Nodes { get; set; }

        /// <summary>
        /// Adds the component to node.
        /// </summary>
        /// <param name="component">The component.</param>
        /// <param name="name">The name.</param>
        public void AddComponentToNode(BaseComponent component, DradisNodeName name)
        {
            if (component == null)
                return;
            if (Nodes == null)
                PrepDradis();
            var sector = Nodes.FirstOrDefault(x => x.NodeName == name);
            if (sector == default(DradisNode))
            { 
                PrepDradis();
                sector = Nodes.First(x => x.NodeName == name);
            }
            sector.Components.Add(component);
        }

        /// <summary>
        /// Removes a component.
        /// </summary>
        /// <param name="component">The component.</param>
        public void RemoveComponent(BaseComponent component)
        {
            if (component == null)
                return;
            if (Nodes == null)
                PrepDradis();
            var sector = Nodes.FirstOrDefault(x => x.Components.Contains(component));
            if(sector == default(DradisNode))
            {
                PrepDradis();
                sector = Nodes.First(x => x.Components.Contains(component));
            }
            sector.Components.Remove(component);
            if (component.ComponentType == Components.Enums.ComponentType.Viper)
            {
                ((Viper)component).Pilot = null;
                ((Viper)component).Status = Components.Enums.ComponentStatus.InReserve;
            }
            if (component.ComponentType == Components.Enums.ComponentType.Civilian)
            {
                ((Civilian)component).Status = Components.Enums.ComponentStatus.InReserve;
            }
        }

        /// <summary>
        /// Removes a component.
        /// </summary>
        /// <param name="component">The component.</param>
        public void RemoveComponent(Guid component)
        {
            RemoveComponent(new GenericComponent { PermanentDesignation = component });
        }

        /// <summary>
        /// Wipes the dradis.
        /// </summary>
        public void WipeDradis()
        {
            foreach (var node in Nodes)
                node.WipeComponents();
        }

        /// <summary>
        /// Moves numerous components.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        /// <param name="componentsToMove">The components to move.</param>
        public void MoveComponents(DradisNodeName source, DradisNodeName destination, IEnumerable<BaseComponent> componentsToMove)
        {
            if (componentsToMove == null)
                return;
            MoveComponents(source, destination, componentsToMove.Select(x => x.PermanentDesignation));
        }

        /// <summary>
        /// Moves numerous components.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        /// <param name="componentsToMove">The components to move.</param>
        public void MoveComponents(DradisNodeName source, DradisNodeName destination, IEnumerable<Guid> componentsToMove)
        {
            if (componentsToMove == null)
                return;
            if (Nodes == null)
                PrepDradis();
            var sectorSource = Nodes.FirstOrDefault(x => x.NodeName == source);
            if (sectorSource == default(DradisNode))
            {
                PrepDradis();
                sectorSource = Nodes.First(x => x.NodeName == source);
            }

            var sectorDestination = Nodes.FirstOrDefault(x => x.NodeName == destination);
            if (sectorDestination == default(DradisNode))
            {
                PrepDradis();
                sectorDestination = Nodes.First(x => x.NodeName == source);
            }

            var movedComponents = sectorSource.Components.Where(x => componentsToMove.Contains(x.PermanentDesignation)).ToList();
            sectorDestination.Components.AddRange(movedComponents);
            foreach (var component in movedComponents)
                sectorSource.Components.Remove(component);
        }

        /// <summary>
        /// Gets the components.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public IEnumerable<BaseComponent> GetComponents(DradisNodeName source)
        {
            if (Nodes == null)
                PrepDradis();
            var sector = Nodes.FirstOrDefault(x => x.NodeName == source);
            return sector == null ? null : sector.Components;
        }

        /// <summary>
        /// Preps the DRADIS in the case that something wasn't found.  Will not stop a crash if you pass in Unknown, but there's no rules around that so hell with it.
        /// </summary>
        private void PrepDradis()
        {
            var alpha = new DradisNode(DradisNodeName.Alpha);
            var bravo = new DradisNode(DradisNodeName.Bravo);
            var charlie = new DradisNode(DradisNodeName.Charlie);
            var delta = new DradisNode(DradisNodeName.Delta);
            var echo = new DradisNode(DradisNodeName.Echo);
            var foxtrot = new DradisNode(DradisNodeName.Foxtrot);

            Nodes = new List<DradisNode> { alpha, bravo, charlie, delta, echo, foxtrot };
        }
    }
}
