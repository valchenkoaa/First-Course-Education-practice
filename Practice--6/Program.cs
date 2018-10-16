using System;
using InputOutputLib;

namespace Practice__6
{
    internal sealed class Program
    {
        private static string[] menuStrings = { "Рекурсивное построение последовательности чисел ак = (7/3* ак–1 + ак-2 ) /2 * ак–3:", "Задать входные данные"};
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
                        Input();
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
            Console.ReadKey();
        }

        /// <summary>
        /// Ввод данных и построение последовательности.
        /// </summary>
        private static void Input()
        {
            Double[] array = new Double[3];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Get.Double("Введите " + i + "-е число последовательности: ");
            }

            Int32 n = Get.Int32("Введите необходимое количество чисел для последовательности, включая уже введённые (N > 3): ", 3);
            Double l = Get.Double("Введите число L, для сравнения: ");
            Int32 m = Get.Int32("Введите M - необходимое количество чисел, меньше L: ");
            Console.Write("\n{0} {1} {2} ", array[0], array[1], array[2]);

            Next(array[0], array[1], array[2], n, m, l, 3);
        }
        /// <summary>
        /// Вычисление следующего числа посоледовательности
        /// </summary>
        /// <param name="a1">Первый элемент.</param>
        /// <param name="a2">Второй элемент.</param>
        /// <param name="a3">Третий элемент.</param>
        /// <param name="n">Число N для сравнения.</param>
        /// <param name="m">Число M для сравнения.</param>
        /// <param name="l">Число L для сравнения.</param>
        /// <param name="count">Номер члена последовательности.</param>
        private static void Next(Double a1, Double a2, Double a3, Int32 n, Int32 m, Double l, Int32 count)
        {
            if (count < n)
            {
                Double member = (7 / 3 * a3 + a2) / 2 * a1;
                if (count < m && member < l)
                {
                    Console.Write(member + " ");
                    count++;
                    Next(a2, a3, member, n, m, l, count);
                }
                else
                    Console.WriteLine("\nПостройка последовательности остановлена. Достигнута граница L или построено M чисел < L.");
            }
            else
            {
                Console.WriteLine("\nПостройка последовательности остановлена. Построено N первых элементов последовательсти.");
            }
        }
    }
}
