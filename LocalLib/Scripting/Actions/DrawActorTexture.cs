using LocalLib.Casting;
using LocalLib.Services;

namespace LocalLib.Scripting.Actions
{
    /// <summary>
    /// A thing that is done in the game.
    /// </summary>
    public class DrawActorTexture : Action
    {
        
        private VideoService videoService;
        
        public DrawActorTexture(VideoService videoService)
        {
            this.videoService = videoService;
        }

        /// <summary>
        /// Executes something that is important in the game. This method should be overriden by 
        /// derived classes.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        /// <param name="script">The script of actions.</param>
        public void Execute(Cast cast, Script script)
        {
            foreach (Actor item in cast.GetAllActors())
            {
                if (item.HasAttribute(AttributeKey.body))
                {
                    // AttributeTexture texture = (AttributeTexture)item.GetActorAttribute(AttributeKey.texture);
                    AttributeBody body = (AttributeBody) item.GetActorAttribute(AttributeKey.body);
                    videoService.DrawRectangle(body.GetSize(), body.GetPosition(), ((AttributeColor)item.GetActorAttribute(AttributeKey.color)).GetColor(), true);
                }
            }
        }
    }
}