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
            IList<NoughtsAndCrossesButton> diagonal1 = new List<NoughtsAndCrossesButton>();
            IList<NoughtsAndCrossesButton> diagonal2 = new List<NoughtsAndCrossesButton>();
			for (int i = 1; i <= Settings.noOfRowsAndColumns; i++)
			{
				IList<NoughtsAndCrossesButton> row = new List<NoughtsAndCrossesButton>();
				IList<NoughtsAndCrossesButton> column = new List<NoughtsAndCrossesButton>();
                var buttonAtForDiagonal1 = (i - 1) * (Settings.noOfRowsAndColumns + 1);
                var buttonAtForDiagonal2 = (i * (Settings.noOfRowsAndColumns - 1));
				for (int j = 1; j <= Settings.noOfRowsAndColumns; j++)
				{
					var buttonAtForRow = (j - 1) + ((i - 1) * Settings.noOfRowsAndColumns);
					var buttonAtForColumn = (i - 1) + ((j - 1) * Settings.noOfRowsAndColumns);
					row.Add(_noughtsAndCrossesBoard.NoughtsAndCrossesButtons.ElementAt(buttonAtForRow));
					column.Add(_noughtsAndCrossesBoard.NoughtsAndCrossesButtons.ElementAt(buttonAtForColumn));
				}
                diagonal1.Add(_noughtsAndCrossesBoard.NoughtsAndCrossesButtons.ElementAt(buttonAtForDiagonal1));
                diagonal2.Add(_noughtsAndCrossesBoard.NoughtsAndCrossesButtons.ElementAt(buttonAtForDiagonal2));
                if (IsWinner(row)) { ShowWinner();  ResetBoard(); }
                if (IsWinner(column)) { ShowWinner();  ResetBoard(); }
			}
            if (IsWinner(diagonal1)) { ShowWinner(); ResetBoard(); }
            if (IsWinner(diagonal2)) { ShowWinner(); ResetBoard(); }
		}

		private bool IsWinner(IList<NoughtsAndCrossesButton> buttons)
		{
			if (buttons.Any(x => x.Value == null)) { return false; }
			return (from b in buttons
				   group b by b.Value into g
				   select new {g.Key}).Count() == 1;
		}

        private void ShowWinner()
        {
            System.Windows.Forms.MessageBox.Show("Winner");
        }

        private void ResetBoard()
        {
            _noughtsAndCrossesBoard.NoughtsAndCrossesButtons.ForEach(x => {
                x.Value = null;
                x.Text = null;
            });
        }
	}
}
