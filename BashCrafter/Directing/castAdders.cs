using LocalLib.Casting;
using LocalLib.Types;



namespace BashCrafter
{
    public class castAdder{
        public void AddTree(Cast cast, Point possition)
        {
            Actor tree = new Actor("tree");
            tree.AddAttribute(new AttributeBody(possition, new Point(64, 128), 0));
            tree.AddAttribute(new AttributeColor(new Color(0,200,0)));

            cast.AddActor("tree", tree);

        }

        public void Addrock(Cast cast)
        {
            Actor rock = new Actor("rock");
            rock.AddAttribute(new AttributeBody(new Point(-176,-10), new Point(64,64), 0));
            rock.AddAttribute(new AttributeColor(new Color(124,124,124)));

            cast.AddActor("rock", rock);
        }

        public void AddPlayer(Cast cast)
        {

            Actor actor = new Actor("player");
            actor.AddAttribute(new AttributeBody(new Point(-90, - 70), new Point(64, 64), 120));
            actor.AddAttribute(new AttributeColor(new Color(125,55,180)));
            actor.AddAttribute(new AttributeCameraTrack());
            
            cast.AddActor("player", actor);
        }
        public void AddBackground(Cast cast, Point size, Color color)
        {

            Actor actor = new Actor("background");
            actor.AddAttribute(new AttributeBody(new Point(0,0), size, 0));
            actor.AddAttribute(new AttributeColor(color));
            actor.AddAttribute(new AttributeCameraTrack());
            
            cast.AddActor("background", actor);
        }
        
    }
}