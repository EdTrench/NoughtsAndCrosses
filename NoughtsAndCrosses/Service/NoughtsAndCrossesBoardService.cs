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
			bool winner = true;
			for (int j = 0; j <= Settings.noOfButtonsInRow; j++)
			{
				string v = "";
				
				if (noughtsAndCrossesBoard.NoughtsAndCrossesButtons.ElementAt(j).Value != v)
				{
					winner = false;
				}
				v = noughtsAndCrossesBoard.NoughtsAndCrossesButtons.ElementAt(j).Value;
			}
		}
	}
}
