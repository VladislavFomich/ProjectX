using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace ProjectX
{
    class Scene1 : PlayerInfo
       
    {
        
        public static void StartScene1() 
        {            
            Clear();
            WriteLine("Привет");
            WriteLine("Введите свое имя");
            Name = ReadLine();
            WriteLine("Введите почту");
            Mail = ReadLine();
            
            link1:
            WriteLine("Готов начинать игру?");
            WriteLine("1- да, 2 - нет.");
            string insert = ReadLine();
            switch (insert)
            {
                case "1":
                    Maze maze = new Maze();
                    maze.StartMaze();
                    break;
                case "2":
                    WriteLine("Тогда пока");
                    Environment.Exit(0);
                    break;
                        
                default:
                    WriteLine("Неверное значение");
                    goto link1;
            }

        }
    }
}
