using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectX
{
    class Scene1
    {
     public static void StartScene1() 
        {
            Console.Clear();
            Console.WriteLine("Привет");
            Console.ReadLine();
            link1:
            Console.WriteLine("Готов начинать игру?");
            Console.WriteLine("1- да, 2 - нет.");
            string insert = Console.ReadLine();
            switch (insert)
            {
                case "1":
                    Maze maze = new Maze();
                    maze.StartMaze();
                    break;
                case "2":
                    Console.WriteLine("Тогда пока");
                    Environment.Exit(0);
                    break;
                        
                default:
                    Console.WriteLine("Неверное значение");
                    goto link1;
            }

        }
    }
}
