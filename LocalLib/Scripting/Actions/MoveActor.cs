using LocalLib.Casting;
using LocalLib.Services;
using LocalLib.Types;

namespace LocalLib.Scripting.Actions
{
    /// <summary>
    /// A thing that is done in the game.
    /// </summary>
    public class MoveActor : Action
    {
        VideoService videoService;
        public MoveActor(VideoService videoService)
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
                    AttributeBody body = (AttributeBody) item.GetActorAttribute(AttributeKey.body);
                    Point position = body.GetPosition();
                    
                    // System.Console.WriteLine($"speed = {(body.GetSpeed() )}");
                    System.Numerics.Vector2 velocity =  body.GetVelocity().VectorScale( (body.GetSpeed() * videoService.GetDeltaTime()));
                    // int posx = position.GetX();

                    position = position.Add(VectorToPoint(velocity));

                    // if (posx < 0)
                    // {
                    //     position = new Point(0, position.GetY());
                    // }
                    // else if (posx > PROGRAM_SETTINGS.SCREEN_WIDTH -  body.GetSize().GetX())
                    // {
                    //     position = new Point(PROGRAM_SETTINGS.SCREEN_WIDTH -  body.GetSize().GetX(), 
                    //         position.GetY());
                    // }

                    body.SetPosition(position);   
                }
            }
        }

        private Point VectorToPoint(System.Numerics.Vector2 Vector2)
        {
            return new Point((int) Vector2.X, (int) Vector2.Y);
        }
    }
}
