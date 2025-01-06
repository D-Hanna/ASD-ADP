using Microsoft.VisualStudio.TestTools.UnitTesting;
using DequeProj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DequeProj.Tests
{
    [TestClass()]
    public class DequeTests
    {
        [TestMethod()]
        public void AddFront_ShouldAddElementToFront()
        {
            var deque = new Deque<int>();
            deque.AddFront(1);
            Assert.AreEqual(1, deque.PeekFront());
            Assert.AreEqual(1, deque.Count);
        }

        [TestMethod()]
        public void AddBack_ShouldAddElementToBack()
        {
            var deque = new Deque<int>();
            deque.AddBack(1);
            Assert.AreEqual(1, deque.PeekBack());
            Assert.AreEqual(1, deque.Count);
        }

        [TestMethod()]
        public void RemoveFront_ShouldRemoveElementFromFront()
        {
            var deque = new Deque<int>();
            deque.AddFront(1);
            deque.AddFront(2);
            var removed = deque.RemoveFront();
            Assert.AreEqual(2, removed);
            Assert.AreEqual(1, deque.Count);
        }

        [TestMethod()]
        public void RemoveBack_ShouldRemoveElementFromBack()
        {
            var deque = new Deque<int>();
            deque.AddBack(1);
            deque.AddBack(2);
            var removed = deque.RemoveBack();
            Assert.AreEqual(2, removed);
            Assert.AreEqual(1, deque.Count);
        }

        [TestMethod()]
        public void PeekFront_ShouldReturnFrontElementWithoutRemoving()
        {
            var deque = new Deque<int>();
            deque.AddFront(1);
            var peeked = deque.PeekFront();
            Assert.AreEqual(1, peeked);
            Assert.AreEqual(1, deque.Count);
        }

        [TestMethod()]
        public void PeekBack_ShouldReturnBackElementWithoutRemoving()
        {
            var deque = new Deque<int>();
            deque.AddBack(1);
            var peeked = deque.PeekBack();
            Assert.AreEqual(1, peeked);
            Assert.AreEqual(1, deque.Count);
        }

        [TestMethod()]
        public void IsEmpty_ShouldReturnTrueWhenDequeIsEmpty()
        {
            var deque = new Deque<int>();
            Assert.IsTrue(deque.IsEmpty);
        }

        [TestMethod()]
        public void IsEmpty_ShouldReturnFalseWhenDequeIsNotEmpty()
        {
            var deque = new Deque<int>();
            deque.AddFront(1);
            Assert.IsFalse(deque.IsEmpty);
        }

        [TestMethod()]
        public void Count_ShouldReturnNumberOfElementsInDeque()
        {
            var deque = new Deque<int>();
            deque.AddFront(1);
            deque.AddBack(2);
            Assert.AreEqual(2, deque.Count);
        }

        [TestMethod()]
        public void EnsureCapacity_ShouldDoubleCapacityWhenFull()
        {
            var deque = new Deque<int>();
            for (int i = 0; i < 5; i++)
            {
                deque.AddBack(i);
            }
            Assert.AreEqual(5, deque.Count);
            Assert.AreEqual(0, deque.PeekFront());
            Assert.AreEqual(4, deque.PeekBack());
        }
    }
}