using LocalLib.Types;
using LocalLib;
using LocalLib.Casting;
using LocalLib.Scripting;


namespace BashCrafter.clickActions
{
    /// <summary>
    /// A thing that participates in the game.
    /// </summary>
    public class testClicker_attribute : MenuCallback
    {
        
        private string attributeKey = AttributeKey.testClicker_;
        private Actor button;
        private Actor other;

        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public testClicker_attribute()
        {
            setupActors();
        }

        public string GetAttributeKey()
        {
            return attributeKey;
        }
        public void OnNext(Cast cast, Actor actor = null)
        {

            cast.AddActor("button", button);
        } 

        public void removeOnNext(Cast cast)
        {
            cast.RemoveActor("button", button);
        }

        private void setupActors()
        {
            button = new Actor("button_play");
            button.AddAttribute(new AttributeBody(new Point(100,50), new Point(64,64)));
            button.AddAttribute(new AttributeTexture(TextureRegistry.TEXTURE_KEY_BUTTON_play));
            button.AddAttribute(new AttributeAnimated(new Point(34, 12), 3));

        }
    }
}