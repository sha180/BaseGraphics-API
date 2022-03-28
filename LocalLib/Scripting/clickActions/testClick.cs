using LocalLib.Casting;
using LocalLib.Services;

namespace LocalLib.Scripting.Actions
{
    /// <summary>
    /// A thing that is done in the game.
    /// </summary>
    public class TestClick : Action
    {
        public TestClick()
        {
        }

        /// <summary>
        /// Executes something that is important in the game. This method should be overriden by 
        /// derived classes.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        /// <param name="script">The script of actions.</param>
        public void Execute(Cast forground = null, Cast midground = null, Cast background = null, Script script = null, ActionCallback callback = null)
        {
            // videoService.ClearBuffer(true);
        }
    }
}