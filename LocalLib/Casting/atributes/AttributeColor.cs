using LocalLib.Types;


namespace LocalLib.Casting
{
    /// <summary>
    /// A thing that participates in the game.
    /// </summary>
    public class AttributeColor : Attribute
    {
        
        private string attributeKey = AttributeKey.color;

        private Color color;

        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public AttributeColor(Color color)
        {
            this.color = color;
        }

        public string GetAttributeKey()
        {
            return attributeKey;
        }

        /// <summary>
        /// Gets the color.
        /// </summary>
        /// <returns>The color.</returns>
        public Color GetColor()
        {
            return color;
        }


        /// <summary>
        /// Sets the color to the given value.
        /// </summary>
        /// <param name="color">The given color.</param>
        public void SetColor(Color color)
        {
            this.color = color;
        }
    }
}