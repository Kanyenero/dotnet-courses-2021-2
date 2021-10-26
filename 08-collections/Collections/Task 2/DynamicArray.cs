using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2
{
    // Аргумент типа данных DynamicArray дожен иметь конструктор без параметров!
    class DynamicArray <T> : IEnumerable <T> where T : notnull, new()
    {

                        /* Конструкторы */


        // Конструктор по умолчанию. Создается массив емкостью 8 ячеек
        public DynamicArray()
        {
            Length = 8;
            _array = new T[Capacity];
        }

        // Конструктор с параметром. Создается новый массив заданной емкости
        public DynamicArray(uint length)
        {
            Length = length;
            _array = new T[Capacity];
        }

        // Конструктор с параметром. Создается новый массив из уже существующего
        public DynamicArray(T[] collection)
        {
            Length = (uint)collection.Length;
            _array = new T[Capacity];
            Array.Copy(collection, _array, Length);
        }

        // Конструктор, принимающий коллекцию, реализующую интерфейс IEnumerable
        public DynamicArray (IEnumerable <T> collection)
        {
            // Вычислить размер коллекции
            uint collectionSize = 0;
            foreach (T item in collection)
                collectionSize++;

            // Выделить память под массив
            Length = collectionSize;
            _array = new T[Capacity];

            // Копируем данные из коллекции в массив
            int i = 0;
            foreach (T item in collection)
            {
                _array[i] = item;
                i++;
            }
        }


                        /* Поля */


        private uint _length; // Размер массива
        private uint _capacity = 1; // Емкость массива
        public T[] _array; // Массив, с которым мы работаем
        

                        /* Свойства */


        // Свойства длины массива
        public uint Length
        {
            get { return _length; }
            set
            {
                while (value > _capacity) { _capacity *= 2; }
                _length = value;
            }
        }

        // Свойства емкости массива
        public uint Capacity 
        { 
            get { return _capacity; } 
        }

        // Индексатор, позволяющий использовать обращение вида []
        public T this[uint idx]
        {
            get
            {
                if (idx > _length)
                    throw new ArgumentOutOfRangeException("Array out of bounds");

                return _array[idx];
            }
            set
            {
                if (idx > _length)
                    throw new ArgumentOutOfRangeException("Array out of bounds");

                _array[idx] = value;
            }
        }


                        /* Методы */


        // Метод добавляет в конец массива 1 элемент.
        // При нехватке места для добавления элемента
        // емкость массива расширяется в 2 раза
        public void Add(T element)
        {
            Length++;

            // Задать новый размер массива, исходя из изменившегося
            // значения его длины (а следовательно и емкости)
            Array.Resize<T>(ref _array, (int)Capacity);
            _array[Length - 1] = element;
        }

        // Добавляет в конец массива содержимое переданного массива
        public void AddRange(T[] range)
        {
            uint old_length = Length;
            Length += (uint)range.Length;

            // Задать новый размер массива, исходя из изменившегося
            // значения его длины (а следовательно и емкости)
            Array.Resize<T>(ref _array, (int)Capacity);

            range.CopyTo(_array, old_length);
        }

        // Удаляет из коллекции указанный элемент.
        // Возвращает true, если удаление прошло успешно
        // и false в противном случае.
        // При удалении элементов уменьшается длина (Length),
        // а реальная емкость массива (Capacity) не уменьшается.
        public bool Remove(T element)
        {
            bool status = false;

            for (uint i = 0; i < Length; i++)
            {
                if (_array[i].Equals(element))
                {
                    // Очистить данные этой ячейки
                    _array[i] = default(T);

                    // Сместить все элементы на одну позицию влево
                    for (uint j = i; j < Length - 1; j++)
                        _array[j] = _array[j + 1];

                    // Очистить последнюю ячейку
                    _array[Length - 1] = default(T);

                    Length--;
                    status = true;
                    break;
                }
            }

            if (status == false) Console.WriteLine($"Element {element} doesn't exist\n");

            return status;
        }

        // Добавляет элемент в произвольную позицию массива.
        // При выходе за границу массива генерируется исключение
        public void Insert(T element, uint idx)
        {
            Length++;

            if (idx > Length)
                throw new ArgumentOutOfRangeException("Array out of bounds");

            // Задать новый размер массива, исходя из изменившегося
            // значения его длины (а следовательно и емкости)
            Array.Resize<T>(ref _array, (int)Capacity);

            // Сместить все элементы на одну позицию вправо
            for (uint i = Length - 1; i > idx; i--)
                _array[i] = _array[i - 1];

            // Очистить ячейку
            _array[idx] = default(T);

            // Записать новые данные в ячейку
            _array[idx] = element;
        }

        // Выводит созданный массив в консоль
        public void Print()
        {
            Console.WriteLine($"Array [length: {Length}] [capacity: {Capacity}]");

            for (int i = 0; i < Capacity; i++)
                Console.WriteLine($"Array [idx: {i}] [val: {_array[i]}]");

            Console.WriteLine();
        }


        /* Методы, реализующие интерфейс IEnumerable */


        private IEnumerable<T> GetValues()
        {
            foreach (T item in _array)
                yield return item;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return GetValues().GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
