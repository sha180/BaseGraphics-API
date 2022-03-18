using LocalLib.Casting;
using LocalLib.Services;
using System;

namespace LocalLib.Scripting
{
    public class CollideActorsAction : Action
    {
        private AudioService audioService;
        private PhysicsService physicsService;
        
        public CollideActorsAction(PhysicsService physicsService, AudioService audioService)
        {
            this.physicsService = physicsService;
            this.audioService = audioService;
        }

        public void Execute(Cast cast, Script script)
        {
            // Ball ball = (Ball)cast.GetFirstActor(Constants.BALL_GROUP);
            // Racket racket = (Racket)cast.GetFirstActor(Constants.RACKET_GROUP);
            // Body ballBody = ball.GetBody();
            // Body racketBody = racket.GetBody();

            foreach (Actor item in cast.GetAllActors())
            {
                

                // System.Console.WriteLine($"player colided with  {cast.GetAllActors().IndexOf(item)}");
                if (physicsService.HasCollided((AttributeBody) cast.GetFirstActor("player").GetActorAttribute(AttributeKey.body), (AttributeBody) item.GetActorAttribute(AttributeKey.body)) && cast.GetFirstActor("player") != item )
                {
                    // cast.GetDictionary().
                    Console.WriteLine($"player colided {cast.GetAllActors().IndexOf(item)}");

                    // ball.BounceY();
                    // Sound sound = new Sound(Constants.BOUNCE_SOUND);
                    // audioService.PlaySound(sound);
                }
                // Racket player = (Racket)cast.GetFirstActor(Constants.PLAYER_GROUP);
                // Body playerBody = player.GetBody();

                // if (physicsService.HasCollided(playerBody, ballBody))
                // {
                    
                //     ball.BounceY();
                //     Sound sound = new Sound(Constants.BOUNCE_SOUND);
                //     audioService.PlaySound(sound);
                // }
            }
        }
    }
}