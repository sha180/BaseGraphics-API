using LocalLib.Types;


namespace LocalLib.Casting
{
    /// <summary>
    /// A thing that participates in the game.
    /// </summary>
    public class AttributeEntity : Attribute
    {
        
        private string attributeKey = AttributeKey.entity;

        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public AttributeEntity()
        {

        }
        public string GetAttributeKey()
        {
            return attributeKey;
        }
    }
}