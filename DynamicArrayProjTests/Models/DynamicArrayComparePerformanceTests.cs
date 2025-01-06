using Microsoft.VisualStudio.TestTools.UnitTesting;
using DynamicArrayProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics;
using ASD_ADP;

namespace DynamicArrayProj.Models.Tests
{
    [TestClass()]
    public class DynamicArrayComparePerformanceTests
    {
                [TestMethod()]
        public void Compare_Add()
        {
            var dataset = DataSets.RandomList(100000, 0, 100000);
            var dynamicArray = new DynamicArray<object>();
            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (var item in dataset)
            {
                dynamicArray.Add(item);
            }
            stopwatch.Stop();
            Console.WriteLine($"DynamicArray Add: {stopwatch.ElapsedMilliseconds} ms");
            Assert.AreEqual(dataset.Length, dynamicArray.Count);

            var list = new List<object>();
            stopwatch.Restart();
            foreach (var item in dataset)
            {
                list.Add(item);
            }
            stopwatch.Stop();
            Console.WriteLine($"List Add: {stopwatch.ElapsedMilliseconds} ms");
            Assert.AreEqual(dataset.Length, list.Count);
        }

        [TestMethod()]
        public void Compare_RemoveAt()
        {
            var dataset = DataSets.RandomList(100000, 0, 100000);
            var dynamicArray = new DynamicArray<object>();
            foreach (var item in dataset)
            {
                dynamicArray.Add(item);
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = dynamicArray.Count - 1; i >= 0; i--)
            {
                dynamicArray.RemoveAt(i);
            }
            stopwatch.Stop();
            Console.WriteLine($"DynamicArray RemoveAt: {stopwatch.ElapsedMilliseconds} ms");
            Assert.AreEqual(0, dynamicArray.Count);

            var list = new List<object>(dataset);
            stopwatch.Restart();
            for (int i = list.Count - 1; i >= 0; i--)
            {
                list.RemoveAt(i);
            }
            stopwatch.Stop();
            Console.WriteLine($"List RemoveAt: {stopwatch.ElapsedMilliseconds} ms");
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod()]
        public void Compare_Get()
        {
            var dataset = DataSets.RandomList(100000, 0, 100000);
            var dynamicArray = new DynamicArray<object>();
            foreach (var item in dataset)
            {
                dynamicArray.Add(item);
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < dynamicArray.Count; i++)
            {
                var item = dynamicArray[i];
            }
            stopwatch.Stop();
            Console.WriteLine($"DynamicArray Get: {stopwatch.ElapsedMilliseconds} ms");

            var list = new List<object>(dataset);
            stopwatch.Restart();
            for (int i = 0; i < list.Count; i++)
            {
                var item = list[i];
            }
            stopwatch.Stop();
            Console.WriteLine($"List Get: {stopwatch.ElapsedMilliseconds} ms");
        }

        [TestMethod()]
        public void Compare_Set()
        {
            var dataset = DataSets.RandomList(100000, 0, 100000);
            var dynamicArray = new DynamicArray<object>();
            foreach (var item in dataset)
            {
                dynamicArray.Add(item);
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < dynamicArray.Count; i++)
            {
                dynamicArray[i] = dataset[i];
            }
            stopwatch.Stop();
            Console.WriteLine($"DynamicArray Set: {stopwatch.ElapsedMilliseconds} ms");

            var list = new List<object>(dataset);
            stopwatch.Restart();
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = dataset[i];
            }
            stopwatch.Stop();
            Console.WriteLine($"List Set: {stopwatch.ElapsedMilliseconds} ms");
        }

        [TestMethod()]
        public void Compare_Clear()
        {
            var dataset = DataSets.RandomList(100000, 0, 100000);
            var dynamicArray = new DynamicArray<object>();
            foreach (var item in dataset)
            {
                dynamicArray.Add(item);
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            dynamicArray.Clear();
            stopwatch.Stop();
            Console.WriteLine($"DynamicArray Clear: {stopwatch.ElapsedMilliseconds} ms");
            Assert.AreEqual(0, dynamicArray.Count);

            var list = new List<object>(dataset);
            stopwatch.Restart();
            list.Clear();
            stopwatch.Stop();
            Console.WriteLine($"List Clear: {stopwatch.ElapsedMilliseconds} ms");
            Assert.AreEqual(0, list.Count);
        }
    }
}