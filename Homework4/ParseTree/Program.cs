global using System;
global using System.Collections.Generic;

namespace ParseTree;

/// <summary>
/// Class with Main function.
/// </summary>
public class Program
{
    /// <summary>
    /// Main function.
    /// </summary>
    /// <param name="args">arguments from command line.</param>
    public static void Main(string[] args)
    {
        FileInfo fileInfo = new("../../../PrefixExpression.txt");
        string prefixSequence = File.ReadAllText($"{fileInfo}");
        Console.WriteLine($"Sequence from file: {prefixSequence}");
        ParseTree parseTree = new();
        var indexForParseTreeCreation = -1;
        INode? newTree = parseTree.CreateNewNodeForParseTree(prefixSequence, ref indexForParseTreeCreation);
        if (newTree == null)
        {
            Console.WriteLine("Error with Parse tree creation");
        }

        Console.WriteLine($"Result of calculation: {parseTree.Eval(newTree!)}");
        Console.Write("Expression in infix form: ");
        parseTree.Print(newTree!);
    }
}