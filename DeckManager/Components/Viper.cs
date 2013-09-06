using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeckManager.States.Enums;

namespace DeckManager.States
{
    public class Viper
    {
        public ViperStatus Status { get; set; }
        public bool IsMarkVII { get; private set; }
        public Player Pilot { get; set; }   // need to represent characters in vipers

        public override string ToString()
        {
            return "Viper" + (IsMarkVII ? " MkVII" : "") + (Pilot == null ? "" : " (" + Pilot.PlayerName + ")");
        }
    }
}
