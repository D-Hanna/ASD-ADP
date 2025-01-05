using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackProj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackProj.Tests
{
    [TestClass()]
    public class StackTests
    {
        [TestMethod]
        public void PushTest()
        {
            var stack = new Stack<int>(5);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Assert.AreEqual(3, stack.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PushTest_StackOverflow()
        {
            var stack = new Stack<int>(2);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3); 
        }

        [TestMethod]
        public void PopTest()
        {
            var stack = new Stack<int>(5);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            var item = stack.Pop();
            Assert.AreEqual(3, item);
            Assert.AreEqual(2, stack.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopTest_StackUnderflow()  
        {
            var stack = new Stack<int>(5);
            stack.Pop();
        }

        [TestMethod]
        public void PeekTest()
        {
            var stack = new Stack<int>(5);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            var item = stack.Peek();
            Assert.AreEqual(3, item);
            Assert.AreEqual(3, stack.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PeekTest_StackEmpty()
        {
            var stack = new Stack<int>(5);
            stack.Peek();
        }

        [TestMethod]
        public void IsEmptyTest()
        {
            var stack = new Stack<int>(5);
            Assert.IsTrue(stack.IsEmpty());
            stack.Push(1);
            Assert.IsFalse(stack.IsEmpty());
        }

        [TestMethod]
        public void CountTest()
        {
            var stack = new Stack<int>(5);
            Assert.AreEqual(0, stack.Count());
            stack.Push(1);
            stack.Push(2);
            Assert.AreEqual(2, stack.Count());
        }
    }
}