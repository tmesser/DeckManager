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
            var beta = new DradisNode(DradisNodeName.Beta);
            var charlie = new DradisNode(DradisNodeName.Charlie);
            var delta = new DradisNode(DradisNodeName.Delta);
            var echo = new DradisNode(DradisNodeName.Echo);
            var foxtrot = new DradisNode(DradisNodeName.Foxtrot);

            alpha.SetNodePosition(beta, foxtrot);
            beta.SetNodePosition(charlie, alpha);
            charlie.SetNodePosition(delta, beta);
            delta.SetNodePosition(echo, charlie);
            echo.SetNodePosition(foxtrot, delta);
            foxtrot.SetNodePosition(alpha, echo);

            Nodes = new List<DradisNode> {alpha, beta, charlie, delta, echo, foxtrot};
        }
    }
}
