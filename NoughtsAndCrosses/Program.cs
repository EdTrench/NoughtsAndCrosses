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

            NoughtsAndCrossesMainForm mainForm = new NoughtsAndCrossesMainForm();
            mainForm.Text = "Noughts and Crosses";
            mainForm.Width = Settings.mainFormWidth;
            mainForm.Height = Settings.mainFormHeight;

            Panel mainPanel = new Panel();
            mainPanel.Width = Settings.mainPanelWidth;
            mainPanel.Height = Settings.mainPanelHeight;

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
                mainPanel.Controls.Add(button);
                NoughtsAndCrossesButtonListener listener = new NoughtsAndCrossesButtonListener();
                listener.Subscribe(button);
            }

            mainForm.Controls.Add(mainPanel);
            
            Application.Run(mainForm);

        }
    }
}
