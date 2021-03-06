using LocalLib.Services;
using LocalLib.Types;


namespace LocalLib.Services
{
    public interface MouseService
    {
        /// <summary>
        /// Gets the current mouse cursor coordinates.
        /// </summary>
        /// <returns>The mouse cursor coordinates.</returns>
        Point GetCoordinates();

        /// <summary>
        /// Whether or not the given button is down.
        /// </summary>
        /// <param name="button">The given key.</param>
        bool IsButtonDown(string button);

        /// <summary>
        /// Whether or not the given button has been pressed.
        /// </summary>
        /// <param name="button">The given button.</param>
        bool IsButtonPressed(string button);

        /// <summary>
        /// Whether or not the given button has been released.
        /// </summary>
        /// <param name="button">The given button.</param>
        bool IsButtonReleased(string button);

        /// <summary>
        /// Whether or not the given button is up.
        /// </summary>
        /// <param name="button">The given button.</param>
        bool IsButtonUp(string button);

        
        bool IsMouseOverBox(Types.Rectangle rectangle, Types.Point PosOffset);

        
        bool IsMouseOverButton(Types.Rectangle rectangle);
    }
}