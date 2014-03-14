using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoughtsAndCrosses.Model
{
    public class NoughtsAndCrossesBoard : Form
    {
        public List<Model.NoughtsAndCrossesButton> NoughtsAndCrossesButtons { get; set; }

        public NoughtsAndCrossesBoard()
        {
            this.NoughtsAndCrossesButtons = new List<NoughtsAndCrossesButton>();
        }
    }
}
