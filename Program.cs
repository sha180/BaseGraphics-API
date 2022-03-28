using System;
using System.Collections.Generic;
using Raylib_cs;
using BashCrafter.Directing;
using LocalLib.Services;


namespace LocalLib
{
    // public struct SYSTEM_SETTINGS
    // {
    // public static int FRAME_RATE = 60;
    // public static int MAX_X = 1280;
    // public static int MAX_Y = 720;
    // public static int CELL_SIZE = 64;
    // public static int FONT_SIZE = 24;
    // public static int COLS = 40;
    // public static int ROWS = 26;
    // public static string CAPTION ="BashCrafter";
    // public static string DATA_PATH = "Data/messages.txt";
    // public static string TEXTURE_PATH_icons = "Data/Textures/icons_vx.png";
    // public static string TEXTURE_PATH_Battler = "Data/Textures/battler_1_1.png";
    // public static string TEXTURE_PATH_BUTTONS = "Data/Textures/Button_play.png";
    // public static Color WHITE = new Color(255, 255, 255, 255);
    // public static int DEFAULT_ARTIFACTS = 40;
    // }
    class Program
    {
        static void Main(string[] args)
        {

            
            // start the game

            // LocalLib.Types.Texture Icons = new LocalLib.Types.Texture(TextureRegistry.TEXTURE_PATH_icons);
            // LocalLib.Types.Texture Battler = new LocalLib.Types.Texture(TextureRegistry.TEXTURE_PATH_Battler);
            // LocalLib.Types.Texture Buttons = new LocalLib.Types.Texture(TextureRegistry.TEXTURE_PATH_BUTTON);
            // LocalLib.Types.Texture settings = new LocalLib.Types.Texture(TextureRegistry.TEXTURE_PATH_settings);


            // List<LocalLib.Types.Texture> TexturesList = new List<LocalLib.Types.Texture>();
            // TexturesList.Add(settings);
            // TexturesList.Add(Buttons);
            // TexturesList.Add(Battler);
            // TexturesList.Add(Icons);

            // InputService inputService = new InputService();
            // VideoService videoService 
            //     = new VideoService(false, TexturesList);

            newDirector director = new newDirector(SceneManager.VideoService);
            
            director.GameLoop();
        }
    }
}
