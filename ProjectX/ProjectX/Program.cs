using System;

namespace ProjectX
{
    
    class Program
    {
        static readonly int x = 80;
        static readonly int y = 26;
       
        static void Main(string[] args)
        {
            Console.SetWindowSize(x + 1, y + 1);
            Console.SetBufferSize(x + 1, y + 1);
            Console.CursorVisible = false;
            ConsoleMenu.StartMenu();
            
        }
    }
}

