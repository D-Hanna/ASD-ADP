using Microsoft.VisualStudio.TestTools.UnitTesting;
using AVLSearchTreeProj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AVLSearchTreeProj.Tests
{
    [TestClass()]
    public class AVLTreePerformanceTests
    {
        private const int NumberOfOperations = 100000;

        [TestMethod]
        public void InsertPerformanceTest()
        {
            var tree = new AVLTree();
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            for (int i = 0; i < NumberOfOperations; i++)
            {
                tree.Insert(i);
            }
            stopwatch.Stop();

            Console.WriteLine($"Time taken to insert {NumberOfOperations} elements: {stopwatch.ElapsedMilliseconds} ms");
        }

        [TestMethod]
        public void DeletePerformanceTest()
        {
            var tree = new AVLTree();
            for (int i = 0; i < NumberOfOperations; i++)
            {
                tree.Insert(i);
            }

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < NumberOfOperations; i++)
            {
                tree.Delete(i);
            }
            stopwatch.Stop();

            Console.WriteLine($"Time taken to delete {NumberOfOperations} elements: {stopwatch.ElapsedMilliseconds} ms");
        }

        [TestMethod]
        public void SearchPerformanceTest()
        {
            var tree = new AVLTree();
            for (int i = 0; i < NumberOfOperations; i++)
            {
                tree.Insert(i);
            }

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < NumberOfOperations; i++)
            {
                tree.Search(i);
            }
            stopwatch.Stop();

            Console.WriteLine($"Time taken to search {NumberOfOperations} elements: {stopwatch.ElapsedMilliseconds} ms");
        }

        [TestMethod]
        public void FindMinPerformanceTest()
        {
            var tree = new AVLTree();
            for (int i = 0; i < NumberOfOperations; i++)
            {
                tree.Insert(i);
            }

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < NumberOfOperations; i++)
            {
                tree.FindMin();
            }
            stopwatch.Stop();

            Console.WriteLine($"Time taken to find min {NumberOfOperations} times: {stopwatch.ElapsedMilliseconds} ms");
        }

        [TestMethod]
        public void FindMaxPerformanceTest()
        {
            var tree = new AVLTree();
            for (int i = 0; i < NumberOfOperations; i++)
            {
                tree.Insert(i);
            }

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < NumberOfOperations; i++)
            {
                tree.FindMax();
            }
            stopwatch.Stop();

            Console.WriteLine($"Time taken to find max {NumberOfOperations} times: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}