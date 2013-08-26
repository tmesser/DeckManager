using System;
using System.Collections.Generic;
using System.Linq;

namespace DeckManager.Components
{
    public class ComponentPile<T> where T : BaseComponent
    {
        /// <summary>
        /// Gets or sets the undeployed components.
        /// </summary>
        /// <value>
        /// The undeployed.
        /// </value>
        public List<T> Undeployed { get; set; }

        /// <summary>
        /// Any deployed components, for easy reshuffling later.
        /// </summary>
        /// <value>
        /// The discarded.
        /// </value>
        public List<T> Deployed { get; set; }

        /// <summary>
        /// Shuffles this pile.
        /// </summary>
        public void Shuffle()
        {
            Undeployed.AddRange(Deployed);
            Deployed.Clear();
            foreach (var component in Undeployed)
            {
                component.InternalDesignation = Guid.NewGuid();
            }
            Undeployed = Undeployed.OrderBy(x => x.InternalDesignation).ToList();
            Undeployed = Undeployed.Distinct().ToList();
        }

        /// <summary>
        /// Draws a component from the pile.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException">Tried to draw from a component pile that was empty.  Component:  + typeof(T)</exception>
        public T Draw()
        {
            if (Undeployed.Count == 0)
                throw new InvalidOperationException("Tried to draw from a component pile that was empty.  Component: " + typeof(T));

            var ret = Undeployed.ElementAt(0);
            Undeployed.RemoveAt(0);
            Deployed.Add(ret);

            return ret;
        }

        /// <summary>
        /// Discards the specified component.
        /// </summary>
        /// <param name="component">The component.</param>
        public void Discard(T component)
        {
            Undeployed.Add(component);
            Deployed.Remove(component);
        }
    }
}
