using DeckManager.Components.Enums;

namespace DeckManager.Components
{
    public class Basestar : BaseComponent
    {
        /// <summary>
        /// Gets the type of the component.
        /// </summary>
        /// <value>
        /// The type of the component.
        /// </value>
        public override ComponentType ComponentType
        {
            get { return ComponentType.Basestar; }
        }
    }
}
