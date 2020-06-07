using System;
using System.Linq;
using console_snake.Entity;

namespace console_snake
{
    interface IMapRendered
    {
        void Render();
    }
    public class MapRenderer : IMapRendered
    {
        private Map _map { get; set; }

        public MapRenderer(Map map)
        {
            _map = map;
        }

        public void Render()
        {
            #region Version1
            //for (int y = 0; y < _map.Size.Y; y++)
            //{
            //    for (int x = 0; x < _map.Size.X; x++)
            //    {
            //        //Console.BackgroundColor = ConsoleColor.Green;
            //        if (this._map.Entities.Any(e => e.Position.X == x && e.Position.Y == y))
            //        {
            //            Console.BackgroundColor =
            //                this._map.Entities.Find(e => e.Position.X == x && e.Position.Y == y).Color;
            //        }
            //        else
            //        {
            //            Console.BackgroundColor = ConsoleColor.Black;
            //        }

            //        Console.Write("  ");
            //    }
            //    Console.WriteLine();
            //}


            #endregion
             
            //Version 2
            Console.Clear();
            this._map.Entities.ForEach(e =>
            {
                Console.SetCursorPosition(e.Position.X,e.Position.Y);
                Console.BackgroundColor = e.Color;
                Console.Write(e.Model);
                Console.BackgroundColor = ConsoleColor.Black;
            });
        }
    }
}