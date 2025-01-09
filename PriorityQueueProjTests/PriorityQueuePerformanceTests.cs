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
    public class PriorityQueuePerformanceTests
    {
        [TestMethod()]
        public void Test_EnqueuePerformance()
        {
            var dataset = DataSets.RandomList(100000, 0, 100000);
            var pq = new PriorityQueue<int>();

            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (var item in dataset)
            {
                pq.Enqueue(item, item);
            }
            stopwatch.Stop();
            Console.WriteLine($"PriorityQueue Enqueue: {stopwatch.ElapsedMilliseconds} ms");
        }

        [TestMethod()]
        public void Test_DequeuePerformance()
        {
            var dataset = DataSets.RandomList(100000, 0, 100000);
            var pq = new PriorityQueue<int>();
            foreach (var item in dataset)
            {
                pq.Enqueue(item, item);
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            while (pq.Count > 0)
            {
                pq.Dequeue();
            }
            stopwatch.Stop();
            Console.WriteLine($"PriorityQueue Dequeue: {stopwatch.ElapsedMilliseconds} ms");
        }

        [TestMethod()]
        public void Test_PeekPerformance()
        {
            var dataset = DataSets.RandomList(100000, 0, 100000);
            var pq = new PriorityQueue<int>();
            foreach (var item in dataset)
            {
                pq.Enqueue(item, item);
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < 100000; i++)
            {
                pq.Peek();
            }
            stopwatch.Stop();
            Console.WriteLine($"PriorityQueue Peek: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}