using LocalLib.Casting;
using LocalLib.Services;
using LocalLib.Types;

namespace LocalLib.Scripting.Actions
{
    /// <summary>
    /// A thing that is done in the game.
    /// </summary>
    public class MoveCameraAction : Action
    {
        private VideoService videoService;
        public MoveCameraAction(VideoService videoService )
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
                if (item.HasAttribute(AttributeKey.body) && item.HasAttribute(AttributeKey.TrackAble))
                {
                    AttributeBody body = (AttributeBody) item.GetActorAttribute(AttributeKey.body);
                    Point position = body.GetPosition();
                    Point size = body.GetSize();

                    videoService.UpdateCameraPosition(position, size);
                }
            }
        }
    }
}