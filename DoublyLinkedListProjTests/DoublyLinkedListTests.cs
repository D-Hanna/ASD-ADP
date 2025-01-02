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
        public void InsertAt_ShouldInsertElementAtPosition()
        {
            DoublyLinkedList<int> list = new();
            list.AddLast(10);
            list.AddLast(20);
            list.InsertAt(15, 1);

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
    }
}