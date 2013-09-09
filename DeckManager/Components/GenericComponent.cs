using DeckManager.Components.Enums;

namespace DeckManager.Components
{
    /// <summary>
    /// A generic component for when we don't actually care what type it is.
    /// </summary>
    public class GenericComponent : BaseComponent
    {
        /// <summary>
        /// Gets the type of the component.
        /// </summary>
        /// <value>
        /// The type of the component.
        /// </value>
        public override ComponentType ComponentType
        {
            get { return ComponentType.Unknown; }
        }
    }
}
