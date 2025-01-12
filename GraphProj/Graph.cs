using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphProj
{
    public class Graph
    {
        private int Vertices;
        private Dictionary<int, List<(int, int)>> adjList;

        public Graph(int vertices)
        {
            Vertices = vertices;
            adjList = new Dictionary<int, List<(int, int)>>();

            for (int i = 0; i < vertices; i++)
            {
                adjList[i] = new List<(int, int)>();
            }
        }

        public void AddEdge(int u, int v, int weight = 1, bool isDirected = false)
        {
            adjList[u].Add((v, weight));
            if (!isDirected)
            {
                adjList[v].Add((u, weight));
            }
        }

        public void Display()
        {
            Console.WriteLine("Graph Adjacency List:");
            foreach (var vertex in adjList)
            {
                Console.Write($"Vertex {vertex.Key}: ");
                foreach (var edge in vertex.Value)
                {
                    Console.Write($"-> {edge.Item1}(Weight: {edge.Item2}) ");
                }
                Console.WriteLine();
            }
        }

        public List<(int, int)> GetNeighbors(int vertex)
        {
            if (adjList.ContainsKey(vertex))
            {
                return adjList[vertex];
            }
            else
            {
                Console.WriteLine($"Vertex {vertex} does not exist.");
                return new List<(int, int)>();
            }
        }
    }
}
