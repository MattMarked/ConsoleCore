using ConsoleCore.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using Console = Colorful.Console;

namespace ConsoleCore
{
    class Program
    {
        static bool quit = false;
        const int screenWidth = 80;
        const int screenHeight = 24;
        static Entity Player = new Entity(0,0);
        private static void ConsoleOnCancelKeyPress(object sender, ConsoleCancelEventArgs consoleCancelEventArgs)
        {
            // Set flag that we’ll use to cancel on our own terms
            quit = true;
            consoleCancelEventArgs.Cancel = true;
        }
        static void Main(string[] args)
        {
            // Register Ctrl+C handler and hide the cursor
            Console.CancelKeyPress += ConsoleOnCancelKeyPress;
            Console.CursorVisible = false;
            
            // Initialize Game variables
            InitializeGame();

            // Enter Game Loop
            GameLoop();
        }

        static void InitializeGame()
        {
            // Set window size
            Console.SetWindowSize(screenWidth, screenHeight);
            Console.SetBufferSize(screenWidth, screenHeight);
            // Set initial player position to center of screen
            Player.X = screenWidth / 2;
            Player.Y = screenHeight / 2;
            Player.Char = '@';
            Player.Color = Color.Fuchsia;
        }

        static void GameLoop()
        {
            while (!quit)
            {
                // Sleep a short period at the end of each iteration of the loop
                Thread.Sleep(100);
                // The Render section
                // Clear the console before we draw
                Console.Clear();


                // Draw the player at the current position in white
                var entities = new List<Entity>();
                entities.Add(Player);
                RenderManager.RenderAll(entities);
                

                // The Update section
                // Wait for a key press and do not display key on the console
                var action = HandleKeys(Console.ReadKey(true));
                object move = null, exit = null;
                action.TryGetValue("move", out move);
                action.TryGetValue("exit", out exit);
                

                if (move != null)
                {
                    Player.Move( (move as Tuple<int, int>).Item1, (move as Tuple<int, int>).Item2);                    
                }
            }
        }

        static Dictionary<string,object> HandleKeys(ConsoleKeyInfo keyPressed)
        {
            if (keyPressed.Key == ConsoleKey.UpArrow)
                return new Dictionary<string, object>() { ["move"] = new Tuple<int,int>(0,-1)  };
            else if (keyPressed.Key == ConsoleKey.DownArrow)
                return new Dictionary<string, object>() { ["move"] = new Tuple<int, int>(0, 1) };
            else if (keyPressed.Key == ConsoleKey.LeftArrow)
                return new Dictionary<string, object>() { ["move"] = new Tuple<int, int>(-1, 0) };
            else if (keyPressed.Key == ConsoleKey.RightArrow)
                return new Dictionary<string, object>() { ["move"] = new Tuple<int, int>(1, -0) };
            

            if(keyPressed.Key == ConsoleKey.Escape)
                return new Dictionary<string, object>() { ["exit"] = true };
            return new Dictionary<string, object>() ;

        }



        
    }
}
