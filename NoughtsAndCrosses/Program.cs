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
 
            //create the board listener

            int x = 0;
            int y = 0;

            for (int i = 1; i <= Settings.noOfButtons; i++)
            {
                NoughtsAndCrossesButton button = new NoughtsAndCrossesButton();
                button.Name = "button" + i;
                button.Width = Settings.buttonWidth;
                button.Height = Settings.buttonHeight;
                button.Left = x;
                button.Top = y;
                x = (i % Settings.noOfButtonsInRow) == 0 ? 0 : x + Settings.buttonWidth;
                y = (i % Settings.noOfButtonsInRow) == 0 ? (y + Settings.buttonHeight) : y;
                board.NoughtsAndCrossesButtons.Add(button);
                board.Controls.Add(button);
                NoughtsAndCrossesButtonListener listener = new NoughtsAndCrossesButtonListener();
                listener.Subscribe(button);
            }
           
            Application.Run(board);
        }
    }
}
