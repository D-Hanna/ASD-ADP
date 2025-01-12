using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchAndSort.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAndSortTests.Search
{
    [TestClass()]
    public class BinarySearchTests
    {
        [TestMethod()]
        public void Test_Search_ElementExists()
        {
            var binarySearch = new BinarySearch<int>();
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            int index = binarySearch.Search(array, 5);

            Assert.AreEqual(4, index);
        }

        [TestMethod()]
        public void Test_Search_ElementDoesNotExist()
        {
            var binarySearch = new BinarySearch<int>();
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            int index = binarySearch.Search(array, 11);

            Assert.AreEqual(-1, index);
        }

        [TestMethod()]
        public void Test_Search_EmptyArray()
        {
            var binarySearch = new BinarySearch<int>();
            int[] array = { };

            int index = binarySearch.Search(array, 5);

            Assert.AreEqual(-1, index);
        }

        [TestMethod()]
        public void Test_Search_SingleElementArray_ElementExists()
        {
            var binarySearch = new BinarySearch<int>();
            int[] array = { 5 };

            int index = binarySearch.Search(array, 5);

            Assert.AreEqual(0, index);
        }

        [TestMethod()]
        public void Test_Search_SingleElementArray_ElementDoesNotExist()
        {
            var binarySearch = new BinarySearch<int>();
            int[] array = { 5 };

            int index = binarySearch.Search(array, 10);

            Assert.AreEqual(-1, index);
        }

        [TestMethod()]
        public void Test_Search_DuplicateElements()
        {
            var binarySearch = new BinarySearch<int>();
            int[] array = { 1, 2, 2, 2, 3, 4, 5 };

            int index = binarySearch.Search(array, 2);

            Assert.IsTrue(index == 1 || index == 2 || index == 3);
        }
    }
}