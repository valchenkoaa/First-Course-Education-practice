using System;
using System.Collections.Generic;
using System.Diagnostics;
using InputOutputLib;

namespace Practice__12
{
    internal static class Program
    {
        private static Random Random = new Random();
        private static Double n = 100.0;

        private static string[] menuStrings =
        {
            "Демонстрационная программа сортировки массивов методом простыв вставок и блочной сортировкой:",
            "Упорядоченный по возрастанию массив", "Упорядоченный по убыванию массив", "Неупорядоченный массив",
            "Массив из 10000 случайных элементов"
        };
        private static Menu mainMenu = new Menu(menuStrings);
        private static bool status = true;
        static void Main(string[] args)
        {
            while (status)
            {
                Double[] array = Array(n);
                switch (mainMenu.Show())
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.WriteLine("Исходный массив: " + array.ToUp().String() + "\n");
                        Console.WriteLine("Количество сравнений и количество перемещений равно: " + EasyEnterSort(array, true).String() + "\n");
                        Console.WriteLine("Количество сравнений и количество перемещений равно: " + BucketSort(array, true).String() + "\n");
                        Get.Wait();
                        break;

                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        Console.Clear();
                        Console.WriteLine("Исходный массив: " + array.ToDown().String() + "\n");
                        Console.WriteLine("Количество сравнений и количество перемещений равно: " + EasyEnterSort(array, true).String() + "\n");
                        Console.WriteLine("Количество сравнений и количество перемещений равно: " + BucketSort(array, true).String() + "\n");
                        Get.Wait();
                        break;

                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        Console.Clear();
                        Console.WriteLine("Исходный массив: " + array.ToRandom().String() + "\n");
                        Console.WriteLine("Количество сравнений и количество перемещений равно: " + EasyEnterSort(array, true).String() + "\n");
                        Console.WriteLine("Количество сравнений и количество перемещений равно: " + BucketSort(array, true).String() + "\n");
                        Get.Wait();
                        break;

                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        Console.Clear();
                        Console.WriteLine("Подождите, идёт сортировка...\n");
                        Console.WriteLine("Количество сравнений и количество перемещений равно: " + EasyEnterSort(Array(10000.0).ToRandom(), false).String() + "\n");
                        Console.WriteLine("Количество сравнений и количество перемещений равно: " + BucketSort(Array(10000.0).ToRandom(), false).String() + "\n");
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

        #region Работа с массивами
        /// <summary>
        /// Создаёт новый массив заданной размерности.
        /// </summary>
        /// <param name="n">Размерность массива.</param>
        /// <returns></returns>
        private static Double[] Array(Double n) => new Double[(Int32)n];
        /// <summary>
        /// Заполняет массив числами по возрастанию.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private static Double[] ToUp(this Double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i / n;
            }

            return array;
        }
        /// <summary>
        /// Заполняет массив числами по убыванию.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private static Double[] ToDown(this Double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (array.Length - i - 1) / n;
            }

            return array;
        }
        /// <summary>
        /// Заполняет массив случайными числами.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private static Double[] ToRandom(this Double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Math.Round(Random.NextDouble(), 3);
            }

            return array;
        }
        /// <summary>
        /// Меняет элементы местами.
        /// </summary>
        /// <param name="left">Левый элемент.</param>
        /// <param name="right">Правый элемент.</param>
        /// <param name="count">Счётчик перемещений.</param>
        private static void Swap(ref Double left, ref Double right, ref Int32[] count)
        {
            Double temp = left;
            left = right;
            right = temp;
            count[0]++;
        }
        #endregion
        /// <summary>
        /// Сортировка простыми вставками.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private static Int32[] EasyEnterSort(Double[] array, bool print)
        {
            Int32[] count = new Int32[2] { 0, 0 };
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = 1; i < array.Length; i++)
            for (int j = i; j > 0; j--)
            {
                count[1]++;
                if (array[j - 1] > array[j])
                {
                    Swap(ref array[j - 1], ref array[j], ref count);
                }
            }
            timer.Stop();
            if(print)
                Console.WriteLine("Отсортированный простыми вставками массив: " + array.String());
            Console.WriteLine("Количество тиков, затраченное на сортировку: " + timer.ElapsedTicks);

            return count;
        }
        /// <summary>
        /// Блочная сортировка.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private static Int32[] BucketSort(Double[] array, bool print)
        {
            List<Double>[] bucket = new List<Double>[array.Length];
            Int32 j = 0;
            Int32[] count = new Int32[2] {0, 0};
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < array.Length; i++)
            {
                bucket[i] = new List<Double>(0);
            }
            for (int i = 0; i < array.Length; i++)
            {
                bucket[(Int32)Math.Truncate(array[i] * n)].Add(array[i]);
                count[1]++;
            }
            foreach (List<double> doubles in bucket)
            {
                doubles.Sort();
                foreach (double digit in doubles)
                {
                    count[1]++;
                    if (array[j] != digit)
                    {
                        array[j] = digit;
                        count[0]++;
                    }
                    j++;
                }
            }
            timer.Stop();
            if(print)
                Console.WriteLine("Отсортированный блочной сортировкой массив: " + array.String());
            Console.WriteLine("Количество тиков, затраченное на сортировку: " + timer.ElapsedTicks);
            return count;
        }
        #region Strings
        private static string String(this Double[] array)
        {
            string output = "";
            foreach (Double digit in array)
            {
                output += digit + " ";
            }
            return output;
        }
        private static string String(this Int32[] array)
        {
            string output = "";
            foreach (Int32 digit in array)
            {
                output += digit + " ";
            }
            return output;
        }
        #endregion
    }
}
