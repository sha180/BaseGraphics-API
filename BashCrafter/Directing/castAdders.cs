using LocalLib.Casting;
using LocalLib.Types;



namespace BashCrafter
{
    public class castAdder{
        public void AddTree(Cast cast)
        {
            Actor rock = new Actor();
            rock.AddAttribute(new AttributeBody(new Point(-100,-10), new Point(64, 128), 0));
            rock.AddAttribute(new AttributeColor(new Color(0,200,0)));

            cast.AddActor("player", rock);

        }

        public void Addrock(Cast cast)
        {
            Actor rock = new Actor();
            rock.AddAttribute(new AttributeBody(new Point(-176,-10), new Point(64,64), 0));
            rock.AddAttribute(new AttributeColor(new Color(124,124,124)));

            cast.AddActor("player", rock);
        }

        public void AddPlayer(Cast cast)
        {

            Actor actor = new Actor();
            actor.AddAttribute(new AttributeBody(new Point(0,0), new Point(64, 64), 120));
            actor.AddAttribute(new AttributeColor(new Color(255,255,255)));
            // actor.AddAttribute(new AttributeEntity());
            actor.AddAttribute(new AttributeCameraTrack());
            
            cast.AddActor("player", actor);
        }
        
    }
}