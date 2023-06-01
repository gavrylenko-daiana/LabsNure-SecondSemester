namespace Lab4;

class Program
{
    static void Main(string[] args)
    {
        var graphWeighted = new GraphWeighted(4);

        graphWeighted.AddEdge(0, 1, 10);
        graphWeighted.AddEdge(0, 2, 6);
        graphWeighted.AddEdge(0, 3, 5);
        graphWeighted.AddEdge(1, 3, 15);
        graphWeighted.AddEdge(2, 3, 4);

        graphWeighted.PrintGraph();

        graphWeighted.Kruskal();

        graphWeighted.Dijkstra(2);

        var primGraphWeighted = new PrimGraphWeighted(4);
        primGraphWeighted.AddEdge(0, 1, 10);
        primGraphWeighted.AddEdge(0, 2, 6);
        primGraphWeighted.AddEdge(0, 3, 5);
        primGraphWeighted.AddEdge(1, 3, 15);
        primGraphWeighted.AddEdge(2, 3, 4);
        primGraphWeighted.Prim_UAR_ADL();
    }
}