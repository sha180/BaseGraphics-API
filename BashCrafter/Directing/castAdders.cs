using LocalLib.Casting;
using LocalLib.Types;
using LocalLib;

namespace BashCrafter
{
    
    public class castAdder
    {
        public static void AddTree(Cast cast, Point position, string ActorKey)
        {
        ItemAdder item = new ItemAdder();
            int invSize = 1;
            Actor[] items = new Actor[invSize];
            items[0] = item.AddWood();

            Actor tree = new Actor(ActorKey);
            tree.AddAttribute(new AttributeBody(position, new Point(PROGRAM_SETTINGS.TREE_LENGTH, PROGRAM_SETTINGS.TREE_HEIGHT), 0));
            tree.AddAttribute(new AttributeColor(PROGRAM_SETTINGS.WHITE));
            tree.AddAttribute(new AttributeHealth(4));
            tree.AddAttribute(new AttributeClickable());
            tree.AddAttribute(new AttributeInventory(invSize, items));
            tree.AddAttribute(new AttributeTexture(TextureRegistry.TEXTURE_KEY_TREE, new Point(138, 155)));
            tree.AddAttribute(new AttributeAnimated(new Point(138, 155), 4));
            
            cast.AddActor("tree", tree);

        }

        public static void Addrock(Cast cast, Point poisition, string ActorKey)
        {
        ItemAdder item = new ItemAdder();
            int invSize = 1;
            Actor[] items = new Actor[invSize];
            items[0] = item.AddStone();

            Actor rock = new Actor(ActorKey);
            rock.AddAttribute(new AttributeBody(poisition, new Point(PROGRAM_SETTINGS.ROCK_DIMENSIONS, PROGRAM_SETTINGS.ROCK_DIMENSIONS), 0));
            rock.AddAttribute(new AttributeColor(PROGRAM_SETTINGS.WHITE));
            rock.AddAttribute(new AttributeHealth(10));
            rock.AddAttribute(new AttributeClickable());
            rock.AddAttribute(new AttributeInventory(invSize, items));
            rock.AddAttribute(new AttributeTexture(TextureRegistry.TEXTURE_KEY_ROCK, new Point(128, 135)));
            rock.AddAttribute(new AttributeAnimated(new Point(128, 135), 5));

            cast.AddActor("rock", rock);
        }

        public static void AddPlayer(Cast cast, Point position)
        {
            ItemAdder item = new ItemAdder();
            int invSize = 8;
            Actor[] items = new Actor[invSize];
            items[1] = item.AddStone(1000);
            items[0] = item.AddWood(1000);

            Actor actor = new Actor("player");
            actor.AddAttribute(new AttributeBody(position, new Point(64, 64), 120));
            actor.AddAttribute(new AttributeColor(new Color(255,255,255)));
            actor.AddAttribute(new AttributeGameInventory(invSize));
            actor.AddAttribute(new AttributeClickable());
            actor.AddAttribute(new AttributeTexture(TextureRegistry.TEXTURE_KEY_Battler, new Point(64,64)));
            actor.AddAttribute(new AttributeAnimated(new Point(64,64), 9));
            
            // actor.AddAttribute(new AttributeEntity());
            actor.AddAttribute(new AttributeCameraTrack());
            
            cast.AddActor("player", actor);
        }
        public static void AddEnemy(Cast cast, Point poisition, string ActorKey, char direction)
        {
        ItemAdder item = new ItemAdder();
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

            cast.AddActor("enemy" + direction, enemy);

        }
        public static void AddAirship(Cast cast, Point poisition, string ActorKey)
        {
        ItemAdder item = new ItemAdder();
            
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

        public static void AddGrass(Cast cast, Point poisition, string ActorKey)
        {
           Actor grass = new Actor(ActorKey);
            grass.AddAttribute(new AttributeBody(poisition, new Point(64, 64), 0));
            grass.AddAttribute(new AttributeColor(PROGRAM_SETTINGS.WHITE));
            grass.AddAttribute(new AttributeTexture(TextureRegistry.TEXTURE_KEY_GRASS, new Point(5, 15)));

            cast.AddActor("grass", grass); 
        }

        public static void AddWall(Cast cast, Point poisition, string ActorKey)
        {
           Actor wall = new Actor(ActorKey);
            wall.AddAttribute(new AttributeBody(poisition, new Point(64, 64), 0));
            wall.AddAttribute(new AttributeColor(PROGRAM_SETTINGS.WHITE));
            wall.AddAttribute(new AttributeTexture(TextureRegistry.TEXTURE_KEY_WALL));
            wall.AddAttribute(new AttributeAnimated(new Point(64, 45), 1));
            wall.AddAttribute(new AttributeHealth(5));

            cast.AddActor("wall", wall); 
        }
        
        public static void AddSpikes(Cast cast, Point poisition, string ActorKey)
        {
           Actor spike = new Actor(ActorKey);
            spike.AddAttribute(new AttributeBody(poisition, new Point(64, 64), 0));
            spike.AddAttribute(new AttributeColor(PROGRAM_SETTINGS.WHITE));
            spike.AddAttribute(new AttributeTexture(TextureRegistry.TEXTURE_KEY_SPIKES));
            spike.AddAttribute(new AttributeHealth(3));
            //enemy.AddAttribute(new AttributeAnimated(new Point(5, 15), 5));

            cast.AddActor("spike", spike); 
        }
        
    }
}