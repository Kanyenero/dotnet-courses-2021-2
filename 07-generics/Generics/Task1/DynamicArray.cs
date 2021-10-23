using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    // Аргумент типа данных DynamicArray дожен иметь конструктор без параметров!
    class DynamicArray <CollectionElement> where CollectionElement : new()
    {
        // Конструктор по умолчанию. Создается массив емкости 8 ячеек
        public DynamicArray()
        {
            Length = 8;
            _array = new CollectionElement[Length];
        }

        // Конструктор с параметром. Создается новый массив заданной емкости
        public DynamicArray(uint length)
        {
            Length = length;
            _array = new CollectionElement[Length];
        }

        // Конструктор с параметром. Создается новый массив заданной емкости
        public DynamicArray(CollectionElement[] array)
        {
            _array = new CollectionElement[array.Length];
            Array.Copy(array, _array, array.Length);
        }

        private uint _length; // Размер массива
        private uint _capacity = 1; // Емкость массива
        public uint Length 
        { 
            get { return _length; }
            set 
            {
                while(value > _capacity) { _capacity *= 2; }
                _length = value;
            }
        }
        public uint Capacity { get { return _capacity; } }


        public CollectionElement[] _array; // Массив
        public CollectionElement this[uint idx]
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

        // Метод добавляет в конец массива 1 элемент.
        // При нехватке места для добавления элемента
        // емкость массива расширяется в 2 раза
        public void Add(CollectionElement element)
        {
            Length++;
            Array.Resize<CollectionElement>(ref _array, (int)Length);
            _array[Length - 1] = element;
        }

        // Добавляет в конец массива содержимое переданного массива
        public void AddRange(CollectionElement[] range)
        {
            uint old_length = Length;
            Length += (uint)range.Length;

            Array.Resize<CollectionElement>(ref _array, (int)Length);

            range.CopyTo(_array, old_length);
        }

        // Удаляет из коллекции указанный элемент.
        // Возвращает true, если удаление прошло успешно
        // и false в противном случае.
        // При удалении элементов уменьшается длина (Length),
        // а реальная емкость массива (Capacity) не уменьшается.
        public bool Remove(CollectionElement element)
        {
            bool status = false;

            for(uint i = 0; i < Length; i++)
            {
                if (_array[i].Equals(element))
                {
                    // Сместить все элементы на одну позицию влево
                    for (uint j = i; j < Length - 1; j++)
                        _array[j] = _array[j + 1];

                    // Отсечь ненужную ячейку в конце
                    Array.Resize<CollectionElement>(ref _array, (int)Length - 1);

                    Length--;
                    status = true;
                    break;
                }
            }

            if(status == false) Console.WriteLine($"Element {element} doesn't exist\n");

            return status;
        }

        // Добавляет элемент в произвольную позицию массива.
        // При выходе за границу массива генерируется исключение
        public void Insert(CollectionElement element, uint idx)
        {
            Length++;

            if (idx > Length)
                throw new ArgumentOutOfRangeException("Array out of bounds");

            // Расширить массив
            Array.Resize<CollectionElement>(ref _array, (int)Length);

            // Сместить все элементы на одну позицию вправо
            for (uint i = Length - 1; i > idx; i--)
                _array[i] = _array[i - 1];

            _array[idx] = element;
        }

        // Выводит созданный массив в консоль
        public void Print()
        {
            Console.WriteLine($"Array [size: {Length}] [capacity: {Capacity}]");

            for (int i = 0; i < Length; i++)
                Console.WriteLine($"Array [idx: {i}] [val: {_array[i]}]");

            Console.WriteLine();
        }
    }
}
