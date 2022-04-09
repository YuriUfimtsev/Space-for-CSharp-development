using NUnit.Framework;
using Routers;
using System.IO;
using System;

namespace RoutersTests;
public class RoutersTests
{
    [Test]
    public void StandartExampleFromTaskTest()
    {
        var newGraph = new Graph();
        var adjacencyMatrix = Program.CreateAdjacencyMatrixFromFileData("..\\..\\..\\StandartExampleTest.txt");
        var resultMatrix = newGraph.GetResultAdjacencyMatrix(adjacencyMatrix);
        Program.FillResultFileFromAdjacencyMatrix(resultMatrix, "..\\..\\..\\TemporaryNUnitResultFile.txt");
        var correctBytesArray = File.ReadAllBytes("..\\..\\..\\StandartExampleTestResult.txt");
        var currentBytesArray = File.ReadAllBytes("..\\..\\..\\TemporaryNUnitResultFile.txt");
        if (correctBytesArray.Length - 3 != currentBytesArray.Length)
        {
            Assert.Fail();
        }

        var isFilesEquals = true;
        for (int i = 3; i < correctBytesArray.Length; ++i)
        {
            if (correctBytesArray[i] != currentBytesArray[i - 3])
            {
                isFilesEquals = false;
                break;
            }
        }

        Assert.IsTrue(isFilesEquals);
    }

    [Test]
    public void BigStandartTest()
    {
        var newGraph = new Graph();
        var adjacencyMatrix = Program.CreateAdjacencyMatrixFromFileData("..\\..\\..\\BigStandartTest.txt");
        var resultMatrix = newGraph.GetResultAdjacencyMatrix(adjacencyMatrix);
        Program.FillResultFileFromAdjacencyMatrix(resultMatrix, "..\\..\\..\\TemporaryNUnitResultFile.txt");
        var correctBytesArray = File.ReadAllBytes("..\\..\\..\\BigStandartTestResult.txt");
        var currentBytesArray = File.ReadAllBytes("..\\..\\..\\TemporaryNUnitResultFile.txt");
        if (correctBytesArray.Length - 3 != currentBytesArray.Length)
        {
            Assert.Fail();
        }

        var isFilesEquals = true;
        for (int i = 3; i < correctBytesArray.Length; ++i)
        {
            if (correctBytesArray[i] != currentBytesArray[i - 3])
            {
                isFilesEquals = false;
                break;
            }
        }

        Assert.IsTrue(isFilesEquals);
    }

    [Test]
    public void TestWithEmptyFile()
    {
        var adjacencyMatrix = new int[1, 1];
        Assert.Throws<IncorrectInputException>(()
            => adjacencyMatrix = Program.CreateAdjacencyMatrixFromFileData("..\\..\\..\\EmptyFile.txt"));
    }

    [Test]
    public void IncoherentTopolyTest()
    {
        var newGraph = new Graph();
        var adjacencyMatrix = Program.CreateAdjacencyMatrixFromFileData("..\\..\\..\\IncoherentTopologyTest.txt");
        var resultMatrix = new int[1, 1];
        Assert.Throws<NotCoherentTopologyException>(() => resultMatrix = newGraph.GetResultAdjacencyMatrix(adjacencyMatrix));
        Program.FillResultFileFromAdjacencyMatrix(resultMatrix, "..\\..\\..\\TemporaryNUnitResultFile.txt");
    }
}