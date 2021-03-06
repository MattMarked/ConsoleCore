﻿using System;
using System.Collections.Generic;
using System.Text;
using Console = Colorful.Console;
using System.Drawing;

namespace ConsoleCore.Objects
{
    public class Entity
    {
        public int X { get; set; }
        public int? X_prev { get; set; }
        public int Y { get; set; }
        public int? Y_prev { get; set; }
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
            X_prev = X;
            Y_prev = Y;
            X += xMovement;
            Y += yMovement;
        }

    }
}
