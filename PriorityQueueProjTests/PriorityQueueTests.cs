using Microsoft.VisualStudio.TestTools.UnitTesting;
using PriorityQueueProj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueueProj.Tests
{
    [TestClass()]
    public class PriorityQueueTests
    {

        [TestMethod()]
        public void Test_EnqueueAndDequeue()
        {
            var pq = new PriorityQueue<int>();
            pq.Enqueue(10, 1);
            pq.Enqueue(20, 2);
            pq.Enqueue(30, 0);

            Assert.AreEqual(3, pq.Count);
            Assert.AreEqual(30, pq.Dequeue());
            Assert.AreEqual(10, pq.Dequeue());
            Assert.AreEqual(20, pq.Dequeue());
            Assert.AreEqual(0, pq.Count);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_Dequeue_EmptyQueue()
        {
            var pq = new PriorityQueue<int>();
            pq.Dequeue();
        }

        [TestMethod()]
        public void Test_Peek()
        {
            var pq = new PriorityQueue<int>();
            pq.Enqueue(10, 1);
            pq.Enqueue(20, 2);
            pq.Enqueue(30, 0);

            Assert.AreEqual(30, pq.Peek());
            Assert.AreEqual(3, pq.Count);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_Peek_EmptyQueue()
        {
            var pq = new PriorityQueue<int>();
            pq.Peek();
        }

        [TestMethod()]
        public void Test_Enqueue_Resize()
        {
            var pq = new PriorityQueue<int>(2);
            pq.Enqueue(10, 1);
            pq.Enqueue(20, 2);
            pq.Enqueue(30, 0);
            pq.Enqueue(40, 3);

            Assert.AreEqual(4, pq.Count);
            Assert.AreEqual(30, pq.Dequeue());
            Assert.AreEqual(10, pq.Dequeue());
            Assert.AreEqual(20, pq.Dequeue());
            Assert.AreEqual(40, pq.Dequeue());
        }
    }
}