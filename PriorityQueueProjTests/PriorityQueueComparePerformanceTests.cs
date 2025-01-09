using ASD_ADP;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PriorityQueueProj;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueueProj.Tests
{
    [TestClass()]
    public class PriorityQueueComparePerformanceTests
    {
        [TestMethod()]
        public void Compare_EnqueuePerformance()
        {
            var dataset = DataSets.RandomList(100000, 0, 100000);
            var pq = new PriorityQueue<int>();
            var list = new List<(int Item, int Priority)>();

            // PriorityQueue Enqueue
            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (var item in dataset)
            {
                pq.Enqueue(item, item);
            }
            stopwatch.Stop();
            Console.WriteLine($"PriorityQueue Enqueue: {stopwatch.ElapsedMilliseconds} ms");

            // List Enqueue
            stopwatch.Restart();
            foreach (var item in dataset)
            {
                list.Add((item, item));
                list.Sort((x, y) => x.Priority.CompareTo(y.Priority));
            }
            stopwatch.Stop();
            Console.WriteLine($"List Enqueue: {stopwatch.ElapsedMilliseconds} ms");
        }

        [TestMethod()]
        public void Compare_DequeuePerformance()
        {
            var dataset = DataSets.RandomList(100000, 0, 100000);
            var pq = new PriorityQueue<int>();
            var list = new List<(int Item, int Priority)>();

            foreach (var item in dataset)
            {
                pq.Enqueue(item, item);
                list.Add((item, item));
            }
            list.Sort((x, y) => x.Priority.CompareTo(y.Priority));

            // PriorityQueue Dequeue
            Stopwatch stopwatch = Stopwatch.StartNew();
            while (pq.Count > 0)
            {
                pq.Dequeue();
            }
            stopwatch.Stop();
            Console.WriteLine($"PriorityQueue Dequeue: {stopwatch.ElapsedMilliseconds} ms");

            // List Dequeue
            stopwatch.Restart();
            while (list.Count > 0)
            {
                list.RemoveAt(0);
            }
            stopwatch.Stop();
            Console.WriteLine($"List Dequeue: {stopwatch.ElapsedMilliseconds} ms");
        }

        [TestMethod()]
        public void Compare_PeekPerformance()
        {
            var dataset = DataSets.RandomList(100000, 0, 100000);
            var pq = new PriorityQueue<int>();
            var list = new List<(int Item, int Priority)>();

            foreach (var item in dataset)
            {
                pq.Enqueue(item, item);
                list.Add((item, item));
            }
            list.Sort((x, y) => x.Priority.CompareTo(y.Priority));

            // PriorityQueue Peek
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < 100000; i++)
            {
                pq.Peek();
            }
            stopwatch.Stop();
            Console.WriteLine($"PriorityQueue Peek: {stopwatch.ElapsedMilliseconds} ms");

            // List Peek
            stopwatch.Restart();
            for (int i = 0; i < 100000; i++)
            {
                var topItem = list[0].Item;
            }
            stopwatch.Stop();
            Console.WriteLine($"List Peek: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}