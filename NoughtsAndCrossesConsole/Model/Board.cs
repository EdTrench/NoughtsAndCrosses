using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsAndCrossesConsole.Model
{
    class Board
    {
        public Dictionary<int, Model.Tile> Tiles { get; set; }

        public Board()
        {
            this.Tiles = new Dictionary<int, Model.Tile>();
        }
    }
}
