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

        private Image image;

        public Rectangle TextureBounds;
        private TextureType textureType;

        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public AttributeTexture(Image image)
        {
            this.image = image;
            TextureBounds = new Rectangle(new Point(0, 0), new Point(0, 0));
        }

        public string GetAttributeKey()
        {
            return attributeKey;
        }

        public int GetAttributeDataInt()
        {
            return 0;
        }

        /// <summary>
        /// Gets the key to represint the data.
        /// </summary>
        /// <returns>The color.</returns>
        public string GetAttributeDataString()
        {
            return textureKey;
        }

        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <returns>The image.</returns>
        public Image GetImage()
        {
            return image;
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