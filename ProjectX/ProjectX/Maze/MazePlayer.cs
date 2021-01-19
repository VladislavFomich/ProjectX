using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace ProjectX
{
    class MazePlayer
    {
        public int X { get; set; }
        public int Y { get; set; }
        private char PlayerMarker;
        private ConsoleColor PlayerColor;
        public MazePlayer(int initialX, int initialY)
        {
            X = initialX;
            Y = initialY;
            PlayerMarker = '*';
            PlayerColor = ConsoleColor.Green;
        }

        public void Draw()
        {
            ForegroundColor = PlayerColor;
            SetCursorPosition(X, Y);
            Write(PlayerMarker);
            ResetColor();
        }
    }
}
