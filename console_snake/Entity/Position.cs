using System;

namespace console_snake.Entity
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static Position GenerateRandom(int max_x, int max_y, int min_x, int min_y)
        {
            Random random = new Random();
            return new Position(random.Next(min_x,max_x), random.Next(min_y, max_y));
        }
        public Position(Position position)
        {
            this.X = position.X;
            this.Y = position.Y;
        }
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
        public bool Equals(Position obj)
        {
            return this.X == obj.X && this.Y == obj.Y;
        }
    }
}