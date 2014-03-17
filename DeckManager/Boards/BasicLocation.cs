using System.Text;
using DeckManager.Boards.Enums;

namespace DeckManager.Boards
{
    public class BasicLocation : BaseNode
    {
        /// <summary>
        /// Gets or sets the location information, such as activation effects.
        /// </summary>
        /// <value>
        /// The location information.
        /// </value>
        public string LocationInfo { get; set; }

        /// <summary>
        /// Gets or sets the name of the board the location is on.
        /// </summary>
        /// <value>
        /// The name of the board.
        /// </value>
        public BoardName BoardName { get; set; }

        public override string ToString()
        {
            var ret = Name;
            if (PlayersPresent.Count > 0)
            {
                var players = new StringBuilder();
                foreach (var player in PlayersPresent)
                {
                    players.Append(player);
                    players.Append(',');
                    players.Append(' ');
                }
                ret = string.Format("{0} - {1}", Name, players.ToString().Trim(',',' '));
            }
            return ret;
        }
    }
}
