using LocalLib.Casting;
using LocalLib.Types;
using BashCrafter.clickActions;
using LocalLib;
using System.Collections.Generic;



namespace BashCrafter
{
    public class MenuBuilder{
        public void AddButton(Cast cast, Point possition, Point size)
        {
            Actor actor = new Actor("button");
            actor.AddAttribute(new AttributeClickable());
            actor.AddAttribute(new AttributeBody(possition, size));
            actor.AddAttribute(new AttributeColor(new Color(255,255,255)));
            actor.AddAttribute(new AttributeTexture(TextureRegistry.TEXTURE_KEY_BUTTON));
            actor.AddAttribute(new AttributeAnimated(new Point(34, 12), 3));
            // actor.AddAttribute(new testClicker_attribute());
            // actor.AddAttribute(new );

            cast.AddActor("buttons", actor);


        }

        public void Addrock(Cast cast)
        {
        }
        public static void AddHotbar(Cast cast, Actor actor)
        {
            if (actor.HasAttribute(LocalLib.AttributeKey.Inventory))
            {
                int barSize = 0;
                AttributeInventory inventory = (AttributeInventory) actor.GetActorAttribute(LocalLib.AttributeKey.Inventory);
                Actor background = new Actor("hotbarBase");
            Point zero = new Point(0,0);
            background.AddAttribute(new AttributeBody(zero, zero));
            background.AddAttribute(new AttributeColor(new Color(150,150,150, 190)));
List<Actor> items = new List<Actor>();
                foreach (Actor item in inventory.GetItems())
                {
                    if (item != null && item.ActorKey.ToLower() != "null")
                    {
                        Actor newActorItem = new Actor(item.ActorKey);
                        newActorItem = item;
                                newActorItem.AddAttribute(new AttributeColor(new Color(255,255,255)));
                                newActorItem.AddAttribute(new AttributeTexture(TextureRegistry.TEXTURE_KEY_icons));
                                newActorItem.AddAttribute(new AttributeAnimated(new Point(24,24), 1));
                                AttributeAnimated animated = (AttributeAnimated) newActorItem.GetActorAttribute(AttributeKey.animated);
                                
                        barSize ++;
                        
                                Point pos;
                        switch (newActorItem.ActorKey)
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
                        System.Console.WriteLine($"its not null");
                        ((AttributeBody)newActorItem.GetActorAttribute(LocalLib.AttributeKey.body)).SetPosition(new Point(PROGRAM_SETTINGS.SCREEN_WIDTH/2, PROGRAM_SETTINGS.SCREEN_HEIGHT - PROGRAM_SETTINGS.CELL_SIZE));
                    //    cast.AddActor("hotbar", item);
                       items.Add(newActorItem);
                    }
                }
                ((AttributeBody)background.GetActorAttribute(AttributeKey.body)).SetSize(
                                new Point(PROGRAM_SETTINGS.CELL_SIZE * barSize,
                                            PROGRAM_SETTINGS.CELL_SIZE));

                ((AttributeBody)background.GetActorAttribute(AttributeKey.body)).SetPosition(
                                new Point((PROGRAM_SETTINGS.SCREEN_WIDTH/2) - ((PROGRAM_SETTINGS.CELL_SIZE * barSize)/2),
                                            PROGRAM_SETTINGS.SCREEN_HEIGHT - PROGRAM_SETTINGS.CELL_SIZE));
                cast.AddActor("hotbar_BG", background);
                cast.AddActorList("hotbars_Sfdds", items);
            }
        }
        
    }
}