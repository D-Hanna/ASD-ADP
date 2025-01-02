using Microsoft.VisualStudio.TestTools.UnitTesting;
using DynamicArrayProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASD_ADP;
using System.Diagnostics;

namespace DynamicArrayProj.Models.Tests
{
    [TestClass()]
    public class DynamicArrayPerformanceTests
    {
        [TestMethod()]
        public void TestDynamicArrayPerformanceWithLijstFloat8001()
        {
            var dataset = DataSets.LijstFloat8001;
            var dynamicArray = new DynamicArray<object>();
            Stopwatch sw = Stopwatch.StartNew();
            foreach (var item in dataset)
            {
                dynamicArray.Add(item);
            }
            sw.Stop();
            Console.WriteLine("dynamic array filled with " + dynamicArray.Count + " items in " + sw.Elapsed.TotalMilliseconds + " milliseconds");
            Assert.IsTrue(dynamicArray.Count == dataset.Length, "The dynamic array count does not match the dataset length.");
        }

        [TestMethod()]
        public void TestDynamicArrayPerformanceWithLijstoplopend10000()
        {
            var dataset = DataSets.Lijstoplopend10000;
            var dynamicArray = new DynamicArray<object>();
            Stopwatch sw = Stopwatch.StartNew();
            foreach (var item in dataset)
            {
                dynamicArray.Add(item);
            }
            sw.Stop();
            Console.WriteLine("dynamic array filled with " + dynamicArray.Count + " items in " + sw.Elapsed.TotalMilliseconds + " milliseconds");
            Assert.IsTrue(dynamicArray.Count == dataset.Length, "The dynamic array count does not match the dataset length.");
        }

        [TestMethod()]
        public void TestDynamicArrayPerformanceWithLijstHerhaald1000()
        {
            var dataset = DataSets.LijstHerhaald1000;
            var dynamicArray = new DynamicArray<object>();
            Stopwatch sw = Stopwatch.StartNew();
            foreach (var item in dataset)
            {
                dynamicArray.Add(item);
            }
            sw.Stop();
            Console.WriteLine("dynamic array filled with " + dynamicArray.Count + " items in " + sw.Elapsed.TotalMilliseconds + " milliseconds");
            Assert.IsTrue(dynamicArray.Count == dataset.Length, "The dynamic array count does not match the dataset length.");
        }

        [TestMethod()]
        public void TestDynamicArrayRemovePerformance()
        {
            var dataset = DataSets.LijstFloat8001;
            var dynamicArray = new DynamicArray<object>();
            foreach (var item in dataset)
            {
                dynamicArray.Add(item);
            }

            Stopwatch sw = Stopwatch.StartNew();
            for (int i = dynamicArray.Count - 1; i >= 0; i--)
            {
                dynamicArray.RemoveAt(i);
            }
            sw.Stop();
            Console.WriteLine("dynamic array removed " + dataset.Length + " items in " + sw.Elapsed.TotalMilliseconds + " milliseconds");
            Assert.IsTrue(dynamicArray.Count == 0, "The dynamic array count should be zero after removing all items.");
        }

        [TestMethod()]
        public void TestDynamicArrayClearPerformance()
        {
            var dataset = DataSets.LijstFloat8001;
            var dynamicArray = new DynamicArray<object>();
            foreach (var item in dataset)
            {
                dynamicArray.Add(item);
            }

            Stopwatch sw = Stopwatch.StartNew();
            dynamicArray.Clear();
            sw.Stop();
            Console.WriteLine("dynamic array cleared in " + sw.Elapsed.TotalMilliseconds + " milliseconds");
            Assert.IsTrue(dynamicArray.Count == 0, "The dynamic array count should be zero after clearing.");
        }

        [TestMethod()]
        public void CompareDynamicArrayToListPerformance()
        {
            var dataset = DataSets.LijstFloat8001;

            var dynamicArray = new DynamicArray<object>();
            Stopwatch swDynamicArray = Stopwatch.StartNew();
            foreach (var item in dataset)
            {
                dynamicArray.Add(item);
            }
            swDynamicArray.Stop();
            Console.WriteLine("DynamicArray filled with " + dynamicArray.Count + " items in " + swDynamicArray.Elapsed.TotalMilliseconds + " milliseconds");

            var list = new List<object>();
            Stopwatch swList = Stopwatch.StartNew();
            foreach (var item in dataset)
            {
                list.Add(item);
            }
            swList.Stop();
            Console.WriteLine("List filled with " + list.Count + " items in " + swList.Elapsed.TotalMilliseconds + " milliseconds");

            Assert.IsTrue(dynamicArray.Count == list.Count, "The counts of DynamicArray and List do not match.");
        }


        [TestMethod()]
        public void CompareDynamicArrayToArrayPerformance()
        {
            var dataset = DataSets.LijstFloat8001;

            var dynamicArray = new DynamicArray<object>();
            Stopwatch swDynamicArray = Stopwatch.StartNew();
            foreach (var item in dataset)
            {
                dynamicArray.Add(item);
            }
            swDynamicArray.Stop();
            Console.WriteLine("DynamicArray filled with " + dynamicArray.Count + " items in " + swDynamicArray.Elapsed.TotalMilliseconds + " milliseconds");

            var array = new object[dataset.Length];
            Stopwatch swArray = Stopwatch.StartNew();
            for (int i = 0; i < dataset.Length; i++)
            {
                array[i] = dataset[i];
            }
            swArray.Stop();
            Console.WriteLine("Array filled with " + array.Length + " items in " + swArray.Elapsed.TotalMilliseconds + " milliseconds");

            // Assert that both collections have the same number of items
            Assert.IsTrue(dynamicArray.Count == array.Length, "The counts of DynamicArray and Array do not match.");
        }
    }
}