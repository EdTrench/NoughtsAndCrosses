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

        public bool IsValidTilePosition(Model.Tile tile)
        {
            if (IsPostionAlreadyTaken(tile)) return false;
            if (! IsPositionOnTheBoard(tile)) return false;
            return true;
        }

        public bool HasWon()
        {
            bool winner = false;
                        
            for (int i = 0; i < Settings.numberOfRowsAndColumns; i++)
            {
                IList<int> row = new List<int>();
                for (int j = 0; j < Settings.numberOfRowsAndColumns; j++)
                {
                    var position = j + (i * Settings.numberOfRowsAndColumns);
                    row.Add(position);
                }
                winner = ! row.Except(_board.Tiles.Where(x => x.Value.Player == GetPlayer()).Select(y => y.Value.Postion)).Any();
                if (winner) return winner;
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

        private bool IsPostionAlreadyTaken(Model.Tile tile)
        {
            return _board.Tiles.Any(x => x.Value.Postion == tile.Postion);
        }

        private bool IsPositionOnTheBoard(Model.Tile tile)
        {
            if (tile.Postion < 0) return false;
            if (tile.Postion > Settings.numberOfTiles) return false;
            return true;
        }
    }
}
