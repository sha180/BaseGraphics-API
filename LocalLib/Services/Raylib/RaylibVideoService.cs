using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Runtime.CompilerServices;
using Raylib_cs;


namespace LocalLib.Services
{
    public class RaylibVideoService : VideoService
    {
        private Types.Color color;
        private int height;
        private string title;
        private int width;
        private bool debug = false;
        private bool CameraTracking = true;
        Camera2D camera;
        private Dictionary<string, Raylib_cs.Font> fonts
            = new Dictionary<string, Raylib_cs.Font>();
        
        private Dictionary<string, Raylib_cs.Texture2D> textures
            = new Dictionary<string, Raylib_cs.Texture2D>();
        
        public RaylibVideoService(string title, int width, int height, Types.Color color, bool debug = false)
        {
            this.title = title;
            this.width = width;
            this.height = height;
            this.color = color;
            this.camera = new Camera2D();
            
        }

        public void loadTextures(List<Types.Texture> TextureList)
        {
            foreach (Types.Texture item in TextureList)
            {
                textures.Add(item.GetTextureKey(), Raylib.LoadTextureFromImage(item.GetTexture()));
                item.UnloadTexture();
            } 
        }

        /// </inheritdoc>
        public void ClearBuffer()
        {
            Raylib_cs.Color background = ToRaylibColor(color);
            Raylib.BeginDrawing();
            Raylib.ClearBackground(background);
            DrawGrid();
            if (CameraTracking)
            {
                Raylib.BeginMode2D(camera);
            }
        }


        public float GetDeltaTime()
        {
            return Raylib.GetFrameTime();
        }

        /// </inheritdoc>
        public void DrawImage(string textureKey, Types.Rectangle body, Types.Color color)
        {
            // string filename = image.GetFilename();
            // if (!textures.ContainsKey(filename))
            // {
            //     Raylib_cs.Texture2D loaded = Raylib.LoadTexture(filename);
            //     textures[filename] = loaded;
            // }
            // System.Console.WriteLine($"file name: {filename} graphics");
            Raylib_cs.Texture2D texture = textures[textureKey];
            
            Raylib.DrawTexturePro(texture, new Raylib_cs.Rectangle(0,0, texture.width, texture.height), toRaylibRectangle(body),new Vector2(0,0), 0, ToRaylibColor(color));
        }

        /// </inheritdoc>
        public void DrawImageAnimated(string textureKey, Types.Rectangle body, Types.Rectangle texturebounds, Types.Color color)
        {
            Raylib_cs.Texture2D texture = textures[textureKey];
            
            Raylib.DrawTexturePro(texture, toRaylibRectangle(texturebounds), toRaylibRectangle(body), new Vector2(0,0), 0, ToRaylibColor(color));
        }
        /// </inheritdoc>
        public void DrawRectangle(Types.Point size, Types.Point position, Types.Color color,
            bool filled = false)
        {
            int x = position.GetX();
            int y = position.GetY();
            int width = size.GetX();
            int height = size.GetY();
            Raylib_cs.Color raylibColor = ToRaylibColor(color);

            if (filled)
            {
                Raylib.DrawRectangle(x, y, width, height, raylibColor);
            }
            else
            {
                Raylib.DrawRectangleLines(x, y, width, height, raylibColor);
            }
        }

        /// </inheritdoc>
        public void DrawText(Types.Text text, Types.Point position)
        {
            string value = text.GetValue();
            int size = text.GetSize();
            int alignment = text.GetAlignment();
            Types.Color color = text.GetColor();
            int x = position.GetX();
            int y = position.GetY();
            
            string filename = text.GetFontFile();
            if (!fonts.ContainsKey(filename))
            {
                Raylib_cs.Font loaded = Raylib.LoadFont(filename);
                fonts[filename] = loaded;
            }
            Raylib_cs.Font font = fonts[filename];

            x = RecalcuteTextPosition(font, value, size, x, alignment);
            Raylib_cs.Color raylibColor = ToRaylibColor(color);
            Vector2 vector = new Vector2(x, y);
            Raylib.DrawTextEx(font, value, vector, size, 5, raylibColor);
        }

        /// </inheritdoc>
        public void FlushBuffer()
        {
            Raylib.EndDrawing(); 
        }

        /// </inheritdoc>
        public void Initialize()
        {
            Raylib.InitWindow(width, height, title);
            Raylib.SetTargetFPS(PROGRAM_SETTINGS.FRAME_RATE);
            Raylib.SetExitKey(0);  

        }
        

