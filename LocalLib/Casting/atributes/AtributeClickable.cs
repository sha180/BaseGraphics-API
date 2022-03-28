using LocalLib.Types;


namespace LocalLib.Casting
{
    /// <summary>
    /// A thing that participates in the game.
    /// </summary>
    public class AttributeClickable : Attribute
    {
        
        private string attributeKey = AttributeKey.clickable;

        // private Point position;
        // private Point size;
        // private Point velocity;
        public bool clickState;
        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public AttributeClickable()
        {
            clickState = false;
        }

        public string GetAttributeKey()
        {
            return attributeKey;
        }
    }
}