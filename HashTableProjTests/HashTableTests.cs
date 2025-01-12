using Microsoft.VisualStudio.TestTools.UnitTesting;
using HashTableProj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableProj.Tests
{
    [TestClass()]
    public class HashTableTests
    {
        [TestMethod]
        public void Test_AddAndRetrieve()
        {
            var hashTable = new HashTable<int, string>(10);
            hashTable.Add(1, "one");
            hashTable.Add(2, "two");
            hashTable.Add(3, "three");

            Assert.IsTrue(hashTable.TryGetValue(1, out var value1));
            Assert.AreEqual("one", value1);

            Assert.IsTrue(hashTable.TryGetValue(2, out var value2));
            Assert.AreEqual("two", value2);

            Assert.IsTrue(hashTable.TryGetValue(3, out var value3));
            Assert.AreEqual("three", value3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_AddDuplicateKey()
        {
            var hashTable = new HashTable<int, string>(10);
            hashTable.Add(1, "one");
            hashTable.Add(1, "duplicate");
        }

        [TestMethod]
        public void Test_Remove()
        {
            var hashTable = new HashTable<int, string>(10);
            hashTable.Add(1, "one");
            hashTable.Add(2, "two");
            hashTable.Add(3, "three");

            Assert.IsTrue(hashTable.Remove(2));
            Assert.IsFalse(hashTable.TryGetValue(2, out _));
        }

        [TestMethod]
        public void Test_Remove_NonExistentKey()
        {
            var hashTable = new HashTable<int, string>(10);
            hashTable.Add(1, "one");
            hashTable.Add(2, "two");

            Assert.IsFalse(hashTable.Remove(3));
        }

        [TestMethod]
        public void Test_TryGetValue_NonExistentKey()
        {
            var hashTable = new HashTable<int, string>(10);
            hashTable.Add(1, "one");
            hashTable.Add(2, "two");

            Assert.IsFalse(hashTable.TryGetValue(3, out _));
        }

        [TestMethod]
        public void Test_AddAndRetrieve_MultipleBuckets()
        {
            var hashTable = new HashTable<int, string>(3);
            hashTable.Add(1, "one");
            hashTable.Add(4, "four");
            hashTable.Add(7, "seven");

            Assert.IsTrue(hashTable.TryGetValue(1, out var value1));
            Assert.AreEqual("one", value1);

            Assert.IsTrue(hashTable.TryGetValue(4, out var value4));
            Assert.AreEqual("four", value4);

            Assert.IsTrue(hashTable.TryGetValue(7, out var value7));
            Assert.AreEqual("seven", value7);
        }
    }
}