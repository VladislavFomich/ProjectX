using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
namespace ProjectX
{
    class SettingMenu
    {
        string[] settingsItems;
        int counter = 0;
       static string difficult { get; set; } = "Easy";

        public SettingMenu(string[] settingsItems)
        {
            this.settingsItems = settingsItems;
        }

        public int PrintSettingMenu()
        {
            ConsoleKeyInfo key;
            do
            {
                Clear();
                SetCursorPosition(36, 0);
                 
                WriteLine("Settings");
                new MenuPicture().DrowPicture();

                for (int i = 0; i < settingsItems.Length; i++)
                {
                    if (counter == i)
                    {
                        BackgroundColor = ConsoleColor.Green;
                        ForegroundColor = ConsoleColor.Black;
                        WriteLine(settingsItems[i]);
                        BackgroundColor = ConsoleColor.Black;
                        ForegroundColor = ConsoleColor.White;
                    }
                    else
                        WriteLine(settingsItems[i]);

                }
                key = ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    counter--;
                    if (counter == -1) counter = settingsItems.Length - 1;
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    counter++;
                    if (counter == settingsItems.Length) counter = 0;
                }
            }
            while (key.Key != ConsoleKey.Enter);
            return counter;

        }
        delegate void method();
        public static void StartSettingsMenu()
        {
            string[] items = {"Difficult", "List of Win Player" ,"Return",};
            method[] methods = new method[] { Difficult, WinPlayer, Return };
            SettingMenu menu = new SettingMenu(items);
            int menuResult;
            do
            {
                menuResult = menu.PrintSettingMenu();
                methods[menuResult]();
                ReadKey();
            }
            while (menuResult != items.Length - 1);
        }
        static void Difficult()
        {
            link1:
            Clear();
            WriteLine("Sellect difficulty: ");
            WriteLine("1 - easy, 2 - hard");
            string input = ReadLine();
            switch (input)
            {
                case "1":
                    difficult = "easy";
                    Clear();
                    WriteLine($"You sellect {difficult} difficulty");
                    WriteLine("press any button to return...");
                    ReadLine();
                    break;
                case "2":
                    Clear();
                    difficult = "hard";
                    WriteLine($"You sellect {difficult} difficulty");
                    WriteLine("press any button to return...");
                    ReadLine();
                    break;
                default:
                    WriteLine("Неверное значение");
                    goto link1;
            }
            StartSettingsMenu();
        }
       static void WinPlayer()
        {
            new WinPLayerList().PlayerScore();
        }
       
        static void Return()
        {
            ConsoleMenu.StartMenu(); 
        }
    }
}

