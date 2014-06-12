using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsAndCrossesConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Model.Board();
            var boardService = new Service.Board(board);

            //while (! boardService.HasWon())
            for (int i = 0; i < Settings.numberOfTiles; i++)
            {
                var player = boardService.GetNextPlayer();
                Console.WriteLine(string.Format("Your turn {0}, please enter a position:", player.Name));
                var position = Console.ReadLine();
                var tile = new Model.Tile { Postion = int.Parse(position), Player = player };
                if (boardService.IsValidTilePosition(tile))
                {
                    boardService.AddTile(tile);
                    if (boardService.HasWon()) 
                    { 
                        Console.WriteLine("WINNER!");
                        break;
                    }
                    Console.WriteLine(String.Format("Tile - Id: {0}, Position : {1}, Value : {2}", Service.Board.GetKey(), tile.Postion.ToString(), tile.Player.ShortName));
                }
                else
                {
                    Console.WriteLine("Bad Tile!");
                }
            }
            
        }
    }
}
