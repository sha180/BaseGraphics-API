using LocalLib.Casting;
using LocalLib.Services;


namespace LocalLib.Scripting
{
    public class ChangeSceneAction : Action
    {
        private KeyboardService keyboardService;
        private string nextScene;

        public ChangeSceneAction(KeyboardService keyboardService, string nextScene)
        {
            this.keyboardService = keyboardService;
            this.nextScene = nextScene;
        }

        public void Execute(Cast forground, Cast midground, Cast background, Script script, ActionCallback callback)
        {
            if (keyboardService.IsKeyPressed("enter"))
            {
                callback.OnNext(nextScene);
            }
        }
    }
}