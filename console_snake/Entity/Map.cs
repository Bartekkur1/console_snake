using System;
using System.Collections.Generic;

namespace console_snake.Entity
{
    public class Map
    {
        public List<Entity> Entities { get; set; }
        public Position Size { get; set; }

        public Map(int x , int y)
        {
            this.Size = new Position(x*2,y);
            this.Entities = new List<Entity>();
        }
    }
}