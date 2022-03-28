using LocalLib.Casting;
using LocalLib.Scripting;

using System.Collections.Generic;


namespace LocalLib.Screens
{
    public class Stage
    {

        public Cast forground = new Cast();
        public Cast midground = new Cast();
        public Cast background = new Cast();
        public Cast Menu = new Cast();
        private Script script = new Script();
        private List<string> scripKeys = new List<string>(); 

        string GUI = "none";
        public Stage()
        {

        }

        public void GetInputs(ActionCallback callback)
        {
            // foreach(string key in scripKeys)
            // {
            for (int i = 0; i < scripKeys.Count; i++)
            {
                foreach (Action item in script.GetActions(scripKeys[i]))
                {
                    item.Execute(forground, midground, background, script, callback);
                }
            }
        }

        public void addActionToScript(string group, Action action)
        {
            scripKeys.Add(group);
            script.AddAction(group, action);

        }

        public void ClearActions()
        {
            script.ClearAllActions();
        }
        public void ClearCast()
        {
            forground.clearCast();
            midground.clearCast();
            background.clearCast();
        }
        
    }
}