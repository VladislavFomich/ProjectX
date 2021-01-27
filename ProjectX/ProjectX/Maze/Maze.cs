using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Linq;
using System.Threading;



namespace ProjectX
{
    class Maze
    {
        private MazeWorld myMaze;
        private MazePlayer mazePlayer;
        private MazeParts mazeParts1;
        private MazeParts mazeParts2;
        private MazeParts mazeParts3;
        private int parts = 0;
        private int step = 200;
        public void StartMaze()
        {
            string path = @"D:\gitHub\ProjectX\ProjectX\ProjectX\Maze\Maze1.txt";
            char[,] maze = LevelConverter.ConvertFileToArray(path);
           
            myMaze = new MazeWorld(maze);
            mazePlayer = new MazePlayer(1, 1);
            mazeParts1 = new MazeParts(6, 13);
            mazeParts2 = new MazeParts(31, 11);
            mazeParts3 = new MazeParts(32, 4);
            RunGameLoop();
        }
        private void Lose()
        {
            Clear();
            WriteLine("Вы проиграли!");
            WriteLine("Для выхода введите любой символ...");
            ReadLine();
            Environment.Exit(0);
        }
        private void Conditions()
        {
            SetCursorPosition(55, 0);
            WriteLine($"Осталось шагов: {step--}");
            SetCursorPosition(55, 1);
            WriteLine($"Собранные части: {parts}!");
        }   
        private void DrawFrame()
        {
            Clear();
            myMaze.Draw();
            mazeParts1.Draw();
            mazeParts2.Draw();
            mazeParts3.Draw();
            mazePlayer.Draw();
            Conditions();
        }
        private void PlayerInput()
        {
            ConsoleKey key;
            do
            {
                ConsoleKeyInfo keyInfo = ReadKey(true);
                key = keyInfo.Key;
            } while (KeyAvailable);
           
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
        private void RunGameLoop()
        {
            
            while (true)
            {
                
                DrawFrame();
                PlayerInput(); 
                int[] playerPosition = { mazePlayer.X, mazePlayer.Y };
                int[] parts1Position = { mazeParts1.X, mazeParts1.Y };
                int[] parts2Position = { mazeParts2.X, mazeParts2.Y };
                int[] parts3Position = { mazeParts3.X, mazeParts3.Y };
                if (playerPosition.SequenceEqual(parts1Position))
                {
                    mazeParts1.X = 73;
                    mazeParts1.Y = 1;
                    parts++;
                }
                if (playerPosition.SequenceEqual(parts2Position))
                {
                    mazeParts2.X = 73;
                    mazeParts2.Y = 1;
                    parts++;
                }
                if (playerPosition.SequenceEqual(parts3Position))
                {
                    mazeParts3.X = 73;
                    mazeParts3.Y = 1;
                    parts++;
                }
                if (parts == 3)
                    break;
               if (step == 0)
                   Lose();
              
               Thread.Sleep(20);
            }
            new EndScene().StartScene2();
        }
    }
}
