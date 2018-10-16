using System;
using System.IO;

namespace InputOutputLib
{
    /// <summary>
    /// Предосталвяет меню. Поддерживает консольный вывод.
    /// </summary>
    public sealed class Menu
    {
        /// <summary>
        /// Инициализирует экземпляр класса Menu, содержащий строки меню.
        /// </summary>
        /// <param name="menuStrings">Строки меню.</param>
        public Menu(string[] menuStrings)
        {
            MenuStrings = menuStrings;
        }
        /// <summary>
        /// Возвращает массив строк-пунктов меню.
        /// </summary>
        private string[] MenuStrings { get; }
        /// <summary>
        /// Выводит меню, согласно данным в передаваемом массиве строк. Возвращает значение клавиши консоли.
        /// </summary>
        /// <param name="menuText">Массив строк меню, где на [0] индексе находится название меню.</param>
        public ConsoleKey Show()
        {
            short count = 0;
            Console.Clear(); // Очищаем консоль перед выводом меню
            Console.WriteLine("Переключение между пунктами меню осуществляется с помощью цифровых клавиш [1;9] или NumPad-клавиатуры.\n"); // Вывод вступительной строки
            foreach (string menuString in MenuStrings)
            {
                if (count == 0)
                {
                    Console.WriteLine(menuString);
                    count++;
                }
                else
                    Console.WriteLine("<{0}> - " + menuString, count++);
            }
            Console.WriteLine("<Esc> - Выход"); // Вывод переключателя уровней
            
            return Console.ReadKey(true).Key;
        }
    }
    /// <summary>
    /// Предоставляет методы для вывода запроса к пользователю через консоль и получения значения Int16, либо Int32, либо Double, либо String.
    /// </summary>
    public static class Get
    {
        /// <summary>
        /// Выводит запрос для пользователя в консоль. Возвращает 16-битовое целое число со знаком.
        /// </summary>
        /// <param name="question">Запрос для пользователя.</param>
        /// <param name="min">Нижняя граница для числа.</param>
        /// <param name="max">Верхняя граница для числа.</param>
        /// <returns>Возвращает 16-битовое целое число со знаком.</returns>
        public static Int16 Int16(string question, Int16 min = System.Int16.MinValue, Int16 max = System.Int16.MaxValue)
        {
            Console.Write(question);
            Int16 result;
            while (!(System.Int16.TryParse(Console.ReadLine(), out result)) || !(result >= min) || !(result <= max))
            {
                Console.Clear();
                Console.Write("Ошибка. \"{0}\" - некорректное/пустое значение для Int16.\n" + question, result);
            }
            return result;
        }
        /// <summary>
        /// Выводит запрос для пользователя в консоль. Возвращает 32-битовое целое число со знаком.
        /// </summary>
        /// <param name="question">Запрос для пользователя.</param>
        /// <param name="min">Нижняя граница для числа.</param>
        /// <param name="max">Верхняя граница для числа.</param>
        /// <returns>Возвращает 32-битовое целое число со знаком.</returns>
        public static Int32 Int32(string question, Int32 min = System.Int32.MinValue, Int32 max = System.Int32.MaxValue)
        {
            Console.Write(question);
            Int32 result;
            while (!(System.Int32.TryParse(Console.ReadLine(), out result)) || !(result >= min) || !(result <= max))
            {
                Console.Clear();
                Console.Write("Ошибка. \"{0}\" - некорректное/пустое значение для Int32.\n" + question, result);
            }
            return result;
        }
        /// <summary>
        /// Выводит запрос для пользователя в консоль. Возвращает число двойной точности с плавающей запятой.
        /// </summary>
        /// <param name="question">Запрос для пользователя.</param>
        /// <param name="min">Нижняя граница для числа.</param>
        /// <param name="max">Верхняя граница для числа.</param>
        /// <returns>Возвращает число двойной точности с плавающей запятой.</returns>
        public static Double Double(string question, Double min = System.Double.MinValue, Double max = System.Double.MaxValue)
        {
            Console.Write(question);
            Double result;
            while (!(System.Double.TryParse(Console.ReadLine(), out result)) || !(result >= min) || !(result <= max))
            {
                Console.Clear();
                Console.Write("Ошибка. \"{0}\" - некорректное/пустое значение для Double.\n" + question, result);
            }
            return result;
        }
        /// <summary>
        /// Выводит запрос для пользователя в консоль. Возвращает текст как последовательность из частей кода UTF-16.
        /// </summary>
        /// <param name="question">Запрос для пользователя.</param>
        /// <returns>Возвращает текст как последовательность из частей кода UTF-16.</returns>
        public static String String(string question)
        {
            Console.Write(question);
            string result;
            while ((result = Console.ReadLine().Trim()) == "")
            {
                Console.Clear();
                Console.Write("Ошибка. \"{0}\" - некорректное/пустое значение для String.\n" + question, result);
            }
            return result;
        }
        /// <summary>
        /// Ждёт действия пользователя перед выполнением задачи.
        /// </summary>
        public static void Wait()
        {
            Console.WriteLine("Нажмите любую клавишу для продолжения.");
            Console.ReadKey(true);
        }
    }
    /// <summary>
    /// Предоставляет метод для записи данных в файл, а так же выступает в роли объекта работы с файлом.
    /// </summary>
    public class File
    {
        private string[] _strings; // Считываемые строки из файла
        private Int32 _indexer; // Индексатор считывания строк

        /// <summary>
        /// Создаёт новый объект класса File, содержащий данные, считанные из файла.
        /// </summary>
        /// <param name="fileName">Имя файла без разширения.</param>
        public File(string fileName)
        {
            StreamReader file = new StreamReader(fileName + ".txt");
            string fileText = file.ReadToEnd();
            _strings = fileText.Split('\n', ' ');
            file.Close();
        }
        /// <summary>
        /// Возвращает считываемую строку, разделённую по пробелам.
        /// </summary>
        /// <returns>Возвращает считываемую строку, разделённую по пробелам.</returns>
        public string NextString()
        {
            try
            {
                return _strings[_indexer++];
            }
            catch(Exception)
            {
                return " ";
            }
        }
        /// <summary>
        /// Выводит заданную строку в файл с заданным именем.
        /// </summary>
        /// <param name="fileName">Имя файла без расширения.</param>
        /// <param name="exportString">Строка для записи в файл.</param>
        public static void Export(string fileName, string exportString)
        {
            StreamWriter file = new StreamWriter(fileName + ".txt");
            string[] strings = exportString.Split('\n', '\r');
            foreach (string text in strings)
                file.WriteLine(text);
            file.Close();
        }
    }
}