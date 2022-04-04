using LocalLib.Scripting;
using LocalLib.Casting;
using LocalLib.Services;
using LocalLib.Types;
using LocalLib;
using System.Collections.Generic;


namespace BashCrafter
{
    /// <summary>
    /// A thing that is done in the game.
    /// </summary>
    public class itemSelectorAction : Action
    {
        private MouseService mouseService;
        public itemSelectorAction(MouseService mouseService )
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
int count = forground.GetActors("itemSlot").Count;
            if(count > 0)
            {
                Actor player = midground.GetFirstActor("player");
                AttributeInventory playerinv = (AttributeInventory) player.GetActorAttribute(AttributeKey.Inventory);

                        // System.Console.WriteLine(forground.GetActors("itemSlot").Count );
            int i = 0;
                    
                foreach (Actor item in forground.GetActors("itemSlot"))
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
                    AttributeAnimated animated = (AttributeAnimated) item.GetActorAttribute(AttributeKey.animated);
                    AttributeColor color = (AttributeColor) item.GetActorAttribute(AttributeKey.color);


                    if(mouseService.IsMouseOverButton(body.GetRectangle()) && item.HasAttribute(AttributeKey.color))
                    {
                        // System.Console.WriteLine($"mouse over box key = {item.ActorKey}");
                        // AttributeColor color = (AttributeColor) item.GetActorAttribute(AttributeKey.color);
                        // Types.Color tmpColor = color.GetColor();
                        
                        // color.SetColor(new Color(200,200,0));
                        if(mouseService.IsButtonPressed("left")){
                            // animated.currentFrame = 2;
                            clickable.clicks++;
                            clickable.clickState = true;
                            clickable.toggalSwitch();
                        System.Console.WriteLine($" clicks = {clickable.clicks}");
                            if(clickable.clicks > 0)
                            {

                                for (int j = 0; j < playerinv.size; j++)
                                {
                                    if(playerinv.GetItems()[j] != null)
                                    {
                                      
                                        if(playerinv.GetItems()[j].ActorKey == item.ActorKey)
                                        {
                                            color.SetColor(new Color(0,255,0,90));
                                            for (int k = 0; k < playerinv.size; k++)
                                            {
                                                
                                                if(playerinv.GetItems()[k] != null && playerinv.GetItems()[k].HasAttribute(AttributeKey.color )  && k != j)
                                                {
                                                    AttributeColor newColor = (AttributeColor) playerinv.GetItems()[k].GetActorAttribute(AttributeKey.color);
                                                    newColor.SetColor(new Color(100,100,100, 200));
                                                }
                                            }
                                            playerinv.selectedSlot = j;
                                            // System.Console.WriteLine($"j = {j}");
                                            break;
                                        }
                                    }

                                }
                                        // playerinv.selectedSlot = i;
                        // System.Console.WriteLine($"i = {i}");

                                // switch (item.ActorKey)
                                // {
                                //     case "stone":
                                //         break;
                                //     case "wood":

                                //         break; 
                                //     default:
                                //         break;
                                // }

                            }
                            

                            
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
                clickable.clicks = 0;
                    
                }
                i++;

                }
            
            }
        }
    }
}