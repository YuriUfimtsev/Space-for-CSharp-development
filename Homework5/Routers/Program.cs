namespace Routers;
using System.Text;

/// <summary>
/// Class with Main method.
/// </summary>
public static class Program
{
    /// <summary>
    /// Main method. Launches a set of methods.
    /// </summary>
    /// <param name="args">parameters from command line.</param>
    /// <returns>0 if programm finishes correctly. else not 0.</returns>
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
        try
        {
            var adjacencyMatrix = CreateAdjacencyMatrixFromFileData(fileName);
            var resultMatrix = newGraph.GetResultAdjacencyMatrix(adjacencyMatrix);
            FillResultFileFromAdjacencyMatrix(resultMatrix, resultFileName);
        }
        catch (NotCoherentTopologyException)
        {
            Console.Error.WriteLine("Topology from file isn't coherent.");
            return -1;
        }
        catch (IncorrectInputException exception)
        {
            Console.WriteLine(exception.Message);
            Console.WriteLine("Incorrect data in file.");
        }

        return 0;
    }

    /// <summary>
    /// Method create adjacency matrix from file's data.
    /// </summary>
    /// <param name="fileName">path to file.</param>
    /// <returns>result adjacency matrix.</returns>
    /// <exception cref="IncorrectInputException">throws this exception if file contains incorrect data.</exception>
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

        if (maxMatrixElement == int.MinValue)
        {
            throw new IncorrectInputException("IncorrectInput.");
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
                        throw new IncorrectInputException("Incorrect Input.");
                    }

                    ++arrayOfStringElementsIndex;
                    var value = int.Parse(arrayOfStringElementsIndex == arrayOfStringElements.Length - 1
                        ? arrayOfStringElements[arrayOfStringElementsIndex].Substring(
                            1,
                            arrayOfStringElements[arrayOfStringElementsIndex].Length - 2)
                        : arrayOfStringElements[arrayOfStringElementsIndex].Substring(
                            1,
                            arrayOfStringElements[arrayOfStringElementsIndex].Length - 3));
                    adjacencyMatrix[firstIndexForAdjacencyMatrix - 1, secondNodeNumber - 1] = value;
                    ++arrayOfStringElementsIndex;
                }
            }
        }

        return adjacencyMatrix;
    }

    /// <summary>
    /// Method fill in result file from adjacency matrix.
    /// </summary>
    /// <param name="adjacencyMatrix">input matrix.</param>
    /// <param name="resultFileName">path to result file.</param>
    public static void FillResultFileFromAdjacencyMatrix(int[,] adjacencyMatrix, string resultFileName)
    {
        using (StreamWriter fileStream = new(resultFileName))
        {
            for (var i = 0; i < adjacencyMatrix.GetLength(0); ++i)
            {
                var lineForResultFile = new StringBuilder();
                var indexForAdjacencyMatrixString = 0;
                var isNotNULLValuesInString = false;
                lineForResultFile.Append((i + 1) + ": ");
                while (indexForAdjacencyMatrixString < adjacencyMatrix.GetLength(1))
                {
                    if (adjacencyMatrix[i, indexForAdjacencyMatrixString] != 0)
                    {
                        isNotNULLValuesInString = true;
                        lineForResultFile.Append((indexForAdjacencyMatrixString + 1) + " ("
                            + adjacencyMatrix[i, indexForAdjacencyMatrixString] + ")");
                        lineForResultFile.Append(indexForAdjacencyMatrixString == adjacencyMatrix.GetLength(0) - 1
                            ? string.Empty : ", ");
                    }

                    ++indexForAdjacencyMatrixString;
                }

                if (isNotNULLValuesInString)
                {
                    if (lineForResultFile.Length >= 2)
                    {
                        if (lineForResultFile[lineForResultFile.Length - 1] == ' '
                            && lineForResultFile[lineForResultFile.Length - 2] == ',')
                        {
                            lineForResultFile.Remove(lineForResultFile.Length - 2, 2);
                        }
                    }

                    fileStream.WriteLine(lineForResultFile);
                }
            }
        }
    }
}
