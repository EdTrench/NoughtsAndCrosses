using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoughtsAndCrosses.Service;

namespace NoughtsAndCrosses.Model
{
    class NoughtsAndCrossesBoardListener
    {
        public void Subscribe(NoughtsAndCrossesBoard noughtsAndCrossesBoard)
        {
            foreach (NoughtsAndCrossesButton button in noughtsAndCrossesBoard.NoughtsAndCrossesButtons)
            {
                button.Click += new System.EventHandler(ClickedIt);
            }
             
        }

        private void ClickedIt(object sender, EventArgs e)
        {
            NoughtsAndCrossesBoard noughtsAndCrossesBoard = (NoughtsAndCrossesBoard)sender;
            NoughtsAndCrossesBoardService noughtsAndCrossesBoardService = new NoughtsAndCrossesBoardService(noughtsAndCrossesBoard);
            noughtsAndCrossesBoardService.HasWon();

        }
    }
}