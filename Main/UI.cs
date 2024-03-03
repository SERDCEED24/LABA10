using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LABA10;
namespace Main
{
    public class UI
    {
        public static void PrintMenu()
        {
            Console.WriteLine("Выберите задачу для демонстрации:");
            Console.WriteLine("1. Задача 1.");
            Console.WriteLine("2. Задача 2.");
            Console.WriteLine("3. Задача 3.");
            Console.WriteLine("4. Выход.");
        }
        public static void Menu()
        {
            int x;
            do
            {
                PrintMenu();
                x = VHS.Input("Ошибка! Введите целое число от 1 до 4 включительно.", 1, 4);
                switch (x)
                {
                    case 1:
                        {
                            Program.Task1();
                            break;
                        }
                    case 2:
                        {
                            Program.Task2();
                            break;
                        }
                    case 3:
                        {
                            Program.Task3();
                            break;
                        }
                }
            } while (x != 4);
        }
    }
}
