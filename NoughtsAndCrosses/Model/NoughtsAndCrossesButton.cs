using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoughtsAndCrosses.Model
{
    class NoughtsAndCrossesButton : Button
    {
        private int _numberOfClicks = 0;
        public int NumberOfClicks
        {
            get { return _numberOfClicks; }
        }

        public void IncrementNumberOfClicks()
        {
            _numberOfClicks++;
        }

        public void SetText()
        {
            this.Text = (_numberOfClicks % 2) == 0 ? "0" : "X";
            this.Font = new System.Drawing.Font("Consolas", 50);
        }
    }
}