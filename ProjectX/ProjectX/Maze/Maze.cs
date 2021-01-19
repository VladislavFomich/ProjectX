using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;



namespace ProjectX
{
    class Maze
    {
        private MazeWorld myMaze;
        private MazePlayer mazePlayer;
        public void StartMaze()
        {
            char[,] maze =   {{'-','-','-','-','-'},
                              {'|',' ','!','!','|'},
                              {'|',' ',' ','!','|'},
                              {'-','-','-','-','-'}
             };

            myMaze = new MazeWorld(maze);
            mazePlayer = new MazePlayer(1, 1);
            RunGameLoop();
        }
        private void DrawFrame()
        {
            Clear();
            myMaze.Draw();
            mazePlayer.Draw();      
            WriteLine($"Собранные части {parts}");
        }
        private void PlayerInput()
        {
            ConsoleKeyInfo keyInfo = ReadKey(true);
            ConsoleKey key = keyInfo.Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (myMaze.IsPositionWalkable(mazePlayer.X, mazePlayer.Y - 1))
                      mazePlayer.Y -= 1; 
                break;
                case ConsoleKey.DownArrow:
                    if (myMaze.IsPositionWalkable(mazePlayer.X, mazePlayer.Y + 1))
                        mazePlayer.Y += 1;
                    break;
                case ConsoleKey.LeftArrow:
                    if (myMaze.IsPositionWalkable(mazePlayer.X - 1, mazePlayer.Y))
                        mazePlayer.X -= 1;
                    break;
                case ConsoleKey.RightArrow:
                    if (myMaze.IsPositionWalkable(mazePlayer.X + 1, mazePlayer.Y))
                        mazePlayer.X += 1;
                    break;
                default:
                    break;
            }
        }
        private int parts = 0;
        
        private void RunGameLoop()
        {
            while (true)
            {
                DrawFrame();
                PlayerInput();
                char elementAtPlayerPos = myMaze.GetElementAt(mazePlayer.X, mazePlayer.Y);
           
                if (elementAtPlayerPos == '!')
                {
                    
                    parts++;
                    if (parts == 99)
                    {
                        break;
                    }
                }
                System.Threading.Thread.Sleep(20);
            }
            Clear();
            WriteLine("Ура"); 
        }
    }
}
