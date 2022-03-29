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
                AttributeInventory inventory = (AttributeInventory) actor.GetActorAttribute(AttributeKey.Inventory);
                // Item[]
                for (int i = 0; i < inventory.GetSize(); i++)
                {
                    if (inventory.GetItems()[i] != null)
                    {

                    }
                }
                // foreach (Item item in inventory.GetItems())
                // {
                    
                // }
            }
            else
            {
                System.Console.WriteLine($"actor {actor.ActorKey} does not have an inventory");
            }
        } 

        public void removeOnNext(Cast cast)
        {

        }

        private void setupActors()
        {

        }
    }
}