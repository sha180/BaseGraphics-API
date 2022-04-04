using LocalLib.Casting;
using LocalLib.Services;
using LocalLib.Types;
using System;

namespace LocalLib.Scripting
{
    public class EnemyColideAction : Action
    {
        private AudioService audioService;
        private PhysicsService physicsService;
        private VideoService videoService;
        private RaylibKeyboardService KeyboardServices = new RaylibKeyboardService();
        
private int framesCounter = 0;
    int currentFrame = 0;
    int framesSpeed = 4;
    bool wait = false;
    int pireod = PROGRAM_SETTINGS.FRAME_RATE * 300;
        public EnemyColideAction(PhysicsService physicsService, AudioService audioService, VideoService videoService)
        {
            this.physicsService = physicsService;
            this.audioService = audioService;
            this.videoService = videoService;
        }

        public void Execute(Cast forground, Cast midground, Cast background, Script script, ActionCallback callback = null)
        {
                     framesCounter++;
            //  if (!wait && framesCounter >= pireod)
            //  {
            //     wait = true;
            //  }  else     
                if ( framesCounter >= (PROGRAM_SETTINGS.FRAME_RATE /2))
            {
                framesCounter = 0;

                foreach (Actor item in midground.GetActors("enemy"))
                {
                    AttributeBody itemBody = (AttributeBody)item.GetActorAttribute(AttributeKey.body);
                    
                    foreach (Actor wall in midground.GetActors("wall"))
                    {

                        AttributeBody wallBody = (AttributeBody)wall.GetActorAttribute(AttributeKey.body);
                        if (physicsService.HasCollided(itemBody, wallBody))
                        {

                                Console.WriteLine($"enamy collided wall {midground.GetAllActors().IndexOf(item)}");
                        }

                    }
                    
                    foreach (Actor spike in midground.GetActors("spike"))
                    {
                    
                        AttributeBody spikesBody = (AttributeBody)spike.GetActorAttribute(AttributeKey.body);

                        if (physicsService.HasCollided(itemBody, spikesBody))
                        {
                            if(item.HasAttribute(AttributeKey.health))
                            {
                                AttributeHealth health = (AttributeHealth) item.GetActorAttribute(AttributeKey.health);
                                AttributeHealth spikehealth = (AttributeHealth) spike.GetActorAttribute(AttributeKey.health);

                                    // animated.currentFrame++;

                                health.damage();
                                
                                spikehealth.damage();

                                
                                System.Console.WriteLine("spike healt == " + spikehealth.getHealth() );

                                System.Console.WriteLine("healt == " + health.getHealth() );
                                

                                if (health.getHealth() < 1)
                                midground.RemoveActor("enemy", item);
                                
                                if(spikehealth.getHealth() < 1)
                                midground.RemoveActor("spike", spike);
                                

                            }
                        else
                            {
                                midground.RemoveActor("enemy", item);
                            }

                                // Console.WriteLine($"enamy collided spike {midground.GetAllActors().IndexOf(item)}");
                        }
                    }
                    if(midground.GetFirstActor("airship") != null)
                    {
                      

                        AttributeBody airshipBody = (AttributeBody) midground.GetFirstActor("airship").GetActorAttribute(AttributeKey.body);
                        
                        AttributeBody body = new AttributeBody(airshipBody.GetPosition(), airshipBody.GetSize().Scale(2f));

                        AttributeHealth airshiphealth = (AttributeHealth) midground.GetFirstActor("airship").GetActorAttribute(AttributeKey.health);
                        
                        if (physicsService.HasCollided(itemBody, body))
                        {
                            airshiphealth.damage();
                        }
                        if(airshiphealth.getHealth() < 1)
                        {
                            midground.clearGroup("airship");
                        }  
                    }
                }   
            }
            
        }
    }
}