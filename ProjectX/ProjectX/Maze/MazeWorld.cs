using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace ProjectX
{
    class MazeWorld
    {
        private char[,] Maze;
        private int Rows;
        private int Cols;
        
        public MazeWorld(char[,] maze)
        {
            Maze = maze;
            Rows = maze.GetLength(0);
            Cols = maze.GetLength(1);
        }

        public void Draw()
        {
            Clear();
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Cols; x++)
                {
                    char element = Maze[y, x];
                    SetCursorPosition(x, y);
                    if (element == '!')
                    {
                        ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        ForegroundColor = ConsoleColor.White;
                    }
                    Write(element);
                    
                }
            }
        }
        public char GetElementAt(int x, int y)
        {
            return Maze[y, x];
        }
        public bool IsPositionWalkable(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Cols || y >= Rows)
                return false;

            return Maze[y, x] == ' ' || Maze[y, x] == '!';
        }
    }
}
