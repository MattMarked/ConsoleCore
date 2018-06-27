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

        public static void ClearEntity(Entity entity)
        {
            Console.SetCursorPosition(entity.X, entity.Y);            
            Console.Write(' ');
        }

        public static void RenderAll(IEnumerable<Entity> entities)
        {
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
    }
}
