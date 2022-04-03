using System;
using System.Collections.Generic;
using System.IO;

using BashCrafter.clickActions;
using BashCrafter.Actions;

using LocalLib.Casting;
using LocalLib.Scripting;
using LocalLib.Scripting.Actions;
using LocalLib.Services;
using LocalLib.Types;
using LocalLib.Screens;
using LocalLib;


namespace BashCrafter.Directing
{
    public class SceneManager
    {
        // public static VideoService VideoService = new RaylibVideoService(Constants.GAME_NAME,
        //     Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT, Constants.BLACK);
        public static AudioService AudioService = new RaylibAudioService();
        public static KeyboardService KeyboardService = new RaylibKeyboardService();
        public static VideoService VideoService = new RaylibVideoService(PROGRAM_SETTINGS.GAME_NAME,
                    PROGRAM_SETTINGS.SCREEN_WIDTH, PROGRAM_SETTINGS.SCREEN_HEIGHT, PROGRAM_SETTINGS.WHITE, true);

        public static MouseService MouseService = new RaylibMouseService();
        public static PhysicsService PhysicsService = new RaylibPhysicsService();
        public static MenuBuilder menuBuilder = new MenuBuilder();

        public List<Texture> TexturesList = new List<Texture>();

        // private Cast forground = new Cast();
        // private Cast midground = new Cast();
        
        // private Cast background = new Cast();
        

        private bool debug = true;
        private Random random = new Random(); 
        public SceneManager()
        {
            
        }

        public void InitializeTextures()
        {


            LocalLib.Types.Texture Icons = new LocalLib.Types.Texture(TextureRegistry.TEXTURE_PATH_icons);
            LocalLib.Types.Texture Battler = new LocalLib.Types.Texture(TextureRegistry.TEXTURE_PATH_Battler);
            LocalLib.Types.Texture Buttons = new LocalLib.Types.Texture(TextureRegistry.TEXTURE_PATH_BUTTON);
            LocalLib.Types.Texture settings = new LocalLib.Types.Texture(TextureRegistry.TEXTURE_PATH_settings);
            LocalLib.Types.Texture play = new LocalLib.Types.Texture(TextureRegistry.TEXTURE_PATH_BUTTON_play);
            LocalLib.Types.Texture tree = new LocalLib.Types.Texture(TextureRegistry.TEXTURE_PATH_TREE);
            LocalLib.Types.Texture rock = new LocalLib.Types.Texture(TextureRegistry.TEXTURE_PATH_ROCK);
            LocalLib.Types.Texture enemy = new LocalLib.Types.Texture(TextureRegistry.TEXTURE_PATH_ENEMY);
            LocalLib.Types.Texture airship = new LocalLib.Types.Texture(TextureRegistry.TEXTURE_PATH_AIRSHIP);
            LocalLib.Types.Texture grass = new LocalLib.Types.Texture(TextureRegistry.TEXTURE_PATH_GRASS);
            LocalLib.Types.Texture spikes = new LocalLib.Types.Texture(TextureRegistry.TEXTURE_PATH_SPIKES);
            LocalLib.Types.Texture walls = new LocalLib.Types.Texture(TextureRegistry.TEXTURE_PATH_WALL);
            




            TexturesList.Add(settings);
            TexturesList.Add(Buttons);
            TexturesList.Add(Battler);
            TexturesList.Add(Icons);
            TexturesList.Add(play);
            TexturesList.Add(tree);
            TexturesList.Add(rock);
            TexturesList.Add(enemy);
            TexturesList.Add(airship);
            TexturesList.Add(grass);
            TexturesList.Add(spikes);
            TexturesList.Add(walls);
        }

