using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace ProjectX
{
    class ConsoleMenu
    {
        string[] menuItems;
        int counter = 0;
        public ConsoleMenu(string[] menuItems)
        {
            this.menuItems = menuItems;
        }

        public int PrintMenu()
        {
            ConsoleKeyInfo key;
            do
            {
                Clear();              
                WriteLine("ProjectX");
             
                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (counter == i)
                    {
                        BackgroundColor = ConsoleColor.Green;
                        ForegroundColor = ConsoleColor.Black;
                        WriteLine(menuItems[i]);
                        BackgroundColor = ConsoleColor.Black;
                        ForegroundColor = ConsoleColor.White;
                    }
                    else
                        WriteLine(menuItems[i]);

                }
                key = ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    counter--;
                    if (counter == -1) counter = menuItems.Length - 1;
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    counter++;
                    if (counter == menuItems.Length) counter = 0;
                }
            }
            while (key.Key != ConsoleKey.Enter);
            return counter;
            
        }
        delegate void method();
       public static void StartMenu()
        {
            
            string[] items = { "Start", "Settings", "Exit", };
            method[] methods = new method[] { Start, Settings, Exit };
            ConsoleMenu menu = new ConsoleMenu(items);
            int menuResult;
            do
            {
                menuResult = menu.PrintMenu();
                methods[menuResult]();
                ReadKey();
            } 
            while (menuResult != items.Length - 1);
        }

        static void Start()
        {
            Scene1.StartScene1();
        }
        static void Settings()
        {
            SettingMenu.StartSettingsMenu();
        }
        static void Exit()
        {
            Clear();
            WriteLine();
            WriteLine("Пока");
            Environment.Exit(0);
        }
    }
}
