using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;
using ConsoleCore.Objects;
using Console = Colorful.Console;

namespace ConsoleCore
{
    public static class RenderManager
    {
        public static void DrawEntity(Entity entity)
        {
            Console.SetCursorPosition(entity.X, entity.Y);
            Console.ForegroundColor = entity.Color;
            Console.Write(entity.Char);
        }

        public static void ClearPreviousEntity(Entity entity)
        {
            if(entity.X_prev.HasValue && entity.Y_prev.HasValue)
            {
                Console.SetCursorPosition(entity.X_prev.Value, entity.Y_prev.Value);
                Console.Write(' ');
            }            
        }

        public static void ClearEntity(Entity entity)
        {
            Console.SetCursorPosition(entity.X, entity.Y);            
            Console.Write(' ');
        }

        public static void DrawCell(Cell cell, char c = ' ')
        {
            Console.SetCursorPosition(cell.X, cell.Y);
            Console.ForegroundColor = cell.Color;
            Console.Write(c);
        }

        public static void RenderAll(IEnumerable<Entity> entities, GameMap gameMap, bool mapIsChanged)
        {
            if (mapIsChanged)
            {
                for (int i = 0; i < gameMap.Width; i++)
                {
                    for (int j = 0; j < gameMap.Height; j++)
                    {
                        var cell = gameMap.Cells[i, j];
                        if (!cell.Blocked)
                            DrawCell(gameMap.Cells[i, j]);
                        else
                            DrawCell(gameMap.Cells[i, j], 'X');

                    }
                } 
            }
            foreach (var entity in entities)
            {
                DrawEntity(entity);
            }
        }

        public static void ClearAll(IEnumerable<Entity> entities)
        {
            foreach (var entity in entities)
            {
                ClearEntity(entity);
            }
        }
        public static void ClearAllPrevious(IEnumerable<Entity> entities)
        {
            foreach (var entity in entities)
            {
                ClearPreviousEntity(entity);
            }
        }
    }
}
