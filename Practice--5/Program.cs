using System;
using System.Linq;
using InputOutputLib;

namespace Practice__5
{
    internal sealed class Program
    {
        private static string[] menuStrings = {"Программа вычисления X(1) * X(n) + X(2) * X(n-1) + ... + X(n) * X(1), где X(k) - максимальный элемент в K-той строке", "Ввести матрицу"};
        private static Menu mainMenu = new Menu(menuStrings);
        private static bool status = true;
        static void Main(string[] args)
        {
            while (status)
            {
                switch (mainMenu.Show())
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.WriteLine("\nЗначение заданного выражения равно : {0}.", GetAnswer(GetMatrix()));
                        Get.Wait();
                        break;

                    case ConsoleKey.Escape:
                        status = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Выбран несуществующий пункт меню.");
                        Get.Wait();
                        break;
                }
            }
            
        }

        /// <summary>
        /// Ввод матрицы пользователем.
        /// </summary>
        /// <returns></returns>
        private static Double[][] GetMatrix()
        {
            Int32 n = Get.Int32("Введите размер действительной квадратной матрицы: ", 0);
            Console.WriteLine();
            Double[][] matrix = new Double[n][];
            for (int i = 0; i < n; i++)
            {
                matrix[i] = new Double[n];
                for (int j = 0; j < n; j++)
                {
                    matrix[i][j] = Get.Double("Введите значение в ячейке [" + i + "," + j + "]: ");
                }
            }
            return matrix;
        }
        /// <summary>
        /// Вычисление ответа по заданной формуле.
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        private static Double GetAnswer(Double[][] matrix)
        {
            Double output = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                output += matrix[i].Max() * matrix[matrix.Length - i - 1].Max();
            }

            return output;
        }
    }
}
