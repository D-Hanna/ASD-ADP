using System;
using System.Collections.Generic;

namespace GraphProj
{
    public class Graph<T> where T : notnull
    {
        private Dictionary<T, List<(T Neighbor, int Weight)>> adjList;

        public Graph()
        {
            adjList = new Dictionary<T, List<(T, int)>>();
        }

        public void AddVertex(T vertex)
        {
            if (!adjList.ContainsKey(vertex))
            {
                adjList[vertex] = new List<(T, int)>();
            }
        }

        public void AddEdge(T u, T v, int weight = 1, bool isDirected = false)
        {
            if (weight < 0)
            {
                throw new ArgumentException("Edge weight cannot be negative", nameof(weight));
            }
            if (!adjList.ContainsKey(u))
            {
                AddVertex(u);
            }
            if (!adjList.ContainsKey(v))
            {
                AddVertex(v);
            }

            adjList[u].Add((v, weight));

            if (!isDirected)
            {
                adjList[v].Add((u, weight));
            }
        }

        public List<(T Neighbor, int Weight)> GetNeighbors(T vertex)
        {
            if (adjList.ContainsKey(vertex))
            {
                return adjList[vertex];
            }
            else
            {
                Console.WriteLine($"Vertex {vertex} does not exist.");
                return new List<(T, int)>();
            }
        }

        public Dictionary<T, int> Dijkstra(T source)
        {
            var distances = new Dictionary<T, int>();
            var priorityQueue = new SortedSet<(int Distance, T Vertex)>();
            var visited = new HashSet<T>();

            foreach (var vertex in adjList.Keys)
            {
                distances[vertex] = int.MaxValue;
            }
            distances[source] = 0;

            priorityQueue.Add((0, source));

            while (priorityQueue.Count > 0)
            {
                var (currentDistance, currentVertex) = priorityQueue.Min;
                priorityQueue.Remove(priorityQueue.Min);

                if (visited.Contains(currentVertex)) continue;
                visited.Add(currentVertex);

                foreach (var (neighbor, weight) in GetNeighbors(currentVertex))
                {
                    if (visited.Contains(neighbor)) continue;

                    int newDistance = currentDistance + weight;

                    if (newDistance < distances[neighbor])
                    {
                        priorityQueue.Remove((distances[neighbor], neighbor));
                        distances[neighbor] = newDistance;
                        priorityQueue.Add((newDistance, neighbor));
                    }
                }
            }

            return distances;
        }
    }
}
