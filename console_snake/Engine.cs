using System;
using console_snake.Entity;

namespace console_snake
{
    interface IEngine
    {
        void Init();
        void Run();
    }

    public class Engine : IEngine 
    {
        private MapRenderer _mapRenderer { get; set; }
        private Map _map { get; set; }
        private Player _player { get; set; }

        public void Init()
        {
            Console.SetWindowSize(40, 20);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
            this._map = new Map(10, 10);
            this._player = new Player(5,5,ConsoleColor.Green);
            _map.Entities.Add(_player);

            _mapRenderer = new MapRenderer(_map);
        }

        public void Run()
        {
            while (true)
            {
                this._mapRenderer.Render();
                if (Console.ReadKey().Key == ConsoleKey.A)
                {
                    this._player.Position.X -= 2;
                }
                else if (Console.ReadKey().Key == ConsoleKey.D)
                {
                    this._player.Position.X += 2;
                }
                else if (Console.ReadKey().Key == ConsoleKey.W)
                {
                    this._player.Position.Y += 1;
                }
                else if (Console.ReadKey().Key == ConsoleKey.S)
                {
                    this._player.Position.Y -= 1;
                }

            }
        }
    }
}