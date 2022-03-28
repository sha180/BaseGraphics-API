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

    public static class TextureRegistry
    {
        public  const int ICONS_TextureID = 0;
        public static string TEXTURE_PATH_icons = "Data/Textures/icons_vx.png";
        public static string TEXTURE_KEY_icons = "icons_vx";

        public const int Play_BOTTON_TextureID = 1;
        public static string TEXTURE_PATH_BUTTON_play = "Data/Textures/Button_play_2.0.png";
        public static string TEXTURE_KEY_BUTTON_play = "Button_play_2.0";

        public const int PLAYER_TextureID = 2;
        public static string TEXTURE_PATH_Battler = "Data/Textures/battler_1_1.png";
        public static string TEXTURE_KEY_Battler = "battler_1_1";


        public const int settings_Button_TextureID = 3;
        public static string TEXTURE_PATH_settings = "Data/Textures/Button_Settings.png";
        public static string TEXTURE_KEY_settings = "Button_Settings";


        public const int BOTTON_TextureID = 4;
        public static string TEXTURE_PATH_BUTTON = "Data/Textures/Button.png";
        public static string TEXTURE_KEY_BUTTON = "Button";
    }
}
