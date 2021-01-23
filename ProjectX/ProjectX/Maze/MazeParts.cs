using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace ProjectX
{
    class MazeParts : MazeObject
    {     
        
        public MazeParts(int initialX, int initialY)
        {
            X = initialX;
            Y = initialY;
            Marker = '!';
            Color = ConsoleColor.Red;
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
