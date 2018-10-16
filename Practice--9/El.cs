using System;

namespace Practice__9
{
    internal sealed class El
    {
        /// <summary>
        /// Возвращает или задаёт значение элемента в последовательности.
        /// </summary>
        public int number { get; set; }
        /// <summary>
        /// Ссылка на следующий элемент в последовательности.
        /// </summary>
        public El next { get; private set; }
        
        /// <summary>
        /// Конструктор элемента.
        /// </summary>
        /// <param name="number">Значение элемента.</param>
        private El(int number)
        {
            this.number = number;
            next = this;
        }
        /// <summary>
        /// Добавляет элемент в список.
        /// </summary>
        /// <param name="number">Значение элемента.</param>
        private void Add(int number)
        {
            El newEl =  new El(number), el = this;
            while (el.next != this)
            {
                el = el.next;
            }

            newEl.next = el.next;
            el.next = newEl;
        }
        /// <summary>
        /// Создаёт новый списк заданного размера.
        /// </summary>
        /// <param name="capacity">Размер списка.</param>
        /// <returns></returns>
        public static El MakeList(int capacity)
        {
            int number = 1;
            El el = new El(number);
            while (number < capacity)
                el.Add(++number);

            return el;
        }
        /// <summary>
        /// Удаляет из списка элемент с заданным значением.
        /// </summary>
        /// <param name="number">Значение элемента.</param>
        public El Remove(int number)
        {
            El searchEl = Search(number), predEl = this;
            if (searchEl == this)
            {
                while (predEl.next != this)
                {
                    predEl = predEl.next;
                }
                predEl.next = next;
                Console.WriteLine("\nЭлемент " + searchEl + " успешно удалён.\n\nИзменённый список:");
                next.Print();
                return next;
            }

            while (predEl.next != searchEl)
            {
                predEl = predEl.next;
            }

            predEl.next = searchEl.next;
            Console.WriteLine("\nЭлемент " + searchEl + " успешно удалён.\n\nИзменённый список:");
            Print();
            return this;
        }
        /// <summary>
        /// Ищет в списке элемент с заданным значением.
        /// </summary>
        /// <param name="number">Значение элемента.</param>
        /// <returns></returns>
        public El Search(int number)
        {
            El el = this;
            while (el.number != number)
            {
                el = el.next;
                if (el == this)
                    throw new NullReferenceException("Элемент не найден.");
            }
            
            return el;
        }
        /// <summary>
        /// Преобразует список в строку.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return number.ToString();
        }
        /// <summary>
        /// Печатает список.
        /// </summary>
        public void Print()
        {
            El el = this;
            Console.Write(el.ToString() + " ");
            while (el.next != this)
            {
                el = el.next;
                Console.Write(el.ToString() + " ");
            }
            Console.WriteLine();
        }
    }
}
