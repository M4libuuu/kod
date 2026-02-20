using System;

namespace SnakeGame
{
    public static class Renderer
    {
        public static void DrawBorder(int width, int height)
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("# ");
            for (int x = 1; x <= width; x++) Console.Write("# ");
            Console.WriteLine("# ");

            for (int y = 1; y <= height; y++)
            {
                Console.Write("# ");
                for (int x = 1; x <= width; x++) Console.Write("  ");
                Console.WriteLine("# ");
            }

            Console.Write("# ");
            for (int x = 1; x <= width; x++) Console.Write("# ");
            Console.WriteLine("# ");
        }

        public static void DrawAt(int x, int y, string c)
        {
            try
            {
                Console.SetCursorPosition(x * 2, y);
                Console.Write(c);
            }
            catch { }
        }

        public static void DrawScore(int score, int speed, int height, int width)
        {
            Console.SetCursorPosition(0, height + 1);
            Console.Write($"🏆 Score: {score}   ⚡ Speed: {Math.Max(1, 200 - speed)}   🎮 Move: W/A/S/D   ❌ Quit (Esc)"
                .PadRight(width * 2 + 4));
        }
    }
}