using LocalLib.Types;
using LocalLib.Directing;


namespace  LocalLib.Casting
{
    /// <summary>
    /// A thing that participates in the game.
    /// </summary>
    public class AttributeAnimated : Attribute
    {
        
        private string attributeKey = AttributeKey.animated;

        public int frames;
        public int currentFrame;


        // private Image image;

        public Rectangle TextureBounds;

        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public AttributeAnimated(Point size, int frames)
        {
            TextureBounds = new Rectangle(new Point(0, 0), size);
            this.frames = frames;
            this.currentFrame = 0;
        }

        public string GetAttributeKey()
        {
            return attributeKey;
        }

        /// <summary>
        /// Gets the key to represint the data.
        /// </summary>
        /// <returns>The color.</returns>

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