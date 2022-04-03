using LocalLib;
using LocalLib.Types;
using LocalLib.Casting;
using System.Collections.Generic;


namespace BashCrafter
{
    /// <summary>
    /// A thing that participates in the game.
    /// </summary>
    public class AttributeGameInventory : AttributeInventory
    {
        
        private string attributeKey = AttributeKey.Inventory;
        
        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public AttributeGameInventory(int size, Actor[] items = null) : base(size, items)
        {

        }
        public override void addItem(string itemKey, int amount = 1)
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
                                actor.AddAttribute(new AttributeColor(new Color(255,255,255)));
                                actor.AddAttribute(new AttributeTexture(TextureRegistry.TEXTURE_KEY_icons));
                                actor.AddAttribute(new AttributeAnimated(new Point(24,24), 1));
                                AttributeAnimated animated = (AttributeAnimated) actor.GetActorAttribute(AttributeKey.animated);
                                
                                Point pos;
                        switch (itemKey)
                        {
                            case "wood":
                                pos = new Point(1,7);
                                pos.Scale(24);
                                animated.TextureBounds.position = pos.Scale(24);
                                animated.TextureBounds.size = new Point(24,24);
                                break;
                            
                            case "stone":
                                pos = new Point(14,6);
                                pos.Scale(24);
                                animated.TextureBounds.position = pos.Scale(24);
                                animated.TextureBounds.size = new Point(24,24);
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

    }
}