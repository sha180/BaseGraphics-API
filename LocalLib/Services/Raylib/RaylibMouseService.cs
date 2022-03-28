using System.Collections.Generic;
using Raylib_cs;
using LocalLib.Types;


namespace LocalLib.Services
{
    public class RaylibMouseService : MouseService
    {
        private Dictionary<string, Raylib_cs.MouseButton> buttons
                = new Dictionary<string, Raylib_cs.MouseButton>() {
            { "left", Raylib_cs.MouseButton.MOUSE_LEFT_BUTTON },
            { "middle", Raylib_cs.MouseButton.MOUSE_MIDDLE_BUTTON },
            { "right", Raylib_cs.MouseButton.MOUSE_RIGHT_BUTTON }
        };

        /// </inheritdoc>
        public Point GetCoordinates()
        {
            int x = Raylib.GetMouseX();
            int y = Raylib.GetMouseY();
            return new Point(x, y);
        }

        /// </inheritdoc>
        public bool IsButtonDown(string button)
        {
            Raylib_cs.MouseButton raylibButton = buttons[button.ToLower()];
            return Raylib.IsMouseButtonDown(raylibButton);
        }

        /// </inheritdoc>
        public bool IsButtonPressed(string button)
        {
            Raylib_cs.MouseButton raylibButton = buttons[button.ToLower()];
            return Raylib.IsMouseButtonPressed(raylibButton);
        }

        /// </inheritdoc>
        public bool IsButtonReleased(string button)
        {
            Raylib_cs.MouseButton raylibButton = buttons[button.ToLower()];
            return Raylib.IsMouseButtonReleased(raylibButton);
        }

        /// </inheritdoc>
        public bool IsButtonUp(string button)
        {
            Raylib_cs.MouseButton raylibButton = buttons[button.ToLower()];
            return Raylib.IsMouseButtonUp(raylibButton);
        }
        
        public bool IsMouseOverBox(Types.Rectangle rectangle, Types.Point PosOffset)
        {
            Types.Point possition = rectangle.GetPosition();
            int x = possition.GetX() + (PROGRAM_SETTINGS.SCREEN_WIDTH/2 - PosOffset.GetX());
            int y = possition.GetY() + (PROGRAM_SETTINGS.SCREEN_HEIGHT)/2 - PosOffset.GetY();

            Types.Point size = rectangle.GetSize();
            int width = size.GetX();
            int height = size.GetY();
            // if (Raylib.mou)
            return Raylib_cs.Raylib.CheckCollisionPointRec(Raylib_cs.Raylib.GetMousePosition(), new Raylib_cs.Rectangle(x, y, width, height));
        }
        public bool IsMouseOverButton(Types.Rectangle rectangle)
        {
            Types.Point possition = rectangle.GetPosition();
            int x = possition.GetX();
            int y = possition.GetY();

            Types.Point size = rectangle.GetSize();
            int width = size.GetX();
            int height = size.GetY();
            // if (Raylib.mou)
            return Raylib_cs.Raylib.CheckCollisionPointRec(Raylib_cs.Raylib.GetMousePosition(), new Raylib_cs.Rectangle(x, y, width, height));
        }
    }
}