using System;
using System.IO;

namespace Practice_1
{
    internal sealed class Program
    {
        private static int count;                                                                   // число кучек
        private static int[] stack;                                                                 // количество монет в каждой кучке
        private static int[,] newStack;                                                             // матрица максимальных выигрышей
        public static void Main(string[] args)
        {
            string[] input = File.ReadAllText("input.txt").Replace("  ", " ").Split(' ');
            count = int.Parse(input[0]);                                                            // получаем количество кучек
            stack = new int[count];                                                                 // создаём массив, заданного размера

            for (int i = 0; i < count; i++)
            {
                stack[i] = int.Parse(input[i + 1]);                                                 // заполняем массив
            }

            int firstStep = int.Parse(input[input.Length - 1]);                                     // получаем максимальное количество кучек в первом ходу
            newStack = new int[firstStep + 1, count + 1];                                           // начало заполнения массива максимальных выигрышей

            File.AppendAllText("output.txt", f(firstStep, 0).ToString());
        }
        #region Рекурсивные функции вычисления
        /// <summary>
        /// Вычисляет значение в ячейке выигрыша.
        /// </summary>
        /// <param name="i">Параметр строки.</param>
        /// <returns></returns>
        private static int s(int i)
        {
            return i >= count ? 0 : stack[i] + s(i + 1);
        }
        /// <summary>
        /// Возвращает массив максимальных выигрышей.
        /// </summary>
        /// <param name="k">Параметр строки.</param>
        /// <param name="i">Параметр столбца.</param>
        /// <returns></returns>
        private static int f(int k, int i)
        {
            if (newStack[k, i] == 0)
            {
                newStack[k, i] = l(Math.Min(k, count - i), 0, i);
            }

            return newStack[k, i];
        }
        /// <summary>
        /// Возвращает 0, вычисляя возможные варианты.
        /// </summary>
        /// <param name="j">Минимум из строки и числа выигрышей.</param>
        /// <param name="r">Значение по умолчанию.</param>
        /// <param name="i">Параметр столбца.</param>
        /// <returns></returns>
        private static int l(int j, int r, int i)
        {
            return j <= 0 ? r : l(j - 1, Math.Max(r, s(i) - f(j, i + j)), i);
        }
        #endregion
    }
}