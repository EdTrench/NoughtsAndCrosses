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
        
        Model.Board _board;
        Model.Player _player1;
        Model.Player _player2;

        public void Init()
        {
            _board = new Model.Board();
            _player1 = new Model.Player { Name = "Frederick", ShortName = 'X', Id = 1 };
            _player2 = new Model.Player { Name = "Edward", ShortName = 'O', Id = 2 };
            CreateTilesOnBoard();
        }

        public void TakeTurn()
        {
            int userInput;
            Model.Tile selectedTile;
            
            Console.Write(String.Format("Please take your turn {0}. Which Tile would you like? (0-8)", GetPlayer().Name));
            userInput = GetUserInput();
            selectedTile = _board.Tiles.Where(x => x.Id == userInput).Where(x => x.Player == null).SingleOrDefault();
            if (selectedTile != null)
            {
                selectedTile.Player = GetPlayer();
                if (HasWonRow() || HasWonColumn() || HasWonDiagonalLeft() || HasWonDiagonalRight())
                {
                    Console.WriteLine("WINNER!");
                }
                Model.Turn.key++;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("This Tile has already been taken by {0}", _board.Tiles[userInput].Player.Name);
            }
            Console.WriteLine();
        }
        
        public void Display()
        {
            foreach (var tile in _board.Tiles)
            {
                Console.Write(String.Format("|{0}|",
                    (tile.Player == null) ? "-" : tile.Player.ShortName.ToString()));
                if ((tile.Id + 1) % Settings.numberOfRowsAndColumns == 0) { Console.WriteLine(); }
            }
        }
        
        public bool HasWonRow()
        {
            int[] row = new int[Settings.numberOfRowsAndColumns];
            for (int i = 0; i < Settings.numberOfRowsAndColumns; i++)
            {
                for (int j = 0; j < Settings.numberOfRowsAndColumns; j++)
                {
                    row[j] = j + (i * Settings.numberOfRowsAndColumns);
                }
                var playersTiles = _board.Tiles.Where(x => x.Player == GetPlayer());
                return !row.Except(playersTiles.Select(x => x.Id)).Any();
            }
            return false;
        }

        public bool HasWonColumn()
        {
            int[] column = new int[Settings.numberOfRowsAndColumns];
            for (int i = 0; i < Settings.numberOfRowsAndColumns; i++)
            {
                for (int j = 0; j < Settings.numberOfRowsAndColumns; j++)
                {
                    column[j] = i + (j * Settings.numberOfRowsAndColumns);
                }
                var playersTiles = _board.Tiles.Where(x => x.Player == GetPlayer());
                return !column.Except(playersTiles.Select(x => x.Id)).Any();
            }
            return false;
        }

        public bool HasWonDiagonalLeft()
        {
            int[] diagonalLeft = new int[Settings.numberOfRowsAndColumns];
            for (int i = 0; i < Settings.numberOfRowsAndColumns; i++)
            {
                diagonalLeft[i] = (i * (Settings.numberOfRowsAndColumns + 1));
            }
            var playersTiles = _board.Tiles.Where(x => x.Player == GetPlayer());
            return !diagonalLeft.Except(playersTiles.Select(x => x.Id)).Any();
        }

        public bool HasWonDiagonalRight()
        {
            int[] diagonalRight = new int[Settings.numberOfRowsAndColumns];
            for (int i = 0; i < Settings.numberOfRowsAndColumns; i++)
            {
                diagonalRight[i] = ((i + 1) * (Settings.numberOfRowsAndColumns - 1));
            }
            var playersTiles = _board.Tiles.Where(x => x.Player == GetPlayer());
            return !diagonalRight.Except(playersTiles.Select(x => x.Id)).Any();
        }

        private int GetUserInput()
        {
            return Convert.ToInt32(Console.ReadKey().KeyChar.ToString());
        }

        private void CreateTilesOnBoard()
        {
            for (int i = 0; i < Settings.numberOfTiles; i++)
            {
                _board.Tiles.Add(new Model.Tile() { Id = i });
            }
        }

        private Model.Player GetPlayer()
        {
            return (Turn.key % 2) == 0 ? _player1 : _player2;
        }

    }
}
