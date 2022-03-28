using LocalLib.Types;
using System.Collections.Generic;


namespace LocalLib.Casting
{
    /// <summary>
    /// A thing that participates in the game.
    /// </summary>
    public class AttributeHealth : Attribute
    {
        
        private string attributeKey = AttributeKey.health;
        
        private int health;

        // private Point position;
        // private Point size;
        // private Point velocity;

        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public AttributeHealth(int health)
        {
            this.health = health;
        }

        public string GetAttributeKey()
        {
            return attributeKey;
        }

    }
}