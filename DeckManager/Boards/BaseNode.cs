using System.Collections.Generic;

namespace DeckManager.Boards
{
    public abstract class BaseNode
    {
        private List<string> _playersPresent;

        public virtual string Name { get; set; }

        public List<string> PlayersPresent
        {
            get { return _playersPresent ?? (_playersPresent = new List<string>()); }
        }
    }
}
