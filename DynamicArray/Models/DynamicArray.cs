using System;
using System.Text.Json;

namespace DynamicArrayProj.Models
{

    public class DynamicArray<T>
    {
        private T[] _array;
        private int _count;

        private const int DefaultCapacity = 4;

        public DynamicArray()
        {
            _array = new T[DefaultCapacity];
            _count = 0;
        }

        public int Count => _count;

        public int Capacity => _array.Length;

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _count)
                    throw new ArgumentOutOfRangeException(nameof(index));

                return _array[index];
            }
            set
            {
                if (index < 0 || index >= _count)
                    throw new ArgumentOutOfRangeException(nameof(index));

                _array[index] = value;
            }
        }

        public void Set(int index, T item)
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException(nameof(index));

            _array[index] = item;
        }

        public void Add(T item)
        {
            if (_count == _array.Length)
            {
                Resize(_array.Length * 2);
            }

            _array[_count++] = item;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_array[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public int Find(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_array[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException(nameof(index));

            for (int i = index; i < _count - 1; i++)
            {
                _array[i] = _array[i + 1];
            }

            _count--;
            _array[_count] = default;

            if (_count > 0 && _count == _array.Length / 4)
            {
                Resize(_array.Length / 2);
            }
        }

        public bool Remove(T item)
        {
            int index = Find(item);
            if (index == -1)
            {
                return false;
            }

            RemoveAt(index);
            return true;
        }

        public void Clear()
        {
            _array = new T[DefaultCapacity];
            _count = 0;
        }

        private void Resize(int newSize)
        {
            T[] newArray = new T[newSize];
            for (int i = 0; i < _count; i++)
            {
                newArray[i] = _array[i];
            }

            _array = newArray;
        }
    }

}
