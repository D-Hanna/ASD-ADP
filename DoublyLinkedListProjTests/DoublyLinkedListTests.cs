using Microsoft.VisualStudio.TestTools.UnitTesting;
using DoublyLinkedListProj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedListProj.Tests
{
    [TestClass()]
    public class DoublyLinkedListTests
    {

        [TestMethod()]
        public void AddFirst_ShouldAddElementToFront()
        {
        DoublyLinkedList<int> list = new();

        list.AddFirst(10);
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(10, list.Get(0));

            list.AddFirst(20);
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(20, list.Get(0));
            Assert.AreEqual(10, list.Get(1));
        }

        [TestMethod()]
        public void AddLast_ShouldAddElementToEnd()
        {
            DoublyLinkedList<int> list = new();
            list.AddLast(10);
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(10, list.Get(0));

            list.AddLast(20);
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(10, list.Get(0));
            Assert.AreEqual(20, list.Get(1));
        }

        [TestMethod()]
        public void RemoveFirst_ShouldRemoveFirstElement()
        {
            DoublyLinkedList<int> list = new();
            list.AddLast(10);
            list.AddLast(20);
            list.RemoveFirst();

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(20, list.Get(0));

            list.RemoveFirst();
            Assert.AreEqual(0, list.Count);
            Assert.ThrowsException<InvalidOperationException>(() => list.RemoveFirst());
        }

        [TestMethod()]
        public void RemoveLast_ShouldRemoveLastElement()
        {
            DoublyLinkedList<int> list = new();
            list.AddLast(10);
            list.AddLast(20);
            list.RemoveLast();

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(10, list.Get(0));

            list.RemoveLast();
            Assert.AreEqual(0, list.Count);
            Assert.ThrowsException<InvalidOperationException>(() => list.RemoveLast());
        }

        [TestMethod()]
        public void InsertAt_ShouldAddElementAtPosition()
        {
            DoublyLinkedList<int> list = new();
            list.AddLast(10);
            list.AddLast(20);
            list.Add(15, 1);

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(10, list.Get(0));
            Assert.AreEqual(15, list.Get(1));
            Assert.AreEqual(20, list.Get(2));
        }

        [TestMethod()]
        public void DeleteAt_ShouldRemoveElementAtPosition()
        {
            DoublyLinkedList<int> list = new();
            list.AddLast(10);
            list.AddLast(20);
            list.AddLast(30);
            list.DeleteAt(1);

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(10, list.Get(0));
            Assert.AreEqual(30, list.Get(1));
        }

        [TestMethod()]
        public void Get_ShouldReturnElementAtPosition()
        {
            DoublyLinkedList<int> list = new();
            list.AddLast(10);
            list.AddLast(20);
            list.AddLast(30);

            Assert.AreEqual(10, list.Get(0));
            Assert.AreEqual(20, list.Get(1));
            Assert.AreEqual(30, list.Get(2));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.Get(3));
        }

        [TestMethod]
        public void TestSet()
        {
            var list = new DoublyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            list.Set(1, 5);

            Assert.AreEqual(5, list.Get(1));
        }

        [TestMethod]
        public void TestContains()
        {
            var list = new DoublyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            Assert.IsTrue(list.Contains(2));
            Assert.IsFalse(list.Contains(4));
        }

        [TestMethod]
        public void TestFind()
        {
            var list = new DoublyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            Assert.AreEqual(1, list.Find(2));
            Assert.AreEqual(-1, list.Find(4));
        }

        [TestMethod]
        public void TestRemove_ExistingElement_ShouldReturnTrueAndDecreaseCount()
        {
            var list = new DoublyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            bool result = list.Remove(2);

            Assert.IsTrue(result);
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(1, list.Get(0));
            Assert.AreEqual(3, list.Get(1));
        }

        [TestMethod]
        public void TestRemove_NonExistingElement_ShouldReturnFalse()
        {
            var list = new DoublyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            bool result = list.Remove(4);

            Assert.IsFalse(result);
            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        public void TestRemove_MultipleOccurrences_ShouldRemoveFirstOccurrence()
        {
            var list = new DoublyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(2);
            list.Add(3);

            bool result = list.Remove(2);

            Assert.IsTrue(result);
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(1, list.Get(0));
            Assert.AreEqual(2, list.Get(1));
            Assert.AreEqual(3, list.Get(2));
        }
    }
}