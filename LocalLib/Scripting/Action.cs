using LocalLib.Casting;


namespace LocalLib.Scripting 
{
    /// <summary>
    /// A thing that is done in the game.
    /// </summary>
    public interface Action
    {
        /// <summary>
        /// Executes something that is important in the game. This method should be overriden by 
        /// derived classes.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        /// <param name="script">The script of actions.</param>
        void Execute(Cast forground, Cast midground, Cast background, Script script, ActionCallback callback = null);
    }
}