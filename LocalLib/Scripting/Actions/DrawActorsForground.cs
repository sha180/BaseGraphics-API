using LocalLib.Casting;
using LocalLib.Services;
using LocalLib.Types;

namespace LocalLib.Scripting.Actions
{
    /// <summary>
    /// A thing that is done in the game.
    /// </summary>
    public class DrawActorsForground : Action
    {
        
        private VideoService videoService;
        
        public DrawActorsForground(VideoService videoService)
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
            foreach (Actor item in forground.GetAllActors())
            {
                if (item.HasAttribute(AttributeKey.body))
                {
                    // AttributeTexture texture = (AttributeTexture)item.GetActorAttribute(AttributeKey.texture);
                    AttributeBody body = (AttributeBody) item.GetActorAttribute(AttributeKey.body);
                    // videoService.DrawRectangle(body.GetSize(), body.GetPosition(), ((AttributeColor)item.GetActorAttribute(AttributeKey.color)).GetColor(), true);
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
                    
                    if(item.HasAttribute(ItemAttributeKey.Stack))
                    {
                        ItemStack stack = (ItemStack) item.GetActorAttribute(ItemAttributeKey.Stack);
                        Point position = body.GetPosition();//stack.StackSize.ToString()
                        Point newPoint = new Point(position.x,position.y);

                        newPoint.x = body.GetSize().x + 20 + position.x;
                        Text text = new Text(stack.StackSize.ToString(), PROGRAM_SETTINGS.FONT_FILE, 48, 0,
                            item.HasAttribute(AttributeKey.color) ? ((AttributeColor)item.GetActorAttribute(AttributeKey.color)).GetColor() : new Types.Color(255,255,255));
                        videoService.DrawText(text, newPoint);
                    }
                }
            }
        }
    }
}