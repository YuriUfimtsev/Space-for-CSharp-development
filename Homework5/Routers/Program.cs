namespace Routers;

public class Program
{
    public static void Main()
    {
        var newGraph = new Graph();
        var fileName = "..//..//topology.txt";
        var adjacencyMatrix = new int[4, 4]
        {
            { 0, 0, 0, 0 },
            { 15, 0, 0, 0 },
            { 25, 18, 0, 0 },
            { 30, 7, 50, 0 },
        };
        var result = newGraph.GetResultAdjacencyMatrix(adjacencyMatrix);
    }

    public static int[,] CreateAdjacencyMatrixFromFileData(string fileName)
    {
        var sizeOfMatrix = 0;
        var line = String.Empty;
        using (StreamReader fileStreamForCountMatrixSize = new(fileName))
        {
            while ((line = fileStreamForCountMatrixSize.ReadLine()) != null)
            {
                ++sizeOfMatrix;
            }
        }

        var adjacencyMatrix = new int[sizeOfMatrix, sizeOfMatrix];
        using (StreamReader fileStreamForCreateMatrix = new(fileName))
        {
            for (int i = 0; i < sizeOfMatrix; ++i)
            {
                var lineFromTopology = fileStreamForCreateMatrix.ReadLine();
                var arrayOfStringElements = lineFromTopology!.Split();
                for (int k = 1; k < arrayOfStringElements.Length; ++k)
                {
                    var secondNodeNumber = 0;
                    bool isParsingCorrect = int.TryParse(arrayOfStringElements[k], out secondNodeNumber);
                    if (!isParsingCorrect)
                    {
                        throw new IncorrectInputException();
                    }

                    var value = 0;
                    //Следующим шагом из конструкции "(...)," достать число ... !!!!
                    // И записать все это в матрицу смежности!!!
                }

            }
        }


    }
}
