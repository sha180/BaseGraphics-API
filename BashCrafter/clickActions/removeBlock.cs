using LocalLib.Casting;
using LocalLib.Services;
using LocalLib.Types;
using System.Collections.Generic;
namespace LocalLib.Scripting.Actions
{
    /// <summary>
    /// A thing that is done in the game.
    /// </summary>
    public class removeBlockAction : Action
    {
        private MouseService mouseService;
        public removeBlockAction(MouseService mouseService )
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
        Dictionary<string, bool>  mouseOverObject = new Dictionary<string, bool>();
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
                
                                bool ONECE = true;
                if(item != midground.GetFirstActor("player"))
                {
                    if (item.HasAttribute(AttributeKey.body))
                    {
                        if(!mouseOverObject.ContainsKey(item.ActorKey))
                        {
                            mouseOverObject.Add(item.ActorKey, false);
                        }
                        AttributeBody body = (AttributeBody) item.GetActorAttribute(AttributeKey.body);
                        Point position = body.GetPosition();
                        Point size = body.GetSize();
                            
                        AttributeBody PlayerBody = (AttributeBody) midground.GetFirstActor("player").GetActorAttribute(AttributeKey.body);
                        Point PlayerPosition = PlayerBody.GetPosition();
                        Point PlayerSize = PlayerBody.GetSize();
                            
                            // System.Console.WriteLine(item.HasAttribute(AttributeKey.color));
                        bool mouseOver = mouseOverObject[item.ActorKey];
                        if(mouseService.IsMouseOverBox(body.GetRectangle(), PlayerPosition) && item.HasAttribute(AttributeKey.color))
                        {
                            if (item.HasAttribute(AttributeKey.clickable))
                            {
                    AttributeClickable clickable = (AttributeClickable) item.GetActorAttribute(AttributeKey.clickable);
                                if(mouseService.IsButtonPressed("left") && ONECE ){
                                    // animated.currentFrame = 2;
                                    // clickable.clickState = true;
                                    // clickable.toggalSwitch();
                                    // if(clickable.getPREVEUS_State())
                                    
                                    clickable.clicks ++;
                                System.Console.WriteLine($"CLICKS {item.ActorKey} = {clickable.clicks }");
                                    if(clickable.clicks % 5 == 0 && ONECE)
                                    {

                                    ONECE = false;
                                    if (item.HasAttribute(AttributeKey.health))
                                    {
                                        AttributeHealth health = 
                                            (AttributeHealth) item.GetActorAttribute(AttributeKey.health);
                                        
                                        health.damage();
                                        AttributeAnimated animated = (AttributeAnimated) item.GetActorAttribute(AttributeKey.animated);
                                        
                                System.Console.WriteLine($"health {item.ActorKey} = {health.getHealth()}");
                                int dev = health.getMaxHealth()/animated.frames;

                                        if ((health.getHealth() ) % dev  == 0)
                                        {
                                            animated.currentFrame += 1;
                                        }
                                        animated.TextureBounds.position.x = (animated.TextureBounds.size.x*animated.currentFrame);

                                        if(health.getHealth() <= 0)
                                        {
                                            System.Console.WriteLine($"mouse over box key = {item.ActorKey}");
                                            AttributeInventory inventoryPlayer = (AttributeInventory) midground.GetFirstActor("player").GetActorAttribute(AttributeKey.Inventory);
                                            AttributeInventory inventoryItem = (AttributeInventory) item.GetActorAttribute(AttributeKey.Inventory);
                                            foreach(Actor actor in inventoryItem.GetItems())
                                            {
                                                inventoryPlayer.addItem(actor.ActorKey);
                                                string aray = "";

                                                foreach (char CHAR in item.ActorKey)
                                                {
                                                    if( CHAR == ' ')
                                                    {
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        aray += CHAR;
                                                    }
                                                }
                                                midground.RemoveActor(aray.ToLower(), item);
                                            }
                                        }
                                    }
                                    clickable.clicks = 0;
                                    }
                                    
                                }
                            }
                            else{
                                // System.Console.WriteLine($"mouse over box key = {item.ActorKey}");
                                AttributeColor color = (AttributeColor) item.GetActorAttribute(AttributeKey.color);
                                // Types.Color tmpColor = color.GetColor();

                                // color.SetColor(new Color(200,200,0));

                            }
                            mouseOverObject[item.ActorKey] = true;

                        }else if (!mouseService.IsMouseOverBox(body.GetRectangle(), PlayerPosition) && mouseOver)
                        {
                            mouseOverObject[item.ActorKey] = false;
                        }
                    }
                }else
                {
                    
                }
            }
        }
    }
}