using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckManager.Boards
{
    public abstract class BaseNode
    {
        private List<string> _playersPresent;

        public List<string> PlayersPresent
        {
            get { return _playersPresent ?? (_playersPresent = new List<string>()); }
        }
    }
}
