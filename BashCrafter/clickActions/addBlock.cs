using LocalLib;
using LocalLib.Scripting;
using LocalLib.Casting;
using LocalLib.Services;
using LocalLib.Types;
using System.Collections.Generic;


namespace BashCrafter.Actions
{
    /// <summary>
    /// A thing that is done in the game.
    /// </summary>
    public class addBlockAction : Action
    {
        private MouseService mouseService;
        public addBlockAction(MouseService mouseService )
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
         
        Actor player = midground.GetFirstActor("player");
        AttributeBody PlayerBody = (AttributeBody) player.GetActorAttribute(AttributeKey.body);
        Point PlayerPosition = PlayerBody.GetPosition();
        Point PlayerSize = PlayerBody.GetSize();
        AttributeInventory inventoryPlayer = (AttributeInventory) player.GetActorAttribute(AttributeKey.Inventory);


        if (player.HasAttribute(AttributeKey.clickable))
        {
            
        // AttributeClickable clickable = (AttributeClickable) player.GetActorAttribute(AttributeKey.clickable);
                                    

            if(mouseService.IsButtonPressed("right")){
                // if(clickable.getPREVEUS_State_2())
                // {

                Point mousepos = GetWorldToScreen2D( PlayerPosition, mouseService.GetCoordinates());
                           
                    string slot = inventoryPlayer.getSelectedItem();
                    
                            // System.Console.WriteLine("mousepos x = " + mouseService.GetCoordinates().x);
                            // System.Console.WriteLine("mousepos y = " + mouseService.GetCoordinates().y);
                            // System.Console.WriteLine("pos x = " + mousepos.x);
                            // System.Console.WriteLine("pos y = " + mousepos.y);
                            // System.Console.WriteLine("PlayerPosition x = " + PlayerPosition.x);
                            // System.Console.WriteLine("PlayerPosition y = " + PlayerPosition.y);
                            // System.Console.WriteLine("slot" +  slot);
                        switch (slot)
                        {
                            case "wood":
                                System.Console.WriteLine("spikes");
                                // castAdder.AddSpicks(midground, mousepos, "spikes");
                                castAdder.AddSpicks(midground, mousepos, "spike");
                                break;
                            case "stone":
                                castAdder.AddWall(midground,  mousepos, "walls");
                                break;
                            default:
                                break;
                        }

                        inventoryPlayer.removeSeleced();
                    // }
                }
            }
        }
        
        private Point GetWorldToScreen2D(Point possition, Point PosOffset)
        {
            int x = ( possition.GetX() - (PROGRAM_SETTINGS.SCREEN_WIDTH/2)) - PROGRAM_SETTINGS.CELL_SIZE/2 + PosOffset.x ;
            int y = ( possition.GetY() - (PROGRAM_SETTINGS.SCREEN_HEIGHT/2)) - PROGRAM_SETTINGS.CELL_SIZE/2  + PosOffset.y;

            // Types.Point size = rectangle.GetSize();
            // int width = size.GetX();
            // int height = size.GetY();

            return new Point (x, y);
        }
    }
}