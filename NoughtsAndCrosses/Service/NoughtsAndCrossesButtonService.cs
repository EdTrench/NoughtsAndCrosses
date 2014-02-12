using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoughtsAndCrosses.Model;

namespace NoughtsAndCrosses.Service
{
    class NoughtsAndCrossesButtonService
    {
        private NoughtsAndCrossesButton _noughtsAndCrossesButton;

        public NoughtsAndCrossesButtonService(NoughtsAndCrossesButton noughtsAndCrossesButton)
        {
            _noughtsAndCrossesButton = noughtsAndCrossesButton;
        }

        public void SetText()
        {
            _noughtsAndCrossesButton.Font = new System.Drawing.Font("Consolas", 50);
            _noughtsAndCrossesButton.Value = (_noughtsAndCrossesButton.NumberOfClicks % 2) == 0 ? "0" : "X";
            _noughtsAndCrossesButton.Text = _noughtsAndCrossesButton.Value;
        }

    }
}
