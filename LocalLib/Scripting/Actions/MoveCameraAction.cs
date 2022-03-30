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
            
            foreach (Actor item in midground.GetAllActors())
            {
                if (item.HasAttribute(AttributeKey.body) && item.HasAttribute(AttributeKey.TrackAble))
                {
                    AttributeBody body = (AttributeBody) item.GetActorAttribute(AttributeKey.body);
                    Point position = body.GetPosition();
                    Point size = body.GetSize();

                    // camera->target = player->position;
                    // camera->offset = (Vector2){ width/2.0f, height/2.0f };
                    // float minX = 1000, minY = 1000, maxX = -1000, maxY = -1000;

                    // for (int i = 0; i < envItemsLength; i++)
                    // {
                    //     EnvItem *ei = envItems + i;
                    //     minX = fminf(ei->rect.x, minX);
                    //     maxX = fmaxf(ei->rect.x + ei->rect.width, maxX);
                    //     minY = fminf(ei->rect.y, minY);
                    //     maxY = fmaxf(ei->rect.y + ei->rect.height, maxY);
                    // }

                    // Vector2 max = GetWorldToScreen2D((Vector2){ maxX, maxY }, *camera);
                    // Vector2 min = GetWorldToScreen2D((Vector2){ minX, minY }, *camera);

                    // if (max.x < width) camera->offset.x = width - (max.x - width/2);
                    // if (max.y < height) camera->offset.y = height - (max.y - height/2);
                    // if (min.x > 0) camera->offset.x = width/2 - min.x;
                    // if (min.y > 0) camera->offset.y = height/2 - min.y;
                    
                    videoService.UpdateCameraPosition(position, size);
                }
            }
        }
    }
}