using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace console_snake.Entity
{
    public class Player : Entity
    {
        public PlayerDirection PlayerDirection { get; set; }
        public int Speed { get; set; } = 1;
        private Position _mapSize  { get; set; }
        public List<Tail> Tail { get; set; }
        public Player(int x, int y, ConsoleColor color) : base(x, y, color)
        {
            this.PlayerDirection = PlayerDirection.DOWN;
            this.Tail = new List<Tail>();
        }

        public void SetSizeMap(Map map)
        {
            this._mapSize = map.Size;
            this._mapSize.X--;
            this._mapSize.Y--;
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
            this.TailMove();

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

        public bool FoodColide(Food food)
        {
            return this.Position.Equals(food.Position);
        }

        public bool InvalidMove()
        {
            if (this.Position.X < 0) return true;
            if (this.Position.Y < 0) return true;
            if (this.Position.X > _mapSize.X) return true;
            if (this.Position.Y > _mapSize.Y) return true;
            if(this.Tail.Any(x => x.Position.Equals(this.Position))) return true;
            return false;
        }
        private void TailMove()
        {
            if (this.Tail.Count > 0)
            {
                this.Tail[0].SetPosition(new Position(this.Position));
                for (int i = 1; i < Tail.Count; i++)
                {
                    int j = i;
                    Tail[i].SetPosition(new Position(Tail[--j].OldPosition));
                }
            }
        }
        public Tail TailGrow()
        {
            Tail newTail = new Tail(new Position(this.Position), ConsoleColor.DarkGreen);
            this.Tail.Add(newTail);
            return newTail;
        }
    }
}