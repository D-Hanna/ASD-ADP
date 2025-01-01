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
            // Arrange
            var dynamicArray = new DynamicArray<int>();

            // Act
            dynamicArray.Add(42);

            // Assert
            Assert.AreEqual(1, dynamicArray.Count);
            Assert.AreEqual(42, dynamicArray[0]);
        }

        [TestMethod]
        public void Add_MultipleElements_ShouldResizeAndRetainElements()
        {
            // Arrange
            var dynamicArray = new DynamicArray<int>();

            // Act
            for (int i = 0; i < 10; i++)
            {
                dynamicArray.Add(i);
            }

            // Assert
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
            // Arrange
            var dynamicArray = new DynamicArray<int>();

            // Act
            var value = dynamicArray[0];
        }

        [TestMethod]
        public void Indexer_SetValidIndex_ShouldUpdateValue()
        {
            // Arrange
            var dynamicArray = new DynamicArray<int>();
            dynamicArray.Add(10);

            // Act
            dynamicArray[0] = 20;

            // Assert
            Assert.AreEqual(20, dynamicArray[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Indexer_SetInvalidIndex_ShouldThrowException()
        {
            // Arrange
            var dynamicArray = new DynamicArray<int>();

            // Act
            dynamicArray[1] = 42;
        }

        [TestMethod]
        public void RemoveAt_ValidIndex_ShouldShiftElements()
        {
            // Arrange
            var dynamicArray = new DynamicArray<int>();
            dynamicArray.Add(1);
            dynamicArray.Add(2);
            dynamicArray.Add(3);

            // Act
            dynamicArray.RemoveAt(1);

            // Assert
            Assert.AreEqual(2, dynamicArray.Count);
            Assert.AreEqual(1, dynamicArray[0]);
            Assert.AreEqual(3, dynamicArray[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveAt_InvalidIndex_ShouldThrowException()
        {
            // Arrange
            var dynamicArray = new DynamicArray<int>();

            // Act
            dynamicArray.RemoveAt(0);
        }

        [TestMethod]
        public void Clear_ShouldResetArray()
        {
            // Arrange
            var dynamicArray = new DynamicArray<int>();
            dynamicArray.Add(1);
            dynamicArray.Add(2);

            // Act
            dynamicArray.Clear();

            // Assert
            Assert.AreEqual(0, dynamicArray.Count);
            Assert.AreEqual(4, dynamicArray.Capacity); // Default capacity
        }

        [TestMethod]
        public void Capacity_ShouldDoubleWhenExceedingInitialCapacity()
        {
            // Arrange
            var dynamicArray = new DynamicArray<int>();

            // Act
            for (int i = 0; i < 5; i++)
            {
                dynamicArray.Add(i);
            }

            // Assert
            Assert.AreEqual(8, dynamicArray.Capacity); // Doubled from 4 to 8
        }

        [TestMethod]
        public void Capacity_ShouldShrinkWhenSparse()
        {
            // Arrange
            var dynamicArray = new DynamicArray<int>();
            for (int i = 0; i < 8; i++)
            {
                dynamicArray.Add(i);
            }

            // Act
            for (int i = 7; i >= 2; i--)
            {
                dynamicArray.RemoveAt(i);
            }

            // Assert
            Assert.AreEqual(4, dynamicArray.Capacity); // Shrinks to half when sparse
        }
    }
}