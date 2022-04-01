using LocalLib.Casting;
using LocalLib.Types;
using LocalLib;

namespace BashCrafter
{
    
    public class castAdder
    {
        ItemAdder item = new ItemAdder();
        public void AddTree(Cast cast, Point position, string ActorKey)
        {
            int invSize = 1;
            Actor[] items = new Actor[invSize];
            items[0] = item.AddWood();

            Actor tree = new Actor(ActorKey);
            tree.AddAttribute(new AttributeBody(position, new Point(PROGRAM_SETTINGS.TREE_LENGTH, PROGRAM_SETTINGS.TREE_HEIGHT), 0));
            tree.AddAttribute(new AttributeColor(PROGRAM_SETTINGS.WHITE));
            tree.AddAttribute(new AttributeHealth(3));
            tree.AddAttribute(new AttributeClickable());
            tree.AddAttribute(new AttributeInventory(invSize, items));
            tree.AddAttribute(new AttributeTexture(TextureRegistry.TEXTURE_KEY_TREE, new Point(138, 155)));
            tree.AddAttribute(new AttributeAnimated(new Point(138, 155), 5));
            
            cast.AddActor("tree", tree);

        }

        public void Addrock(Cast cast, Point poisition, string ActorKey)
        {
            int invSize = 1;
            Actor[] items = new Actor[invSize];
            items[0] = item.AddStone();

            Actor rock = new Actor(ActorKey);
            rock.AddAttribute(new AttributeBody(poisition, new Point(PROGRAM_SETTINGS.ROCK_DIMENSIONS, PROGRAM_SETTINGS.ROCK_DIMENSIONS), 0));
            rock.AddAttribute(new AttributeColor(PROGRAM_SETTINGS.WHITE));
            rock.AddAttribute(new AttributeHealth(5));
            rock.AddAttribute(new AttributeClickable());
            rock.AddAttribute(new AttributeInventory(invSize, items));
            rock.AddAttribute(new AttributeTexture(TextureRegistry.TEXTURE_KEY_ROCK, new Point(128, 135)));
            rock.AddAttribute(new AttributeAnimated(new Point(128, 135), 5));

            cast.AddActor("rock", rock);
        }

        public void AddPlayer(Cast cast, Point position)
        {
            int invSize = 8;
            Actor[] items = new Actor[invSize];
            items[0] = item.AddStone();
            items[1] = item.AddWood();

            Actor actor = new Actor("player");
            actor.AddAttribute(new AttributeBody(position, new Point(64, 64), 120));
            actor.AddAttribute(new AttributeColor(new Color(255,255,255)));
            actor.AddAttribute(new AttributeInventory(invSize));
            actor.AddAttribute(new AttributeTexture(TextureRegistry.TEXTURE_KEY_Battler, new Point(64,64)));
            actor.AddAttribute(new AttributeAnimated(new Point(64,64), 9));
            
            // actor.AddAttribute(new AttributeEntity());
            actor.AddAttribute(new AttributeCameraTrack());
            
            cast.AddActor("player", actor);
        }
        public void AddEnemy(Cast cast, Point poisition, string ActorKey)
        {
            //  int invSize = 1;
            // Actor[] items = new Actor[invSize];
            // items[0] = item.AddStone();

            Actor enemy = new Actor(ActorKey);
            enemy.AddAttribute(new AttributeBody(poisition, new Point(PROGRAM_SETTINGS.ROCK_DIMENSIONS, PROGRAM_SETTINGS.ROCK_DIMENSIONS), 0));
            enemy.AddAttribute(new AttributeColor(PROGRAM_SETTINGS.WHITE));
            enemy.AddAttribute(new AttributeHealth(5));
            //enemy.AddAttribute(new AttributeClickable());
            //enemy.AddAttribute(new AttributeInventory(invSize, items));
            enemy.AddAttribute(new AttributeTexture(TextureRegistry.TEXTURE_KEY_ENEMY, new Point(64, 64)));
            //enemy.AddAttribute(new AttributeAnimated(new Point(128, 135), 5));

            cast.AddActor("enemy", enemy);

        }
        public void AddAirship(Cast cast, Point poisition, string ActorKey)
        {
            
            Actor airship = new Actor(ActorKey);
            airship.AddAttribute(new AttributeBody(poisition, new Point(256, 256), 0));
            airship.AddAttribute(new AttributeColor(PROGRAM_SETTINGS.WHITE));
            airship.AddAttribute(new AttributeHealth(500));
            //airship.AddAttribute(new AttributeClickable());
            airship.AddAttribute(new AttributeInventory(2));
            airship.AddAttribute(new AttributeTexture(TextureRegistry.TEXTURE_KEY_AIRSHIP, new Point(64, 64)));
            //enemy.AddAttribute(new AttributeAnimated(new Point(128, 135), 5));

            cast.AddActor("airship", airship);

        }

        public void AddGrass(Cast cast, Point poisition, string ActorKey)
        {
           Actor grass = new Actor(ActorKey);
            grass.AddAttribute(new AttributeBody(poisition, new Point(64, 64), 0));
            grass.AddAttribute(new AttributeColor(PROGRAM_SETTINGS.WHITE));
            grass.AddAttribute(new AttributeTexture(TextureRegistry.TEXTURE_KEY_GRASS, new Point(5, 15)));
            //enemy.AddAttribute(new AttributeAnimated(new Point(5, 15), 5));

            cast.AddActor("grass", grass); 
        }
    }
}