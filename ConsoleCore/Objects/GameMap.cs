using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ConsoleCore.Objects
{
    public class GameMap
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Cell[,] Cells { get; set; }

        public GameMap(int width, int height)
        {
            Width = width;
            Height = height;
            
            Cells = InitializeCells();
        }

  

        public Cell[,] InitializeCells()
        {
            var newCells = new Cell[Width,Height];
            for(int i = 0; i < Width; i++)
            {
                for(int j = 0; j < Height; j++)
                {
                    newCells[i, j] = new Cell(false,i,j,false,Color.Black);
                }
            }
            newCells[30,22].Blocked = true;
            newCells[30,22].BlockSight = true;
            newCells[30,22].Color = Color.Aquamarine;
            newCells[31,22].Blocked = true;
            newCells[31,22].BlockSight = true;
            newCells[31, 22].Color = Color.Aquamarine;
            newCells[32, 22].Blocked = true;
            newCells[32, 22].BlockSight = true;
            newCells[32, 22].Color = Color.Aquamarine;

            return newCells;
        }

    }
}
