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
        public int Id { get; set; }
        public string Value { get; set; }
        protected int _numberOfClicks = 0;
        public int NumberOfClicks
        {
            get { return _numberOfClicks; }
        }

        public void IncrementNumberOfClicks()
        {
            _numberOfClicks++;
        }

    }
}