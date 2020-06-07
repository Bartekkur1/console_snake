using System;

namespace console_snake.Entity
{
    public class Player : Entity
    {
        public Player(int x, int y, ConsoleColor color)
        {
            this.Position = new Position(x,y);
            this.Color = color;
        }
    }
}