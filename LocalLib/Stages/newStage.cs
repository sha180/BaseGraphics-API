using LocalLib.Casting;
using LocalLib.Scripting;

using System.Collections.Generic;


namespace LocalLib.Screens
{
    public class Stage
    {

        
        public Stage()
        {

        }

        public void GetInputs(Cast cast, Script script, string scriptKey)
        {
            foreach (Action item in script.GetActions(scriptKey))
            {
                item.Execute(cast, script);
            }
        }

    }
}