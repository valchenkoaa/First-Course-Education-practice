using System;
using InputOutputLib;

namespace Practice__9
{
    internal sealed class Application
    {
        private static string[] menuStrings =
        {
            "Работа с циклическим списком:", "Создание циклического списка заданного размера",
            "Удаление элемента из списка", "Поиск элемента в списке", "Вывод списка"
        };
        private static Menu mainMenu = new Menu(menuStrings);
        private static bool status = true;
        private static El List;
        static void Main(string[] args)
        {
            while (status)
            {
                switch (mainMenu.Show())
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        Console.Clear();
                        List = El.MakeList(Get.Int32("Введите количество элементов в списке: "));
                        break;

                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        Console.Clear();
                        if(List != null)
                            try
                            {
                                List = List.Remove(Get.Int32("Введите удаляемый элемент: "));
                            }
                            catch (NullReferenceException error)
                            {
                                Console.WriteLine('\n' + error.Message + '\n');
                            }
                        else
                            Console.WriteLine("Список не создан.");
                        Get.Wait();
                        break;

                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        Console.Clear();
                        if(List != null)
                            try
                            {
                                El findEl = List.Search(Get.Int32("Введите искомый элемент: "));
                                Console.WriteLine("Элемент " + findEl + " найден.\n");
                            }
                            catch (NullReferenceException error)
                            {
                                Console.WriteLine('\n' + error.Message + '\n');
                            }
                        else
                            Console.WriteLine("Список не создан.");
                        Get.Wait();
                        break;

                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        Console.Clear();
                        if(List != null)
                            List.Print();
                        else
                            Console.WriteLine("Списко не создан.\n");
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
    }
}
