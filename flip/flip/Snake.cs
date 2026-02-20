using System.Collections.Generic;

namespace SnakeGame
{
    public class Snake
    {
        public LinkedList<Point> Body { get; private set; } = new LinkedList<Point>();
        public HashSet<int> BodySet { get; private set; } = new HashSet<int>();

        private int width;

        public Snake(int startX, int startY, int width)
        {
            this.width = width;

            for (int i = 0; i < 4; i++)
            {
                var p = new Point(startX - i, startY);
                Body.AddLast(p);
                BodySet.Add(ToKey(p.X, p.Y));
            }
        }

        public int ToKey(int x, int y) => x + y * (width + 2);
    }
}