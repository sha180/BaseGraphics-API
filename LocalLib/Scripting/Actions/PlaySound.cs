using LocalLib.Casting;
using LocalLib.Types;
using LocalLib.Services;

namespace LocalLib.Scripting.Actions
{
    public class PlaySoundAction : Action
    {
        private AudioService audioService;
        private string filename;

        public PlaySoundAction(AudioService audioService, string filename)
        {
            this.audioService = audioService;
            this.filename = filename;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            // System.Console.WriteLine("exicute audio");
            Sound sound = new Sound(filename);
            audioService.PlaySound(sound);
            script.RemoveAction(Constants.OUTPUT, this);
        }
    }
}