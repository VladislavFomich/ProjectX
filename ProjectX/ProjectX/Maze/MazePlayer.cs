using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace ProjectX
{
    class MazePlayer  : MazeObject
    {
       
        public MazePlayer(int initialX, int initialY)
        {
            X = initialX;
            Y = initialY;
            Marker = '*';
            Color = ConsoleColor.Green;
        }

        public void Draw()
        {
            ForegroundColor = Color;
            SetCursorPosition(X, Y);
            Write(Marker);
            ResetColor();
        }
    }
}
