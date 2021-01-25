using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ProjectX
{
    class LevelConverter
    {
        public static char[,] ConvertFileToArray(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            string firstLine = lines[0];
            int rows = lines.Length;
            int cols = firstLine.Length;
            char[,] maze = new char[rows, cols];
            
            for (int y = 0; y < rows; y++)
            {
                string line = lines[y];
                for (int x = 0; x < cols; x++)
                {
                    char currentChar = line[x];
                    maze[y, x] = currentChar;
                }

            }
            return maze;
        }
    }
}
