using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoughtsAndCrosses.Model;

namespace NoughtsAndCrosses.Service
{
    class NoughtsAndCrossesBoardService
    {
        private NoughtsAndCrossesBoard _noughtsAndCrossesBoard;

        public NoughtsAndCrossesBoardService(NoughtsAndCrossesBoard noughtsAndCrossesBoard)
        {
            _noughtsAndCrossesBoard = noughtsAndCrossesBoard;
        }

        public void HasWon()
        {
            //_noughtsAndCrossesBoard.NoughtsAndCrossesButtons.Where(x => x.)
            System.Windows.Forms.MessageBox.Show("has won?");
        }
    }
}
