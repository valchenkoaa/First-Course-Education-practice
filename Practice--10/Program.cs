using System;
using System.Collections.Generic;
using InputOutputLib;

namespace Practice__10
{
    class Program
    {
        private static string[] menuStrings =
        {
            "Программа для работы с графами:", "Создать новый граф по вершинам и рёбрам",
            "Удалить из графа рёбра с заданным информационным полем", "Распечатать матрицу смежности графа"
        };
        private static Menu mainMenu = new Menu(menuStrings);
        private static bool status = true;
        private static Graph<int> graph;
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
                            graph = MakeGraph(Get.Int32("Введите количество вершин графа (нумеруются с нуля): ", 1));
                            Console.WriteLine("\nГраф успешно создан.");
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("\nПоследовательность рёбер имеет неверный формат.\n");
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("\nПоследовательность рёбер имеет неверный формат.\n");
                        }
                        finally
                        {
                            Get.Wait();
                        }
                        break;

                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        Console.Clear();
                        if (graph != null)
                            try
                            {
                                graph.DelPoints(Get.Int32("Введите значение информационного поля для удаления: "));
                                Console.WriteLine("\nВершина успешно удалена из графа.");
                            }
                            catch (ArgumentException error)
                            {
                                Console.WriteLine("\n" + error.Message + "\n");
                            }
                        else
                            Console.WriteLine("Граф не задан.");
                        Get.Wait();
                        break;

                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        Console.Clear();
                        if(graph != null)
                            graph.Print();
                        else
                            Console.WriteLine("Граф не задан.");
                        Get.Wait();
                        break;

                    case ConsoleKey.Escape:
                        status = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Выбран несущетсвующий пункт меню.");
                        Get.Wait();
                        break;
                }
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Создание нового графа.
        /// </summary>
        /// <param name="count">Количество вершин в графе.</param>
        /// <returns></returns>
        private static Graph<int> MakeGraph(int count)
        {
            string[] edges = Get.String("Введите ребра в виде <начало><конец>, разделяя каждое пробелом: ").Split(' ');
            List<int> infoms = new List<int>();
            for (int i = 0; i < count; i++)
            {
                infoms.Add(Get.Int32($"Ведите значение для {i} вершины графа: "));
            }
            return new Graph<int>(count, edges, infoms);
        }
    }
}
