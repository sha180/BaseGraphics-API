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
        public void Execute(Cast forground, Cast midground, Cast background, Script script, ActionCallback callback = null)
        {
            
            // foreach (Actor item in background.GetAllAc)
            // {
                Actor player = midground.GetFirstActor("player");
                if ( player != null)
                {

                
                Actor item = background.GetFirstActor("background");
                
                    AttributeBody body = (AttributeBody) item.GetActorAttribute(AttributeKey.body);
                    Point position = body.GetPosition();
                    Point size = body.GetSize();

                    Point offset = new Point(PROGRAM_SETTINGS.SCREEN_WIDTH/2, PROGRAM_SETTINGS.SCREEN_HEIGHT/2 );

                        AttributeBody PlayerBody = (AttributeBody) player.GetActorAttribute(AttributeKey.body);
                        Point PlayerPosition = PlayerBody.GetPosition();
                        
                        // PlayerPosition.Scale(0);

                        Point PlayerSize = PlayerBody.GetSize();
         
                    videoService.SetCameraTracking(true);
                    videoService.UpdateCameraPosition(PlayerPosition, size, offset);
                
                }
                else
                {
                    videoService.SetCameraTracking(false);
                }
        }

        
        private  Types.Point GetWorldToScreen2D(Types.Rectangle body, Types.Point PosOffset)
        {
            Types.Point possition = body.GetPosition();
            int x = possition.GetX() + (PROGRAM_SETTINGS.SCREEN_WIDTH/2 - PosOffset.GetX());
            int y = possition.GetY() + (PROGRAM_SETTINGS.SCREEN_HEIGHT)/2 - PosOffset.GetY();

            // Types.Point size = rectangle.GetSize();
            // int width = size.GetX();
            // int height = size.GetY();

            return new Point (x, y);
        }
    }
}