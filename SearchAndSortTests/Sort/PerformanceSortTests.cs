using ASD_ADP;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchAndSort.Sort;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAndSort.Sort.Tests
{
    [TestClass()]
    public class PerformanceSortTests
    {
        [TestMethod]
        public void Test_InsertionSortPerformance()
        {
            var list = new List<int>();
            var random = new Random();
            for (int i = 0; i < 10000; i++)
            {
                list.Add(random.Next(0, 10000));
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            var sortedList = InsertionSort.Sort(list);
            stopwatch.Stop();

            Console.WriteLine($"InsertionSort Time: {stopwatch.ElapsedMilliseconds} ms");

            for (int i = 1; i < sortedList.Count; i++)
            {
                Assert.IsTrue(sortedList[i - 1].CompareTo(sortedList[i]) <= 0);
            }
        }

        //selection sort
        [TestMethod]
        public void Test_SelectionSortPerformance()
        {
            int[] array = new int[10000];
            var random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 10000);
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            SelectionSort.Sort(array);
            stopwatch.Stop();

            Console.WriteLine($"SelectionSort Time: {stopwatch.ElapsedMilliseconds} ms");

            for (int i = 1; i < array.Length; i++)
            {
                Assert.IsTrue(array[i - 1] <= array[i]);
            }
        }

        //quick sort
        [TestMethod]
        public void Test_QuickSortPerformance()
        {
            var list = new List<int>();
            var random = new Random();
            for (int i = 0; i < 10000; i++)
            {
                list.Add(random.Next(0, 10000));
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            QuickSort.Sort(list);
            stopwatch.Stop();

            Console.WriteLine($"QuickSort Time: {stopwatch.ElapsedMilliseconds} ms");

            for (int i = 1; i < list.Count; i++)
            {
                Assert.IsTrue(list[i - 1] <= list[i]);
            }
        }

        [TestMethod]
        public void Compare_SortPerformance()
        {
            var listSize = 10000;
            var minValue = 0;
            var maxValue = 10000;

            // Generate the same random list for each sort
            List<int> originalList = DataSets.RandomList(listSize, minValue, maxValue).OfType<int>().ToList();

            // InsertionSort
            var insertionSortList = new List<int>(originalList);
            Stopwatch stopwatch = Stopwatch.StartNew();
            var sortedInsertionList = InsertionSort.Sort(insertionSortList);
            stopwatch.Stop();
            var insertionSortTime = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"InsertionSort Time: {insertionSortTime} ms");

            // Verify the list is sorted
            for (int i = 1; i < sortedInsertionList.Count; i++)
            {
                Assert.IsTrue(sortedInsertionList[i - 1].CompareTo(sortedInsertionList[i]) <= 0);
            }

            // SelectionSort
            var selectionSortArray = originalList.ToArray();
            stopwatch.Restart();
            SelectionSort.Sort(selectionSortArray);
            stopwatch.Stop();
            var selectionSortTime = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"SelectionSort Time: {selectionSortTime} ms");

            // Verify the array is sorted
            for (int i = 1; i < selectionSortArray.Length; i++)
            {
                Assert.IsTrue(selectionSortArray[i - 1] <= selectionSortArray[i]);
            }

            // QuickSort
            var quickSortList = new List<int>(originalList);
            stopwatch.Restart();
            QuickSort.Sort(quickSortList);
            stopwatch.Stop();
            var quickSortTime = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"QuickSort Time: {quickSortTime} ms");

            // Verify the list is sorted
            for (int i = 1; i < quickSortList.Count; i++)
            {
                Assert.IsTrue(quickSortList[i - 1] <= quickSortList[i]);
            }

            // Print comparison results
            Console.WriteLine($"InsertionSort Time: {insertionSortTime} ms");
            Console.WriteLine($"SelectionSort Time: {selectionSortTime} ms");
            Console.WriteLine($"QuickSort Time: {quickSortTime} ms");
        }
    }
}