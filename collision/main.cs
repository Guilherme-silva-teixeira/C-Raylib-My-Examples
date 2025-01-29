using Raylib_cs;

namespace HelloWorld;

class Program
{
    public static void Main()
    {
        Raylib.InitWindow(800, 480, "Hello World");
        Raylib.SetTargetFPS(60);
        Raylib.SetWindowPosition(100, 100);

        Rectangle rect0 = new Rectangle(0, 0, 100, 100);
        Rectangle rect1 = new Rectangle(333, 333, 100, 101);

        int coordX = 0;
        int coordY = 0;

        while (!Raylib.WindowShouldClose())
        {
            Raylib.ClearBackground(Color.White);

            if (Raylib.IsKeyDown(KeyboardKey.W))
                {
                coordY -= 1;
            }else if (Raylib.IsKeyDown(KeyboardKey.S))
            {
                coordY += 1;
            }else if (Raylib.IsKeyDown(KeyboardKey.A))
            {
                coordX -= 1;
            }else if(Raylib.IsKeyDown(KeyboardKey.D))
            {
                coordX += 1;
            }

            if(coordX >= 800)
            {
                coordX = 800;
            }else if(coordX <= 0)
            {
                coordX = 0;
            }else if(coordY >= 480)
            {
                coordY = 480;
            }else if(coordY <= 0)
            {
                coordY = 0;
            }

            rect0.X = coordX;
            rect0.Y = coordY;

            Raylib.DrawRectangleLinesEx(rect0, 1, Color.Black);
            Raylib.DrawRectangleLinesEx(rect1, 1, Color.Black);
            Raylib.DrawText("X: " +coordX + " Y: " + coordY, 0, 0,3, Color.Black);
            Raylib.DrawText("FPS:" + Raylib.GetFPS(), 0, 13, 3, Color.Black);
            
            if(Raylib.CheckCollisionRecs(rect0, rect1))
            {
                Raylib.DrawText("Collision Detected! Rect0, Rect1", 0, 27, 7, Color.Black);
            }
            else
            {
                Raylib.DrawText("Collision Not Detected!", 0, 27, 7, Color.Black);
            }
            
            Raylib.EndDrawing();

        }
        Raylib.CloseWindow();
    }
}
