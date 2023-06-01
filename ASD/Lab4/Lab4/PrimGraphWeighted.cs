namespace Lab4;

class PrimGraphWeighted
{
    public int Vertices;
    public List<Tuple<int, int, int>> Edges;

    public PrimGraphWeighted(int vertices)
    {
        Vertices = vertices;
        Edges = new List<Tuple<int, int, int>>();
    }

    public void AddEdge(int source, int destination, int weight)
    {
        Edges.Add(new Tuple<int, int, int>(source, destination, weight));
    }

    public void Prim_UAR_ADL()
    {
        var key = new int[Vertices];
        var mstSet = new bool[Vertices];
        var parent = new int[Vertices];

        for (int i = 0; i < Vertices; i++)
        {
            key[i] = int.MaxValue;
            mstSet[i] = false;
        }

        key[0] = 0;

        for (int count = 0; count < Vertices - 1; count++)
        {
            int u = MinKey(key, mstSet);

            mstSet[u] = true;

            for (int v = 0; v < Vertices; v++)
            {
                int weight = GetWeight(u, v);
                if (weight != 0 && !mstSet[v] && weight < key[v])
                {
                    parent[v] = u;
                    key[v] = weight;
                }
            }
        }

        Console.WriteLine("Minimum Spanning Tree:");
        for (int i = 1; i < Vertices; i++)
        {
            Console.WriteLine(parent[i] + " - " + i + " : " + GetWeight(i, parent[i]));
        }
    }

    private int GetWeight(int u, int v)
    {
        foreach (var edge in Edges)
        {
            if ((edge.Item1 == u && edge.Item2 == v) || (edge.Item1 == v && edge.Item2 == u))
            {
                return edge.Item3;
            }
        }
        return 0;
    }

    private int MinKey(int[] key, bool[] mstSet)
    {
        int minKey = int.MaxValue;
        int minIndex = -1;

        for (int v = 0; v < Vertices; v++)
        {
            if (mstSet[v] == false && key[v] < minKey)
            {
                minKey = key[v];
                minIndex = v;
            }
        }

        return minIndex;
    }
}