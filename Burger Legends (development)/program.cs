using Raylib_cs;
using System.Numerics;

namespace BurgerLegends
{
    class Program
    {
        public static void Main(string[] args)
        {
            bool gameOver = false;

            Raylib.InitWindow(480, 640, "Burger Legends!");
            Raylib.SetTargetFPS(60);

            Random random = new Random();

            Rectangle player = new Rectangle(0, 551, 59, 93);

            Rectangle ing1 = new Rectangle(0, 0, 33, 33);

            Texture2D chef = Raylib.LoadTexture("C:\\Users\\shake\\Pictures\\chef.png");

            if(!gameOver)
            {
                bool collisionWithLettuce = false;

                ing1.X = random.Next(480);

                while (!Raylib.WindowShouldClose())
                {
                    Raylib.BeginDrawing();
                    Raylib.ClearBackground(Color.White);

                    Raylib.DrawRectangleLinesEx(player, 1, Color.Black);

                    ing1.Y += 1;

                    Raylib.DrawRectangleLinesEx(ing1, 1, Color.Green);

                    if(Raylib.CheckCollisionRecs(player, ing1)||ing1.Y >= Raylib.GetScreenHeight())
                    {
                        collisionWithLettuce = true;
                        ing1.Y = 0;
                        ing1.X = random.Next(457);
                    }

                    Raylib.DrawTextureEx(chef, new Vector2(player.X - 7, player.Y - 23), 0, 0.5f, Color.White);

                    if (Raylib.IsKeyDown(KeyboardKey.A))
                    {
                        player.X -= 10;
                    }
                    else if (Raylib.IsKeyDown(KeyboardKey.D))
                    {
                        player.X += 10;
                    }

                    if (player.X <= 0)
                    {
                        player.X = 0;
                    }
                    else if (player.X + player.Width > Raylib.GetScreenWidth())
                    {
                        player.X = Raylib.GetScreenWidth() - player.Width;
                    }

                    Raylib.EndDrawing();
                }
                Raylib.UnloadTexture(chef);
                Raylib.CloseWindow();
            }
        }
              
    }
}
