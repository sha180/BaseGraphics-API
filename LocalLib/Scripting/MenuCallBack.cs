using LocalLib.Casting;


namespace LocalLib.Scripting 
{
    /// <summary>
    /// A callback that can be used to trigger scene changes.
    /// </summary>
    public interface MenuCallback
    {
        /// <summary>
        /// Called when we need to transition from one scene to the next.
        /// </summary>
        /// <param name="sceneName">The next scene.</param>
        void OnNext(Cast cast, Actor actor = null);
        void removeOnNext(Cast cast);
    }
}