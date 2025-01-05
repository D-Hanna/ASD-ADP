﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using DoublyLinkedListProj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using ASD_ADP;
using System.Data;

namespace DoublyLinkedListProj.Tests
{
    [TestClass()]
    public class DoublyLinkedListPerformanceComparisonTests
    {
        [TestMethod()]
        public void Compare_AddFirst()
        {
            var dataset = DataSets.RandomList(100000, 0, 100000);

            var list = new DoublyLinkedList<int>();
            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (var item in dataset)
            {
                list.AddFirst(item);
            }
            stopwatch.Stop();
            Console.WriteLine($"DoublyLinkedList AddFirst: {stopwatch.ElapsedMilliseconds} ms");
            Assert.AreEqual(100000, list.Count);

            var normalList = new List<int>();
            stopwatch.Restart();
            foreach (var item in dataset)
            {
                normalList.Insert(0, item);
            }
            stopwatch.Stop();
            Console.WriteLine($"List AddFirst: {stopwatch.ElapsedMilliseconds} ms");
            Assert.AreEqual(100000, normalList.Count);
        }

        [TestMethod()]
        public void Compare_AddLast()
        {
            var dataset = DataSets.RandomList(100000, 0, 100000);
            var list = new DoublyLinkedList<int>();
            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (var item in dataset)
            {
                list.AddLast(item);
            }
            stopwatch.Stop();
            Console.WriteLine($"DoublyLinkedList AddLast: {stopwatch.ElapsedMilliseconds} ms");
            Assert.AreEqual(100000, list.Count);

            var normalList = new List<int>();
            stopwatch.Restart();
            foreach (var item in dataset)
            {
                normalList.Add(item);
            }
            stopwatch.Stop();
            Console.WriteLine($"List AddLast: {stopwatch.ElapsedMilliseconds} ms");
            Assert.AreEqual(100000, normalList.Count);
        }

        [TestMethod()]
        public void Compare_RemoveFirst()
        {
            var dataset = DataSets.RandomList(100000, 0, 100000);
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
            Console.WriteLine($"DoublyLinkedList RemoveFirst: {stopwatch.ElapsedMilliseconds} ms");
            Assert.AreEqual(0, list.Count);

            var normalList = new List<int>();
            foreach (var item in dataset)
            {
                normalList.Add(item);
            }

            stopwatch.Restart();
            while (normalList.Count > 0)
            {
                normalList.RemoveAt(0);
            }
            stopwatch.Stop();
            Console.WriteLine($"List RemoveFirst: {stopwatch.ElapsedMilliseconds} ms");
            Assert.AreEqual(0, normalList.Count);
        }

        [TestMethod()]
        public void Compare_RemoveLast()
        {
            var dataset = DataSets.RandomList(100000, 0, 100000);
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
            Console.WriteLine($"DoublyLinkedList RemoveLast: {stopwatch.ElapsedMilliseconds} ms");
            Assert.AreEqual(0, list.Count);

            var normalList = new List<int>();
            foreach (var item in dataset)
            {
                normalList.Add(item);
            }

            stopwatch.Restart();
            while (normalList.Count > 0)
            {
                normalList.RemoveAt(normalList.Count - 1);
            }
            stopwatch.Stop();
            Console.WriteLine($"List RemoveLast: {stopwatch.ElapsedMilliseconds} ms");
            Assert.AreEqual(0, normalList.Count);
        }

        [TestMethod()]
        public void Compare_InsertAt()
        {
            var dataset = DataSets.RandomList(100000, 0, 100000);
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
            Console.WriteLine($"DoublyLinkedList InsertAt: {stopwatch.ElapsedMilliseconds} ms");

            var normalList = new List<int>();
            foreach (var item in dataset)
            {
                normalList.Add(item);
            }

            stopwatch.Restart();
            for (int i = 0; i < 1000; i++)
            {
                normalList.Insert(normalList.Count / 2, i);
            }
            stopwatch.Stop();
            Console.WriteLine($"List InsertAt: {stopwatch.ElapsedMilliseconds} ms");
        }

        [TestMethod()]
        public void Compare_DeleteAt()
        {
            var dataset = DataSets.RandomList(100000, 0, 100000);
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
            Console.WriteLine($"DoublyLinkedList DeleteAt: {stopwatch.ElapsedMilliseconds} ms");

            var normalList = new List<int>();
            foreach (var item in dataset)
            {
                normalList.Add(item);
            }

            stopwatch.Restart();
            while (normalList.Count > 0)
            {
                normalList.RemoveAt(normalList.Count / 2);
            }
            stopwatch.Stop();
            Console.WriteLine($"List DeleteAt: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}