
using LocalLib.Casting;
using LocalLib.Services;
using LocalLib.Types;
using System.Collections.Generic;


namespace LocalLib.Scripting.Actions
{
    /// <summary>
    /// A thing that is done in the game.
    /// </summary>
    public class MouseObjectAction : Action
    {
        private MouseService mouseService;
        public MouseObjectAction(MouseService mouseService )
        {
            this.mouseService = mouseService;
        }

        /// <summary>
        /// Executes something that is important in the game. This method should be overriden by 
        /// derived classes.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        /// <param name="script">The script of actions.</param>
            // bool mouseOverObject = false;

        public Dictionary<string, bool>  mouseOverObject = new Dictionary<string, bool>();
        public void Execute(Cast forground, Cast midground, Cast background, Script script, ActionCallback callback = null)
        {
                    // AttributeBody PlayerBody = (AttributeBody) midground.GetFirstActor("player").GetActorAttribute(AttributeKey.body);
                    // Point PlayerPosition = PlayerBody.GetPosition();
                    // Point PlayerSize = PlayerBody.GetSize();
            
                    // if(mouseService.IsMouseOverBox(body.GetRectangle(), PlayerPosition) && item.HasAttribute(AttributeKey.color))
                    // {
                    //     // System.Console.WriteLine("mouse over box");
                    //     AttributeColor color = (AttributeColor) item.GetActorAttribute(AttributeKey.color);
                    //     // color.SetColor(new Color(200,200,0));
                    // }
        
            foreach (Actor item in midground.GetAllActors())
            {

                if (item.HasAttribute(AttributeKey.clickable))
                {
                    if(!mouseOverObject.ContainsKey(item.ActorKey))
                    {
                        mouseOverObject.Add(item.ActorKey, false);
                    }
                    AttributeBody body = (AttributeBody) item.GetActorAttribute(AttributeKey.body);
                    Point position = body.GetPosition();
                    Point size = body.GetSize();
                        
                    // AttributeBody PlayerBody = (AttributeBody) midground.GetFirstActor("player").GetActorAttribute(AttributeKey.body);
                    // Point PlayerPosition = PlayerBody.GetPosition();
                    // Point PlayerSize = PlayerBody.GetSize();
                        
                        // System.Console.WriteLine(mouseService.IsMouseOverBox(body.GetRectangle(), new Point(0,0)));
                    bool mouseOver = mouseOverObject[item.ActorKey];
                    AttributeClickable clickable = (AttributeClickable) item.GetActorAttribute(AttributeKey.clickable);
                        // AttributeAnimated animated = (AttributeAnimated) item.GetActorAttribute(AttributeKey.animated);

                    if(mouseService.IsMouseOverButton(body.GetRectangle()) && item.HasAttribute(AttributeKey.color))
                    {
                        // AttributeColor color = (AttributeColor) item.GetActorAttribute(AttributeKey.color);
                        // Types.Color tmpColor = color.GetColor();
                        
                        // color.SetColor(new Color(200,200,0));
                        if(mouseService.IsButtonPressed("left")){
                            // animated.currentFrame = 2;
                            clickable.clickState = true;
                            clickable.toggalSwitch();
                        System.Console.WriteLine($"mswitch = {clickable.getSwitch()}");
                            // if(clickable.getSwitch())
                            // {
                            if (item.HasAttribute(AttributeKey.health))
                            {
                                AttributeHealth health = 
                                    (AttributeHealth) item.GetActorAttribute(AttributeKey.health);
                                    health.damage();
                                    if(health.getHealth() < 1)
                                    {
                        System.Console.WriteLine($"mouse over box key = {item.ActorKey}");

                                        midground.RemoveActor("tree", item);
                                    }
                            }
                                // menucallback.OnNext(forground, midground.GetFirstActor("player"));
                            // }else if(clickable.getPREVEUS_State())
                            // {
                                
                            //     // menucallback.removeOnNext(forground);
                            // }
                            

                            
                        }
                        else {
                            // animated.currentFrame = 1;
                            // clickable.clickState = false;
                        }


                        // animated.TextureBounds.position.x = (animated.TextureBounds.size.x*animated.currentFrame);
                        mouseOverObject[item.ActorKey] = true;
                        
                    }else if (!mouseService.IsMouseOverButton(body.GetRectangle()) && mouseOver)
                    {
                        // animated.currentFrame = 0;

                        // animated.TextureBounds.position.x = (animated.TextureBounds.size.x*animated.currentFrame);
                        mouseOverObject[item.ActorKey] = false;
                            // clickable.clickState = false;

                    }
                }

            }
        }
    }
}