using Microsoft.VisualStudio.TestTools.UnitTesting;
using DoublyLinkedListProj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics;
using ASD_ADP;

namespace DoublyLinkedListProj.Tests
{
    [TestClass()]
    public class DoublyLinkedListPerformanceTests
    {
        [TestMethod()]
        public void Performance_AddFirst()
        {
            var dataset = DataSets.LijstFloat8001;
            var list = new DoublyLinkedList<int>();
            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (var item in dataset)
            {
                list.AddFirst(item);
            }
            stopwatch.Stop();
            Console.WriteLine($"AddFirst: {stopwatch.ElapsedMilliseconds} ms");
            Assert.AreEqual(100000, list.Count);
        }

        [TestMethod()]
        public void Performance_AddLast()
        {
            var dataset = DataSets.LijstFloat8001;
            var list = new DoublyLinkedList<int>();
            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (var item in dataset)
            {
                list.AddLast(item);
            }
            stopwatch.Stop();
            Console.WriteLine($"AddLast: {stopwatch.ElapsedMilliseconds} ms");
            Assert.AreEqual(100000, list.Count);
        }

        [TestMethod()]
        public void Performance_RemoveFirst()
        {
            var dataset = DataSets.LijstFloat8001;
            var list = new DoublyLinkedList<int>();
            foreach (var item in dataset)
            {
                list.AddLast(item);
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            while (list.Count > 0)
            {
                list.RemoveFirst();
            }
            stopwatch.Stop();
            Console.WriteLine($"RemoveFirst: {stopwatch.ElapsedMilliseconds} ms");
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod()]
        public void Performance_RemoveLast()
        {
            var dataset = DataSets.LijstFloat8001;
            var list = new DoublyLinkedList<int>();
            foreach (var item in dataset)
            {
                list.AddLast(item);
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            while (list.Count > 0)
            {
                list.RemoveLast();
            }
            stopwatch.Stop();
            Console.WriteLine($"RemoveLast: {stopwatch.ElapsedMilliseconds} ms");
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod()]
        public void Performance_InsertAt()
        {
            var dataset = DataSets.LijstFloat8001;
            var list = new DoublyLinkedList<int>();
            foreach (var item in dataset)
            {
                list.AddLast(item);
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < 1000; i++)
            {
                list.InsertAt(i, list.Count / 2);
            }
            stopwatch.Stop();
            Console.WriteLine($"InsertAt: {stopwatch.ElapsedMilliseconds} ms");
        }

        [TestMethod()]
        public void Performance_DeleteAt()
        {
            var dataset = DataSets.LijstFloat8001;
            var list = new DoublyLinkedList<int>();
            foreach (var item in dataset)
            {
                list.AddLast(item);
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            while (list.Count > 0)
            {
                list.DeleteAt(list.Count / 2);
            }
            stopwatch.Stop();
            Console.WriteLine($"DeleteAt: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}