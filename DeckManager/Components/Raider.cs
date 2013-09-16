using DeckManager.Components.Enums;

namespace DeckManager.Components
{
    public class Raider : BaseComponent
    {
        /// <summary>
        /// Gets the type of the component.
        /// </summary>
        /// <value>
        /// The type of the component.
        /// </value>
        public override ComponentType ComponentType
        {
            get { return ComponentType.Raider; }
        }
        public override string ToString()
        {
            return "Raider";
        }
    }
}
