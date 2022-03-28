namespace LocalLib.Types
{
    public class Texture
    {
        
        private Raylib_cs.Image image;
        private string TextureKey = "";
        public Texture(string PathToTexture)
        {
            image = Raylib_cs.Raylib.LoadImage(PathToTexture);
            bool exit = false;
            for (int i = PathToTexture.Length - 1; i > 0; i--)
            {
            // System.Console.WriteLine(PathToTexture[i] );
                if (PathToTexture[i] == '/')
                {
            // System.Console.WriteLine(PathToTexture.Length );
                    for (int j = i + 1; j < PathToTexture.Length; j++)
                    {
                        if (PathToTexture[j] == '.')
                        {
                            exit = true;
                            break;
                        }
                        if (!exit){
                        TextureKey += PathToTexture[j];
                        }
                    }

                }

                if(exit)
                {
                    break;
                }
            }
            System.Console.WriteLine(TextureKey);

        }

        public Raylib_cs.Image GetTexture()
        {
            return image;
        }
        public string GetTextureKey()
        {
            return TextureKey;
        }
        public void UnloadTexture()
        {
            Raylib_cs.Raylib.UnloadImage(image);
        }

        public void SetTexture(string PathToTexture)
        {
            this.image = Raylib_cs.Raylib.LoadImage(PathToTexture);
        }
    }
}