        public void PrepareScene(string scene, Stage stage)
        {

            // TestWorld(stage);
            if (scene == PROGRAM_SETTINGS.NEW_GAME)
            {
                PrepareNewGame(stage);
            }
            // else if (scene == "2")
            // {
            //     PrepareNextGame(stage);
            // }

            // else if (scene == PROGRAM_SETTINGS.NEXT_LEVEL)
            // {
            //     PrepareNextLevel(cast, script);
            // }
            // else if (scene == PROGRAM_SETTINGS.TRY_AGAIN)
            // {
            //     PrepareTryAgain(cast, script);
            // }
            // else if (scene == PROGRAM_SETTINGS.IN_PLAY)
            // {
            //     PrepareInPlay(cast, script);
            // }
            // else if (scene == PROGRAM_SETTINGS.GAME_OVER)
            // {
            //     PrepareGameOver(cast, script);
            // }
        }
        private void PrepareNewGame(Stage stage)
        {
            // AddStats(cast);
            // AddLevel(cast);
            // AddScore(cast);
            // AddLives(cast);
            // AddBall(cast);
            // AddBricks(cast);
            // AddRacket(cast);
            // AddPlayer(cast);
            // AddDialog(cast, PROGRAM_SETTINGS.ENTER_TO_START); 

            Actor player = null;
            
            if (stage.midground.GetFirstActor("player") != null)
            {
                player = stage.midground.GetFirstActor("player");

            }

            stage.ClearCast();

            // background
            Actor background = new Actor("background");
            background.AddAttribute(new AttributeBody(new Point(0,0), new Point(PROGRAM_SETTINGS.MAP_X,PROGRAM_SETTINGS.MAP_Y), 0));
            background.AddAttribute(new AttributeColor(PROGRAM_SETTINGS.GREEN));

            stage.background.AddActor("background", background);
            
            for (int i = 0; i< 300;i++)
            {
            castAdder.AddGrass(stage.background, new Point(random.Next((PROGRAM_SETTINGS.MAP_X/PROGRAM_SETTINGS.CELL_SIZE) ) * PROGRAM_SETTINGS.CELL_SIZE, random.Next((PROGRAM_SETTINGS.MAP_Y/PROGRAM_SETTINGS.CELL_SIZE) ) * PROGRAM_SETTINGS.CELL_SIZE),"grass " + i);
            }

            // midground
            if (player == null)
            {
                castAdder.AddPlayer(stage.midground, new Point(PROGRAM_SETTINGS.MAP_X/2,(PROGRAM_SETTINGS.MAP_Y/2)+256));
            }else
            {
                stage.midground.AddActor("player", player);
            }

            
            addTrees(stage.midground, 20);
            addRocks(stage.midground, 50);
            
            
            //spawn left
             for (int i = 0; i < 10; i++)
            {
                castAdder.AddEnemy(stage.midground, new Point(0, random.Next(PROGRAM_SETTINGS.rows) * PROGRAM_SETTINGS.CELL_SIZE),"enemy 1 " + i);
            }
            //spawn top
            for (int i = 0; i < 10; i++)
            {
                castAdder.AddEnemy(stage.midground, new Point(random.Next(PROGRAM_SETTINGS.calloms)* PROGRAM_SETTINGS.CELL_SIZE, 0),"enemy 2 " + i);
            }
            //spawn bottom
            for (int i = 0; i < 10; i++)
            {
                castAdder.AddEnemy(stage.midground, new Point(random.Next(PROGRAM_SETTINGS.calloms)* PROGRAM_SETTINGS.CELL_SIZE, (PROGRAM_SETTINGS.rows-1)*PROGRAM_SETTINGS.CELL_SIZE),"enemy 3 " + i);
            }
            //spawn right
            for (int i = 0; i < 10; i++)
            {
                castAdder.AddEnemy(stage.midground, new Point((PROGRAM_SETTINGS.calloms-1)*PROGRAM_SETTINGS.CELL_SIZE, random.Next(PROGRAM_SETTINGS.calloms)* PROGRAM_SETTINGS.CELL_SIZE),"enemy 4 " + i);
            }
            

            castAdder.AddAirship(stage.midground,new Point(((PROGRAM_SETTINGS.calloms-1)/2)*PROGRAM_SETTINGS.CELL_SIZE,((PROGRAM_SETTINGS.rows-1)/2)*PROGRAM_SETTINGS.CELL_SIZE),"airship");
            // forground
            // menuBuilder.AddButton(stage.forground, new Point(100,100), new Point(200,50));


            // setup Actions
            // stage.ClearActions();


            stage.ClearActions();
            MouseMenuAction mouseMenu = new MouseMenuAction(MouseService, new InventoryMenu());

            stage.addActionToScript("control", new ControlActorAction(KeyboardService, VideoService));
            stage.addActionToScript("control", new enemybehavior());
            stage.addActionToScript("COLISHION", new CollideActorsAction(PhysicsService, AudioService, VideoService));
            stage.addActionToScript("COLISHION", new EnemyColideAction(PhysicsService, AudioService, VideoService));
            // stage.addActionToScript("COLISHION", new MouseInteracAction(MouseService));
            stage.addActionToScript("COLISHION", new removeBlockAction(MouseService));
            stage.addActionToScript("COLISHION", new addBlockAction(MouseService));
            stage.addActionToScript("COLISHION", new KeyboardAction(MouseService, new InventoryMenu(), KeyboardService, VideoService));

            // stage.addActionToScript("COLISHION", mouseMenu);
            // stage.addActionToScript("COLISHION",  new MouseObjectAction(MouseService));

            // stage.addActionToScript("menu", new TestClick(mouseMenu, new testClicker_attribute()));
            stage.addActionToScript("move", new MoveActor(VideoService));
            stage.addActionToScript("camera", new MoveCameraAction(VideoService));
            
            stage.addActionToScript("startDrawing", new StartDrawing(VideoService));
            stage.addActionToScript("drawforground", new DrawActorsBackground(VideoService));
            stage.addActionToScript("drawMidground", new DrawActorTexture(VideoService));
            stage.addActionToScript("end2dDraw", new End2dCamera(VideoService));
            stage.addActionToScript("drawBackground", new DrawActorsForground(VideoService));
            stage.addActionToScript("endDrawing", new EndDrawing(VideoService));
            stage.addActionToScript("changesen", new ChangeSceneAction(KeyboardService, "2"));
        }


