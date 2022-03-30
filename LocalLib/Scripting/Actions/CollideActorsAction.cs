using LocalLib.Casting;
using LocalLib.Services;
using LocalLib.Types;
using System;

namespace LocalLib.Scripting
{
    public class CollideActorsAction : Action
    {
        private AudioService audioService;
        private PhysicsService physicsService;
        private VideoService videoService;
        private RaylibKeyboardService KeyboardServices = new RaylibKeyboardService();
        
        public CollideActorsAction(PhysicsService physicsService, AudioService audioService, VideoService videoService)
        {
            this.physicsService = physicsService;
            this.audioService = audioService;
            this.videoService = videoService;
        }

        public void Execute(Cast forground, Cast midground, Cast background, Script script, ActionCallback callback = null)
        {
            Actor player = midground.GetFirstActor("player");
            AttributeBody playBody = (AttributeBody)player.GetActorAttribute(AttributeKey.body);
            Point playerPos = playBody.GetPosition();
            int playerY = playerPos.GetY();
            int playerX = playerPos.GetX();

            foreach (Actor item in midground.GetAllActors())
            {
                AttributeBody itemBody = (AttributeBody) item.GetActorAttribute(AttributeKey.body);
                Point itemPos = itemBody.GetPosition();
                int itemX = itemPos.GetX();
                int itemY = itemPos.GetY();

                if (physicsService.HasCollided(playBody, itemBody))

                // PLAN B
                // if
                // (
                // itemX <= playerX &&
                // itemX + itemBody.GetSize().GetX() >=  playerX &&
                // itemY >= playerY &&
                // itemY < playerY + playBody.GetSpeed() * videoService.GetDeltaTime())
                
                {
                    if (item != player)
                    {
                        if (KeyboardServices.IsKeyDown("left"))
                        {
                            playBody.SetVelocity(new Point(10,0));
                            // playBody.SetSpeed(0.0f);
                        }
                        if (KeyboardServices.IsKeyDown("right"))
                        {
                            playBody.SetVelocity(new Point(-10,0));
                        }
                        if (KeyboardServices.IsKeyDown("down"))
                        {
                            playBody.SetVelocity(new Point(0,-10));
                        }
                        if (KeyboardServices.IsKeyDown("up"))
                        {
                            playBody.SetVelocity(new Point(0,10));
                        }
                        // playBody.SetSpeed(100.0f);
                        // playBody.SetPosition(new Point(playerX, itemY));
                        Console.WriteLine($"player collided {midground.GetAllActors().IndexOf(item)}");
                    }
                }
            }
        }
    }
}