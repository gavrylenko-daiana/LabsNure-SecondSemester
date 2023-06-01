namespace Lab4;

class GraphWeighted
{
    public int Vertices;
    public List<Tuple<int, int, int>> Edges;

    public GraphWeighted(int vertices)
    {
        Vertices = vertices;
        Edges = new List<Tuple<int, int, int>>();
    }

    public void AddEdge(int source, int destination, int weight)
    {
        Edges.Add(new Tuple<int, int, int>(source, destination, weight));
    }

    public void PrintGraph()
    {
        Console.WriteLine("Edges of the graph:");
        foreach (var edge in Edges)
        {
            Console.WriteLine(edge.Item1 + " - " + edge.Item2 + " : " + edge.Item3);
        }
    }

    public void Kruskal()
    {
        var result = new List<Tuple<int, int, int>>();
        Edges.Sort((a, b) => a.Item3.CompareTo(b.Item3));
        var subsets = new Subset[Vertices];
        for (int i = 0; i < Vertices; i++)
        {
            subsets[i] = new Subset(i);
        }

        foreach (var edge in Edges)
        {
            int x = Find(subsets, edge.Item1);
            int y = Find(subsets, edge.Item2);
            if (x != y)
            {
                result.Add(edge);
                Union(subsets, x, y);
            }
        }

        Console.WriteLine("Minimum Spanning Tree:");
        foreach (var edge in result)
        {
            Console.WriteLine(edge.Item1 + " - " + edge.Item2 + " : " + edge.Item3);
        }
    }

    public void Dijkstra(int source)
    {
        var distances = new int[Vertices];
        var visited = new bool[Vertices];
        for (int i = 0; i < Vertices; i++)
        {
            distances[i] = int.MaxValue;
        }

        distances[source] = 0;
        for (int count = 0; count < Vertices - 1; count++)
        {
            int u = MinDistance(distances, visited);
            visited[u] = true;
            foreach (var edge in Edges)
            {
                if (edge.Item1 == u && !visited[edge.Item2])
                {
                    if (distances[u] != int.MaxValue && distances[u] + edge.Item3 < distances[edge.Item2])
                    {
                        distances[edge.Item2] = distances[u] + edge.Item3;
                    }
                }
                else if (edge.Item2 == u && !visited[edge.Item1])
                {
                    if (distances[u] != int.MaxValue && distances[u] + edge.Item3 < distances[edge.Item1])
                    {
                        distances[edge.Item1] = distances[u] + edge.Item3;
                    }
                }
            }
        }

        Console.WriteLine("Shortest paths from source " + source + ":");
        for (int i = 0; i < Vertices; i++)
        {
            Console.WriteLine(i + ": " + distances[i]);
        }
    }

    private class Subset
    {
        public int Parent;

        public Subset(int parent)
        {
            Parent = parent;
        }
    }

    private static int Find(Subset[] subsets, int i)
    {
        if (subsets[i].Parent != i)
        {
            subsets[i].Parent = Find(subsets, subsets[i].Parent);
        }

        return subsets[i].Parent;
    }

    private static void Union(Subset[] subsets, int xroot, int yroot)
    {
        subsets[xroot].Parent = yroot;
    }

    private static int MinDistance(int[] dist, bool[] visited)
    {
        int min = int.MaxValue;
        int minIndex = -1;
        for (int v = 0; v < dist.Length; v++)
        {
            if (!visited[v] && dist[v] <= min)
            {
                min = dist[v];
                minIndex = v;
            }
        }

        return minIndex;
    }
}
