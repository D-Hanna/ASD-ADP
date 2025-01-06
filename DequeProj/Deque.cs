using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DequeProj
{
    public class Deque<T>
    {
        private T[] _items;
        private int _front;
        private int _back;
        private int _count;

        private const int DefaultCapacity = 4;

        public Deque()
        {
            _items = new T[DefaultCapacity];
            _front = 0;
            _back = 0;
            _count = 0;
        }

        public void AddFront(T item)
        {
            EnsureCapacity();
            _front = (_front - 1 + _items.Length) % _items.Length; 
            _items[_front] = item;
            _count++;
        }

        public void AddBack(T item)
        {
            EnsureCapacity();
            _items[_back] = item;
            _back = (_back + 1) % _items.Length; 
            _count++;
        }

        public T RemoveFront()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Deque is empty.");

            T value = _items[_front];
            _items[_front] = default;
            _front = (_front + 1) % _items.Length;
            _count--;
            return value;
        }

        public T RemoveBack()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Deque is empty.");

            _back = (_back - 1 + _items.Length) % _items.Length;
            T value = _items[_back];
            _items[_back] = default;
            _count--;
            return value;
        }

        public T PeekFront()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Deque is empty.");
            return _items[_front];
        }

        public T PeekBack()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Deque is empty.");
            int backIndex = (_back - 1 + _items.Length) % _items.Length;
            return _items[backIndex];
        }

        public bool IsEmpty => _count == 0;

        public int Count => _count;

        private void EnsureCapacity()
        {
            if (_count == _items.Length)
            {
                int newCapacity = _items.Length * 2;
                T[] newItems = new T[newCapacity];

                for (int i = 0; i < _count; i++)
                {
                    newItems[i] = _items[(_front + i) % _items.Length];
                }

                _items = newItems;
                _front = 0;
                _back = _count;
            }
        }
    }
}