        private void PrepareNextGame(Stage stage)
        {
            // AddStats(cast);
            // AddLevel(cast);
            // AddScore(cast);
            // AddLives(cast);
            // AddBall(cast);
            // AddBricks(cast);
            // AddRacket(cast);
            // AddPlayer(cast);
            // AddDialog(cast, PROGRAM_SETTINGS.ENTER_TO_START); 

            // AddStats(cast);
            // AddLevel(cast);
            // AddScore(cast);
            // AddLives(cast);
            // AddBall(cast);
            // AddBricks(cast);
            // AddRacket(cast);
            // AddPlayer(cast);
            // AddDialog(cast, PROGRAM_SETTINGS.ENTER_TO_START); 

            Actor player = null;
            
            if (stage.midground.GetFirstActor("player") != null)
            {
                player = stage.midground.GetFirstActor("player");

            }

            stage.ClearCast();

            // background
            Actor background = new Actor("background");
            background.AddAttribute(new AttributeBody(new Point(0,0), new Point(PROGRAM_SETTINGS.MAP_X,PROGRAM_SETTINGS.MAP_Y), 0));
            background.AddAttribute(new AttributeColor(PROGRAM_SETTINGS.GREEN));

            stage.background.AddActor("background", background);

            // midground
            if (player == null)
            {
                castAdder.AddPlayer(stage.midground, new Point(PROGRAM_SETTINGS.MAP_X/2,(PROGRAM_SETTINGS.MAP_Y/2)+256));
            }else
            {
                stage.midground.AddActor("player", player);
            }

            // for (int i = 0; i < 50; i++)
            // {
            //     // System.Console.WriteLine("sdf " + (PROGRAM_SETTINGS.MAP_X/PROGRAM_SETTINGS.CELL_SIZE));
            // // castAdder.Addrock(stage.midground, new Point(random.Next((PROGRAM_SETTINGS.MAP_X/PROGRAM_SETTINGS.CELL_SIZE) ) * PROGRAM_SETTINGS.CELL_SIZE, random.Next((PROGRAM_SETTINGS.MAP_Y/PROGRAM_SETTINGS.CELL_SIZE) ) * PROGRAM_SETTINGS.CELL_SIZE),"Rock " + i);
            // // castAdder.AddTree(stage.midground, new Point(random.Next((PROGRAM_SETTINGS.MAP_X/PROGRAM_SETTINGS.CELL_SIZE) ) * PROGRAM_SETTINGS.CELL_SIZE, random.Next((PROGRAM_SETTINGS.MAP_X/PROGRAM_SETTINGS.CELL_SIZE) ) * PROGRAM_SETTINGS.CELL_SIZE),"Tree " + i);
            // }
            addTrees(stage.midground, 20);
            addRocks(stage.midground, 50);



            
           
            castAdder.AddAirship(stage.midground,new Point(PROGRAM_SETTINGS.MAP_X/2,PROGRAM_SETTINGS.MAP_Y/2),"airship");
            // forground
            // menuBuilder.AddButton(stage.forground, new Point(100,100), new Point(200,50));


            // setup Actions
            // stage.ClearActions();


            stage.ClearActions();
            MouseMenuAction mouseMenu = new MouseMenuAction(MouseService, new InventoryMenu());

            stage.addActionToScript("control", new ControlActorAction(KeyboardService, VideoService));
            stage.addActionToScript("COLISHION", new CollideActorsAction(PhysicsService, AudioService, VideoService));
            stage.addActionToScript("COLISHION", new EnemyColideAction(PhysicsService, AudioService, VideoService));
            stage.addActionToScript("COLISHION", new MouseInteracAction(MouseService));
            stage.addActionToScript("COLISHION", new KeyboardAction(MouseService, new InventoryMenu(), KeyboardService, VideoService));
            // stage.addActionToScript("COLISHION", mouseMenu);
            // stage.addActionToScript("COLISHION",  new MouseObjectAction(MouseService));

            // stage.addActionToScript("menu", new TestClick(mouseMenu, new testClicker_attribute()));
            stage.addActionToScript("move", new MoveActor(VideoService));
            stage.addActionToScript("camera", new MoveCameraAction(VideoService));
            
            stage.addActionToScript("startDrawing", new StartDrawing(VideoService));
            stage.addActionToScript("drawforground", new DrawActorsBackground(VideoService));
            stage.addActionToScript("drawMidground", new DrawActorTexture(VideoService));
            stage.addActionToScript("end2dDraw", new End2dCamera(VideoService));
            stage.addActionToScript("drawBackground", new DrawActorsForground(VideoService));
            stage.addActionToScript("endDrawing", new EndDrawing(VideoService));
            stage.addActionToScript("changesen", new ChangeSceneAction(KeyboardService, PROGRAM_SETTINGS.NEW_GAME));
//             // Actor player = stage.midground.GetFirstActor("player");
// stage.ClearCast();

//             // background
//             Actor backdrop = new Actor("background");
//             backdrop.AddAttribute(new AttributeBody(new Point(0,0), new Point(10000,10000), 0));
//             backdrop.AddAttribute(new AttributeColor(PROGRAM_SETTINGS.PURPLE));

//             // stage.background.AddActor("background", backdrop);

//             // midground
            
//             castAdder.AddPlayer(stage.midground, new Point(0,0));
//             // stage.midground.AddActor("player", player);

//             castAdder.AddAirship(stage.midground,new Point(PROGRAM_SETTINGS.MAP_X/2,PROGRAM_SETTINGS.MAP_Y/2),"airship");
//             // castAdder.Addrock(stage.midground);



//             addRocks(stage.midground, 50);
            

//             // forground


//             // setup Actions
//             stage.ClearActions();

//             stage.addActionToScript("control", new ControlActorAction(KeyboardService, VideoService));
//             stage.addActionToScript("COLISHION", new CollideActorsAction(PhysicsService, AudioService, VideoService));
//             stage.addActionToScript("COLISHION", new MouseInteracAction(MouseService));
//             stage.addActionToScript("move", new MoveActor(VideoService));
//             stage.addActionToScript("camera", new MoveCameraAction(VideoService));
            
//             stage.addActionToScript("startDrawing", new StartDrawing(VideoService));
//             stage.addActionToScript("draw", new DrawActorsBackground(VideoService));
//             stage.addActionToScript("draw", new DrawActorTexture(VideoService));
//             stage.addActionToScript("end2dDraw", new End2dCamera(VideoService));
//             stage.addActionToScript("draw", new DrawActorsForground(VideoService));
//             stage.addActionToScript("endDrawing", new EndDrawing(VideoService));
//             stage.addActionToScript("changesen", new ChangeSceneAction(KeyboardService, PROGRAM_SETTINGS.NEW_GAME));
        }

