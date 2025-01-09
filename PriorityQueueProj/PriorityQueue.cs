using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueueProj
{
    public class PriorityQueue<T>
    {
        public (T Item, int Priority)[] _heap;
        public int _size;

        public PriorityQueue(int capacity = 16)
        {
            _heap = new (T, int)[capacity];
            _size = 0;
        }

        public void Enqueue(T item, int priority)
        {
            if (_size == _heap.Length)
            {
                Resize();
            }

            _heap[_size] = (item, priority);
            HeapifyUp(_size);
            _size++;
        }

        public T Dequeue()
        {
            if (_size == 0)
                throw new InvalidOperationException("The priority queue is empty.");

            T topItem = _heap[0].Item;

            _heap[0] = _heap[_size - 1];
            _size--;

            HeapifyDown(0);

            return topItem;
        }

        public T Peek()
        {
            if (_size == 0)
                throw new InvalidOperationException("The priority queue is empty.");

            return _heap[0].Item;
        }

        public int Count => _size;

        public void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parentIndex = (index - 1) / 2;

                if (_heap[index].Priority >= _heap[parentIndex].Priority)
                    break;

                Swap(index, parentIndex);
                index = parentIndex;
            }
        }

        public void HeapifyDown(int index)
        {
            while (true)
            {
                int smallest = index;
                int leftChild = 2 * index + 1;
                int rightChild = 2 * index + 2;

                if (leftChild < _size && _heap[leftChild].Priority < _heap[smallest].Priority)
                {
                    smallest = leftChild;
                }

                if (rightChild < _size && _heap[rightChild].Priority < _heap[smallest].Priority)
                {
                    smallest = rightChild;
                }

                if (smallest == index)
                    break;

                Swap(index, smallest);
                index = smallest;
            }
        }

        public void Swap(int i, int j)
        {
            var temp = _heap[i];
            _heap[i] = _heap[j];
            _heap[j] = temp;
        }

        public void Resize()
        {
            int newCapacity = _heap.Length * 2;
            var newHeap = new (T, int)[newCapacity];
            Array.Copy(_heap, newHeap, _size);
            _heap = newHeap;
        }
    }
}
