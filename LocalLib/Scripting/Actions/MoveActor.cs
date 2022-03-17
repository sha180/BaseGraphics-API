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
        public MoveActor()
        {
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
                if (item.HasAttribute(AttributeKey.body) && item.HasAttribute(AttributeKey.entity))
                {
                    AttributeBody body = (AttributeBody) item.GetActorAttribute(AttributeKey.body);
                    Point position = body.GetPosition();
                    Point velocity = body.GetVelocity();
                    int posx = position.GetX();

                    position = position.Add(velocity);

                    if (posx < 0)
                    {
                        position = new Point(0, position.GetY());
                    }
                    else if (posx > PROGRAM_SETTINGS.SCREEN_WIDTH -  body.GetSize().GetX())
                    {
                        position = new Point(PROGRAM_SETTINGS.SCREEN_WIDTH -  body.GetSize().GetX(), 
                            position.GetY());
                    }

                    body.SetPosition(position);   
                }
            }
        }
    }
}