using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoughtsAndCrossesConsole.Model;

namespace NoughtsAndCrossesConsole.Service
{
    class Board
    {
        Model.Board _board = new Model.Board();
        Model.Player _player1 = new Model.Player { Name = "Frederick", ShortName = 'F', Id = 1 };
        Model.Player _player2 = new Model.Player { Name = "Edward", ShortName = 'E', Id = 2 };
        static int _key;

        public Board(Model.Board board)
        {
            _board = board;
            _key = 0;
        }

        public void AddTile(Model.Tile tile)
        {
            _board.Tiles.Add(GetNextKey(), tile);
        }

        public bool ValidTilePosition(Model.Tile tile)
        {
            return ! _board.Tiles.Any(x => x.Value.Postion == tile.Postion);
        }

        public bool HasWon()
        {
            bool winner = false;
                        
            for (int i = 0; i < Settings.noOfRowsAndColumns; i++)
            {
                IList<int> row = new List<int>();
                for (int j = 0; j < Settings.noOfRowsAndColumns; j++)
                {
                    var position = j + (i * Settings.noOfRowsAndColumns);
                    row.Add(position);
                }

                //_board.Tiles.Where(x => x.Value.Player == GetPlayer()).Select(y => y.Value.Postion).Except(row);
                winner = ! row.Except(_board.Tiles.Where(x => x.Value.Player == GetPlayer()).Select(y => y.Value.Postion)).Any();
                Console.WriteLine(winner);
            //    foreach (var item in row)
            //    {
            //        Console.WriteLine(item);
            //    }
            //    foreach (var item in _board.Tiles.Where(x => x.Value.Player == GetPlayer()))
            //    {
            //        Console.WriteLine(String.Format("Player: {0}. Position {1}",  item.Value.Player.Name, item.Value.Postion));
            //    }
            }

            return winner;

        }

        private Player GetPlayer()
        {
            return (GetKey() % 2) == 0 ? _player1 : _player2;
        }

        public Player GetNextPlayer()
        {
            return (GetKey() % 2) == 0 ? _player2 : _player1;
        }

        public static int GetKey()
        {
            return _key;
        }

        private static int GetNextKey()
        {
            return _key++;
        }
    }
}
