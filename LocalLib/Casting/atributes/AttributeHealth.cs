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
        private int MaxHealth;


        // private Point position;
        // private Point size;
        // private Point velocity;

        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public AttributeHealth(int health)
        {
            this.health = health;
            this.MaxHealth = health;
        }

        public string GetAttributeKey()
        {
            return attributeKey;
        }
        public int getHealth()
        {
            return health;
        }
        public int getMaxHealth()
        {
            return MaxHealth;
        }
        public void damage()
        {
            health -= 1;
        }

    }
}