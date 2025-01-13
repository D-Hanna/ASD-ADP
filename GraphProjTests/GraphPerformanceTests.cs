using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphProj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics;
using ASD_ADP;

namespace GraphProj.Tests
{
    [TestClass()]
    public class GraphPerformanceTests
    {
        [TestMethod()]
        public void Performance_AddVertex()
        {
            var dataset = DataSets.RandomList(100000, 0, 100000);

            var graph = new Graph<int>();
            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (var item in dataset)
            {
                graph.AddVertex(item);
            }
            stopwatch.Stop();
            Console.WriteLine($"Graph AddVertex: {stopwatch.ElapsedMilliseconds} ms");
        }

        [TestMethod()]
        public void Performance_AddEdge_Undirected()
        {
            var dataset = DataSets.RandomList(100000, 0, 100000);
            var graph = new Graph<int>();
            foreach (var item in dataset)
            {
                graph.AddVertex(item);
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < dataset.Length - 1; i++)
            {
                graph.AddEdge(dataset[i], dataset[i + 1], 1);
            }
            stopwatch.Stop();
            Console.WriteLine($"Graph AddEdge (Undirected): {stopwatch.ElapsedMilliseconds} ms");
        }

        [TestMethod()]
        public void Performance_AddEdge_Directed()
        {
            var dataset = DataSets.RandomList(100000, 0, 100000);
            var graph = new Graph<int>();
            foreach (var item in dataset)
            {
                graph.AddVertex(item);
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < dataset.Length - 1; i++)
            {
                graph.AddEdge(dataset[i], dataset[i + 1], 1, true);
            }
            stopwatch.Stop();
            Console.WriteLine($"Graph AddEdge (Directed): {stopwatch.ElapsedMilliseconds} ms");
        }

        [TestMethod()]
        public void Performance_GetNeighbors()
        {
            var dataset = DataSets.RandomList(100000, 0, 100000);
            var graph = new Graph<int>();
            foreach (var item in dataset)
            {
                graph.AddVertex(item);
            }
            for (int i = 0; i < dataset.Length - 1; i++)
            {
                graph.AddEdge(dataset[i], dataset[i + 1], 1);
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (var item in dataset)
            {
                var neighbors = graph.GetNeighbors(item);
            }
            stopwatch.Stop();
            Console.WriteLine($"Graph GetNeighbors: {stopwatch.ElapsedMilliseconds} ms");
        }

        [TestMethod()]
        public void Performance_Dijkstra_LargeGraph()
        {
            var dataset = DataSets.RandomList(100000, 0, 100000);
            var graph = new Graph<int>();
            foreach (var item in dataset)
            {
                graph.AddVertex(item);
            }
            for (int i = 0; i < dataset.Length - 1; i++)
            {
                graph.AddEdge(dataset[i], dataset[i + 1], 1);
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            var distances = graph.Dijkstra(0);
            stopwatch.Stop();
            Console.WriteLine($"Dijkstra LargeGraph: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}