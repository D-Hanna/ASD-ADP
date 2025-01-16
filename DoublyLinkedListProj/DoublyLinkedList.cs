using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedListProj
{
    public class DoublyLinkedList<T>
    {
        private class Node
        {
            public T Data;
            public Node Next;
            public Node Prev;

            public Node(T data)
            {
                Data = data;
                Next = null;
                Prev = null;
            }
        }

        private Node head;
        private Node tail;
        public int Count { get; private set; }

        public DoublyLinkedList()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        public void Add(T data, int position = 0)
        {
            if (position < 0 || position > Count) throw new ArgumentOutOfRangeException(nameof(position));

            if (position == 0)
            {
                AddFirst(data);
                return;
            }
            if (position == Count)
            {
                AddLast(data);
                return;
            }

            Node newNode = new Node(data);
            Node current = head;
            for (int i = 0; i < position - 1; i++)
            {
                current = current.Next;
            }

            newNode.Next = current.Next;
            newNode.Prev = current;
            current.Next.Prev = newNode;
            current.Next = newNode;

            Count++;
        }

        public T Get(int position)
        {
            if (position < 0 || position >= Count) throw new ArgumentOutOfRangeException(nameof(position));

            Node current = head;
            for (int i = 0; i < position; i++)
            {
                current = current.Next;
            }

            return current.Data;
        }

        public void Set(int position, T data)
        {
            if (position < 0 || position >= Count) throw new ArgumentOutOfRangeException(nameof(position));

            Node current = head;
            for (int i = 0; i < position; i++)
            {
                current = current.Next;
            }

            current.Data = data;
        }

        public void DeleteAt(int position)
        {
            if (position < 0 || position >= Count) throw new ArgumentOutOfRangeException(nameof(position));

            if (position == 0)
            {
                RemoveFirst();
                return;
            }
            if (position == Count - 1)
            {
                RemoveLast();
                return;
            }

            Node current = head;
            for (int i = 0; i < position; i++)
            {
                current = current.Next;
            }

            current.Prev.Next = current.Next;
            current.Next.Prev = current.Prev;

            Count--;
        }

        public void AddFirst(T data)
        {
            Node newNode = new Node(data);
            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head.Prev = newNode;
                head = newNode;
            }
            Count++;
        }

        public void AddLast(T data)
        {
            Node newNode = new Node(data);
            if (tail == null)
            {
                head = tail = newNode;
            }
            else
            {
                newNode.Prev = tail;
                tail.Next = newNode;
                tail = newNode;
            }
            Count++;
        }

        public void RemoveFirst()
        {
            if (head == null) throw new InvalidOperationException("The list is empty.");

            if (head == tail)
            {
                head = tail = null;
            }
            else
            {
                head = head.Next;
                head.Prev = null;
            }
            Count--;
        }

        public void RemoveLast()
        {
            if (tail == null) throw new InvalidOperationException("The list is empty.");

            if (head == tail)
            {
                head = tail = null;
            }
            else
            {
                tail = tail.Prev;
                tail.Next = null;
            }
            Count--;
        }

        public bool Remove(T item)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    if (current == head)
                    {
                        RemoveFirst();
                    }
                    else if (current == tail)
                    {
                        RemoveLast();
                    }
                    else
                    {
                        current.Prev.Next = current.Next;
                        current.Next.Prev = current.Prev;
                        Count--;
                    }
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public bool Contains(T item)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public int Find(T item)
        {
            Node current = head;
            int index = 0;
            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    return index;
                }
                current = current.Next;
                index++;
            }
            return -1;
        }
    }
}
