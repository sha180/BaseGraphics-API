

using LocalLib.Casting;
using LocalLib.Services;
using LocalLib.Types;
using System;


namespace LocalLib.Scripting.Actions
{
    public class enemybehavior: Action
    {
        public enemybehavior()
        {}
        public void Execute(Cast forground, Cast midground, Cast background, Script script, ActionCallback callback = null)
        {
            
            foreach (Actor item in midground.GetAllActors())
            {
                string array = "";
                foreach (char CHAR in item.ActorKey)
                {
                    
                    if( CHAR == ' ')
                    {
                        break;
                    }
                    else
                    {
                        array += CHAR;
                    }
                }
                
                
                if (array ==  "enemy" && item.HasAttribute(AttributeKey.body))
                {


                    // System.Console.WriteLine("enemyMove");
                    AttributeBody body = (AttributeBody) item.GetActorAttribute(AttributeKey.body);
                    Point position = body.GetPosition();
                    Point velocity = body.GetVelocity();
                    
                    Point Airship = new Point((((PROGRAM_SETTINGS.calloms-1)/2)*PROGRAM_SETTINGS.CELL_SIZE)+128,(((PROGRAM_SETTINGS.rows-1)/2)*PROGRAM_SETTINGS.CELL_SIZE)+128);
                    
        
                    int xspeed = (int) System.Math.Round((float) (Airship.GetX() - position.GetX()) /PROGRAM_SETTINGS.CELL_SIZE);
                    int yspeed = (int) System.Math.Round((float) (Airship.GetY() - position.GetY()) /PROGRAM_SETTINGS.CELL_SIZE);
                    

                    // int slope = yspeed/(xspeed == 0 ? 1 : xspeed);
                    // int slope2 = xspeed/yspeed;
                    // System.Console.WriteLine("slope = " + yspeed);

                    // body.SetVelocity(new Point(xspeed,yspeed));
                    body.SetVelocity(new Point(xspeed, yspeed));
                    body.SetSpeed(5.0f);




                }
                
            }
        }
    }
}