        // -----------------------------------------------------------------------------------------
        // casting methods
        // -----------------------------------------------------------------------------------------

        private void addTrees(Cast cast, int amount)
        {
             for (int i = 0; i < amount; i++)
            {
                castAdder.AddTree(cast, new Point(random.Next((PROGRAM_SETTINGS.MAP_X/PROGRAM_SETTINGS.CELL_SIZE) ) * PROGRAM_SETTINGS.CELL_SIZE, random.Next((PROGRAM_SETTINGS.MAP_Y/PROGRAM_SETTINGS.CELL_SIZE) ) * PROGRAM_SETTINGS.CELL_SIZE), "Tree " + i);
            }
        }


        private void addRocks(Cast cast, int amount)
        {
             for (int i = 0; i < amount; i++)
            {
               castAdder.Addrock(cast, new Point(random.Next((PROGRAM_SETTINGS.MAP_X/PROGRAM_SETTINGS.CELL_SIZE) ) * PROGRAM_SETTINGS.CELL_SIZE, random.Next((PROGRAM_SETTINGS.MAP_Y/PROGRAM_SETTINGS.CELL_SIZE) ) * PROGRAM_SETTINGS.CELL_SIZE), "Rock " + i);
            }
        }

        private List<List<string>> LoadLevel(string filename)
        {
            List<List<string>> data = new List<List<string>>();
            using(StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string row = reader.ReadLine();
                    List<string> columns = new List<string>(row.Split(',', StringSplitOptions.TrimEntries));
                    data.Add(columns);
                }
            }
            return data;
        }

