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

        public void Move(ConsoleKey keyPressed)
        {
            switch (keyPressed)
            {
                case ConsoleKey.A:
                    Position.X -= 2;
                    break;
                case ConsoleKey.D:
                    Position.X += 2;
                    break;
                case ConsoleKey.W:
                    Position.Y -= 1;
                    break;
                case ConsoleKey.S:
                    Position.Y += 1;
                    break;
            }
        }
    }
}