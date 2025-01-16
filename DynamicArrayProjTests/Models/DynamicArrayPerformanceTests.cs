using Microsoft.VisualStudio.TestTools.UnitTesting;
using DynamicArrayProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASD_ADP;
using System.Diagnostics;
using System.Data;

namespace DynamicArrayProj.Models.Tests
{
    [TestClass()]
    public class DynamicArrayPerformanceTests
    {

        [TestMethod()]
        public void Performance_Add()
        {
            var dataset = DataSets.LijstFloat8001;
            var dynamicArray = new DynamicArray<object>();
            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (var item in dataset)
            {
                dynamicArray.Add(item);
            }
            stopwatch.Stop();
            Console.WriteLine($"DynamicArray Add: {stopwatch.ElapsedMilliseconds} ms");
            Assert.AreEqual(dataset.Length, dynamicArray.Count);
        }

        [TestMethod()]
        public void Performance_RemoveAt()
        {
            var dataset = DataSets.LijstFloat8001;
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
        }

        [TestMethod()]
        public void Performance_Get()
        {
            var dataset = DataSets.LijstFloat8001;
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
        }

        [TestMethod()]
        public void Performance_Clear()
        {
            var dataset = DataSets.LijstFloat8001;
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
        }

        [TestMethod()]
        public void Performance_Set()
        {
            var dataset = DataSets.LijstFloat8001;
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
        }

        [TestMethod()]
        public void Performance_Contains()
        {
            var dataset = DataSets.LijstFloat8001;
            var dynamicArray = new DynamicArray<object>();
            foreach (var item in dataset)
            {
                dynamicArray.Add(item);
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < dynamicArray.Count; i++)
            {
                dynamicArray.Contains(dataset[i]);
            }
            stopwatch.Stop();
            Console.WriteLine($"DynamicArray Contains: {stopwatch.ElapsedMilliseconds} ms");
        }

        [TestMethod()]
        public void Performance_Remove()
        {
            var dataset = DataSets.LijstFloat8001;
            var dynamicArray = new DynamicArray<object>();
            foreach (var item in dataset)
            {
                dynamicArray.Add(item);
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (var item in dataset)
            {
                dynamicArray.Remove(item);
            }
            stopwatch.Stop();
            Console.WriteLine($"DynamicArray Remove: {stopwatch.ElapsedMilliseconds} ms");
            Assert.AreEqual(0, dynamicArray.Count);
        }

        [TestMethod()]
        public void Performance_Find()
        {
            var dataset = DataSets.LijstFloat8001;
            var dynamicArray = new DynamicArray<object>();
            foreach (var item in dataset)
            {
                dynamicArray.Add(item);
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < dynamicArray.Count; i++)
            {
                dynamicArray.Find(dataset[i]);
            }
            stopwatch.Stop();
            Console.WriteLine($"DynamicArray Find: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}