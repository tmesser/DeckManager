using System;
using System.Collections.Generic;
using System.Linq;
using DeckManager.Components;

namespace DeckManager.Boards.Dradis
{
    public class DradisBoard
    {
        /// <summary>
        /// Gets or sets the nodes.
        /// </summary>
        /// <value>
        /// The nodes.
        /// </value>
        public IEnumerable<DradisNode> Nodes { get; set; }

        public DradisBoard()
        {
            var alpha = new DradisNode(DradisNodeName.Alpha);
            var bravo = new DradisNode(DradisNodeName.Bravo);
            var charlie = new DradisNode(DradisNodeName.Charlie);
            var delta = new DradisNode(DradisNodeName.Delta);
            var echo = new DradisNode(DradisNodeName.Echo);
            var foxtrot = new DradisNode(DradisNodeName.Foxtrot);

            Nodes = new List<DradisNode> {alpha, bravo, charlie, delta, echo, foxtrot};
        }

        public void AddComponentToNode(BaseComponent component, DradisNodeName name)
        {
            if (component == null)
                return;
            var sector = Nodes.FirstOrDefault(x => x.Name == name);
            if (sector == default(DradisNode))
                return;
            sector.Components.Add(component);
        }

        public void RemoveComponent(BaseComponent component)
        {
            if (component == null)
                return;
            var sector = Nodes.FirstOrDefault(x => x.Components.Contains(component));
            if(sector == default(DradisNode))
                return;
            sector.Components.Remove(component);

        }

        /// <summary>
        /// Wipes the dradis.
        /// </summary>
        public void WipeDradis()
        {
            foreach (var node in Nodes)
                node.WipeComponents();
        }

        public void RemoveComponent(Guid component)
        {
            RemoveComponent(new GenericComponent { PermanentDesignation = component });
        }

        public void MoveComponents(DradisNodeName source, DradisNodeName destination, IEnumerable<BaseComponent> componentsToMove)
        {
            if (componentsToMove == null)
                return;
            MoveComponents(source, destination, componentsToMove.Select(x => x.PermanentDesignation));
        }

        public void MoveComponents(DradisNodeName source, DradisNodeName destination, IEnumerable<Guid> componentsToMove)
        {
            if (componentsToMove == null)
                return;
            var sectorSource = Nodes.FirstOrDefault(x => x.Name == source);
            if (sectorSource == default(DradisNode))
                return;

            var sectorDestination = Nodes.FirstOrDefault(x => x.Name == destination);
            if (sectorSource == default(DradisNode))
                return;

            var movedComponents = sectorSource.Components.Where(x => componentsToMove.Contains(x.PermanentDesignation)).ToList();
            sectorDestination.Components.AddRange(movedComponents);
            foreach (var component in movedComponents)
                sectorSource.Components.Remove(component);
        }

        public IEnumerable<BaseComponent> GetComponents(DradisNodeName source)
        {
            var sector = Nodes.FirstOrDefault(x => x.Name == source);
            return sector == null ? null : sector.Components;
        }
    }
}
