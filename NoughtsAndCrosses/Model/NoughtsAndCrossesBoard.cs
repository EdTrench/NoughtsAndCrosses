using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoughtsAndCrosses.Model
{
    class NoughtsAndCrossesBoard : Form
    {
        public NoughtsAndCrossesBoard()
        {
            this.NoughtsAndCrossesButtons = new List<NoughtsAndCrossesButton>();
        }

        public List<Model.NoughtsAndCrossesButton> NoughtsAndCrossesButtons { get; set; }
    }
}
