using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoughtsAndCrosses;
using NoughtsAndCrosses.Model;

namespace NoughtsAndCrosses
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
                       
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            NoughtsAndCrossesBoard board = new NoughtsAndCrossesBoard();
            board.Text = "Noughts and Crosses";
            board.Width = Settings.mainFormWidth;
            board.Height = Settings.mainFormHeight;

            var player1 = new Player { Name = "Frederick", ShortName = 'F' };
            var player2 = new Player { Name = "Edward", ShortName = 'E' };

            player1.Board = board;
            player2.Board = board;

            int x = 0;
            int y = 0;

            for (int i = 1; i <= Settings.noOfButtons; i++)
            {
                NoughtsAndCrossesButton button = new NoughtsAndCrossesButton();
                button.Id = i;
                button.Value = null;
                button.Width = Settings.buttonWidth;
                button.Height = Settings.buttonHeight;
                button.Left = x;
                button.Top = y;
                x = (i % Settings.noOfRowsAndColumns) == 0 ? 0 : x + Settings.buttonWidth;
                y = (i % Settings.noOfRowsAndColumns) == 0 ? (y + Settings.buttonHeight) : y;
                board.NoughtsAndCrossesButtons.Add(button);
                board.Controls.Add(button);
                NoughtsAndCrossesButtonListener Buttonlistener = new NoughtsAndCrossesButtonListener();
                Buttonlistener.Subscribe(button);
            }

            //create the board listener
            NoughtsAndCrossesBoardListener BoardListener = new NoughtsAndCrossesBoardListener();
            BoardListener.Subscribe(board);

            Application.Run(board);
        }
    }
}
