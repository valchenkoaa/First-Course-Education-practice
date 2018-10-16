using System;
using System.Collections.Generic;

namespace Practice__10
{
    class Graph<T>
    {
        /// <summary>
        /// Получает матрицу смежности графа.
        /// </summary>
        public List<List<int>> Matrix { get; }
        /// <summary>
        /// Получает количество вершин в графе.
        /// </summary>
        public int Count { get; private set; }
        /// <summary>
        /// Получает список информационных полей вершин.
        /// </summary>
        public List<T> Inform { get; }
        /// <summary>
        /// Создаёт новый граф по заданным параметрам.
        /// </summary>
        /// <param name="count">Количество вершин.</param>
        /// <param name="input">Массив ребер.</param>
        /// <param name="inform">Список информационнх полей для вершин.</param>
        public Graph(int count, string[] input, List<T> inform)
        {
            Count = count;
            Inform = inform;
            Matrix = MakeMatrix(Count);
            foreach (string edge in input)
            {
                Matrix[Convert.ToInt32(Char.ToString(edge[0]))][Convert.ToInt32(Char.ToString(edge[1]))] = 1;
                Matrix[Convert.ToInt32(Char.ToString(edge[1]))][Convert.ToInt32(Char.ToString(edge[0]))] = 1;
            }
        }
        /// <summary>
        /// Создаёт матрицу смежности графа.
        /// </summary>
        /// <param name="count">Количество вершин.</param>
        /// <returns></returns>
        private static List<List<int>> MakeMatrix(int count)
        {
            List<List<int>> matrix = new List<List<int>>(count);
            for (int i = 0; i < count; i++)
            {
                matrix.Add(new List<int>(count));
            }

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    matrix[i].Add(0);
                }
            }

            return matrix;
        }
        /// <summary>
        /// Удаляет вершину с заданным информационным полем.
        /// </summary>
        /// <param name="inform">Значение поля.</param>
        public void DelPoints(T inform)
        {
            if (!Inform.Contains(inform))
                throw new ArgumentException("Вершины с заданным информационным полем не существует.");
            for (int i = 0; i < Count; i++)
            {
                if (Inform[i].Equals(inform))
                {
                    for (int j = 0; j < Count; j++)
                    {
                        Matrix[j].RemoveAt(i);
                    }
                    Matrix.RemoveAt(i);

                    Count--;
                }
            }
            Inform.Remove(inform);
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
                    output += Matrix[i][j] + " ";
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

            Console.WriteLine("Значения информационных полей в графе:");
            foreach (T el in Inform)
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();
        }
    }
}