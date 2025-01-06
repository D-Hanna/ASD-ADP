using Microsoft.VisualStudio.TestTools.UnitTesting;
using DequeProj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASD_ADP;
using System.Diagnostics;

namespace DequeProj.Tests
{
    [TestClass()]
    public class DequeComparePerformanceTests
    {
        [TestMethod]
        public void Test_AddFrontPerformance()
        {
            var dataset = DataSets.RandomList(100000, 0, 100000);
            var deque = new Deque<int>();

            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (var item in dataset)
            {
                deque.AddFront(item);
            }
            stopwatch.Stop();
            Console.WriteLine($"Deque AddFront: {stopwatch.ElapsedMilliseconds} ms");
        }

        [TestMethod]
        public void Test_AddBackPerformance()
        {
            var dataset = DataSets.RandomList(100000, 0, 100000);
            var deque = new Deque<int>();

            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (var item in dataset)
            {
                deque.AddBack(item);
            }
            stopwatch.Stop();
            Console.WriteLine($"Deque AddBack: {stopwatch.ElapsedMilliseconds} ms");
        }

        [TestMethod]
        public void Test_RemoveFrontPerformance()
        {
            var dataset = DataSets.RandomList(100000, 0, 100000);
            var deque = new Deque<int>();
            foreach (var item in dataset)
            {
                deque.AddBack(item);
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            while (!deque.IsEmpty)
            {
                deque.RemoveFront();
            }
            stopwatch.Stop();
            Console.WriteLine($"Deque RemoveFront: {stopwatch.ElapsedMilliseconds} ms");
        }

        [TestMethod]
        public void Test_RemoveBackPerformance()
        {
            var dataset = DataSets.RandomList(100000, 0, 100000);
            var deque = new Deque<int>();
            foreach (var item in dataset)
            {
                deque.AddBack(item);
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            while (!deque.IsEmpty)
            {
                deque.RemoveBack();
            }
            stopwatch.Stop();
            Console.WriteLine($"Deque RemoveBack: {stopwatch.ElapsedMilliseconds} ms");
        }

        [TestMethod]
        public void Compare_AddFrontPerformance()
        {
            var dataset = DataSets.RandomList(100000, 0, 100000);
            var deque = new Deque<int>();
            var linkedList = new LinkedList<int>();

            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (var item in dataset)
            {
                deque.AddFront(item);
            }
            stopwatch.Stop();
            Console.WriteLine($"Deque AddFront: {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Restart();
            foreach (var item in dataset)
            {
                linkedList.AddFirst(item);
            }
            stopwatch.Stop();
            Console.WriteLine($"LinkedList AddFront: {stopwatch.ElapsedMilliseconds} ms");
        }

        [TestMethod]
        public void Compare_AddBackPerformance()
        {
            var dataset = DataSets.RandomList(100000, 0, 100000);
            var deque = new Deque<int>();
            var linkedList = new LinkedList<int>();

            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (var item in dataset)
            {
                deque.AddBack(item);
            }
            stopwatch.Stop();
            Console.WriteLine($"Deque AddBack: {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Restart();
            foreach (var item in dataset)
            {
                linkedList.AddLast(item);
            }
            stopwatch.Stop();
            Console.WriteLine($"LinkedList AddBack: {stopwatch.ElapsedMilliseconds} ms");
        }

        [TestMethod]
        public void Compare_RemoveFrontPerformance()
        {
            var dataset = DataSets.RandomList(100000, 0, 100000);
            var deque = new Deque<int>();
            var linkedList = new LinkedList<int>();

            foreach (var item in dataset)
            {
                deque.AddBack(item);
                linkedList.AddLast(item);
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            while (!deque.IsEmpty)
            {
                deque.RemoveFront();
            }
            stopwatch.Stop();
            Console.WriteLine($"Deque RemoveFront: {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Restart();
            while (linkedList.Count > 0)
            {
                linkedList.RemoveFirst();
            }
            stopwatch.Stop();
            Console.WriteLine($"LinkedList RemoveFront: {stopwatch.ElapsedMilliseconds} ms");
        }

        [TestMethod]
        public void Compare_RemoveBackPerformance()
        {
            var dataset = DataSets.RandomList(100000, 0, 100000);
            var deque = new Deque<int>();
            var linkedList = new LinkedList<int>();

            foreach (var item in dataset)
            {
                deque.AddBack(item);
                linkedList.AddLast(item);
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            while (!deque.IsEmpty)
            {
                deque.RemoveBack();
            }
            stopwatch.Stop();
            Console.WriteLine($"Deque RemoveBack: {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Restart();
            while (linkedList.Count > 0)
            {
                linkedList.RemoveLast();
            }
            stopwatch.Stop();
            Console.WriteLine($"LinkedList RemoveBack: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}