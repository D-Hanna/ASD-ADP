using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchAndSort.Search;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAndSort.Search.Tests
{
    [TestClass()]
    public class BinarySearchPerformanceTests
    {
        [TestMethod()]
        public void Test_BinarySearchPerformance()
        {
            var binarySearch = new BinarySearch<int>();
            int[] array = new int[1000000];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }

            int target = 999999;
            Stopwatch stopwatch = Stopwatch.StartNew();
            int index = binarySearch.Search(array, target);
            stopwatch.Stop();

            Console.WriteLine($"BinarySearch Time: {stopwatch.ElapsedMilliseconds} ms");
            Assert.AreEqual(target, index);
        }
    }
}