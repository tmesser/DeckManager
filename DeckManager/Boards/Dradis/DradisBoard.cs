using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
