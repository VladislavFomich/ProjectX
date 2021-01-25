using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using static System.Console;


namespace ProjectX
{
    class MazeTimer
    {
        public static void StartTimer()
        {
            for (int i = 30; i > 0; i--)
            {
                
                SetCursorPosition(55, 2);
                WriteLine( i );
                Thread.Sleep(1000);
            }
        }
    }
}
