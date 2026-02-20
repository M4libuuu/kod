using System;
using System.Threading;

namespace SnakeGame
{
    public class Game
    {
        private int width = 20;
        private int height = 20;
        private Snake snake;
        private Point food;
        private Random rnd = new Random();

        private int score = 0;
        private int speed = 120;
        private int dx = 1, dy = 0;
        private bool gameOver = false;

        private object lockObj = new object();

        public void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false;

            InitGame();

            Thread inputThread = new Thread(InputLoop)
            {
                IsBackground = true
            };
            inputThread.Start();

            Renderer.DrawBorder(width, height);
            Renderer.DrawScore(score, speed, height, width);

            while (!gameOver)
            {
                Thread.Sleep(speed);
                Update();
            }

            EndGame();
        }

        private void InitGame()
        {
            int startX = width / 2;
            int startY = height / 2;
            snake = new Snake(startX, startY, width);
        }

        private void InputLoop()
        {
            while (!gameOver)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;

                    if (key == ConsoleKey.W && dy != 1) { dx = 0; dy = -1; }
                    else if (key == ConsoleKey.S && dy != -1) { dx = 0; dy = 1; }
                    else if (key == ConsoleKey.A && dx != 1) { dx = -1; dy = 0; }
                    else if (key == ConsoleKey.D && dx != -1) { dx = 1; dy = 0; }
                    else if (key == ConsoleKey.Escape) gameOver = true;
                }
                else Thread.Sleep(10);
            }
        }

        private void Update()
        {
            // Tu przenosisz logikę z Update() z Twojego kodu
        }

        private void EndGame()
        {
            Console.SetCursorPosition(0, height + 3);
            Console.CursorVisible = true;
            Console.WriteLine($"\n💀 Game Over! Score: {score} 🏆");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }
    }
}