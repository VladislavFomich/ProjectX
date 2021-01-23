using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace ProjectX
{
  abstract class MazeObject 
    {
        public int X { get; set; }
        public int Y { get; set; }
        protected char Marker { get; set; }
        protected ConsoleColor Color { get; set; }
    }
}
