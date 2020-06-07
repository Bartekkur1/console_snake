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
        public bool IsRunning { get; set; } = true;

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
            while (IsRunning)
            {
                this._mapRenderer.Render();
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.A:
                        this._player.Position.X -= 2;
                        break;
                    case ConsoleKey.D:
                        this._player.Position.X += 2;
                        break;
                    case ConsoleKey.W:
                        this._player.Position.Y -= 1;
                        break;
                    case ConsoleKey.S:
                        this._player.Position.Y += 1;
                        break;
                }
            }
        }
    }
}