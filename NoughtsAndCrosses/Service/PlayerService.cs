using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoughtsAndCrosses.Model;

namespace NoughtsAndCrosses.Service
{
    class PlayerService
    {
        public void TakeTurn(Player player)
        {
            NoughtsAndCrossesBoardService noughtsAndCrossesBoardService = new NoughtsAndCrossesBoardService(player.Board);
            noughtsAndCrossesBoardService.HasWon();
        }
    }
}
