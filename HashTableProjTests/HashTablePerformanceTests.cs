using Microsoft.VisualStudio.TestTools.UnitTesting;
using HashTableProj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using ASD_ADP;
using System.Data;

namespace HashTableProj.Tests
{
    [TestClass()]
    public class HashTablePerformanceTests
    {
        [TestMethod]
        public void Test_AddPerformance()
        {
            int NumberOfElements = 1000000;
            var hashTable = new HashTable<int, string>(NumberOfElements);
            var dataset = DataSets.RandomList(NumberOfElements).ToHashSet();
            Stopwatch stopwatch = Stopwatch.StartNew();

            foreach (var item in dataset)
            {
                hashTable.Add(item, item.ToString());
            }

            stopwatch.Stop();
            Console.WriteLine($"Add Time: {stopwatch.ElapsedMilliseconds} ms");
        }

        [TestMethod]
        public void Test_TryGetValuePerformance()
        {
            int NumberOfElements = 1000000;
            var hashTable = new HashTable<int, string>(NumberOfElements);
            var dataset = DataSets.RandomList(NumberOfElements).ToHashSet();

            foreach (var item in dataset)
            {
                hashTable.Add(item, item.ToString());
            }

            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < NumberOfElements; i++)
            {
                hashTable.TryGetValue(i, out _);
            }

            stopwatch.Stop();
            Console.WriteLine($"TryGetValue Time: {stopwatch.ElapsedMilliseconds} ms");
        }

        [TestMethod]
        public void Test_RemovePerformance()
        {
            int NumberOfElements = 1000000;
            var hashTable = new HashTable<int, string>(NumberOfElements);
            var dataset = DataSets.RandomList(NumberOfElements).ToHashSet();
            foreach (var item in dataset)
            {
                hashTable.Add(item, item.ToString());
            }

            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < NumberOfElements; i++)
            {
                hashTable.Remove(i);
            }

            stopwatch.Stop();
            Console.WriteLine($"Remove Time: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}