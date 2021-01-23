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
                WriteLine("Settings");

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
            string[] items = {"Difficult", "Return",};
            method[] methods = new method[] { Difficult, Return };
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
                    WriteLine($"You sellect {difficult} difficulty");
                    WriteLine("press any button to return...");
                    ReadLine();
                    break;
                case "2":
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
       
        static void Return()
        {
            ConsoleMenu.StartMenu(); 
        }
    }
}

