using System;

namespace console_snake.Entity
{
    abstract public class Entity
    {
        public Position Position { get; set; }

        public ConsoleColor Color { get; set; }

        public string Model = "  ";
    }
}
