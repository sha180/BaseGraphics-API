using LocalLib.Casting;
using LocalLib.Services;

namespace LocalLib.Scripting.Actions
{
    /// <summary>
    /// A thing that is done in the game.
    /// </summary>
    public class DrawActorTexture : Action
    {
        
        private VideoService videoService;
        
        public DrawActorTexture(VideoService videoService)
        {
            this.videoService = videoService;
        }

        /// <summary>
        /// Executes something that is important in the game. This method should be overriden by 
        /// derived classes.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        /// <param name="script">The script of actions.</param>
        public void Execute(Cast forground, Cast midground, Cast background, Script script, ActionCallback callback = null)
        {

            foreach (Actor item in midground.GetAllActors())
            {
                
                if (item.HasAttribute(AttributeKey.body))
                {
                    AttributeBody body = (AttributeBody) item.GetActorAttribute(AttributeKey.body);
                    
                    if(item.HasAttribute(AttributeKey.texture))
                    {
                        AttributeTexture texture = (AttributeTexture) item.GetActorAttribute(AttributeKey.texture);
                        
                        if (item.HasAttribute(AttributeKey.animated))
                        {
                            videoService.DrawImageAnimated(texture.GetTextureKey(), body.GetRectangle(), ((AttributeAnimated) item.GetActorAttribute(AttributeKey.animated)).TextureBounds, item.HasAttribute(AttributeKey.color) ? ((AttributeColor)item.GetActorAttribute(AttributeKey.color)).GetColor() : new Types.Color(255,255,255));
                        }else
                        {
                            
                            // System.Console.WriteLine(texture.GetTextureKey());
                            
                            videoService.DrawImage(texture.GetTextureKey(), body.GetRectangle(), item.HasAttribute(AttributeKey.color) ? ((AttributeColor)item.GetActorAttribute(AttributeKey.color)).GetColor() : new Types.Color(255,255,255));
                        }
                    }else{
                        // AttributeTexture texture = (AttributeTexture)item.GetActorAttribute(AttributeKey.texture);
                        videoService.DrawRectangle(body.GetSize(), body.GetPosition(), ((AttributeColor)item.GetActorAttribute(AttributeKey.color)).GetColor(), true);
                    }

                    // if(item.HasAttribute(AttributeKey.texture)){
                    //     AttributeTexture texture = (AttributeTexture)   item.GetActorAttribute(AttributeKey.texture);

                    //     if(item.HasAttribute(AttributeKey.animated))
                    //     {
                    //         videoService.DrawImageAnimated(  texture.GetTextureKey(), body.GetRectangle(), texture.TextureBounds, ((AttributeColor)item.GetActorAttribute(AttributeKey.color)).GetColor());
                    //     }
                    // }else
                    // { 
                    //     videoService.DrawRectangle(body.GetSize(), body.GetPosition(), ((AttributeColor)item.GetActorAttribute(AttributeKey.color)).GetColor(), true);
                    // }
                    // AttributeTexture texture = (AttributeTexture)item.GetActorAttribute(AttributeKey.texture);
                    }
            }
        }
    }
}