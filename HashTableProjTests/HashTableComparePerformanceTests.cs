using Microsoft.VisualStudio.TestTools.UnitTesting;
using HashTableProj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using ASD_ADP;

namespace HashTableProj.Tests
{
    [TestClass()]
    public class HashTableComparePerformanceTests
    {
        private const int NumberOfElements = 100000;
        [TestMethod]
        public void Compare_AddPerformance()
        {
            var dataset = DataSets.RandomList(NumberOfElements).ToHashSet();
            var customHashTable = new HashTable<int, string>(NumberOfElements);
            var dictionary = new Dictionary<int, string>();

            // Custom HashTable Add
            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (var item in dataset)
            {
                customHashTable.Add(item, item.ToString());
            }
            stopwatch.Stop();
            var customHashTableAddTime = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"Custom HashTable Add Time: {customHashTableAddTime} ms");

            // Dictionary Add
            stopwatch.Restart();
            foreach (var item in dataset)
            {
                dictionary.Add(item, item.ToString());
            }
            stopwatch.Stop();
            var dictionaryAddTime = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"Dictionary Add Time: {dictionaryAddTime} ms");
        }

        [TestMethod]
        public void Compare_TryGetValuePerformance()
        {
            var dataset = DataSets.RandomList(NumberOfElements).ToHashSet();
            var customHashTable = new HashTable<int, string>(NumberOfElements);
            var dictionary = new Dictionary<int, string>();

            foreach (var item in dataset)
            {
                customHashTable.Add(item, item.ToString());
                dictionary.Add(item, item.ToString());
            }

            // Custom HashTable TryGetValue
            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (var item in dataset)
            {
                customHashTable.TryGetValue(item, out string _);
            }
            stopwatch.Stop();
            var customHashTableGetTime = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"Custom HashTable TryGetValue Time: {customHashTableGetTime} ms");

            // Dictionary TryGetValue
            stopwatch.Restart();
            foreach (var item in dataset)
            {
                dictionary.TryGetValue(item, out string _);
            }
            stopwatch.Stop();
            var dictionaryGetTime = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"Dictionary TryGetValue Time: {dictionaryGetTime} ms");
        }

        [TestMethod]
        public void Compare_RemovePerformance()
        {
            var dataset = DataSets.RandomList(NumberOfElements).ToHashSet();
            var customHashTable = new HashTable<int, string>(NumberOfElements);
            var dictionary = new Dictionary<int, string>();

            foreach (var item in dataset)
            {
                customHashTable.Add(item, item.ToString());
                dictionary.Add(item, item.ToString());
            }

            // Custom HashTable Remove
            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (var item in dataset)
            {
                customHashTable.Remove(item);
            }
            stopwatch.Stop();
            var customHashTableRemoveTime = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"Custom HashTable Remove Time: {customHashTableRemoveTime} ms");

            // Dictionary Remove
            stopwatch.Restart();
            foreach (var item in dataset)
            {
                dictionary.Remove(item);
            }
            stopwatch.Stop();
            var dictionaryRemoveTime = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"Dictionary Remove Time: {dictionaryRemoveTime} ms");
        }
    }
}