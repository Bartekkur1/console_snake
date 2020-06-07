using System;

namespace console_snake.Entity
{
    abstract public class Entity
    {
        public Position Position { get; set; }

        public ConsoleColor Color { get; set; }

        public string Model = "  ";

        protected Entity(Position position, ConsoleColor color)
        {
            Position = position;
            Color = color;
        }

        protected Entity(int x, int y, ConsoleColor color)
        {
            this.Position = new Position(x, y);
            this.Color = color;
        }
        protected Entity()
        {
        }
    }
}
