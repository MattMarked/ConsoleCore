using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ConsoleCore.Objects
{
    public class Cell
    {
      
        public Item CellItem { get; set; }
        public Entity CellEntity { get; set; }
        public Color Color { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool Blocked { get; set; }
        public bool BlockSight { get; set; }
        public Cell( bool? blockSight, int x = 0, int y = 0, bool blocked = false, Color color = new Color())
        {
            X = x;
            Y = y;
            if (!color.IsEmpty)
                Color = color;
            else
                Color = Color.Black;

            Blocked = blocked;
            if (Blocked)
                BlockSight = true;

            if(blockSight.HasValue)
                BlockSight = blockSight.Value;
        }
    }
}
