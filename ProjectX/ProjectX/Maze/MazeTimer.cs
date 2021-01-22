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
            int num = 0;
            TimerCallback tm = new TimerCallback(Count);
            Timer timer = new Timer(tm, num, 0, 1000);
        }

        private static void Count(object obj)
        {
            int second = (int)obj;
            second = 15;
            SetCursorPosition(55, 2);
            Console.WriteLine(second --);
        }
    }
}
