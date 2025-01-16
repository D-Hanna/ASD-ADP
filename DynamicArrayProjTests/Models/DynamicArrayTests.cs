using Microsoft.VisualStudio.TestTools.UnitTesting;
using DynamicArrayProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArrayProj.Models.Tests
{
    [TestClass()]
    public class DynamicArrayTests
    {
        [TestMethod]
        public void Add_SingleElement_ShouldIncreaseCount()
        {
            var dynamicArray = new DynamicArray<int>();

            dynamicArray.Add(42);

            Assert.AreEqual(1, dynamicArray.Count);
            Assert.AreEqual(42, dynamicArray[0]);
        }

        [TestMethod]
        public void Add_MultipleElements_ShouldResizeAndRetainElements()
        {
            var dynamicArray = new DynamicArray<int>();

            for (int i = 0; i < 10; i++)
            {
                dynamicArray.Add(i);
            }

            Assert.AreEqual(10, dynamicArray.Count);
            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(i, dynamicArray[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Indexer_GetInvalidIndex_ShouldThrowException()
        {
            var dynamicArray = new DynamicArray<int>();

            var value = dynamicArray[0];
        }

        [TestMethod]
        public void Indexer_SetValidIndex_ShouldUpdateValue()
        {
            var dynamicArray = new DynamicArray<int>();
            dynamicArray.Add(10);

            dynamicArray[0] = 20;

            Assert.AreEqual(20, dynamicArray[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Indexer_SetInvalidIndex_ShouldThrowException()
        {
            var dynamicArray = new DynamicArray<int>();

            dynamicArray[1] = 42;
        }

        [TestMethod]
        public void RemoveAt_ValidIndex_ShouldShiftElements()
        {
            var dynamicArray = new DynamicArray<int>();
            dynamicArray.Add(1);
            dynamicArray.Add(2);
            dynamicArray.Add(3);

            dynamicArray.RemoveAt(1);

            Assert.AreEqual(2, dynamicArray.Count);
            Assert.AreEqual(1, dynamicArray[0]);
            Assert.AreEqual(3, dynamicArray[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveAt_InvalidIndex_ShouldThrowException()
        {
            var dynamicArray = new DynamicArray<int>();

            dynamicArray.RemoveAt(0);
        }

        [TestMethod]
        public void Clear_ShouldResetArray()
        {
            var dynamicArray = new DynamicArray<int>();
            dynamicArray.Add(1);
            dynamicArray.Add(2);

            dynamicArray.Clear();

            Assert.AreEqual(0, dynamicArray.Count);
            Assert.AreEqual(4, dynamicArray.Capacity);
        }

        [TestMethod]
        public void Remove_ExistingElement_ShouldReturnTrueAndDecreaseCount()
        {
            var dynamicArray = new DynamicArray<int>();
            dynamicArray.Add(1);
            dynamicArray.Add(2);
            dynamicArray.Add(3);

            bool result = dynamicArray.Remove(2);

            Assert.IsTrue(result);
            Assert.AreEqual(2, dynamicArray.Count);
            Assert.AreEqual(1, dynamicArray[0]);
            Assert.AreEqual(3, dynamicArray[1]);
        }

        [TestMethod]
        public void Remove_NonExistingElement_ShouldReturnFalse()
        {
            var dynamicArray = new DynamicArray<int>();
            dynamicArray.Add(1);
            dynamicArray.Add(2);
            dynamicArray.Add(3);

            bool result = dynamicArray.Remove(4);

            Assert.IsFalse(result);
            Assert.AreEqual(3, dynamicArray.Count);
        }

        [TestMethod]
        public void Remove_MultipleOccurrences_ShouldRemoveFirstOccurrence()
        {
            var dynamicArray = new DynamicArray<int>();
            dynamicArray.Add(1);
            dynamicArray.Add(2);
            dynamicArray.Add(2);
            dynamicArray.Add(3);

            bool result = dynamicArray.Remove(2);

            Assert.IsTrue(result);
            Assert.AreEqual(3, dynamicArray.Count);
            Assert.AreEqual(1, dynamicArray[0]);
            Assert.AreEqual(2, dynamicArray[1]);
            Assert.AreEqual(3, dynamicArray[2]);
        }

        [TestMethod]
        public void Capacity_ShouldDoubleWhenExceedingInitialCapacity()
        {
            var dynamicArray = new DynamicArray<int>();

            for (int i = 0; i < 5; i++)
            {
                dynamicArray.Add(i);
            }

            Assert.AreEqual(8, dynamicArray.Capacity);
        }

        [TestMethod]
        public void Capacity_ShouldShrinkWhenSparse()
        {
            var dynamicArray = new DynamicArray<int>();
            for (int i = 0; i < 8; i++)
            {
                dynamicArray.Add(i);
            }

            for (int i = 7; i >= 2; i--)
            {
                dynamicArray.RemoveAt(i);
            }

            Assert.AreEqual(4, dynamicArray.Capacity);
        }

        [TestMethod]
        public void TestSet()
        {
            var dynamicArray = new DynamicArray<int>();
            dynamicArray.Add(1);
            dynamicArray.Add(2);
            dynamicArray.Add(3);

            dynamicArray.Set(1, 5);

            Assert.AreEqual(5, dynamicArray[1]);
        }

        [TestMethod]
        public void TestContains()
        {
            var dynamicArray = new DynamicArray<int>();
            dynamicArray.Add(1);
            dynamicArray.Add(2);
            dynamicArray.Add(3);

            Assert.IsTrue(dynamicArray.Contains(2));
            Assert.IsFalse(dynamicArray.Contains(4));
        }

        [TestMethod]
        public void TestFind()
        {
            var dynamicArray = new DynamicArray<int>();
            dynamicArray.Add(1);
            dynamicArray.Add(2);
            dynamicArray.Add(3);

            Assert.AreEqual(1, dynamicArray.Find(2));
            Assert.AreEqual(-1, dynamicArray.Find(4));
        }
    }
}