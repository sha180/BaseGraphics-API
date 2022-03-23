
using LocalLib.Casting;
using LocalLib.Services;
using LocalLib.Types;

namespace LocalLib.Scripting.Actions
{
    /// <summary>
    /// A thing that is done in the game.
    /// </summary>
    public class MouseInteracAction : Action
    {
        private MouseService mouseService;
        public MouseInteracAction(MouseService mouseService )
        {
            this.mouseService = mouseService;
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
                    Point size = body.GetSize();

                        // System.Console.WriteLine(item.HasAttribute(AttributeKey.color));

                    if(mouseService.IsMouseOverBox(body.GetRectangle()) && item.HasAttribute(AttributeKey.color))
                    {
                        // System.Console.WriteLine("mouse over box");
                        AttributeColor color = (AttributeColor) item.GetActorAttribute(AttributeKey.color);
                        color.SetColor(new Color(200,200,0));
                    }
                }
            }
        }
    }
}