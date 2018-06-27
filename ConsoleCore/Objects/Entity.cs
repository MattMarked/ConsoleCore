using System;
using System.Collections.Generic;
using System.Text;
using Console = Colorful.Console;
using System.Drawing;

namespace ConsoleCore.Objects
{
    class Entity
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Char { get; set; }
        public List<Item> Inventory { get; set; }
        public Color Color { get; set; }        

        public Entity(int x, int y, char @char = 'x')
        {
            X = x;
            Y = y;
            Char = @char;
            Inventory = new List<Item>();
            Color = Color.White;
        }

        public void Move(int xMovement, int yMovement)
        {
            X += xMovement;
            Y += yMovement;
        }

    }
}
