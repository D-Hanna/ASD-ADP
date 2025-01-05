using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackProj
{    public class Stack<T>
    {
        private T[] _items;
        private int _top;
        private int _capacity;

        public Stack(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException("Capacity must be greater than zero.", nameof(capacity));
            }

            _capacity = capacity;
            _items = new T[capacity];
            _top = -1; 
        }

        public void Push(T item)
        {
            if (_top == _capacity - 1)
            {
                throw new InvalidOperationException("Stack overflow. Cannot add more items.");
            }

            _items[++_top] = item;
        }

        public T Pop()
        {
            if (_top == -1)
            {
                throw new InvalidOperationException("Stack underflow. No items to remove.");
            }

            return _items[_top--];
        }

        public T Peek()
        {
            if (_top == -1)
            {
                throw new InvalidOperationException("Stack is empty. No items to peek.");
            }

            return _items[_top];
        }

        public bool IsEmpty()
        {
            return _top == -1;
        }

        public int Count()
        {
            return _top + 1;
        }
    }
}
