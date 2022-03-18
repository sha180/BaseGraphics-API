using System;
using System.Collections.Generic;
using System.IO;
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
            PROGRAM_SETTINGS.SCREEN_WIDTH, PROGRAM_SETTINGS.SCREEN_HEIGHT, PROGRAM_SETTINGS.BLACK);

        public static MouseService MouseService = new RaylibMouseService();
        public static PhysicsService PhysicsService = new RaylibPhysicsService();

        private bool debug = true;
        public SceneManager()
        {
        }

        public void PrepareScene(string scene, Cast cast, Script script)
        {
            if (scene == PROGRAM_SETTINGS.NEW_GAME)
            {
                PrepareNewGame(cast, script);
            }
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

        private void PrepareNewGame(Cast cast, Script script)
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

            Actor background = new Actor();
            background.AddAttribute(new AttributeBody(new Point(0,0), new Point(10000,10000), new Point(0,0)));
            background.AddAttribute(new AttributeColor(PROGRAM_SETTINGS.PURPLE));

            cast.AddActor("background", background);

            Actor actor = new Actor();
            actor.AddAttribute(new AttributeBody(new Point(0,0), new Point(100,100), new Point(0,0)));
            actor.AddAttribute(new AttributeColor(new Color(255,255,255)));
            actor.AddAttribute(new AttributeEntity());
            actor.AddAttribute(new AttributeCameraTrack());
            
            cast.AddActor("player", actor);


            Actor other = new Actor();
            other.AddAttribute(new AttributeBody(new Point(-100,-100), new Point(50,50), new Point(0,0)));
            other.AddAttribute(new AttributeColor(new Color(255,0,0)));
            other.AddAttribute(new AttributeStagePosition(StagePositon.midground, 1000));
            // other.AddAttribute(new AttributeEntity());
            // other.AddAttribute(new AttributeCameraTrack());
            
            cast.AddActor("player", other);


            script.ClearAllActions();

            script.AddAction("control", new ControlActorAction(KeyboardService));
            script.AddAction("draw", new DrawActorTexture(VideoService));
            script.AddAction("move", new MoveActor());
            script.AddAction("camera", new MoveCameraAction(VideoService));
            script.AddAction("COLISHION", new CollideActorsAction(PhysicsService, AudioService));

            // AddInitActions(script);
            // AddLoadActions(script);

            // ChangeSceneAction a = new ChangeSceneAction(KeyboardService, Constants.NEXT_LEVEL);
            // script.AddAction(Constants.INPUT, a);

            // AddOutputActions(script);
            // AddUnloadActions(script);
            // AddReleaseActions(script);
        }

        // private void ActivateBall(Cast cast)
        // {
        //     Ball ball = (Ball)cast.GetFirstActor(Constants.BALL_GROUP);
        //     ball.Release();
        // }

        private void PrepareNextLevel(Cast cast, Script script)
        {

            Actor background = new Actor();
            background.AddAttribute(new AttributeBody(new Point(0,0), new Point(10000,10000), new Point(0,0)));
            background.AddAttribute(new AttributeColor(PROGRAM_SETTINGS.PURPLE));
            background.AddAttribute(new AttributeStagePosition(StagePositon.background, 0));

            cast.AddActor("background", background);

            Actor actor = new Actor();
            actor.AddAttribute(new AttributeBody(new Point(0,0), new Point(100,100), new Point(0,0)));
            actor.AddAttribute(new AttributeColor(new Color(255,255,255)));
            actor.AddAttribute(new AttributeEntity());
            actor.AddAttribute(new AttributeCameraTrack());
            actor.AddAttribute(new AttributeStagePosition(StagePositon.midground, 100));
            
            cast.AddActor("player", actor);

            Actor other = new Actor();
            other.AddAttribute(new AttributeBody(new Point(0, 0), new Point(25,50), new Point(0,0)));
            other.AddAttribute(new AttributeColor(new Color(255,0,0)));
            // other.AddAttribute(new AttributeEntity());
            actor.AddAttribute(new AttributeStagePosition(StagePositon.midground));
            System.Console.WriteLine("OTHER");
            cast.AddActor("  n", other);

            script.ClearAllActions();

            script.AddAction("control", new ControlActorAction(KeyboardService));
            script.AddAction("draw", new DrawActorTexture(VideoService));
            script.AddAction("move", new MoveActor());
            script.AddAction("camera", new MoveCameraAction(VideoService));
        //     AddBall(cast);
        //     AddBricks(cast);
        //     AddRacket(cast);
        //     AddDialog(cast, Constants.PREP_TO_LAUNCH);

        //     script.ClearAllActions();

        //     TimedChangeSceneAction ta = new TimedChangeSceneAction(Constants.IN_PLAY, 2, DateTime.Now);
        //     script.AddAction(Constants.INPUT, ta);

        //     AddOutputActions(script);

        //     PlaySoundAction sa = new PlaySoundAction(AudioService, Constants.WELCOME_SOUND);
        //     script.AddAction(Constants.OUTPUT, sa);
        }

        // private void PrepareTryAgain(Cast cast, Script script)
        // {
        //     AddBall(cast);
        //     AddRacket(cast);
        //     AddDialog(cast, Constants.PREP_TO_LAUNCH);

        //     script.ClearAllActions();
            
        //     TimedChangeSceneAction ta = new TimedChangeSceneAction(Constants.IN_PLAY, 2, DateTime.Now);
        //     script.AddAction(Constants.INPUT, ta);
            
        //     AddUpdateActions(script);
        //     AddOutputActions(script);
        // }

        // private void PrepareInPlay(Cast cast, Script script)
        // {
        //     ActivateBall(cast);
        //     cast.ClearActors(Constants.DIALOG_GROUP);

        //     script.ClearAllActions();

        //     ControlRacketAction action = new ControlRacketAction(KeyboardService);
        //     script.AddAction(Constants.INPUT, new ControlPlayerAction(KeyboardService));
        //     script.AddAction(Constants.INPUT, action);

        //     AddUpdateActions(script);    
        //     AddOutputActions(script);
        
        // }

        
        // private void PrepareGameOver(Cast cast, Script script)
        // {
        //     AddBall(cast);
        //     AddRacket(cast);
        //     AddDialog(cast, Constants.WAS_GOOD_GAME);

        //     script.ClearAllActions();

        //     TimedChangeSceneAction ta = new TimedChangeSceneAction(Constants.NEW_GAME, 5, DateTime.Now);
        //     script.AddAction(Constants.INPUT, ta);

        //     AddOutputActions(script);
        // }

        // -----------------------------------------------------------------------------------------
        // casting methods
        // -----------------------------------------------------------------------------------------




        // private void AddBall(Cast cast)
        // {
        //     cast.ClearActors(Constants.BALL_GROUP);
        
        //     int x = Constants.CENTER_X - Constants.BALL_WIDTH / 2;
        //     int y = Constants.SCREEN_HEIGHT - Constants.RACKET_HEIGHT - Constants.BALL_HEIGHT;
        
        //     Point position = new Point(x, y);
        //     Point size = new Point(Constants.BALL_WIDTH, Constants.BALL_HEIGHT);
        //     Point velocity = new Point(0, 0);
        
        //     Body body = new Body(position, size, velocity);
        //     Image image = new Image(Constants.BALL_IMAGE);
        //     Ball ball = new Ball(body, image, debug);
        
        //     cast.AddActor(Constants.BALL_GROUP, ball);
        // }

        // private void AddBricks(Cast cast)
        // {
        //     cast.ClearActors(Constants.BRICK_GROUP);

        //     Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
        //     int level = stats.GetLevel() % Constants.BASE_LEVELS;
        //     string filename = string.Format(Constants.LEVEL_FILE, level);
        //     List<List<string>> rows = LoadLevel(filename);

        //     for (int r = 0; r < rows.Count; r++)
        //     {
        //         for (int c = 0; c < rows[r].Count; c++)
        //         {
        //             int x = Constants.FIELD_LEFT + c * Constants.BRICK_WIDTH;
        //             int y = Constants.FIELD_TOP + r * Constants.BRICK_HEIGHT;

        //             string color = rows[r][c][0].ToString();
        //             int frames = (int)Char.GetNumericValue(rows[r][c][1]);
        //             int points = Constants.BRICK_POINTS;

        //             Point position = new Point(x, y);
        //             Point size = new Point(Constants.BRICK_WIDTH, Constants.BRICK_HEIGHT);
        //             Point velocity = new Point(0, 0);
        //             List<string> images = Constants.BRICK_IMAGES[color].GetRange(0, frames);

        //             Body body = new Body(position, size, velocity);
        //             Animation animation = new Animation(images, Constants.BRICK_RATE, 1);
                    
        //             Brick brick = new Brick(body, animation, points, debug);
        //             cast.AddActor(Constants.BRICK_GROUP, brick);
        //         }
        //     }
        // }

        // private void AddDialog(Cast cast, string message)
        // {
        //     cast.ClearActors(Constants.DIALOG_GROUP);

        //     Text text = new Text(message, Constants.FONT_FILE, Constants.FONT_SIZE, 
        //         Constants.ALIGN_CENTER, Constants.WHITE);
        //     Point position = new Point(Constants.CENTER_X, Constants.CENTER_Y);

        //     Label label = new Label(text, position);
        //     cast.AddActor(Constants.DIALOG_GROUP, label);   
        // }

        // private void AddLevel(Cast cast)
        // {
        //     cast.ClearActors(Constants.LEVEL_GROUP);

        //     Text text = new Text(Constants.LEVEL_FORMAT, Constants.FONT_FILE, Constants.FONT_SIZE, 
        //         Constants.ALIGN_LEFT, Constants.WHITE);
        //     Point position = new Point(Constants.HUD_MARGIN, Constants.HUD_MARGIN);

        //     Label label = new Label(text, position);
        //     cast.AddActor(Constants.LEVEL_GROUP, label);
        // }

        // private void AddLives(Cast cast)
        // {
        //     cast.ClearActors(Constants.LIVES_GROUP);

        //     Text text = new Text(Constants.LIVES_FORMAT, Constants.FONT_FILE, Constants.FONT_SIZE, 
        //         Constants.ALIGN_RIGHT, Constants.WHITE);
        //     Point position = new Point(Constants.SCREEN_WIDTH - Constants.HUD_MARGIN, 
        //         Constants.HUD_MARGIN);

        //     Label label = new Label(text, position);
        //     cast.AddActor(Constants.LIVES_GROUP, label);   
        // }

        // private void AddRacket(Cast cast)
        // {
        //     cast.ClearActors(Constants.RACKET_GROUP);
        
        //     int x = Constants.CENTER_X - Constants.RACKET_WIDTH / 2;
        //     int y = Constants.SCREEN_HEIGHT - Constants.RACKET_HEIGHT;
        
        //     Point position = new Point(x, y);
        //     Point size = new Point(Constants.RACKET_WIDTH, Constants.RACKET_HEIGHT);
        //     Point velocity = new Point(0, 0);
        
        //     Body body = new Body(position, size, velocity);
        //     Animation animation = new Animation(Constants.RACKET_IMAGES, Constants.RACKET_RATE, 0);
        //     Racket racket = new Racket(body, animation, debug);
        
        //     cast.AddActor(Constants.RACKET_GROUP, racket);
        // }

        // private void AddPlayer(Cast cast)
        // {
        //     cast.ClearActors(Constants.PLAYER_GROUP);
        
        //     int x = Constants.CENTER_X - Constants.RACKET_WIDTH / 2;
        //     int y = Constants.SCREEN_HEIGHT - Constants.RACKET_HEIGHT;
        
        //     Point position = new Point(x, y);
        //     Point size = new Point(Constants.RACKET_WIDTH, Constants.RACKET_HEIGHT);
        //     Point velocity = new Point(0, 0);
        
        //     Body body = new Body(position, size, velocity);
        //     Animation animation = new Animation(Constants.RACKET_IMAGES, Constants.RACKET_RATE, 0);
        //     Racket racket = new Racket(body, animation, debug);
        
        //     cast.AddActor(Constants.PLAYER_GROUP, racket);
        // }

        // private void AddScore(Cast cast)
        // {
        //     cast.ClearActors(Constants.SCORE_GROUP);

        //     Text text = new Text(Constants.SCORE_FORMAT, Constants.FONT_FILE, Constants.FONT_SIZE, 
        //         Constants.ALIGN_CENTER, Constants.WHITE);
        //     Point position = new Point(Constants.CENTER_X, Constants.HUD_MARGIN);
            
        //     Label label = new Label(text, position);
        //     cast.AddActor(Constants.SCORE_GROUP, label);   
        // }

        // private void AddStats(Cast cast)
        // {
        //     cast.ClearActors(Constants.STATS_GROUP);
        //     Stats stats = new Stats();
        //     cast.AddActor(Constants.STATS_GROUP, stats);
        // }

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

        // private void AddOutputActions(Script script)
        // {
        //     script.AddAction(Constants.OUTPUT, new StartDrawingAction(VideoService));
        //     script.AddAction(Constants.OUTPUT, new DrawHudAction(VideoService));
        //     script.AddAction(Constants.OUTPUT, new DrawBallAction(VideoService));
        //     script.AddAction(Constants.OUTPUT, new DrawBricksAction(VideoService));
        //     script.AddAction(Constants.OUTPUT, new DrawRacketAction(VideoService));
        //     script.AddAction(Constants.OUTPUT, new DrawDialogAction(VideoService));
        //     script.AddAction(Constants.OUTPUT, new DrawPlayerAction(VideoService));
        //     script.AddAction(Constants.OUTPUT, new EndDrawingAction(VideoService));
        // }

        // private void AddUnloadActions(Script script)
        // {
        //     script.AddAction(Constants.UNLOAD, new UnloadAssetsAction(AudioService, VideoService));
        // }

        // private void AddReleaseActions(Script script)
        // {
        //     script.AddAction(Constants.RELEASE, new ReleaseDevicesAction(AudioService, 
        //         VideoService));
        // }

        // private void AddUpdateActions(Script script)
        // {
        //     script.AddAction(Constants.UPDATE, new MoveBallAction());
        //     script.AddAction(Constants.UPDATE, new MoveRacketAction());
        //     script.AddAction(Constants.UPDATE, new MovePlayerAction());
        //     script.AddAction(Constants.UPDATE, new CollideBordersAction(PhysicsService, AudioService));
        //     script.AddAction(Constants.UPDATE, new CollideBrickAction(PhysicsService, AudioService));
        //     script.AddAction(Constants.UPDATE, new CollideRacketAction(PhysicsService, AudioService));
        //     script.AddAction(Constants.UPDATE, new CheckOverAction());     
        // }
    }
}