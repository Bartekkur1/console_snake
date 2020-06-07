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

        public void Move(ConsoleKey keyPressed, int speed)
        {
            switch (keyPressed)
            {
                case ConsoleKey.A:
                    Position.X -= speed * 2;
                    break;
                case ConsoleKey.D:
                    Position.X += speed * 2;
                    break;
                case ConsoleKey.W:
                    Position.Y -= speed;
                    break;
                case ConsoleKey.S:
                    Position.Y += speed;
                    break;
            }
        }
    }
}