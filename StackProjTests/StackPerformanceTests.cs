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
    public class StackPerformanceTests
    {

        [TestMethod]
        public void Performance_Push()
        {
            var dataset = DataSets.LijstFloat8001;
            var stack = new Stack<object>(dataset.Length);
            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (var item in dataset)
            {
                stack.Push(item);
            }
            stopwatch.Stop();
            Console.WriteLine($"Stack Push: {stopwatch.ElapsedMilliseconds} ms");
            Assert.AreEqual(dataset.Length, stack.Count());
        }

        [TestMethod]
        public void Performance_Pop()
        {
            var dataset = DataSets.LijstFloat8001;
            var stack = new Stack<object>(dataset.Length);
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
        }

        [TestMethod]
        public void Performance_Peek()
        {
            var dataset = DataSets.LijstFloat8001;
            var stack = new Stack<object>(dataset.Length);
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
        }

        [TestMethod]
        public void Performance_IsEmpty()
        {
            var dataset = DataSets.LijstFloat8001;
            var stack = new Stack<object>(dataset.Length);
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < dataset.Length; i++)
            {
                stack.IsEmpty();
            }
            stopwatch.Stop();
            Console.WriteLine($"Stack IsEmpty: {stopwatch.ElapsedMilliseconds} ms");
        }

        [TestMethod]
        public void Performance_Count()
        {
            var dataset = DataSets.LijstFloat8001;
            var stack = new Stack<object>(dataset.Length);
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
        }

        [TestMethod]
        public void Performance_Top()
        {
            var dataset = DataSets.LijstFloat8001;
            var stack = new Stack<object>(dataset.Length);
            foreach (var item in dataset)
            {
                stack.Push(item);
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < dataset.Length; i++)
            {
                stack.Top();
            }
            stopwatch.Stop();
            Console.WriteLine($"Stack Top: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}