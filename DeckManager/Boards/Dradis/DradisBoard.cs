﻿using System;
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

            alpha.SetNodePosition(bravo, foxtrot);
            bravo.SetNodePosition(charlie, alpha);
            charlie.SetNodePosition(delta, bravo);
            delta.SetNodePosition(echo, charlie);
            echo.SetNodePosition(foxtrot, delta);
            foxtrot.SetNodePosition(alpha, echo);

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
            var sector = Nodes.FirstOrDefault(x => x.Name == source);
            if (sector == default(DradisNode))
                return;
            sector.MoveComponents(componentsToMove, destination);
        }
    }
}