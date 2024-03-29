﻿namespace Sorting;

/// <summary>
/// Класс сортирует массив методом сортировки вставками.
/// </summary>
internal static class ArraySorting
{
    /// <summary>
    /// Метод реализует сортировку вставками.
    /// </summary>
    /// <param name="arrayForSorting"> Принимает на вход массив для сортировки. </param>
    internal static void SortByInsertion(int[] arrayForSorting)
    {
        for (var i = 1; i < arrayForSorting.Length; ++i)
        {
            var j = i;
            while (j >= 1 && arrayForSorting[j - 1] > arrayForSorting[j])
            {
                (arrayForSorting[j - 1], arrayForSorting[j]) =
                    (arrayForSorting[j], arrayForSorting[j - 1]);
                --j;
            }
        }
    }

    private static int Main(string[] args)
    {
        if (!TestsForArraySorting.AreTestsCorrect())
        {
            Console.WriteLine("Tests failed");
            return -1;
        }

        Console.Write("Enter elements of array: ");
        var sequenceOfNumbers = Console.ReadLine();
        if (sequenceOfNumbers == null)
        {
            Console.WriteLine("No elements for sorting");
            return 0;
        }

        int[] arrayOfNumbers = MakeArrayFromString(sequenceOfNumbers);
        SortByInsertion(arrayOfNumbers);
        Console.Write("Sorted array: ");
        for (var i = 0; i < arrayOfNumbers.Length; i++)
        {
            Console.Write($"{arrayOfNumbers[i]} ");
        }

        Console.WriteLine();
        return 0;
    }

    private static int[] MakeArrayFromString(string sequenceOfNumbers)
    {
        string[] stringArrayOfNumbers = sequenceOfNumbers.Split(' ');
        var intArrayOfNumbers = new int[stringArrayOfNumbers.Length];
        for (int i = 0; i < stringArrayOfNumbers.Length; ++i)
        {
            intArrayOfNumbers[i] = int.Parse(stringArrayOfNumbers[i]);
        }

        return intArrayOfNumbers;
    }
}