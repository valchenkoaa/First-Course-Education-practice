using System;
using System.Diagnostics;

namespace Practice__8
{
    internal sealed class Graph
    {
        public int[,] Matrix { get; }
        public int Count { get; }
        /// <summary>
        /// Создаёт новый граф заданной с заданным количеством вершин и рёбер.
        /// </summary>
        /// <param name="count">Количество вершин.</param>
        /// <param name="input">Ребра графа.</param>
        public Graph(int count, string[] input)
        {
            Count = count;
            Matrix = new int[count, count];
            foreach (string edge in input)
            {
                Matrix[Convert.ToInt32(Char.ToString(edge[0])), Convert.ToInt32(Char.ToString(edge[1]))] = 1;
                Matrix[Convert.ToInt32(Char.ToString(edge[1])), Convert.ToInt32(Char.ToString(edge[0]))] = 1;
            }
        }
        /// <summary>
        /// Создаёт новый граф по таблице смежности.
        /// </summary>
        /// <param name="count"></param>
        /// <param name="inputMatrix"></param>
        public Graph(int count, int[,] inputMatrix)
        {
            Count = count;
            Matrix = inputMatrix;
        }
        /// <summary>
        /// Приведение графа в строку.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string output = "";
            for (int i = 0; i < Count; i++)
            {
                for (int j = 0; j < Count; j++)
                {
                    output += Matrix[i,j] + " ";
                }

                output += "\n";
            }

            return output;
        }
        /// <summary>
        /// Печать матрицы смежности.
        /// </summary>
        public void Print()
        {
            Console.WriteLine("Матрица смежности графа:");
            Console.WriteLine(ToString());
        }
    }
}