        // -----------------------------------------------------------------------------------------
        // scriptig methods
        // -----------------------------------------------------------------------------------------

        // private void AddInitActions(Script script)
        // {
        //     script.AddAction(Constants.INITIALIZE, new InitializeDevicesAction(AudioService, 
        //         VideoService));
        // }

        // private void AddLoadActions(Script script)
        // {
        //     script.AddAction(Constants.LOAD, new LoadAssetsAction(AudioService, VideoService));
        // }

        private void AddOutputActions(Stage stage)
        {
            // stage.addActionToScript(Constants.OUTPUT, new StartDrawingAction(VideoService));
            // stage.addActionToScript(Constants.OUTPUT, new DrawHudAction(VideoService));
            // stage.addActionToScript(Constants.OUTPUT, new DrawBallAction(VideoService));
            // stage.addActionToScript(Constants.OUTPUT, new DrawBricksAction(VideoService));
            // stage.addActionToScript(Constants.OUTPUT, new DrawRacketAction(VideoService));
            // stage.addActionToScript(Constants.OUTPUT, new DrawDialogAction(VideoService));
            // stage.addActionToScript(Constants.OUTPUT, new DrawPlayerAction(VideoService));
            // stage.addActionToScript(Constants.OUTPUT, new EndDrawingAction(VideoService));
        }

        private void AddUnloadActions(Stage stage)
        {
            // stage.addActionToScript(Constants.UNLOAD, new UnloadAssetsAction(AudioService, VideoService));
        }

        private void AddReleaseActions(Stage stage)
        {
            // stage.addActionToScript(Constants.RELEASE, new ReleaseDevicesAction(AudioService, 
            //     VideoService));
        }

        private void AddUpdateActions(Stage stage)
        {
            // stage.addActionToScript(Constants.UPDATE, new MoveBallAction());
            // stage.addActionToScript(Constants.UPDATE, new MoveRacketAction());
            // stage.addActionToScript(Constants.UPDATE, new MovePlayerAction());
            // stage.addActionToScript(Constants.UPDATE, new CollideBordersAction(PhysicsService, AudioService));
            // stage.addActionToScript(Constants.UPDATE, new CollideBrickAction(PhysicsService, AudioService));
            // stage.addActionToScript(Constants.UPDATE, new CollideRacketAction(PhysicsService, AudioService));
            // stage.addActionToScript(Constants.UPDATE, new CheckOverAction());     
        }
    }
}