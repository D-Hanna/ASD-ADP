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
            var list = DataSets.RandomList(10000, 0, 10000).OfType<int>().ToList();

            Stopwatch stopwatch = Stopwatch.StartNew();
            var sortedList = InsertionSort.Sort(list.ToArray());
            stopwatch.Stop();

            Console.WriteLine($"InsertionSort Time: {stopwatch.ElapsedMilliseconds} ms");

            for (int i = 1; i < sortedList.Count(); i++)
            {
                Assert.IsTrue(sortedList[i - 1].CompareTo(sortedList[i]) <= 0);
            }
        }

        //selection sort
        [TestMethod]
        public void Test_SelectionSortPerformance()
        {
            var list = DataSets.RandomList(10000, 0, 10000).OfType<int>().ToList();
            var array = list.ToArray();

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
            var list = DataSets.RandomList(10000, 0, 10000).OfType<int>().ToList();
            var array = list.ToArray();

            Stopwatch stopwatch = Stopwatch.StartNew();
            QuickSort.Sort(array);
            stopwatch.Stop();

            Console.WriteLine($"QuickSort Time: {stopwatch.ElapsedMilliseconds} ms");

            for (int i = 1; i < array.Length; i++)
            {
                Assert.IsTrue(array[i - 1] <= array[i]);
            }
        }

        //merge sort
        [TestMethod]
        public void Test_MergeSortPerformance()
        {
            var list = DataSets.RandomList(10000, 0, 10000).OfType<int>().ToList();
            var array = list.ToArray();

            Stopwatch stopwatch = Stopwatch.StartNew();
            MergeSort.Sort(array);
            stopwatch.Stop();

            Console.WriteLine($"MergeSort Time: {stopwatch.ElapsedMilliseconds} ms");

            for (int i = 1; i < array.Length; i++)
            {
                Assert.IsTrue(array[i - 1] <= array[i]);
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
            var insertionSortList = originalList.ToArray();
            Stopwatch stopwatch = Stopwatch.StartNew();
            var sortedInsertionList = InsertionSort.Sort(insertionSortList);
            stopwatch.Stop();
            var insertionSortTime = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"InsertionSort Time: {insertionSortTime} ms");

            // Verify the list is sorted
            for (int i = 1; i < sortedInsertionList.Length; i++)
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
            var quickSortList = originalList.ToArray();
            stopwatch.Restart();
            QuickSort.Sort(quickSortList);
            stopwatch.Stop();
            var quickSortTime = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"QuickSort Time: {quickSortTime} ms");

            // Verify the list is sorted
            for (int i = 1; i < quickSortList.Length; i++)
            {
                Assert.IsTrue(quickSortList[i - 1] <= quickSortList[i]);
            }

            // MergeSort
            var mergeSortArray = originalList.ToArray();
            stopwatch.Restart();
            MergeSort.Sort(mergeSortArray);
            stopwatch.Stop();
            var mergeSortTime = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"MergeSort Time: {mergeSortTime} ms");

            // Verify the array is sorted
            for (int i = 1; i < mergeSortArray.Length; i++)
            {
                Assert.IsTrue(mergeSortArray[i - 1] <= mergeSortArray[i]);
            }
        }
    }
}