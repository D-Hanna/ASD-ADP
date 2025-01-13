using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphProj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphProj.Tests
{
    [TestClass()]
    public class GraphTests
    {
        [TestMethod]
        public void AddVertexTest()
        {
            var graph = new Graph<int>();
            graph.AddVertex(1);
            var neighbors = graph.GetNeighbors(1);
            Assert.IsNotNull(neighbors);
            Assert.AreEqual(0, neighbors.Count);
        }

        [TestMethod]
        public void AddEdgeTest_Undirected()
        {
            var graph = new Graph<int>();
            graph.AddEdge(1, 2, 5);
            var neighbors1 = graph.GetNeighbors(1);
            var neighbors2 = graph.GetNeighbors(2);

            Assert.AreEqual(1, neighbors1.Count);
            Assert.AreEqual(1, neighbors2.Count);
            Assert.AreEqual((2, 5), neighbors1[0]);
            Assert.AreEqual((1, 5), neighbors2[0]);
        }

        [TestMethod]
        public void AddEdgeTest_Directed()
        {
            var graph = new Graph<int>();
            graph.AddEdge(1, 2, 5, true);
            var neighbors1 = graph.GetNeighbors(1);
            var neighbors2 = graph.GetNeighbors(2);

            Assert.AreEqual(1, neighbors1.Count);
            Assert.AreEqual(0, neighbors2.Count);
            Assert.AreEqual((2, 5), neighbors1[0]);
        }

        [TestMethod]
        public void GetNeighborsTest()
        {
            var graph = new Graph<int>();
            graph.AddEdge(1, 2, 5);
            graph.AddEdge(1, 3, 10);
            var neighbors = graph.GetNeighbors(1);

            Assert.AreEqual(2, neighbors.Count);
            Assert.IsTrue(neighbors.Contains((2, 5)));
            Assert.IsTrue(neighbors.Contains((3, 10)));
        }

        [TestMethod]
        public void GetNeighborsTest_VertexDoesNotExist()
        {
            var graph = new Graph<int>();
            var neighbors = graph.GetNeighbors(1);

            Assert.AreEqual(0, neighbors.Count);
        }

        // Dijkstra tests
        [TestMethod]
        public void DijkstraTest_SingleVertex()
        {
            var graph = new Graph<int>();
            graph.AddVertex(1);
            var distances = graph.Dijkstra(1);

            Assert.AreEqual(1, distances.Count);
            Assert.AreEqual(0, distances[1]);
        }

        [TestMethod]
        public void DijkstraTest_TwoVertices()
        {
            var graph = new Graph<int>();
            graph.AddEdge(1, 2, 5);
            var distances = graph.Dijkstra(1);

            Assert.AreEqual(2, distances.Count);
            Assert.AreEqual(0, distances[1]);
            Assert.AreEqual(5, distances[2]);
        }

        [TestMethod]
        public void DijkstraTest_MultipleVertices()
        {
            var graph = new Graph<int>();
            graph.AddEdge(1, 2, 1);
            graph.AddEdge(2, 3, 2);
            graph.AddEdge(1, 3, 4);
            var distances = graph.Dijkstra(1);

            Assert.AreEqual(3, distances.Count);
            Assert.AreEqual(0, distances[1]);
            Assert.AreEqual(1, distances[2]);
            Assert.AreEqual(3, distances[3]);
        }

        [TestMethod]
        public void DijkstraTest_DisconnectedGraph()
        {
            var graph = new Graph<int>();
            graph.AddEdge(1, 2, 1);
            graph.AddVertex(3);
            var distances = graph.Dijkstra(1);

            Assert.AreEqual(3, distances.Count);
            Assert.AreEqual(0, distances[1]);
            Assert.AreEqual(1, distances[2]);
            Assert.AreEqual(int.MaxValue, distances[3]);
        }

        [TestMethod]
        public void DijkstraTest_DirectedGraph()
        {
            var graph = new Graph<int>();
            graph.AddEdge(1, 2, 1, true);
            graph.AddEdge(2, 3, 2, true);
            graph.AddEdge(1, 3, 4, true);
            var distances = graph.Dijkstra(1);

            Assert.AreEqual(3, distances.Count);
            Assert.AreEqual(0, distances[1]);
            Assert.AreEqual(1, distances[2]);
            Assert.AreEqual(3, distances[3]);
        }

    }
}