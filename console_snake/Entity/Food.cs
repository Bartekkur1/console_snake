using System;

namespace console_snake.Entity
{
    public class Food : Entity
    {
        public void RandomPos(int map_x, int map_y)
        {
            this.Position = Position.GenerateRandom(map_x - 2, map_y - 1, 1, 1);
            if (this.Position.X % 2 != 0)
            {
                this.Position.X++;
            }
        }

        public Food(int x, int y, ConsoleColor color) : base(x, y, color)
        {
        }
    }
}