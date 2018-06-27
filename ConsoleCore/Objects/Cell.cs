using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCore.Objects
{
    class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Item CellItem { get; set; }
        public Entity CellEntity { get; set; }
    }
}
