﻿using System;
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
        private int parts = 0;
        private int step = 100;
        public void StartMaze()
        {
            string path = @"D:\gitHub\ProjectX\ProjectX\ProjectX\Maze\Maze1.txt";
            char[,] maze = LevelConverter.ConvertFileToArray(path);
           
            myMaze = new MazeWorld(maze);
            mazePlayer = new MazePlayer(1, 1);
            mazeParts1 = new MazeParts(3, 1);
            RunGameLoop();
        }
        private void Lose()
        {
            Clear();
            WriteLine("You Lose");
            Environment.Exit(0);
        }
        private void Conditions()
        {
            SetCursorPosition(55, 0);
            WriteLine(step--);
            SetCursorPosition(55, 1);
            WriteLine($"Собранные части {parts}");
            //MazeTimer.StartTimer();
        }
        
        private void DrawFrame()
        {
            Clear();
            myMaze.Draw();
            mazeParts1.Draw();
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

                if (playerPosition.SequenceEqual(parts1Position))
                {
                    mazeParts1.X = 6;
                    mazeParts1.Y = 0;
                    parts++;
                }
                if (parts == 1)
                    break;
               if (step == 0)
                   Lose();
              
               Thread.Sleep(20);
            }
            new Scene2().StartScene2();
        }
    }
}
