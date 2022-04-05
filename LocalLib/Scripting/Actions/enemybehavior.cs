

using LocalLib.Casting;
using LocalLib.Services;
using LocalLib.Types;
using System;


namespace LocalLib.Scripting.Actions
{
    public class enemybehavior: Action
    {
        
        bool one = true;
private int framesCounter = 0;
    private int currentFrame = 0;
    private int framesSpeed = 4;
    private bool wait = false;
    private int pireod = PROGRAM_SETTINGS.FRAME_RATE * 100 ;
        public enemybehavior()
        {}
        public void Execute(Cast forground, Cast midground, Cast background, Script script, ActionCallback callback = null)
        {

            if(midground.GetFirstActor("airship") != null)
            {

            
                    AttributeBody airship = ((AttributeBody) midground.GetFirstActor("airship").GetActorAttribute(AttributeKey.body));
                    Point Airship = airship.GetPosition().Add(airship.GetSize().Scale(.25f));
                    
        Random random = new Random();

        framesCounter++;

             if (!wait && framesCounter >= pireod)
             {
                wait = true;
             }  else     
                if (wait && framesCounter >= (PROGRAM_SETTINGS.FRAME_RATE))
            {
                framesCounter = 0;

            foreach (Actor item in midground.GetActors("enemy"))
            {
                // string array = "";
                // foreach (char CHAR in item.ActorKey)
                // {
                    
                //     if( CHAR == ' ')
                //     {
                //         break;
                //     }
                //     else
                //     {
                //         array += CHAR;
                //     }
                // }
                
                
                if (item.HasAttribute(AttributeKey.body) && one)
                {


                    // System.Console.WriteLine("enemyMove");
                    AttributeBody body = (AttributeBody) item.GetActorAttribute(AttributeKey.body);
                    Point position = body.GetPosition();
                    Point velocity = body.GetVelocity();
                    int xspeed = (int) ((float) ((Airship.GetX()/PROGRAM_SETTINGS.CELL_SIZE) - (position.GetX()/PROGRAM_SETTINGS.CELL_SIZE))) * random.Next(-5, 10);
                    int yspeed = (int) ((float) ((Airship.GetY()/PROGRAM_SETTINGS.CELL_SIZE) - (position.GetY()/PROGRAM_SETTINGS.CELL_SIZE))) * random.Next(-5, 10);
                    

                    // int slope = yspeed/(xspeed == 0 ? 1 : xspeed);
                    // int slope2 = xspeed/yspeed;
                    // System.Console.WriteLine("xspeed = " + xspeed);
                    // System.Console.WriteLine("yspeed = " + yspeed);

                    // body.SetVelocity(new Point(xspeed,yspeed));
                    body.SetVelocity(new Point(xspeed, yspeed));
                        body.SetSpeed(1.0f);

                    // if(xspeed < 10 && yspeed < 10)
                    // {
                    //     body.SetSpeed(3.0f);
                    // }else
                    // {
                    //     body.SetSpeed(1.0f);

                    // }



                }
            }
            }
            }else
            {
                foreach (Actor item in midground.GetActors("enemy"))
                {
                    if (item.HasAttribute(AttributeKey.body) && one)
                    {
                        // System.Console.WriteLine("enemyMove");
                        AttributeBody body = (AttributeBody) item.GetActorAttribute(AttributeKey.body);
                        body.SetVelocity(new Point(0, 0));
                    }
                }
            }
            
        }
    }
}