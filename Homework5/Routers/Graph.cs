namespace Routers;

internal class Graph
{
    private Edge[]? edgesArray;
    private int indexOfEdgesArray;
    private int countsOfNodes;
    private int[,]? resultAdjacencyMatrix;
    private int realSizeOfResultEdgesArray;

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
            throw new InvalidDataException("Incorrect input data");
        }

        this.SortArrayOfEdges(ref this.edgesArray);
        var listOfOptimalGraphNodes = new List<int>();
        var resultArrayOfEdges = new Edge[this.edgesArray.Length];
        var indexOfResultEdgesArray = 0;
        var currentEdgesArrayIndex = 0;
        while (listOfOptimalGraphNodes.Count < this.countsOfNodes)
        {
            if (currentEdgesArrayIndex >= this.indexOfEdgesArray)
            {
                throw new Exception("????????????????????????");
            }

            var currentEdge = this.edgesArray[currentEdgesArrayIndex];
            if (!(listOfOptimalGraphNodes.Contains(currentEdge.FirstNode)
                && listOfOptimalGraphNodes.Contains(currentEdge.SecondNode)))
            {
                if (!listOfOptimalGraphNodes.Contains(currentEdge.FirstNode))
                {
                    listOfOptimalGraphNodes.Add(currentEdge.FirstNode);
                }

                if (!listOfOptimalGraphNodes.Contains(currentEdge.SecondNode))
                {
                    listOfOptimalGraphNodes.Add(currentEdge.SecondNode);
                }

                resultArrayOfEdges[indexOfResultEdgesArray++] = currentEdge;
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
