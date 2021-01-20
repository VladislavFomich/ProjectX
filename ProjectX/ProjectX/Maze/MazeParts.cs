using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace ProjectX
{
    class MazeParts 
    {     
        public int X { get; set; }
        public int Y { get; set; }
        private char PartsMarker;
        private ConsoleColor PartsColor;
        public MazeParts(int initialX, int initialY)
        {
            X = initialX;
            Y = initialY;
            PartsMarker = '!';
            PartsColor = ConsoleColor.Red;
        }

        public void Draw()
        {
            ForegroundColor = PartsColor;
            SetCursorPosition(X, Y);
            Write(PartsMarker);
            ResetColor();
        }
    }
}
