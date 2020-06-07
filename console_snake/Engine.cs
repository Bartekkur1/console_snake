using System;
using System.Threading;
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
        public int GameLoop { get; set; } = 200;

        public void Init()
        {
            Console.SetWindowSize(40, 20);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
            this._map = new Map(20, 20);
            this._player = new Player(20,10,ConsoleColor.Green);
            _map.Entities.Add(_player);

            _mapRenderer = new MapRenderer(_map);
        }

        public void Run()
        {

            while (IsRunning)
            {
                _player.Move();
                if (_player.OutOfBounds(this._map))
                {
                    this.IsRunning = false;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Game Over");
                    break;
                }
                this._mapRenderer.Render();
                Thread.Sleep(GameLoop);
                while (Console.KeyAvailable)
                {

                    var keyPressed = Console.ReadKey().Key;
                    _player.SetDirection(keyPressed);
                }
            }
        }
    }
}