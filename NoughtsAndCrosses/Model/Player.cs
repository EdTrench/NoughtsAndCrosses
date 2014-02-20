using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsAndCrosses.Model
{
    class Player
    {
        public string Name { get; set; }
        public char ShortName { get; set; }
        public NoughtsAndCrossesBoard Board { get; set; }
    }
}
