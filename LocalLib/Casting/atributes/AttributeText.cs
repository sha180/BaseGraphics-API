using LocalLib.Types;
using LocalLib.Directing;


namespace  LocalLib.Casting
{
    /// <summary>
    /// A thing that participates in the game.
    /// </summary>
    public class AttributeText : Attribute
    {
        
        private string attributeKey = AttributeKey.text;

        private string textureKey;

        // private Image image;

        public Rectangle TextureBounds;
        public string text;

        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public AttributeText()
        {
            TextureBounds = new Rectangle(new Point(0, 0), new Point(0, 0));
        }

        public string GetAttributeKey()
        {
            return attributeKey;
        }

        /// <summary>
        /// Gets the key to represint the data.
        /// </summary>
        /// <returns>The color.</returns>
        public string GetTextureKey()
        {
            return textureKey;
        }


        /// <summary>
        /// Sets the color to the given value.
        /// </summary>
        /// <param name="color">The given color.</param>
        // public void SetColor(Color color)
        // {
        //     this.color = color;
        // }
    }
}