using System;
using InputOutputLib;

namespace Practice__8
{
    internal sealed class Application
    {
        private static string[] menuStrings =
        {
            "Проверка графа на двудольнисть:", "Задать граф вручную", "Сгенерировать двудольный граф",
            "Сгенерировать недвудольный граф", "Сгенерировать случаный граф"
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
                        Graph graph = MakeGraph(Get.Int32("Введите количество вершин графа (нумеруются с нуля): ", 1, 10));
                        graph.Print();
                        Console.WriteLine("Заданный граф {0} двудольным.\n", IsBipartite(graph) ? "является" : "не является");
                        Get.Wait();
                        break;

                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        Console.Clear();
                        graph = Test.GenerateBipartiteGraph();
                        graph.Print();
                        Console.WriteLine("Заданный граф {0} двудольным.\n", IsBipartite(graph) ? "является" : "не является");
                        Get.Wait();
                        break;

                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        Console.Clear();
                        graph = Test.GenerateNotBipartiteGraph();
                        graph.Print();
                        Console.WriteLine("Заданный граф {0} двудольным.\n", IsBipartite(graph) ? "является" : "не является");
                        Get.Wait();
                        break;

                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        Console.Clear();
                        graph = Test.GenerateRandomGraph();
                        graph.Print();
                        Console.WriteLine("Заданный граф {0} двудольным.\n", IsBipartite(graph) ? "является" : "не является");
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
        /// Создаёт граф с заданным количеством вершин.
        /// </summary>
        /// <param name="count">Количество вершин.ы</param>
        /// <returns></returns>
        private static Graph MakeGraph(int count)
        {
            string[] edges = Get.String("Введите ребра в виде <начало><конец>, разделяя каждое пробелом: ").Split(' ');

            return new Graph(count, edges);
        }
        /// <summary>
        /// Проверяет граф на двудольность.
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        private static bool IsBipartite(Graph graph)
        {
            int[] marks = new int[graph.Count];

            for (int i = 0; i < graph.Count; i++)
            {
                for (int j = i + 1; j < graph.Count; j++)
                {
                    if (graph.Matrix[i, j] != 0)
                    {
                        if (marks[i] % 2 == marks[j] % 2 && marks[j] != 0)
                            return false;
                        marks[j] = marks[i] + 1;
                    }
                }
            }

            return true;
        }
    }
}
