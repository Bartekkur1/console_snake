using System;

namespace console_snake.Entity
{
    public class Food : Entity
    {
        public void RandomPos(Map map)
        {
            this.Position = Position.GenerateRandom(map.Size.X - 2, --map.Size.Y, 1, 1);
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