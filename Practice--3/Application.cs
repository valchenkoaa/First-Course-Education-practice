using System;
using InputOutputLib;

namespace Practice__3
{
    sealed internal class Application
    {
        private static string[] menuStrings = { "Программа вычисления функции y = | |a| - 1 |:", "Задать значение a"}; // Пункты меню
        private static Menu mainMenu = new Menu(menuStrings);                                                          // Создание нового меню с заданными пунктами
        private static bool status = true;
        static void Main(string[] args)
        {
            while(status)
            {
                switch (mainMenu.Show())
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.WriteLine("Значение функции в заданной точке: {0}.",
                            Function(Get.Double("Введите число a: ")));
                        Get.Wait();
                        break;

                    case ConsoleKey.Escape:
                        status = false;
                        break;
                    
                    default:
                        Console.Clear();
                        Console.WriteLine("Выбран несуществующий пункт меню");
                        Get.Wait();
                        break;
                }
            }
        }

        /// <summary>
        /// Вычисление значения функции в заданной точке.
        /// </summary>
        /// <param name="x">Точка для вычисления.</param>
        /// <returns></returns>
        private static double Function(Double x)
        {
            if (x <= 0)
                return Math.Abs(x + 1);

            return Math.Abs(x - 1);
        }
    }
}