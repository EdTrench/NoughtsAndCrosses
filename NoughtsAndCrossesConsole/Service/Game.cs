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
            CreateTilesOnBoard();
        }

        public void TakeTurn()
        {
            int userInput;
            Model.Tile userTile;

            Console.Write(String.Format("Please take your turn {0}. Which Tile would you like? (0-8)", GetPlayer().Name));
            userInput = GetUserInput();
            userTile = _board.Tiles[userInput];
            if (userTile.Player == null)
            {
                userTile.Player = GetPlayer();
               _key++;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("This Tile has already been taken by {0}", userTile.Player.Name);
            }
            Console.WriteLine();
        }
        
        public void Display()
        {
            foreach (var tile in _board.Tiles)
            {
                Console.Write(String.Format("|{0}|",
                    (tile.Value.Player == null) ? tile.Key.ToString() : tile.Value.Player.ShortName.ToString()));
                if ((tile.Key + 1) % 3  == 0) {Console.WriteLine();}
            }
        }
        
        public bool HasWon()
        {
            var playerTiles = _board.Tiles.Where(x => x.Value.Player == GetPlayer());
            bool result = false;

            foreach (var tile in playerTiles)
            {
                return true;
            }
            return result;
        }

        private int GetUserInput()
        {
            return Convert.ToInt32(Console.ReadKey().KeyChar.ToString());
        }

        private void CreateTilesOnBoard()
        {
            for (int i = 0; i < Settings.numberOfTiles; i++)
            {
                _board.Tiles.Add(i, new Model.Tile());
            }
        }

        private Model.Player GetPlayer()
        {
            return (_key % 2) == 0 ? _player1 : _player2;
        }

    }
}
