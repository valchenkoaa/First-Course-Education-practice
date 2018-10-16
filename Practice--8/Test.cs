using System;

namespace Practice__8
{
    internal sealed class Test
    {
        private static int[] even = {2, 4, 6, 8, 10};
        private static int[] odd = {1, 3, 5, 7, 9};
        private static Random Random = new Random();
        /// <summary>
        /// Генерирует двудольный граф.
        /// </summary>
        /// <returns></returns>
        public static Graph GenerateBipartiteGraph()
        {
            int count = even[Random.Next(0, even.Length)];
            string edges = "";
            for (int i = 0; i < count; i++)
            {
                if ((i + 1) < count)
                {
                    edges += i;
                    int k = i + 1;
                    edges += k;
                    edges += " ";
                }
                else
                {
                    edges += i;
                    edges += 0;
                }
            }
            string[] input = edges.Split(' ');

            return new Graph(count, input);
        }
        /// <summary>
        /// Генерирует не двудольный граф.
        /// </summary>
        /// <returns></returns>
        public static Graph GenerateNotBipartiteGraph()
        {
            int count = odd[Random.Next(0, odd.Length)];
            string edges = "";
            for (int i = 0; i < count; i++)
            {
                if ((i + 1) < count)
                {
                    edges += i;
                    int k = i + 1;
                    edges += k;
                    edges += " ";
                }
                else
                {
                    edges += i;
                    edges += 0;
                }
            }
            string[] input = edges.Split(' ');

            return new Graph(count, input);
        }
        /// <summary>
        /// Генерирует случаный граф.
        /// </summary>
        /// <returns></returns>
        public static Graph GenerateRandomGraph()
        {
            int count = Random.Next(1, 21);
            int[,] matrix = new int[count,count];
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    matrix[i, j] = Random.Next(0, 2);
                }
            }

            return new Graph(count, matrix);
        }
    }
}
