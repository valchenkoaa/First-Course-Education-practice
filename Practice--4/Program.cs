using System;
using InputOutputLib;

namespace Practice__4
{
    internal static class Program
    {
        private static string[] menuStrings =
        {
            "Программа для вычисления значние числа 3p в двоичном представлении:",
            "Ввести двоичное предстваление числа p"
        };
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
                        Int32 p = Convert.ToInt32(GetArray(), 2);
                        string oldP = Convert.ToString(p, 2);
                        p *= 3;
                        Console.Clear();
                        Console.WriteLine("P = {0}" +
                                          "\nДвоичное представление числа 3p:\n" + Convert.ToString(p, 2) + "\n", oldP);
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
        /// Получает строку двоичного представления числа p.
        /// </summary>
        /// <returns></returns>
        private static string GetArray()
        {
            Int32 n = Get.Int32("Введите количество цифр в двоичном представлении числа: ", 1);
            Int16[] array = new Int16[n];
            for (Int32 i = 0; i < n; i++)
                array[i] = Get.Int16("Введите значение в " + i + " ячейке последовательности: ", 0, 1);
            Array.Reverse(array);
            return array.ArrayToString();
        }
        /// <summary>
        /// Преобразует массив в строку.
        /// </summary>
        /// <param name="array">Входной массив.</param>
        /// <returns></returns>
        private static string ArrayToString(this Int16[] array)
        {
            string output = "";
            foreach (Int16 digit in array)
            {
                output += digit;
            }

            return output;
        }
    }
}
