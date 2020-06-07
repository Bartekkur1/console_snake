using System;

namespace console_snake.Entity
{
    public class Tail : Entity
    {
        public Position OldPosition { get; set; }
        public Tail(Position position, ConsoleColor color) : base(position, color)
        {
        }

        public void SetPosition(Position position)
        {
            this.OldPosition = this.Position;
            this.Position = position;
        }
    }
}