using LocalLib.Casting;
using LocalLib.Types;
using BashCrafter.clickActions;


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
        
        
    }
}