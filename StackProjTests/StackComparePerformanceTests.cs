using ASD_ADP;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackProj;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackProj.Tests
{
    [TestClass()]
    public class StackComparePerformanceTests
    {

        [TestMethod()]
        public void Compare_Push()
        {
            var dataset = DataSets.RandomList(100000, 0, 100000);
            var stack = new Stack<int>(dataset.Length);
            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (var item in dataset)
            {
                stack.Push(item);
            }
            stopwatch.Stop();
            Console.WriteLine($"Stack Push: {stopwatch.ElapsedMilliseconds} ms");
            Assert.AreEqual(dataset.Length, stack.Count());

            var list = new List<int>();
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
        public void Compare_Pop()
        {
            var dataset = DataSets.RandomList(100000, 0, 100000);
            var stack = new Stack<int>(dataset.Length);
            foreach (var item in dataset)
            {
                stack.Push(item);
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            while (!stack.IsEmpty())
            {
                stack.Pop();
            }
            stopwatch.Stop();
            Console.WriteLine($"Stack Pop: {stopwatch.ElapsedMilliseconds} ms");
            Assert.AreEqual(0, stack.Count());

            var list = new List<int>(dataset);
            stopwatch.Restart();
            while (list.Count > 0)
            {
                list.RemoveAt(list.Count - 1);
            }
            stopwatch.Stop();
            Console.WriteLine($"List RemoveAt: {stopwatch.ElapsedMilliseconds} ms");
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod()]
        public void Compare_Peek()
        {
            var dataset = DataSets.RandomList(100000, 0, 100000);
            var stack = new Stack<int>(dataset.Length);
            foreach (var item in dataset)
            {
                stack.Push(item);
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < dataset.Length; i++)
            {
                stack.Peek();
            }
            stopwatch.Stop();
            Console.WriteLine($"Stack Peek: {stopwatch.ElapsedMilliseconds} ms");

            var list = new List<int>(dataset);
            stopwatch.Restart();
            for (int i = 0; i < dataset.Length; i++)
            {
                var item = list[list.Count - 1];
            }
            stopwatch.Stop();
            Console.WriteLine($"List Peek: {stopwatch.ElapsedMilliseconds} ms");
        }

        [TestMethod()]
        public void Compare_IsEmpty()
        {
            var dataset = DataSets.RandomList(100000, 0, 100000);
            var stack = new Stack<int>(dataset.Length);
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < dataset.Length; i++)
            {
                stack.IsEmpty();
            }
            stopwatch.Stop();
            Console.WriteLine($"Stack IsEmpty: {stopwatch.ElapsedMilliseconds} ms");

            var list = new List<int>(dataset);
            stopwatch.Restart();
            for (int i = 0; i < dataset.Length; i++)
            {
                var isEmpty = list.Count == 0;
            }
            stopwatch.Stop();
            Console.WriteLine($"List IsEmpty: {stopwatch.ElapsedMilliseconds} ms");
        }

        [TestMethod()]
        public void Compare_Count()
        {
            var dataset = DataSets.RandomList(100000, 0, 100000);
            var stack = new Stack<int>(dataset.Length);
            foreach (var item in dataset)
            {
                stack.Push(item);
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < dataset.Length; i++)
            {
                stack.Count();
            }
            stopwatch.Stop();
            Console.WriteLine($"Stack Count: {stopwatch.ElapsedMilliseconds} ms");

            var list = new List<int>(dataset);
            stopwatch.Restart();
            for (int i = 0; i < dataset.Length; i++)
            {
                var count = list.Count;
            }
            stopwatch.Stop();
            Console.WriteLine($"List Count: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}