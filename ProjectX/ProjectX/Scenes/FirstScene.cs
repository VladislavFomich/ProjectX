using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace ProjectX
{
    class FirstScene : PlayerInfo
       
    {
        
        public static void StartScene1() 
        {
            do
            {
                Clear();
                WriteLine("Здравствуйте");
                WriteLine("Введите свое имя");
                Name = ReadLine();
                if (Name.Length == 0)
                {
                    WriteLine("Введите хотя бы одну букву!");
                    ReadLine();
                }
            } while (Name.Length == 0);

            Clear();
            WriteLine($"Отлично {Name}! Осталось еще немного.");
            WriteLine("Для синхронихации нужно ввести электронную почту.");
            WriteLine("Хотите ввести свой email?");
            WriteLine("1- да, 2 - нет.");
            string insert1 = ReadLine();
            switch (insert1)
            {
                case "1":
                    do
                    {
                        Clear();
                        WriteLine("Ваш email: ");
                        Mail = ReadLine();
                        if (Mail.Length == 0)
                        {
                            Clear();
                            WriteLine("Для продолжения введите email.");
                            ReadLine();
                        }
                    } while (Mail.Length == 0);
                    WriteLine("Превосходно! Продолжаем.");
                    break;
                case "2":
                    goto link1;
                    
                default:
                    WriteLine("Неверное значение.");
                    WriteLine("Тогда продолжим.");
                    ReadLine();
                    break;
            }
     
            link1:
            Clear();
            WriteLine($"{Name}, вы готовы начинать игру?");
            WriteLine("1- да, 2 - нет.");
            string insert2 = ReadLine();
            switch (insert2)
            {
                case "1":
                    new Maze().StartMaze();
                    break;
                case "2":
                    Clear();
                    WriteLine("Тогда пока");
                    Environment.Exit(0);
                    break;
                        
                default:
                    WriteLine("Неверное значение");
                    WriteLine("Для продолжения введите любой символ...");
                    ReadLine();
                    goto link1;
            }

        }
    }
}
