using Raylib_cs;

namespace LocalLib.Directing
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

}
