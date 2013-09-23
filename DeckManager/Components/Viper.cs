using DeckManager.Components.Enums;
using DeckManager.States;

namespace DeckManager.Components
{
    public class Viper : BaseComponent
    {
        public ComponentStatus Status { get; set; }
        public bool IsMarkVII { get; private set; }
        public Player Pilot { get; set; }   // need to represent characters in vipers

        public override string ToString()
        {
            return PublicDesignation + (IsMarkVII ? " MkVII" : "") + (Pilot == null ? "" : " (" + Pilot.PlayerName + ")");
        }
        
        public override ComponentType ComponentType
        {
            get { return ComponentType.Viper; }
        }

    }
}
