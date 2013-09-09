using DeckManager.Components.Enums;
using DeckManager.States.Enums;

namespace DeckManager.Components
{
    public class Viper : BaseComponent
    {
        public ViperStatus Status { get; set; }

        public override ComponentType ComponentType
        {
            get { return ComponentType.Viper; }
        }
    }
}
