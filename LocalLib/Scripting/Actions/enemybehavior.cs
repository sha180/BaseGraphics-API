using System.Collections.Generic;

using LocalLib.Casting;
using LocalLib.Services;
using LocalLib.Types;
using System;


namespace LocalLib.Scripting.Actions
{
    public class enemybehavior: Action
    {
        bool end = false;
        bool one = true;
private int framesCounter = 0;
    private int currentFrame = 0;
    private int framesSpeed = 4;
    private bool wait = false;
    private int pireod = PROGRAM_SETTINGS.FRAME_RATE * 1 ;
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

            foreach (Actor item in midground.GetActors("enemyn"))
            {
                if (item.HasAttribute(AttributeKey.body) && one)
                {
                    AttributeBody body = (AttributeBody) item.GetActorAttribute(AttributeKey.body);
                    Point position = body.GetPosition();
                    Point velocity = body.GetVelocity();
                    int xspeed = (int) ((float) ((Airship.GetX()/PROGRAM_SETTINGS.CELL_SIZE) - (position.GetX()/PROGRAM_SETTINGS.CELL_SIZE)));
                    int yspeed = (int) ((float) ((Airship.GetY()/PROGRAM_SETTINGS.CELL_SIZE) - (position.GetY()/PROGRAM_SETTINGS.CELL_SIZE)));
                    
                    // System.Console.WriteLine("xspeed = " + xspeed);
                    // System.Console.WriteLine("yspeed = " + yspeed);
                    if( yspeed < 8)
                    {

                    System.Console.WriteLine("n");
                    body.SetVelocity(new Point(xspeed * random.Next(-2, 5), 2 * random.Next(-2, 12)));
                        body.SetSpeed(3.0f);
                    }else
                    {
                    // body.SetVelocity(new Point(xspeed,yspeed));
                    body.SetVelocity(new Point(xspeed * random.Next(-5, 10), yspeed * random.Next(-5, 10)));
                        body.SetSpeed(1.0f);
                    }
                }
            }
            
            foreach (Actor item in midground.GetActors("enemye"))
            {
                if (item.HasAttribute(AttributeKey.body) && one)
                {
                    AttributeBody body = (AttributeBody) item.GetActorAttribute(AttributeKey.body);
                    Point position = body.GetPosition();
                    Point velocity = body.GetVelocity();
                    int xspeed = (int) ((float) ((Airship.GetX()/PROGRAM_SETTINGS.CELL_SIZE) - (position.GetX()/PROGRAM_SETTINGS.CELL_SIZE)));
                    int yspeed = (int) ((float) ((Airship.GetY()/PROGRAM_SETTINGS.CELL_SIZE) - (position.GetY()/PROGRAM_SETTINGS.CELL_SIZE)));
                    
                    // System.Console.WriteLine("xspeed = " + xspeed);
                    // System.Console.WriteLine("yspeed = " + yspeed);
                    if(xspeed > 4 )
                    {

                    System.Console.WriteLine("e");
                    body.SetVelocity(new Point(-2 * random.Next(-2, 5), yspeed * random.Next(-2, 5)));
                        body.SetSpeed(2.0f);
                    }else
                    {
                    // body.SetVelocity(new Point(xspeed,yspeed));
                    body.SetVelocity(new Point(xspeed * random.Next(-5, 10), yspeed * random.Next(-5, 10)));
                        body.SetSpeed(1.0f);
                    }
                }
            }

            
            foreach (Actor item in midground.GetActors("enemys"))
            {
                if (item.HasAttribute(AttributeKey.body) && one)
                {
                    AttributeBody body = (AttributeBody) item.GetActorAttribute(AttributeKey.body);
                    Point position = body.GetPosition();
                    Point velocity = body.GetVelocity();
                    int xspeed = (int) ((float) ((Airship.GetX()/PROGRAM_SETTINGS.CELL_SIZE) - (position.GetX()/PROGRAM_SETTINGS.CELL_SIZE)));
                    int yspeed = (int) ((float) ((Airship.GetY()/PROGRAM_SETTINGS.CELL_SIZE) - (position.GetY()/PROGRAM_SETTINGS.CELL_SIZE)));
                    
                    // System.Console.WriteLine("xspeed = " + xspeed);
                    // System.Console.WriteLine("yspeed = " + yspeed);
                    if( yspeed > 8)
                    {

                    System.Console.WriteLine("s");
                    body.SetVelocity(new Point(xspeed * random.Next(-2, 5), yspeed + -2 * random.Next(-2, 5)));
                        body.SetSpeed(2.0f);
                    }else
                    {
                    // body.SetVelocity(new Point(xspeed,yspeed));
                    body.SetVelocity(new Point(xspeed * random.Next(-5, 10), yspeed * random.Next(-5, 10)));
                        body.SetSpeed(1.0f);
                    }
                }
            }
            
            foreach (Actor item in midground.GetActors("enemyw"))
            {
                if (item.HasAttribute(AttributeKey.body) && one)
                {
                    AttributeBody body = (AttributeBody) item.GetActorAttribute(AttributeKey.body);
                    Point position = body.GetPosition();
                    Point velocity = body.GetVelocity();
                    int xspeed = (int) ((float) ((Airship.GetX()/PROGRAM_SETTINGS.CELL_SIZE) - (position.GetX()/PROGRAM_SETTINGS.CELL_SIZE)));
                    int yspeed = (int) ((float) ((Airship.GetY()/PROGRAM_SETTINGS.CELL_SIZE) - (position.GetY()/PROGRAM_SETTINGS.CELL_SIZE)));
                    
                    // System.Console.WriteLine("xspeed = " + xspeed);
                    // System.Console.WriteLine("yspeed = " + yspeed);
                    if(xspeed < 4)
                    {

                    System.Console.WriteLine("w");
                    body.SetVelocity(new Point(2 * random.Next(-2, 5), yspeed * random.Next(-2, 5)));
                        body.SetSpeed(3.0f);
                    }else
                    {
                    // body.SetVelocity(new Point(xspeed,yspeed));
                    body.SetVelocity(new Point(xspeed * random.Next(-5, 10), yspeed * random.Next(-5, 10)));
                        body.SetSpeed(1.0f);
                    }
                }
            }
            }
            }else if (!end)
            {
                end = true;
                
                List<Actor> actors = new List<Actor>();

                actors.AddRange(midground.GetActors("enemyn"));
                actors.AddRange(midground.GetActors("enemye"));
                actors.AddRange(midground.GetActors("enemys"));
                actors.AddRange(midground.GetActors("enemyw"));

                foreach (Actor item in actors)
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