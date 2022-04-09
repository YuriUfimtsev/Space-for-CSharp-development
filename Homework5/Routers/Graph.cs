namespace Routers;

/// <summary>
/// Realizes struct Graph.
/// </summary>
public class Graph
{
    private Edge[]? edgesArray;
    private int indexOfEdgesArray;
    private int countsOfNodes;
    private int[,]? resultAdjacencyMatrix;
    private int realSizeOfResultEdgesArray;

    /// <summary>
    /// Creates new matrix after working with another matrix and building optimal graph.
    /// </summary>
    /// <param name="adjacencyMatrix">matrix for handling.</param>
    /// <returns>adjacency matrix from optimal graph.</returns>
    public int[,] GetResultAdjacencyMatrix(int[,] adjacencyMatrix)
    {
        this.ConvertAdjacencyMatrixToTheEdgeArray(adjacencyMatrix);
        var newGraph = this.CreateOptimalGraph();
        this.ConvertEdgeArrayToTheAdjacencyMatrix(newGraph);
        return this.resultAdjacencyMatrix!;
    }

    private void ConvertEdgeArrayToTheAdjacencyMatrix(Edge[] resultArrayOfEdges)
    {
        var adjacencyMatrix = new int[this.countsOfNodes, this.countsOfNodes];
        for (var i = 0; i < this.countsOfNodes; ++i)
        {
            for (var j = 0; j < this.countsOfNodes; ++j)
            {
                adjacencyMatrix[i, j] = 0;
            }
        }

        for (int i = 0; i < this.realSizeOfResultEdgesArray; ++i)
        {
            var currentNode = resultArrayOfEdges[i];
            adjacencyMatrix[currentNode.FirstNode, currentNode.SecondNode] = currentNode.Value;
        }

        this.resultAdjacencyMatrix = adjacencyMatrix;
    }

    private void AddEdge(int firstNode, int secondNode, int value)
    {
        var newEdge = new Edge();
        newEdge.FirstNode = firstNode;
        newEdge.SecondNode = secondNode;
        newEdge.Value = value;
        this.edgesArray![this.indexOfEdgesArray] = newEdge;
        ++this.indexOfEdgesArray;
    }

    private void ConvertAdjacencyMatrixToTheEdgeArray(int[,] adjacencyMatrix)
    {
        this.countsOfNodes = adjacencyMatrix.GetLength(1);
        this.edgesArray = new Edge[((this.countsOfNodes * this.countsOfNodes) / 2) + 1];
        this.indexOfEdgesArray = 0;
        for (var i = 0; i < adjacencyMatrix.GetLength(1); ++i)
        {
            for (var j = 0; j < adjacencyMatrix.GetLength(1); ++j)
            {
                if (adjacencyMatrix[i, j] != 0)
                {
                    this.AddEdge(i, j, adjacencyMatrix[i, j]);
                }
            }
        }
    }

    private Edge[] CreateOptimalGraph()
    {
        if (this.edgesArray == null || this.edgesArray.Length == 0)
        {
            throw new IncorrectInputException("Incorrect input data");
        }

        this.SortArrayOfEdges(ref this.edgesArray);
        var listOfOptimalGraphNodes = new List<int>();
        var resultArrayOfEdges = new Edge[this.edgesArray.Length];
        var listOfEdges = new LinkedList<Edge>();
        var indexForList = 0;
        while (this.edgesArray[indexForList] != null)
        {
            listOfEdges.AddLast(this.edgesArray[indexForList]);
            ++indexForList;
        }

        listOfOptimalGraphNodes.Add(listOfEdges.First().FirstNode);
        listOfOptimalGraphNodes.Add(listOfEdges.First().SecondNode);
        resultArrayOfEdges[0] = listOfEdges.First();
        listOfEdges.RemoveFirst();

        var indexOfResultEdgesArray = 1;
        var currentEdgesArrayIndex = 1;
        while (listOfOptimalGraphNodes.Count < this.countsOfNodes)
        {
            if (currentEdgesArrayIndex >= this.indexOfEdgesArray)
            {
                throw new NotCoherentTopologyException();
            }

            var currentListOfEdgesElement = listOfEdges.First;
            if (currentListOfEdgesElement == null)
            {
                throw new NotCoherentTopologyException();
            }

            while (!(listOfOptimalGraphNodes.Contains(currentListOfEdgesElement.Value.FirstNode)
                ^ listOfOptimalGraphNodes.Contains(currentListOfEdgesElement.Value.SecondNode)))
            {
                if (currentListOfEdgesElement.Next == null)
                {
                    throw new NotCoherentTopologyException();
                }

                currentListOfEdgesElement = currentListOfEdgesElement.Next;
            }

            if (listOfOptimalGraphNodes.Contains(currentListOfEdgesElement.Value.FirstNode)
                ^ listOfOptimalGraphNodes.Contains(currentListOfEdgesElement.Value.SecondNode))
            {
                if (!listOfOptimalGraphNodes.Contains(currentListOfEdgesElement.Value.FirstNode))
                {
                    listOfOptimalGraphNodes.Add(currentListOfEdgesElement.Value.FirstNode);
                }

                if (!listOfOptimalGraphNodes.Contains(currentListOfEdgesElement.Value.SecondNode))
                {
                    listOfOptimalGraphNodes.Add(currentListOfEdgesElement.Value.SecondNode);
                }

                resultArrayOfEdges[indexOfResultEdgesArray++] = currentListOfEdgesElement.Value;
                listOfEdges.Remove(currentListOfEdgesElement);
            }

            ++currentEdgesArrayIndex;
        }

        this.realSizeOfResultEdgesArray = indexOfResultEdgesArray;
        return resultArrayOfEdges;
    }

    private void SortArrayOfEdges(ref Edge[] arrayOfEdeges)
    {
        var arrayOfKeys = new int[arrayOfEdeges.Length];
        for (int i = 0; i < this.indexOfEdgesArray; ++i)
        {
            arrayOfKeys[i] = arrayOfEdeges[i].Value;
        }

        Array.Sort(arrayOfKeys, arrayOfEdeges);
        Array.Reverse(arrayOfEdeges);
    }
}
