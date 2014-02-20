using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsAndCrosses
{
    static class Settings
    {
        public const int buttonWidth = 200;
        public const int buttonHeight = 200;
        public const int noOfRowsAndColumns = 3;
        public const int mainFormWidth = ((buttonWidth * noOfRowsAndColumns) + 15);
        public const int mainFormHeight = ((buttonHeight * noOfRowsAndColumns)  + 40);
        public const int noOfButtons = (noOfRowsAndColumns * noOfRowsAndColumns);
    }
}
