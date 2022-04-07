namespace Routers;

public class Program
{
    public static void Main()
    {
        var newGraph = new Graph();
        var adjacencyMatrix = new int[4, 4]
        {
            { 0, 0, 0, 0 },
            { 15, 0, 0, 0 },
            { 25, 18, 0, 0 },
            { 30, 7, 50, 0 },
        };
        var result = newGraph.GetResultAdjacencyMatrix(adjacencyMatrix);
    }
}
