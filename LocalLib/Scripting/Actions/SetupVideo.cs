using LocalLib.Casting;
using LocalLib.Services;
using System.Collections.Generic;


namespace LocalLib.Scripting.Actions
{
    /// <summary>
    /// A thing that is done in the game.
    /// </summary>
    public class SetupVideo 
    {
        
        private VideoService videoService;
        List<LocalLib.Types.Texture> TexturesList;
        public SetupVideo(VideoService videoService, List<LocalLib.Types.Texture> TexturesList)
        {
            this.videoService = videoService;
            this.TexturesList = TexturesList;
        }

        /// <summary>
        /// Executes something that is important in the game. This method should be overriden by 
        /// derived classes.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        /// <param name="script">The script of actions.</param>
        public void Execute()
        {
            
            videoService.Initialize();
            videoService.loadTextures(TexturesList);
        }
    }
}