using LocalLib.Types;
using LocalLib.Directing;


namespace  LocalLib.Casting
{
    /// <summary>
    /// A thing that participates in the game.
    /// </summary>
    public class AttributeTexture : Attribute
    {
        
        private string attributeKey = AttributeKey.texture;

        private string textureKey;

        // private Image image;

        public Rectangle TextureBounds;
        private TextureType textureType;

        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public AttributeTexture(string textureKey, Point size = null)
        {
            TextureBounds = new Rectangle(new Point(0, 0), size == null ? new Point(0, 0) : size);
            this.textureKey = textureKey;
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