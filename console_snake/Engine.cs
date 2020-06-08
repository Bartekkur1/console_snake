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
        private bool _isRunning { get; set; } = true;
        private int _gameLoop { get; set; } = 150;
        private Food _food { get; set; }

        public void Init()
        {
            Console.SetWindowSize(40, 20);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
            this._map = new Map(20, 20);
            this._player = new Player(20,10,ConsoleColor.Green);
            this._player.SetSizeMap(this._map);
            this._food = new Food(0, 0, ConsoleColor.Red);
            this._food.RandomPos(this._map.Size.X, this._map.Size.Y);
            _map.Entities.Add(_food);
            _map.Entities.Add(_player);

            _mapRenderer = new MapRenderer(_map);
        }

        public void Run()
        {

            while (_isRunning)
            {
                _player.Move();
                if (_player.InvalidMove())
                {
                    this._isRunning = false;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Game Over");
                    break;
                }

                if (this._player.FoodColide(this._food))
                {
                    if (this._gameLoop > 50) _gameLoop -= 5;
                    _map.Entities.Add(this._player.TailGrow());
                    this._food.RandomPos(this._map.Size.X, this._map.Size.Y);
                }

                this._mapRenderer.Render();
                Thread.Sleep(_gameLoop);
                while (Console.KeyAvailable)
                {

                    var keyPressed = Console.ReadKey().Key;
                    _player.SetDirection(keyPressed);
                }
            }
        }
    }
}