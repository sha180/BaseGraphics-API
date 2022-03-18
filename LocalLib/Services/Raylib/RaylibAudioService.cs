using System.Collections.Generic;
using System.IO;
using Raylib_cs;


namespace LocalLib.Services
{
    public class RaylibAudioService : AudioService
    {
        private Dictionary<string, Raylib_cs.Sound> sounds 
            = new Dictionary<string, Raylib_cs.Sound>();
        
        /// <summary>
        /// Constructs a new RaylibAudioService.
        /// </summary>
        public RaylibAudioService()
        {
        }

        /// </inheritdoc>
        public void Initialize()
        {
            Raylib.InitAudioDevice();
        }

        /// </inheritdoc>
        public void LoadSounds(string directory)
        {
            // List<string> filters = new List<string>() { "*.wav", "*.mp3", "*.acc", "*.wma" };
            // List<string> filepaths = GetFilepaths(directory, filters);
            // foreach (string filepath in filepaths)
            // {
            //     Raylib_cs.Sound sound = Raylib.LoadSound(filepath);
            //     sounds[filepath] = sound;
            // }
        }
        //  public void LoadImages(string directory)
        // {
        //     List<string> filters = new List<string>() { "*.png", "*.gif", "*.jpg", "*.jpeg", "*.bmp" };
        //     List<string> filepaths = GetFilepaths(directory, filters);
        //     foreach (string filepath in filepaths)
        //     {
        //         Raylib_cs.Texture2D texture = Raylib.LoadTexture(filepath);
        //         textures[filepath] = texture;
        //     }
        // }

        /// </inheritdoc>
        public void PlaySound(Types.Sound sound)
        {
            string filename = sound.GetFilename();
            
            if (!sounds.ContainsKey(filename))
            {
                Raylib_cs.Sound loaded = Raylib.LoadSound(filename);
                sounds[filename] = loaded;
            }

            if (sounds.ContainsKey(filename))
            {
                Raylib_cs.Sound raylibSound = sounds[filename];
                Raylib.PlaySound(raylibSound);
            }
        }

        /// </inheritdoc>
        public void Release()
        {
            Raylib.CloseAudioDevice();
        }

        /// </inheritdoc>
        public void UnloadSounds()
        {
            foreach (string filepath in sounds.Keys)
            {
                Raylib_cs.Sound raylibSound = sounds[filepath];
                sounds.Remove(filepath);
                Raylib.UnloadSound(raylibSound);
            }
        }

        private List<string> GetFilepaths(string directory, List<string> filters)
        {
            List<string> results = new List<string>();
            // foreach (string filter in filters)
            // {
            //     string[] filepaths = Directory.GetFiles(directory, filter);
            //     results.AddRange(filepaths);
            // }
            return results;
        }
    }
}