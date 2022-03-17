using LocalLib.Types;


namespace LocalLib.Casting
{
    /// <summary>
    /// A thing that participates in the game.
    /// </summary>
    public class AttributeStagePosition : Attribute
    {
        
        private string attributeKey = AttributeKey.Stage_Position;

        
        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public AttributeStagePosition()
        {

        }
        public string GetAttributeKey()
        {
            return attributeKey;
        }
    }
}