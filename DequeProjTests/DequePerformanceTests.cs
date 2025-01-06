using Microsoft.VisualStudio.TestTools.UnitTesting;
using DequeProj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using ASD_ADP;

namespace DequeProj.Tests
{
    [TestClass()]
    public class DequePerformanceTests
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
    }
}
