using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchAndSort.Sort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAndSort.Sort.Tests
{
    [TestClass()]
    public class SortTests
    {
        [TestMethod]
        public void Test_Sort_AlreadySorted()
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };
            var sortedList = InsertionSort.Sort(list);

            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5 }, sortedList);
        }

        [TestMethod]
        public void Test_Sort_ReverseSorted()
        {
            var list = new List<int> { 5, 4, 3, 2, 1 };
            var sortedList = InsertionSort.Sort(list);

            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5 }, sortedList);
        }

        [TestMethod]
        public void Test_Sort_Unsorted()
        {
            var list = new List<int> { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5 };
            var sortedList = InsertionSort.Sort(list);

            CollectionAssert.AreEqual(new List<int> { 1, 1, 2, 3, 3, 4, 5, 5, 5, 6, 9 }, sortedList);
        }

        [TestMethod]
        public void Test_Sort_EmptyList()
        {
            var list = new List<int>();
            var sortedList = InsertionSort.Sort(list);

            CollectionAssert.AreEqual(new List<int>(), sortedList);
        }

        [TestMethod]
        public void Test_Sort_SingleElement()
        {
            var list = new List<int> { 42 };
            var sortedList = InsertionSort.Sort(list);

            CollectionAssert.AreEqual(new List<int> { 42 }, sortedList);
        }

        [TestMethod]
        public void Test_Sort_DuplicateElements()
        {
            var list = new List<int> { 5, 3, 8, 3, 9, 1, 3 };
            var sortedList = InsertionSort.Sort(list);

            CollectionAssert.AreEqual(new List<int> { 1, 3, 3, 3, 5, 8, 9 }, sortedList);
        }

        //selection sort

        [TestMethod]
        public void Test_Selection_Sort_AlreadySorted()
        {
            int[] array = { 1, 2, 3, 4, 5 };
            SelectionSort.Sort(array);

            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5 }, array);
        }

        [TestMethod]
        public void Test_Selection_Sort_ReverseSorted()
        {
            int[] array = { 5, 4, 3, 2, 1 };
            SelectionSort.Sort(array);

            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5 }, array);
        }

        [TestMethod]
        public void Test_Selection_Sort_Unsorted()
        {
            int[] array = { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5 };
            SelectionSort.Sort(array);

            CollectionAssert.AreEqual(new int[] { 1, 1, 2, 3, 3, 4, 5, 5, 5, 6, 9 }, array);
        }

        [TestMethod]
        public void Test_Selection_Sort_EmptyArray()
        {
            int[] array = { };
            SelectionSort.Sort(array);

            CollectionAssert.AreEqual(new int[] { }, array);
        }

        [TestMethod]
        public void Test_Selection_Sort_SingleElement()
        {
            int[] array = { 42 };
            SelectionSort.Sort(array);

            CollectionAssert.AreEqual(new int[] { 42 }, array);
        }

        [TestMethod]
        public void Test_Selection_Sort_DuplicateElements()
        {
            int[] array = { 5, 3, 8, 3, 9, 1, 3 };
            SelectionSort.Sort(array);

            CollectionAssert.AreEqual(new int[] { 1, 3, 3, 3, 5, 8, 9 }, array);
        }

        //quick sort
        [TestMethod]
        public void Test_Quick_Sort_AlreadySorted()
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };
            QuickSort.Sort(list);

            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5 }, list);
        }

        [TestMethod]
        public void Test_Quick_Sort_ReverseSorted()
        {
            var list = new List<int> { 5, 4, 3, 2, 1 };
            QuickSort.Sort(list);

            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5 }, list);
        }

        [TestMethod]
        public void Test_Quick_Sort_Unsorted()
        {
            var list = new List<int> { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5 };
            QuickSort.Sort(list);

            CollectionAssert.AreEqual(new List<int> { 1, 1, 2, 3, 3, 4, 5, 5, 5, 6, 9 }, list);
        }

        [TestMethod]
        public void Test_Quick_Sort_EmptyList()
        {
            var list = new List<int>();
            QuickSort.Sort(list);

            CollectionAssert.AreEqual(new List<int>(), list);
        }

        [TestMethod]
        public void Test_Quick_Sort_SingleElement()
        {
            var list = new List<int> { 42 };
            QuickSort.Sort(list);

            CollectionAssert.AreEqual(new List<int> { 42 }, list);
        }

        [TestMethod]
        public void Test_Quick_Sort_DuplicateElements()
        {
            var list = new List<int> { 5, 3, 8, 3, 9, 1, 3 };
            QuickSort.Sort(list);

            CollectionAssert.AreEqual(new List<int> { 1, 3, 3, 3, 5, 8, 9 }, list);
        }
    }
}