using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoughtsAndCrossesConsole.Model;

namespace NoughtsAndCrossesConsole.Service
{
    class Game
    {

        static int _key;

        Model.Board _board;
        Model.Player _player1;
        Model.Player _player2;

        public void Init()
        {
            _board = new Model.Board();
            _player1 = new Model.Player { Name = "Frederick", ShortName = 'X', Id = 1 };
            _player2 = new Model.Player { Name = "Edward", ShortName = 'O', Id = 2 };
        }

        public void Play()
        {
            _board.Tiles.Add(_key, new Model.Tile {
                Player = GetPlayer()
            });
            _board.Tiles.Select(x => x.Key == _key);
            _key++;
        }
        
        public void Display()
        {
            foreach (var tile in _board.Tiles)
            {
                Console.Write(String.Format("|{0}|", tile.Value.Player.ShortName));
                Console.WriteLine();
            }
        }

        private Model.Player GetPlayer()
        {
            return (_key % 2) == 0 ? _player1 : _player2;
        }

    }
}
