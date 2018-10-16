using System;
using System.Collections.Generic;
using InputOutputLib;

namespace Practice__7
{
    internal sealed class Program
    {
        private static string[] menuStrings =
        {
            "Самодвойственные функции от трёх аргументов:", "Вывести таблицы истинности",
            "Вывести вектора в лексикографическом порядке", "Проверить вектор функции на самодвойственность"
        };
        private static Menu mainMenu = new Menu(menuStrings);
        private static bool status = true;
        static void Main(string[] args)
        {
            List<string> vectors = GenerateVector();
            string functions = GenerateFuntions(vectors);
            while (status)
            {
                switch (mainMenu.Show())
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.WriteLine("Самодвойственные функции от трёх аргументов:\n");
                        Console.WriteLine(functions);
                        Get.Wait();
                        break;

                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        Console.Clear();
                        Console.WriteLine("Векторы самодвойственных функций от трёх аргументов в лексикографическом порядке:\n");
                        Print(vectors);
                        Get.Wait();
                        break;

                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        Console.Clear();
                        try
                        {
                            Console.WriteLine("\nЗаданный вектор представляет {0} функцию.\n", IsDouble(Get.String("Введите вектор функции: ")) ? "самодвойственную" : "несамодвойственную");
                        }
                        catch (ArgumentException error)
                        {
                            Console.WriteLine("\n" + error.Message + "\n");
                        }
                        Get.Wait();
                        break;

                    case ConsoleKey.Escape:
                        status = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Выбран несуществующий пункт меню.\n");
                        Get.Wait();
                        break;
                }
            }
        }
        /// <summary>
        /// Генерирует вектора самодвойственных функцийю
        /// </summary>
        /// <returns></returns>
        private static List<string> GenerateVector()
        {
            List<string> vectors = new List<string>();
            for (int a = 0; a <= 1; a++)
            {
                for (int b = 0; b <= 1; b++)
                {
                    for (int c = 0; c <= 1; c++)
                    {
                        for (int d = 0; d <= 1; d++)
                        {
                            string vec = "" + a + b + c + d + (~d & 1) + (~c & 1) + (~b & 1) + (~a & 1);
                            vectors.Add(vec);
                        }
                    }
                }
            }

            return vectors;
        }
        /// <summary>
        /// Генерирует функции по векторам.
        /// </summary>
        /// <param name="vectors">Коллекция векторов функций.</param>
        /// <returns></returns>
        private static string GenerateFuntions(List<string> vectors)
        {
            string output = "";
            int count = 0;
            for (int l = 0; l < vectors.Count; l++)
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        for (int k = 0; k < 2; k++)
                        {
                            output += $"{i} {j} {k}\t{vectors[l][count]}\n";
                            count++;
                        }
                    }
                }
                count = 0;
                output += "\n";
            }

            return output;
        }
        /// <summary>
        /// Печатает коллекцию строк.
        /// </summary>
        /// <param name="vectors"></param>
        private static void Print(List<string> vectors)
        {
            foreach (string vector in vectors)
            {
                Console.WriteLine(vector);
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Проверяет заданный вектор на самодвойственность.
        /// </summary>
        /// <param name="vector">Входной вектор.</param>
        /// <returns></returns>
        private static bool IsDouble(string vector)
        {
            if(vector.Length != 8)
                throw new ArgumentException("Вектор должен содержать 8 значений.");
            if (vector[0] == vector[7] && vector[1] == vector[6] && vector[2] == vector[5] && vector[3] == vector[4])
                return true;
            return false;
        }
    }
}
