using LocalLib.Types;
using System.Collections.Generic;


namespace LocalLib.Casting
{
    /// <summary>
    /// A thing that participates in the game.
    /// </summary>
    public class AttributeInventory : Attribute
    {
        
        private string attributeKey = AttributeKey.Inventory;
        
        // List<Item> items = null;
        Actor[] Items;
        private int size;

        // private Point position;
        // private Point size;
        // private Point velocity;

        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public AttributeInventory(int size, Actor[] items = null)
        {
            this.size = size;

            if (items != null)
            {
                this.Items = items;
            }else
            {
                this.Items = new Actor[size];
                for(int i = 0; i < size; i++)
                {
                    Items[i] = new Actor("NULL");
                }
            }
        }

        public string GetAttributeKey()
        {
            return attributeKey;
        }

        // /// <summary>
        // /// Gets the position. 
        // /// </summary>
        // /// <returns>The position.</returns>
        public Actor[] GetItems()
        {
            return Items;
        }

        // /// <summary>
        // /// Gets a rectangle enclosing this body.
        // /// </summary>
        // /// <returns>The enclosing rectangle.</returns>
        public int GetSize()
        {
            return size;
        }

        public void addItem(string itemKey, int amount = 1)
        {
            foreach (Actor actor in Items)
            {
                System.Console.WriteLine($"actor key is null =  { actor == null}");
                if(actor != null)
                if(actor.ActorKey == itemKey)
                {
                    ItemStack stack = (ItemStack) actor.GetActorAttribute(ItemAttributeKey.Stack);
                    stack.StackSize += amount;
                    break;
                }
            }
        }
        // /// <summary>
        // /// Gets the size.
        // /// </summary>
        // /// <returns>The size.</returns>
        // public Point GetSize()
        // {
        //     return size;
        // }

        // /// <summary>
        // /// Gets the velocity.
        // /// </summary>
        // /// <returns>The velocity.</returns>
        // public Point GetVelocity()
        // {
        //     return velocity;
        // }

        // /// <summary>
        // /// Sets the position to the given value.
        // /// </summary>
        // /// <param name="position">The given position.</param>
        // public void SetPosition(Point position)
        // {
        //     this.position = position;
        // }

        // /// <summary>
        // /// Sets the size to the given value.
        // /// </summary>
        // /// <param name="size">The given size.</param>
        // public void SetSize(Point size)
        // {
        //     this.size = size;
        // }

        // /// <summary>
        // /// Sets the velocity to the given value.
        // /// </summary>
        // /// <param name="velocity">The given velocity.</param>
        // public void SetVelocity(Point velocity)
        // {
        //     this.velocity = velocity;
        // }
    }
}