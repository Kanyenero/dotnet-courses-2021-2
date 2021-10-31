using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    // Аргумент типа данных DynamicArray дожен иметь конструктор без параметров!
    class DynamicArray <TCollectionElement> where TCollectionElement : notnull, new()
    {
        // Конструктор с параметром. Создается новый массив заданной емкости
        public DynamicArray(int capacity)
        {
            _array = new TCollectionElement[capacity];
            _length = 0;
        }

        // Конструктор с параметром. Создается новый массив из существующего
        public DynamicArray(TCollectionElement[] array) 
            : this(array.Length)
        {
            _length = array.Length;
            Array.Copy(array, _array, _length);
        }

        // Конструктор по умолчанию. Создается массив емкости 8 ячеек
        public DynamicArray() 
            : this(8)
        {
        }

        private int _length; // Размер массива

        // Свойства позволят пользователю получить значения длины и емкости массива
        public int Length { get { return _length; } }
        public int Capacity { get { return _array.Length; } }


        // Массив, с которым мы работаем
        public TCollectionElement[] _array;

        // Индексатор, позволяющий использовать обращение вида []
        public TCollectionElement this[int idx]
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

        // Вынесем общий метод увеличения длины, чтобы было видно очевидно, когда что как увеличивается.
        // Метод должен уметь увеличивать массив - то есть ресайзить его.
        public void Resize(int length)
        {
            if (_array.Length < length) 
                Array.Resize<TCollectionElement>(ref _array, length * 2);

            _length = length;
        }

        // Метод добавляет в конец массива 1 элемент.
        public void Add(TCollectionElement element)
        {
            _length++;
            Resize(_length);
            _array[_length - 1] = element;
        }

        // Добавляет в конец массива содержимое переданного массива
        public void AddRange(TCollectionElement[] range)
        {
            int old_length = _length;
            Resize(_length + range.Length);

            Array.Copy(range, 0, _array, old_length, range.Length);
        }

        // Удаляет из коллекции указанный элемент.
        // Возвращает true, если удаление прошло успешно
        // и false в противном случае.
        // При удалении элементов уменьшается длина (Length),
        // а реальная емкость массива (Capacity) не уменьшается.
        public bool Remove(TCollectionElement element)
        {
            bool removed = false;
            
            for(int i = 0; i < _length; i++)
            {
                if (_array[i].Equals(element))
                {
                    Array.Copy(_array, i + 1, _array, i, _length - i);

                    _length--;
                    removed = true;
                    break;
                }
            }

            return removed;
        }

        // Добавляет элемент в произвольную позицию массива.
        // При выходе за границу массива генерируется исключение
        public void Insert(TCollectionElement element, int idx)
        {
            if (idx > _length)
                throw new ArgumentOutOfRangeException("Array out of bounds");

            _length++;
            Resize(_length);

            Array.Copy(_array, idx, _array, idx + 1, _length - idx);

            // Перезаписать данные в ячейке
            _array[idx] = element;
        }

        public override string ToString()
        {
            //StringBuilder
            StringBuilder sb = new StringBuilder();
            sb.Append(String.Format("Array [length: {0}] [capacity: {1}]\n", _length, _array.Length));

            for (int i = 0; i < _array.Length; i++)
                sb.Append(String.Format("Array [idx: {0}] [val: {1}]\n", i, _array[i]));

            return sb.ToString();
        }
    }
}
