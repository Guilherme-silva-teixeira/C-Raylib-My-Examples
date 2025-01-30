using Raylib_cs;
using System.Numerics;

namespace main
{
    class Program
    {
        public static void Main(string[] args)
        {
            Raylib.InitWindow(300, 170, "Test tutorial");
            Raylib.SetTargetFPS(60);

            Rectangle button = new Rectangle(90, 70, 130, 50);

            int clicks = 0;

            while(!Raylib.WindowShouldClose())
            {

                Vector2 mouse = Raylib.GetMousePosition();

                bool mouseColl = Raylib.CheckCollisionPointRec(mouse, button);

                if(mouseColl)
                {
                    Raylib.DrawText("Hover", 70, 30, 23, Color.Black);

                    if (Raylib.IsMouseButtonPressed(MouseButton.Left))
                    {
                        clicks++;
                    }
                }

                Raylib.BeginDrawing();

                Raylib.ClearBackground(Color.White);

                Raylib.DrawRectangleLinesEx(button, 1, Color.Black);

                Raylib.DrawText("Clicks: " + clicks, 121, 130, 17, Color.Black);
                Raylib.DrawText("Click Here", (int)button.X + 25, (int)button.Y + 17, 17, Color.Black);

                Raylib.EndDrawing();
            }
        }
    }
}
