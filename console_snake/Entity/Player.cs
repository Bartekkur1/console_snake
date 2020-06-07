using System;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace console_snake.Entity
{
    public class Player : Entity
    {
        public PlayerDirection PlayerDirection { get; set; }
        public int Speed { get; set; } = 1;
        public Player(int x, int y, ConsoleColor color)
        {
            this.Position = new Position(x,y);
            this.Color = color;
            this.PlayerDirection = PlayerDirection.DOWN;
        }

        public void SetDirection(ConsoleKey keyPressed)
        {
            switch (keyPressed)
            {
                case ConsoleKey.A:
                    this.PlayerDirection = PlayerDirection.LEFT;
                    break;
                case ConsoleKey.D:
                    this.PlayerDirection = PlayerDirection.RIGHT;
                    break;
                case ConsoleKey.W:
                    this.PlayerDirection = PlayerDirection.UP;
                    break;
                case ConsoleKey.S:
                    this.PlayerDirection = PlayerDirection.DOWN;
                    break;
            }
        }

        public void Move()
        {
            switch (this.PlayerDirection)
            {
                case PlayerDirection.LEFT:
                    Position.X -= Speed * 2;
                    break;
                case PlayerDirection.RIGHT:
                    Position.X += Speed * 2;
                    break;
                case PlayerDirection.UP:
                    Position.Y -= Speed;
                    break;
                case PlayerDirection.DOWN:
                    Position.Y += Speed;
                    break;
            }
        }

        public bool OutOfBounds(Map map)
        {
            if (this.Position.X < 0) return true;
            if (this.Position.Y < 0) return true;
            if (this.Position.X > map.Size.X-1) return true;
            if (this.Position.Y > map.Size.Y-1) return true;
            return false;
        }
    }
}