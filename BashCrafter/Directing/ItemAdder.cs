using LocalLib.Casting;
using LocalLib.Types;
using LocalLib;

namespace BashCrafter
{
    public class ItemAdder
    {
        public Actor AddWood()
        {
            Actor wood = new Actor("wood");
            wood.AddAttribute(new AttributeBody(new Point(0,0), new Point(48, 48), 0));
            wood.AddAttribute(new AttributeColor(new Color(100,30,0)));
            wood.AddAttribute(new ItemStack());
            
            // tree.AddAttribute(new AttributeColor(new Color(0,200,0)));
            // tree.AddAttribute(new AttributeHealth(3));
            // cast.AddActor("wood", wood);
            return wood;

        }

        public Actor AddStone()
        {
            Actor stone = new Actor("stone");
            stone.AddAttribute(new AttributeBody(new Point(0,0), new Point(48, 48), 0));
            stone.AddAttribute(new AttributeColor(new Color(0,0,100)));
            stone.AddAttribute(new ItemStack());
            return stone;
        }
    }
}