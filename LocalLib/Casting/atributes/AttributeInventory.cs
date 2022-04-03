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
        public Actor[] Items;
        public int size;

        public int selectedSlot;

        // private Point position;
        // private Point size;
        // private Point velocity;

        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public AttributeInventory(int size, Actor[] items = null)
        {
            this.size = size;
            selectedSlot = 0;

            if (items != null)
            {
                this.Items = items;
            }else
            {
                this.Items = new Actor[size];
                for(int i = 0; i < size; i++)
                {
                    Items[i] = new Actor("NULL");
                    Items[i].AddAttribute(new AttributeBody(new Point(0,0), new Point(48, 48), 0));
                    Items[i].AddAttribute(new ItemStack());
                }
                
            }
        }

        public virtual string GetAttributeKey()
        {
            return attributeKey;
        }

        // /// <summary>
        // /// Gets the position. 
        // /// </summary>
        // /// <returns>The position.</returns>
        public virtual Actor[] GetItems()
        {
            return Items;
        }

        // /// <summary>
        // /// Gets a rectangle enclosing this body.
        // /// </summary>
        // /// <returns>The enclosing rectangle.</returns>
        public virtual int GetSize()
        {
            return size;
        }

        public virtual void addItem(string itemKey, int amount = 1)
        {
            bool hasItem = false;
            foreach (Actor actor in Items)
            {
                // System.Console.WriteLine($"actor key is null =  { actor == null}");
                if(actor != null)
                {
                    if(actor.ActorKey == itemKey)
                    {
                        hasItem = true;
                        ItemStack stack = (ItemStack) actor.GetActorAttribute(ItemAttributeKey.Stack);
                        stack.StackSize += amount;
                        break;
                    }
                }
            }
            if (!hasItem)
            {
                
                foreach (Actor actor in Items)
                {
                    // System.Console.WriteLine($"actor ass items =  { actor == null}");
                    if(actor.ActorKey.ToLower() == "null")
                    {
                        actor.ActorKey = itemKey;
                        switch (itemKey)
                        {
                            case "wood":
                                actor.AddAttribute(new AttributeColor(new Color(101,67,33)));
                                // actor.AddAttribute(new AttributeTexture(itemKey));
                                // actor.AddAttribute(new AttributeAnimated(new Point(24,24), 1));
                                // AttributeAnimated animated = (AttributeAnimated) actor.GetActorAttribute(AttributeKey.animated);
                                // animated.TextureBounds.position = new Point(1,7).Scale(24);
                                break;
                            
                            case "stone":
                                actor.AddAttribute(new AttributeColor(new Color(100,100,100)));
                                // actor.AddAttribute(new AttributeTexture(itemKey));
                                break;
                            default:
                                break;

                        }
                        ItemStack stack = (ItemStack) actor.GetActorAttribute(ItemAttributeKey.Stack);
                        stack.StackSize += amount;
                        break;
                    }
                }
            }
            
        }


        
        public virtual void removeItem(string itemKey, int amount = 1)
        {
            foreach (Actor actor in Items)
            {
                // System.Console.WriteLine($"actor key is null =  { actor == null}");
                if(actor != null)
                {
                    if(actor.ActorKey == itemKey)
                    {
                        ItemStack stack = (ItemStack) actor.GetActorAttribute(ItemAttributeKey.Stack);
                        if (stack.StackSize > 0)
                        {
                        stack.StackSize -= amount;
                        }

                        break;
                    }
                }
            }
        }
        public virtual void removeSeleced(int amount = 1)
        {
            if(Items[selectedSlot] != null)
            {
                ItemStack stack = (ItemStack) Items[selectedSlot].GetActorAttribute(ItemAttributeKey.Stack);
                if (stack.StackSize > 0)
                {
                    stack.StackSize -= amount;

                }else
                {
                    Items[selectedSlot].ActorKey = "null";
                    stack.StackSize = 0;
                }
            }
        }
        public virtual string getSelectedItem()
        {
            return Items[selectedSlot] != null ? Items[selectedSlot].ActorKey : "null";
        }
        
    }
}