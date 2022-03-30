
using LocalLib.Casting;
using LocalLib.Services;
using LocalLib.Types;
using System.Collections.Generic;


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
                                if(mouseService.IsButtonPressed("left")){
                                    // animated.currentFrame = 2;
                                    clickable.clickState = true;
                                    clickable.toggalSwitch();
                                    if(clickable.getPREVEUS_State())
                                    {
                                System.Console.WriteLine($"mswitch {item.ActorKey} = {clickable.getPREVEUS_State()}");
                                    
                                    if (item.HasAttribute(AttributeKey.health))
                                    {
                                        AttributeHealth health = 
                                            (AttributeHealth) item.GetActorAttribute(AttributeKey.health);
                                        
                                        health.damage();
                                        AttributeAnimated animated = (AttributeAnimated) item.GetActorAttribute(AttributeKey.animated);
                                        
                                        animated.currentFrame += 1;
                                        animated.TextureBounds.position.x = (animated.TextureBounds.size.x*animated.currentFrame);
                                        
                                        if(health.getHealth() < 0)
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
            
            //     foreach (Actor item in forground.GetAllActors())
            //     {
            //         if (item.HasAttribute(AttributeKey.body))
            //         {
            //             AttributeBody body = (AttributeBody) item.GetActorAttribute(AttributeKey.body);
            //             Point position = body.GetPosition();
            //             Point size = body.GetSize();
                            
            //             AttributeBody PlayerBody = (AttributeBody) midground.GetFirstActor("player").GetActorAttribute(AttributeKey.body);
            //             Point PlayerPosition = PlayerBody.GetPosition();
            //             Point PlayerSize = PlayerBody.GetSize();
                            
            //                 // System.Console.WriteLine(item.HasAttribute(AttributeKey.color));

            //             if(mouseService.IsMouseOverBox(body.GetRectangle(), PlayerPosition) && item.HasAttribute(AttributeKey.color))
            //             {
            //                 // System.Console.WriteLine($"mouse over box ");
            //                 AttributeColor color = (AttributeColor) item.GetActorAttribute(AttributeKey.color);
            //                 // Types.Color tmpColor = color.GetColor();
                            
            //                 color.SetColor(new Color(200,200,0));
            //             }
            //         }
                
            // }

            // foreach (Actor item in background.GetAllActors())
            //     {
            //         if (item.HasAttribute(AttributeKey.body))
            //         {
            //             AttributeBody body = (AttributeBody) item.GetActorAttribute(AttributeKey.body);
            //             Point position = body.GetPosition();
            //             Point size = body.GetSize();
                            
            //             AttributeBody PlayerBody = (AttributeBody) midground.GetFirstActor("player").GetActorAttribute(AttributeKey.body);
            //             Point PlayerPosition = PlayerBody.GetPosition();
            //             Point PlayerSize = PlayerBody.GetSize();
                            
            //                 // System.Console.WriteLine(item.HasAttribute(AttributeKey.color));

            //             if(mouseService.IsMouseOverBox(body.GetRectangle(), PlayerPosition) && item.HasAttribute(AttributeKey.color))
            //             {
            //                 // System.Console.WriteLine($"mouse over box ");
            //                 AttributeColor color = (AttributeColor) item.GetActorAttribute(AttributeKey.color);
            //                 // Types.Color tmpColor = color.GetColor();
                            
            //                 color.SetColor(new Color(200,200,0));
            //             }
            //         }
            //     }
        }
    }
}