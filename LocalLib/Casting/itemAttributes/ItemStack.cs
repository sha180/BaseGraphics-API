using LocalLib.Types;
using LocalLib.Directing;


namespace  LocalLib.Casting
{
    /// <summary>
    /// A thing that participates in the game.
    /// </summary>
    public class ItemStack : Attribute
    {
        
        private string attributeKey = ItemAttributeKey.Stack;
        public int StackSize;

        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public ItemStack(int StackSize = 0)
        {
            this.StackSize = StackSize;
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