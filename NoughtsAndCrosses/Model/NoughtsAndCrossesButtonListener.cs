using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsAndCrosses.Model
{
    class NoughtsAndCrossesButtonListener
    {
        public void Subscribe(NoughtsAndCrossesButton noughtsAndCrossesButton)
        {
            noughtsAndCrossesButton.Click += new System.EventHandler(ClickedIt);
        }
        private void ClickedIt(Object sender, Object e)
        {
            NoughtsAndCrossesButton noughtsAndCrossesButton = (NoughtsAndCrossesButton)sender;
            noughtsAndCrossesButton.IncrementNumberOfClicks();
            noughtsAndCrossesButton.SetText();
        }
    }
}
