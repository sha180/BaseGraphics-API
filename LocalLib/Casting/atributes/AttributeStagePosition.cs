using LocalLib.Types;


namespace LocalLib.Casting
{
    /// <summary>
    /// A thing that participates in the game.
    /// </summary>
    public struct AttributeStagePosition : Attribute
    {
        
        public int positon;
        public int prioratry;

        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public AttributeStagePosition(int positon, int prioratry = 1)
        {
            this.positon = positon;
            this.prioratry = prioratry;
        }
        public string GetAttributeKey()
        {
            return  AttributeKey.Stage_Position;
        }
        
        /// <summary>
        /// Gets the color.
        /// </summary>
        /// <returns>The color.</returns>
        // public int GetStagePositon()
        // {
        //     return positon;
        // }


        /// <summary>
        /// Sets the stage position to the given value.
        /// </summary>
        /// <param name="positon">The given stage positon.</param>
        // public void SetStagePositon(int positon)
        // {
        //     this.positon = positon;
        // }
        
        /// <summary>
        /// Gets the prioratry.
        /// </summary>
        /// <returns>The prioratry.</returns>
        // public int GetPrioratry()
        // {
        //     return prioratry;
        // }


        /// <summary>
        /// Sets the prioratry to the given value.
        /// </summary>
        /// <param name="prioratry">The given prioratry.</param>
        // public void SetPrioratry(int prioratry)
        // {
        //     this.prioratry = prioratry;
        // }
    }
}