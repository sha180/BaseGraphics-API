
using LocalLib.Casting;
using LocalLib.Services;
using LocalLib.Types;
using System.Collections.Generic;


namespace LocalLib.Scripting.Actions
{

    
    /// <summary>
    /// A thing that is done in the game.
    /// </summary>
    public class KeyboardAction : Action
    {
        private VideoService videoService;
        private KeyboardService keyboardService;
        private MouseService mouseService;
        MenuCallback menucallback;
        public KeyboardAction(MouseService mouseService, MenuCallback menucallback, KeyboardService keyboardService, VideoService videoService)
        {
            this.videoService = videoService;
            this.keyboardService = keyboardService;
            this.mouseService = mouseService;
            this.menucallback = menucallback;
        }

        /// <summary>
        /// Executes something that is important in the game. This method should be overriden by 
        /// derived classes.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        /// <param name="script">The script of actions.</param>
            // bool mouseOverObject = false;

        public Dictionary<string, bool>  mouseOverObject = new Dictionary<string, bool>();
        bool togal = false;
                    AttributeClickable clickable =  new AttributeClickable();
        public void Execute(Cast forground, Cast midground, Cast background, Script script, ActionCallback callback = null)
        {
                            if(keyboardService.IsKeyPressed("e"))
                            {
                                
                                    clickable.clickState = true;
                                    clickable.toggalSwitch();
                        System.Console.WriteLine($"Ekey  = {clickable.getSwitch()}");
                                if (clickable.getSwitch()){
                                    menucallback.OnNext(forground, midground.GetFirstActor("player"));
                                }else if(clickable.getPREVEUS_State())
                                {
                                    
                                    menucallback.removeOnNext(forground);
                                }
                            }

                            if(keyboardService.IsKeyPressed("escape"))
                            {
                                
                                    clickable.clickState = true;
                                    clickable.toggalSwitch();
                                System.Console.WriteLine($"Ekey  = {clickable.getSwitch()}");
                                
                                if(clickable.getPREVEUS_State())
                                {
                                    
                                    menucallback.removeOnNext(forground);
                                }
                            }
                        


                        // animated.TextureBounds.position.x = (animated.TextureBounds.size.x*animated.currentFrame);
                        // mouseOverObject[item.ActorKey] = true;
                        
                    
                

            // }
        }
    }
}