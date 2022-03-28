namespace LocalLib.Types
{
    /// <summary>
    /// A rectangle.
    /// </summary>
    public class Rectangle
    {
        public Point position;
        public Point size;
        
        /// <summary>
        /// Constructs a new instance of Rectangle.
        /// </summary>
        public Rectangle(Point position, Point size)
        {
            this.position = position;
            this.size = size;
        }

        /// <summary>
        /// Gets the position.
        /// </summary>
        /// <returns>The position.</returns>
        public Point GetPosition()
        {
            return position;
        }

        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <returns>The size.</returns>
        public Point GetSize()
        {
            return size;
        }
    }
}