using ConsoleCore.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using Console = Colorful.Console;

namespace ConsoleCore
{
    public class Program
    {
        static bool quit = false;
        const int screenWidth = 80;
        const int screenHeight = 50;
        const int mapWidth = 80;
        const int mapHeight = 45;
        

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
            Entity Player;
            GameMap GameMap;
            Player = new Entity(0, 0);
            GameMap = new GameMap(mapWidth, mapHeight);
            // Initialize Game variables
            InitializeGame(Player,GameMap);
            bool mapIsChanged = true;
            // Enter Game Loop
            GameLoop(Player, GameMap, mapIsChanged);
        }

        static void InitializeGame(Entity player, GameMap gameMap)
        {
           
            // Set window size
            Console.SetWindowSize(screenWidth, screenHeight);
            Console.SetBufferSize(screenWidth, screenHeight);
            // Set initial player position to center of screen
            player.X = screenWidth / 2;
            player.Y = screenHeight / 2;
            player.Char = '@';
            player.Color = Color.Fuchsia;
        }

        static void GameLoop(Entity player, GameMap gameMap, bool mapIsChanged)
        {
            while (!quit)
            {     
                var entities = new List<Entity>();
                entities.Add(player);
              
                RenderManager.RenderAll(entities,gameMap,mapIsChanged);
                mapIsChanged = false;

                // The Update section
                // Wait for a key press and do not display key on the console
                var action = HandleKeys(Console.ReadKey(true));
                object move = null, exit = null;
                action.TryGetValue("move", out move);
                action.TryGetValue("exit", out exit);
                

                if (move != null)
                {
                    int next_X = player.X + (move as Tuple<int, int>).Item1, next_Y = player.Y + (move as Tuple<int, int>).Item2;
                    if(next_X >= 0 && next_Y >= 0 && next_X < gameMap.Cells.GetUpperBound(0) && next_Y < gameMap.Cells.GetUpperBound(1))
                    {
                        //next move is inside the map
                        //check if i can move or there's a wall
                        if (!gameMap.Cells[next_X, next_Y].Blocked)
                        {
                            RenderManager.ClearAll(entities);
                            gameMap.Cells[player.X, player.Y].CellEntity = null;
                            player.Move((move as Tuple<int, int>).Item1, (move as Tuple<int, int>).Item2);
                            gameMap.Cells[next_X, next_Y].CellEntity = player;
                        }
                    }                                      
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
