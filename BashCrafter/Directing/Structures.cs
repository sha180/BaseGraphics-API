using Raylib_cs;

namespace BashCrafter
{
        public enum Stages
    {
        TITLE,
        GAME,
        END
    }

    public enum ActorType
    {
        Banner = -1,
        Sprite = 1,
        Box,
        Button
    }
    public enum TextureType
    {
        icon,
        Player,
        Button,
        Box
    }
    public enum ButtonType
    {
        NONE,
        PLAY,
        PAUSE,
        SETTINGS,
        PREVEUS,
        RULES,
        END
    }
    public enum Items
    {
        WOOD,
        STONE
    }

    public enum Tools
    {
        Pickaxe,
        Axe
    }
    public static class TextureRegistry
    {
        public  const int ICONS_TextureID = 0;
        public static string TEXTURE_PATH_icons = "Data/Textures/icons_vx.png";
        public static string TEXTURE_KEY_icons = "icons_vx";

        public const int Play_BOTTON_TextureID = 1;
        public static string TEXTURE_PATH_BUTTON_play = "Data/Textures/Button_play_2.0.png";
        public static string TEXTURE_KEY_BUTTON_play = "Button_play_2";

        public const int PLAYER_TextureID = 2;
        public static string TEXTURE_PATH_Battler = "Data/Textures/battler_1_1.png";
        public static string TEXTURE_KEY_Battler = "battler_1_1";


        public const int settings_Button_TextureID = 3;
        public static string TEXTURE_PATH_settings = "Data/Textures/Button_Settings.png";
        public static string TEXTURE_KEY_settings = "Button_Settings";

        public const int BOTTON_TextureID = 4;
        public static string TEXTURE_PATH_BUTTON = "Data/Textures/Button.png";
        public static string TEXTURE_KEY_BUTTON = "Button";

        public const int TREE_TextureID = 5;
        public static string TEXTURE_PATH_TREE = "Data/Textures/tree1B_ss.png";
        public static string TEXTURE_KEY_TREE = "tree1B_ss";
        public const int ROCK_TextureID = 6;
        public static string TEXTURE_PATH_ROCK = "Data/Textures/rocks-2.png";
        public static string TEXTURE_KEY_ROCK = "rocks-2";
        public const int Enemy_TextureID = 7;
        public static string TEXTURE_PATH_ENEMY = "Data/Textures/golem.png";
        public static string TEXTURE_KEY_ENEMY = "golem";

        public const int Airship_TextureID = 8;
        public static string TEXTURE_PATH_AIRSHIP = "Data/Textures/airship.png";
        public static string TEXTURE_KEY_AIRSHIP = "airship";
        public const int Grass_TextureID = 9;
        public static string TEXTURE_PATH_GRASS = "Data/Textures/grass.png";
        public static string TEXTURE_KEY_GRASS = "grass";

        public static string TEXTURE_PATH_WALL = "Data/Textures/fence2.png";
        public static string TEXTURE_KEY_WALL = "fence2";
        
        public static string TEXTURE_PATH_SPIKES = "Data/Textures/spikes.png";
        public static string TEXTURE_KEY_SPIKES = "spikes"; 
    }
}
