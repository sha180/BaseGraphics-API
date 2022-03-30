using LocalLib.Casting;
using LocalLib.Services;
using LocalLib.Types;

namespace LocalLib.Scripting.Actions
{
    /// <summary>
    /// A thing that is done in the game.
    /// </summary>
    public class ControlActorAction : Action
    {
        
        private VideoService videoService;
        private KeyboardService keyboardService;
private int framesCounter = 0;
    int currentFrame = 0;
    int framesSpeed = 4;
        public ControlActorAction(KeyboardService keyboardService, VideoService videoService)
        {
            this.videoService = videoService;
            this.keyboardService = keyboardService;
        }

        /// <summary>
        /// Executes something that is important in the game. This method should be overriden by 
        /// derived classes.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        /// <param name="script">The script of actions.</param>
        public void Execute(Cast forground, Cast midground, Cast background, Script script, ActionCallback callback = null)
        {
                     framesCounter++;
            foreach (Actor item in midground.GetAllActors())
            {
                    if (item.HasAttribute(AttributeKey.animated))
                    {
                        AttributeAnimated animated = (AttributeAnimated) item.GetActorAttribute(AttributeKey.animated);
                       
                        if (framesCounter >= (PROGRAM_SETTINGS.FRAME_RATE/framesSpeed))
                        {
                            framesCounter = 0;
                            animated.currentFrame++;

                            if (animated.currentFrame > animated.frames - 1) animated.currentFrame = 0;

                            animated.TextureBounds.position.x = animated.currentFrame*animated.TextureBounds.size.x;
                        // System.Console.WriteLine("animated == " + animated.TextureBounds.position.x );
                        }
                    }

                if (item.HasAttribute(AttributeKey.body) && midground.GetFirstActor("player") == item)
                {
                    AttributeBody body = (AttributeBody) item.GetActorAttribute(AttributeKey.body);
                    Point position = body.GetPosition();
                    Point velocity = new Point(0,0);

            // System.Console.WriteLine("up");
                    if (keyboardService.IsKeyDown(PROGRAM_SETTINGS.LEFT))
                    {
                        velocity = velocity.Add(new Point(-1, 0));
            body.SetSpeed(200.0f);
                    }
                     if (keyboardService.IsKeyDown(PROGRAM_SETTINGS.RIGHT))
                    {
                        velocity = velocity.Add(new Point(1, 0));
            body.SetSpeed(200.0f);
                    }
                     if (keyboardService.IsKeyDown(PROGRAM_SETTINGS.UP))
                    {
                        velocity = velocity.Add(new Point(0, -1));
            body.SetSpeed(200.0f);
                    }
                     if (keyboardService.IsKeyDown(PROGRAM_SETTINGS.DOWN))
                    {
                        velocity = velocity.Add(new Point(0, 1));
            body.SetSpeed(200.0f);
                    }

                    body.SetVelocity(velocity);
                }
            }
        }
    }
}