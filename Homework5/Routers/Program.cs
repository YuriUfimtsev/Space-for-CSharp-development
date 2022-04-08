namespace Routers;

public class Program
{
    public static int Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Incorrect input");
            return 0;
        }

        var newGraph = new Graph();
        var fileName = args[0];
        var resultFileName = args[1];
        var adjacencyMatrix = CreateAdjacencyMatrixFromFileData(fileName);
        var resultMatrix = newGraph.GetResultAdjacencyMatrix(adjacencyMatrix);
        FillResultFileFromAdjacencyMatrix(resultMatrix, resultFileName);
        return 0;
    }

    public static int[,] CreateAdjacencyMatrixFromFileData(string fileName)
    {
        var maxMatrixElement = int.MinValue;
        var line = string.Empty;
        using (StreamReader fileStreamForCountMatrixSize = new(fileName))
        {
            while ((line = fileStreamForCountMatrixSize.ReadLine()) != null)
            {
                var arrayOfStringElements = line!.Split();
                var currentElement = 0;
                for (var i = 0; i < arrayOfStringElements.Length; ++i)
                {
                    var isParsingCorrect = true;
                    isParsingCorrect = int.TryParse(arrayOfStringElements[i], out currentElement);
                    if (isParsingCorrect && currentElement > maxMatrixElement)
                    {
                        maxMatrixElement = currentElement;
                    }
                }
            }
        }

        var sizeOfMatrix = maxMatrixElement;
        var adjacencyMatrix = new int[sizeOfMatrix, sizeOfMatrix];
        using (StreamReader fileStreamForCreateMatrix = new(fileName))
        {
            var lineFromTopology = string.Empty;
            while ((lineFromTopology = fileStreamForCreateMatrix.ReadLine()) != null)
            {
                var arrayOfStringElements = lineFromTopology!.Split();
                var arrayOfStringElementsIndex = 1;
                var firstIndexForAdjacencyMatrix = int.Parse(arrayOfStringElements[0].Substring(0, 1));
                while (arrayOfStringElementsIndex < arrayOfStringElements.Length)
                {
                    var secondNodeNumber = 0;
                    bool isParsingCorrect = int.TryParse(
                        arrayOfStringElements[arrayOfStringElementsIndex],
                        out secondNodeNumber);
                    if (!isParsingCorrect)
                    {
                        throw new IncorrectInputException();
                    }

                    ++arrayOfStringElementsIndex;
                    var value = int.Parse(arrayOfStringElementsIndex == arrayOfStringElements.Length - 1
                        ? arrayOfStringElements[arrayOfStringElementsIndex].Substring(1, 1)
                        : arrayOfStringElements[arrayOfStringElementsIndex].Substring(1, 2));
                    adjacencyMatrix[firstIndexForAdjacencyMatrix - 1, secondNodeNumber - 1] = value;
                    ++arrayOfStringElementsIndex;
                }
            }
        }

        return adjacencyMatrix;
    }

    public static void FillResultFileFromAdjacencyMatrix(int[,] adjacencyMatrix, string resultFileName)
    {
        using (StreamWriter fileStream = new(resultFileName))
        {
            for (var i = 0; i < adjacencyMatrix.GetLength(0); ++i)
            {
                var lineForResultFile = string.Empty;
                var indexForAdjacencyMatrixString = 0;
                var isNotNULLValuesInString = false;
                lineForResultFile += (i + 1) + ": ";
                while (indexForAdjacencyMatrixString < adjacencyMatrix.GetLength(1))
                {
                    if (adjacencyMatrix[i, indexForAdjacencyMatrixString] != 0)
                    {
                        isNotNULLValuesInString = true;
                        lineForResultFile += (indexForAdjacencyMatrixString + 1) + " ("
                            + adjacencyMatrix[i, indexForAdjacencyMatrixString] + ")";
                        lineForResultFile += indexForAdjacencyMatrixString == adjacencyMatrix.GetLength(0) - 1
                            ? " " : ", ";
                    }

                    ++indexForAdjacencyMatrixString;
                }

                if (isNotNULLValuesInString)
                {
                    fileStream.WriteLine(lineForResultFile);
                }
            }
        }
    }

}