        public void End2dMap()
        {
            
            Raylib.EndMode2D();
        }

        /// </inheritdoc>
        public void UpdateCameraPosition(Types.Point possition, Types.Point size, Types.Point offset)
        {
            Types.Point pos = possition;
            pos.Add( new Types.Point(pos.GetX() + (size.GetX()/2), pos.GetY() + (size.GetY()/2)));
            Vector2 Vpos = pos.ToVector2();

            camera.target = Vpos;
            camera.offset = offset.ToVector2();
            camera.rotation = 0.0f;
            camera.zoom = 1.0f;
        }

        /// </inheritdoc>
        public bool IsWindowOpen()
        {
            return !Raylib.WindowShouldClose();
        }

        /// </inheritdoc>
        public void LoadFonts(string directory)
        {
            List<string> filters = new List<string>() { "*.otf", "*.ttf" };
            List<string> filepaths = GetFilepaths(directory, filters);
            foreach (string filepath in filepaths)
            {
                Raylib_cs.Font font = Raylib.LoadFont(filepath);
                fonts[filepath] = font;
            }
        }

        /// </inheritdoc>
        public void LoadImages(string directory)
        {
            List<string> filters = new List<string>() { "*.png", "*.gif", "*.jpg", "*.jpeg", "*.bmp" };
            List<string> filepaths = GetFilepaths(directory, filters);
            foreach (string filepath in filepaths)
            {
                System.Console.WriteLine($"file name: {filepath} graphics");
                Raylib_cs.Texture2D texture = Raylib.LoadTexture(filepath);
                textures[filepath] = texture;
            }
        }

        /// </inheritdoc>
        public void Release()
        {
            Raylib.CloseWindow();
        }

        /// </inheritdoc>
        public void UnloadFonts()
        {
            foreach (string key in fonts.Keys)
            {
                Raylib_cs.Font font = fonts[key];
                Raylib.UnloadFont(font);
            }
        }

        /// </inheritdoc>
        public void UnloadImages()
        {
            foreach (string key in textures.Keys)
            {
                Raylib_cs.Texture2D texture = textures[key];
                Raylib.UnloadTexture(texture);
            }
        }

        private List<string> GetFilepaths(string directory, List<string> filters)
        {
            List<string> results = new List<string>();
            foreach (string filter in filters)
            {
                string[] filepaths = Directory.GetFiles(directory, filter,  SearchOption.TopDirectoryOnly);
                int other =  filepaths.GetLength(0);
                results.AddRange(filepaths);
            }
            return results;
        }

        private int RecalcuteTextPosition(Font font, string text, int size, int x, int alignment)
        {
            int width = (int)Raylib.MeasureTextEx(font, text, size, 0).X;
            if (alignment == 0)
            {
                x = x - (width / 2);
            }
            else if (alignment == 1)
            {
                x = x - width;
            }
            return x;
        }

        private Raylib_cs.Color ToRaylibColor(Types.Color color)
        {
            return new Raylib_cs.Color(color.GetRed(), color.GetGreen(), color.GetBlue(), color.GetAlpha()
                // System.Convert.ToByte(255)
                );
        }
        private Raylib_cs.Rectangle toRaylibRectangle(Types.Rectangle rectangle)
        {
            int x = rectangle.GetPosition().GetX();
            int y = rectangle.GetPosition().GetY();
            int width = rectangle.GetSize().GetX();
            int height = rectangle.GetSize().GetY();

            return new Rectangle(x,y,width,height);
        }
        public void DrawGrid()
        {
            if (true)
            {
            for (int x = 0; x < PROGRAM_SETTINGS.MAP_X; x += PROGRAM_SETTINGS.CELL_SIZE)
            {
                Raylib.DrawLine(x, 0, x, PROGRAM_SETTINGS.MAP_Y, Raylib_cs.Color.GRAY);
            }
            for (int y = 0; y < PROGRAM_SETTINGS.MAP_Y; y += PROGRAM_SETTINGS.CELL_SIZE)
            {
                Raylib.DrawLine(0, y, PROGRAM_SETTINGS.MAP_X, y, Raylib_cs.Color.GRAY);
            }
            }
        }
        public void SetCameraTracking(bool enable)
        {
            CameraTracking = enable;
        }
    }
}