using LocalLib.Casting;
using LocalLib.Services;
using LocalLib.Types;

namespace LocalLib.Scripting.Actions
{
    public class enemybehavior: Action
    {
        public enemybehavior()
        {}
        public void Execute(Cast forground, Cast midground, Cast background, Script script, ActionCallback callback = null)
        {
            foreach (Actor item in midground.GetAllActors())
            {
                string array = "";
                foreach (char CHAR in item.ActorKey)
                {
                    if( CHAR == ' ')
                    {
                        break;
                    }
                    else
                    {
                        array += CHAR;
                    }
                }
                if (array ==  "enemy")
                {
                if (item.HasAttribute(AttributeKey.body))
                {
                    
                //midground.GetFirstActor("airship")


                }
                }
            }
        }
    }
}