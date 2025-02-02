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

            Rectangle lettuce = new Rectangle(0, 0, 33, 33);
            Rectangle tomato = new Rectangle(0, 0, 33, 33);

            int lettuceTotal = 0;
            int tomatoTotal = 0;

            Texture2D lettuceTex = Raylib.LoadTexture("C:\\Users\\Shake\\Pictures\\lettuce.png");
            Texture2D chef = Raylib.LoadTexture("C:\\Users\\shake\\Pictures\\chef.png");

            if(!gameOver)
            {
                bool collisionWithLettuce = false;
                bool collisionWithTomato = false;

                lettuce.X = random.Next(Raylib.GetScreenWidth()-33);
                tomato.X = random.Next(Raylib.GetScreenWidth() - 33);

                while (!Raylib.WindowShouldClose())
                {

                    Raylib.BeginDrawing();
                    Raylib.ClearBackground(Color.White);

                    Raylib.DrawRectangleLinesEx(player, 1, Color.Black);

                    lettuce.Y += 1;
                    tomato.Y += 1;
                    
                    Raylib.DrawRectangleLinesEx(lettuce, 1, Color.Green);
                    Raylib.DrawRectangleLinesEx(tomato, 1, Color.Red);

                    if (Raylib.CheckCollisionRecs(player, lettuce))
                    {
                        collisionWithLettuce = true;
                        lettuce.Y = random.Next(33);
                        lettuce.X = random.Next(Raylib.GetScreenWidth() - 33);
                        lettuceTotal += 1;
                    }
                    else if (lettuce.Y >= Raylib.GetScreenHeight())
                    {
                        collisionWithLettuce = false;
                        lettuce.Y = random.Next(33);
                        lettuce.X = random.Next(Raylib.GetScreenWidth() - 33);
                        lettuceTotal += 0;
                    }

                    if (Raylib.CheckCollisionRecs(player, tomato))
                    {
                        collisionWithTomato = true;
                        tomato.Y = random.Next(99);
                        tomato.X = random.Next(Raylib.GetScreenWidth()-33);
                        tomatoTotal += 1;
                    }
                    else if(tomato.Y >= Raylib.GetScreenHeight())
                    {
                        collisionWithTomato = false;
                        tomato.Y = random.Next(99);
                        tomato.X = random.Next(Raylib.GetScreenWidth() - 33);
                        tomatoTotal += 0;
                    }

                    Raylib.DrawTextureEx(chef, new Vector2(player.X - 7, player.Y - 23), 0, 0.5f, Color.White);
                    Raylib.DrawTextureEx(lettuceTex, new Vector2(lettuce.X - 7, lettuce.Y - 1), 0, 1.1f, Color.White);

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

                    //debug

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Lettuce (X): " + lettuce.X);
                    Console.WriteLine("Lettuce (Y): " + lettuce.Y);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Player: (x)" + player.X);
                    Console.WriteLine("Player: (y)" + player.Y);
                    Console.ForegroundColor = ConsoleColor.Red;

                    Raylib.DrawText("Lettuce: " + lettuceTotal, 7, 7, 17, Color.Black);
                    Raylib.EndDrawing();
                }
                Raylib.UnloadTexture(chef);
                Raylib.CloseWindow();
            }
        }
              
    }
}
