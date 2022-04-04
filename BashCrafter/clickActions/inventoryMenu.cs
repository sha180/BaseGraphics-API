using LocalLib.Types;
using LocalLib;
using LocalLib.Casting;
using LocalLib.Scripting;


namespace BashCrafter.clickActions
{
    /// <summary>
    /// A thing that participates in the game.
    /// </summary>
    public class InventoryMenu : MenuCallback
    {
        Actor background;
        Actor ItemSlot;
        
        // private string attributeKey = AttributeKey.InventoryMenu;
        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public InventoryMenu()
        {
            setupActors();
        }
        public void OnNext(Cast cast, Actor actor)
        {
            if(actor.HasAttribute(AttributeKey.Inventory))
            {
// MenuBuilder.AddHotbar(cast, actor);
                AttributeInventory inventory = (AttributeInventory) actor.GetActorAttribute(AttributeKey.Inventory);
                ((AttributeBody)background.GetActorAttribute(AttributeKey.body)).SetSize(
                                // new Point(( inventory.GetSize()/9 > 1 ? (PROGRAM_SETTINGS.GRID_X + 4) * 9 : inventory.GetSize() * (PROGRAM_SETTINGS.GRID_X + 4) ) ,
                                //             inventory.GetSize()/9  * (PROGRAM_SETTINGS.GRID_Y + 9)));
                                new Point(PROGRAM_SETTINGS.SCREEN_WIDTH/4 * 3,
                                            PROGRAM_SETTINGS.SCREEN_HEIGHT/4 * 3));
                
                cast.AddActor("back", background);
                    Actor[] items = inventory.GetItems();
                for (int i = 0; i < inventory.GetSize(); i++)
                {
            //     System.Console.WriteLine($"its slot {(inventory.GetSize()/9 > 1 ? (PROGRAM_SETTINGS.GRID_X + 4) * (i/9 ) + (i%9) : (i/9 ) + (i%9) * (PROGRAM_SETTINGS.GRID_X + 4) )}");
                    
            // ItemSlot = new Actor("item slot " + i);
            // ItemSlot.AddAttribute(new AttributeColor(new Color(100,100,100)));
            //         ItemSlot.AddAttribute(new AttributeBody(new Point(
            //             // inventory.GetSize() * (((i/9 ) + (i%9)) * 4)) + 4 ,
            //             (inventory.GetSize()/9 > 1 ? (PROGRAM_SETTINGS.GRID_X + 4) * (i/9 ) + (i%9) : ((i/9 ) + (i%9)) * (PROGRAM_SETTINGS.GRID_X + 4) ),
            //              i / 9 *  (inventory.GetSize()%9 * (PROGRAM_SETTINGS.GRID_Y)) )
                    
            //         , new Point(PROGRAM_SETTINGS.GRID_X, PROGRAM_SETTINGS.GRID_Y)));
                    
                    // cast.AddActor("itemSlot", ItemSlot);
                // System.Console.WriteLine($"its null{items[i] == null}");
                    bool THERES = items[i] == null || ("null" == items[i].ActorKey.ToLower());
                    if (THERES)
                    {
                        System.Console.WriteLine($"its null");
                    }else
                    {
                        System.Console.WriteLine($"its not null");
                        ((AttributeBody)items[i].GetActorAttribute(AttributeKey.body)).SetPosition(new Point(PROGRAM_SETTINGS.SCREEN_WIDTH/8 + 10, (i * 64) + PROGRAM_SETTINGS.SCREEN_HEIGHT/8 + 10));
                        items[i].AddAttribute(new AttributeClickable());
                       cast.AddActor("itemSlot", items[i]);
                    }
                }
            }
            else
            {
                System.Console.WriteLine($"actor {actor.ActorKey} does not have an inventory");
            }
        } 

        public void removeOnNext(Cast cast)
        {
            cast.RemoveActor("back",background);
            cast.clearGroup("itemSlot");
        }

        private void setupActors()
        {
            Point zero = new Point(0,0);

            background = new Actor("inv_background");
            background.AddAttribute(new AttributeBody(new Point(PROGRAM_SETTINGS.SCREEN_WIDTH/8 , PROGRAM_SETTINGS.SCREEN_HEIGHT/8 ), zero));
            background.AddAttribute(new AttributeColor(new Color(150,150,150, 190)));
            // background.AddAttribute();
            // background.AddAttribute();

            // ItemSlot = new Actor("item slot");
            // background.AddAttribute(new AttributeBody(zero, zero));
            // ItemSlot.AddAttribute(new AttributeColor(new Color(100,100,100)));
        }
    }
}