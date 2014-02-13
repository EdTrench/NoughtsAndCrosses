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

		public void HasWon(NoughtsAndCrossesBoard noughtsAndCrossesBoard)
		{
			for (int i = 1; i <= Settings.noOfRows; i++)
			{
                var start = (i * Settings.noOfRows) - (Settings.noOfRows - 1) - 1;
                var row = _noughtsAndCrossesBoard.NoughtsAndCrossesButtons.GetRange(start, Settings.noOfRows);
                if (IsRowWinner(row)) {System.Windows.Forms.MessageBox.Show("Winner");}

			}
			
			for (int i = 1; i <= Settings.noOfColumns; i++)
			{
                IList<NoughtsAndCrossesButton> column = new List<NoughtsAndCrossesButton>();
                column.Add(_noughtsAndCrossesBoard.NoughtsAndCrossesButtons.ElementAt(i - 1));
                column.Add(_noughtsAndCrossesBoard.NoughtsAndCrossesButtons.ElementAt((i - 1) + Settings.noOfRows));
                column.Add(_noughtsAndCrossesBoard.NoughtsAndCrossesButtons.ElementAt((i - 1) + (Settings.noOfRows * i)));
                if (IsRowWinner(column)) { System.Windows.Forms.MessageBox.Show("Winner"); }
			}
		}

		private bool IsRowWinner(IList<NoughtsAndCrossesButton> buttons)
		{
            if (buttons.Any(x => x.Value == null)) { return false; }

            return (from b in buttons
                   group b by b.Value into g
                   select new {g.Key}).Count() == 1;
		}


        private bool IsColumnWinner(IList<NoughtsAndCrossesButton> buttons)
		{
			return true;
		}

		private bool IsAcrossWinner(int x)
		{
			return true;
		}

	}
}
