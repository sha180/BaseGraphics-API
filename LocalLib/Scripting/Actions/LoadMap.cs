using LocalLib.Casting;
using LocalLib.Services;
using ldtk;


namespace LocalLib.Scripting.Actions
{
    /// <summary>
    /// A thing that is done in the game.
    /// </summary>
    public class LoadMap : Action
    {
        
        private VideoService videoService;
        
        public LoadMap(VideoService videoService)
        {
            this.videoService = videoService;
        }

        /// <summary>
        /// Executes something that is important in the game. This method should be overriden by 
        /// derived classes.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        /// <param name="script">The script of actions.</param>
        public void Execute(Cast forground, Cast midground, Cast background, Script script, ActionCallback callback = null)
        {
            var ldtkJson = LdtkJson.FromJson("");
            
        }
    }
}