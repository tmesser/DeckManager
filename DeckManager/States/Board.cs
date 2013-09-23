using System.Collections.Generic;
using DeckManager.Boards;
using DeckManager.Boards.Enums;

namespace DeckManager.States
{
    public class Board
    {
        public BoardName Name
        {
            get { return Locations.Count > 0 ? Locations[0].BoardName : default(BoardName); }
        }

        public List<BasicLocation> Locations { get; set; }
    }
}
