using System;
using InputOutputLib;

namespace Practice__11
{
    internal sealed class Program
    {
        private static string[] menuStrings =
        {
            "Кодирование строки из 121 символа посредством записи в массив и чтением по спирали из центрального элемента:",
            "Закодировать строку", "Декодировать строку"
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
                        try
                        {
                            Console.WriteLine("\nЗакодированная строка: " + Encode(RemakeString(GetString())) + "\n");
                        }
                        catch (ArgumentException error)
                        {
                            Console.WriteLine("\n" + error.Message + "\n");
                        }
                        Get.Wait();
                        break;

                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        Console.Clear();
                        try
                        {
                            Console.WriteLine("\nДекодировка закодированной строки: " + RemakeArray(Decode(GetString())) + "\n");
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
        /// Получает строку от пользователя длиной 121 символ.
        /// </summary>
        /// <returns></returns>
        private static string GetString()
        {
            string input = Get.String("Введите строку из 121 символа: ");
            if (input.Length != 121)
                throw new ArgumentException("Длина строки не 121 символ.");
            return input;
        }
        /// <summary>
        /// Преоразует строку в массив символов построчно.
        /// </summary>
        /// <param name="input">Входная строка.</param>
        /// <returns></returns>
        private static char[,] RemakeString(string input)
        {
            char[,] array = new char[11,11];
            Int16 count = 0;
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    array[i, j] = input[count];
                    count++;
                }   
            }

            return array;
        }
        /// <summary>
        /// Преобразует массив в строку построчно.
        /// </summary>
        /// <param name="array">Входной массив.</param>
        /// <returns></returns>
        private static string RemakeArray(char[,] array)
        {
            string output = "";
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    output += array[i, j];
                }
            }

            return output;
        }
        /// <summary>
        /// Кодирует строку, заданную массивом.
        /// </summary>
        /// <param name="array">Входной массив.</param>
        /// <returns></returns>
        private static string Encode(char[,] array)
        {
            string output = "";

            Int16 i = 5, j = 5, k = 1, count = 0;
            ReadToCircle(array, ref k, ref output, ref i, ref j);
            while (count < 5)
            {
                ReadCircle(array, ref k, ref output, ref i, ref j);
                count++;
            }

            return output;
        }
        /// <summary>
        /// Декодирует строку.
        /// </summary>
        /// <param name="input">Входная строка.</param>
        /// <returns></returns>
        private static char[,] Decode(string input)
        {
            char[,] array =  new char[11,11];
            Int16 i = 5, j = 5, k = 1, count = 0;
            WriteToCircle(ref array, ref k, input, ref i, ref j, ref count);
            while (count < 121)
            {
                WriteCircle(ref array, ref k, input, ref i, ref j, ref count);
            }

            return array;
        }
        #region Методы чтения из массива по спирали
        /// <summary>
        /// Считывает круг из массива по часовой стрелке.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="k"></param>
        /// <param name="output"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private static void ReadCircle(char[,] array, ref Int16 k, ref string output, ref Int16 i, ref Int16 j)
        {
            ReadToRight(array, k, ref output, ref i, ref j);
            k++;
            ReadToDown(array, k, ref output, ref i, ref j);
            ReadToLeft(array, k, ref output, ref i, ref j);
            if (k < 10)
                k++;
            ReadToUp(array, k, ref output, ref i, ref j);
        }
        private static void ReadToUp(char[,] array, Int16 k, ref string output, ref Int16 i, ref Int16 j)
        {
            while (k > 0)
            {
                i = (short) (i - 1);
                output += array[i, j];
                k--;
            }
        }
        private static void ReadToDown(char[,] array, Int16 k, ref string output, ref Int16 i, ref Int16 j)
        {
            while (k > 0)
            {
                i = (short) (i + 1);
                output += array[i, j];
                k--;
            }
        }
        private static void ReadToRight(char[,] array, Int16 k, ref string output, ref Int16 i, ref Int16 j)
        {
            while (k > 0)
            {
                j = (short) (j + 1);
                output += array[i, j];
                k--;
            }
        }
        private static void ReadToLeft(char[,] array, Int16 k, ref string output, ref Int16 i, ref Int16 j)
        {
            while (k > 0)
            {
                j = (short) (j - 1);
                output += array[i, j];
                k--;
            }
        }
        /// <summary>
        /// Выходит из центра на окружность.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="k"></param>
        /// <param name="output"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private static void ReadToCircle(char[,] array, ref Int16 k, ref string output, ref Int16 i, ref Int16 j)
        {
            output += array[i, j];
            ReadToUp(array, k, ref output, ref i, ref j);
        }
        #endregion
        #region Методы записи из массива по спирали
        /// <summary>
        /// Записывает круг из массива по часовой стрелке.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="k"></param>
        /// <param name="output"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="count"></param>
        private static void WriteCircle(ref char[,] array, ref Int16 k, string output, ref Int16 i, ref Int16 j, ref Int16 count)
        {
            WriteToRight(ref array, k, output, ref i, ref j, ref count);
            k++;
            WriteToDown(ref array, k, output, ref i, ref j, ref count);
            WriteToLeft(ref array, k, output, ref i, ref j, ref count);
            if (k < 10)
                k++;
            WriteToUp(ref array, k, output, ref i, ref j, ref count);
        }
        private static void WriteToUp(ref char[,] array, Int16 k, string output, ref Int16 i, ref Int16 j, ref Int16 count)
        {
            while (k > 0)
            {
                i = (short)(i - 1);
                array[i, j] = output[count];
                k--;
                count++;
            }
        }
        private static void WriteToDown(ref char[,] array, Int16 k, string output, ref Int16 i, ref Int16 j, ref Int16 count)
        {
            while (k > 0)
            {
                i = (short)(i + 1);
                array[i, j] = output[count];
                k--;
                count++;
            }
        }
        private static void WriteToRight(ref char[,] array, Int16 k, string output, ref Int16 i, ref Int16 j, ref Int16 count)
        {
            while (k > 0)
            {
                j = (short)(j + 1);
                array[i, j] = output[count];
                k--;
                count++;
            }
        }
        private static void WriteToLeft(ref char[,] array, Int16 k, string output, ref Int16 i, ref Int16 j, ref Int16 count)
        {
            while (k > 0)
            {
                j = (short)(j - 1);
                array[i, j] = output[count];
                k--;
                count++;
            }
        }
        /// <summary>
        /// Выходит из центра на окружность.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="k"></param>
        /// <param name="output"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="count"></param>
        private static void WriteToCircle(ref char[,] array, ref Int16 k, string output, ref Int16 i, ref Int16 j, ref Int16 count)
        {
            array[i, j] = output[count];
            count++;
            WriteToUp(ref array, k, output, ref i, ref j, ref count);
        }
        #endregion
    }
}
