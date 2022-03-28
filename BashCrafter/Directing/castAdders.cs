using LocalLib.Casting;
using LocalLib.Types;
using LocalLib;

namespace BashCrafter
{
    public class castAdder
    {
        public void AddTree(Cast cast, Point position)
        {
            Actor tree = new Actor();
            tree.AddAttribute(new AttributeBody(position, new Point(PROGRAM_SETTINGS.TREE_LENGTH, PROGRAM_SETTINGS.TREE_HEIGHT), 0));
            tree.AddAttribute(new AttributeColor(new Color(0,200,0)));

            cast.AddActor("tree", tree);

        }

        public void Addrock(Cast cast, Point poisition)
        {
            Actor rock = new Actor();
            rock.AddAttribute(new AttributeBody(poisition, new Point(PROGRAM_SETTINGS.ROCK_DIMENSIONS, PROGRAM_SETTINGS.ROCK_DIMENSIONS), 0));
            rock.AddAttribute(new AttributeColor(new Color(124,124,124)));

            cast.AddActor("rock", rock);
        }

        public void AddPlayer(Cast cast, Point position)
        {

            Actor actor = new Actor();
            actor.AddAttribute(new AttributeBody(position, new Point(64, 64), 120));
            actor.AddAttribute(new AttributeColor(new Color(255,255,255)));
            // actor.AddAttribute(new AttributeEntity());
            actor.AddAttribute(new AttributeCameraTrack());
            
            cast.AddActor("player", actor);
        }
    }
}