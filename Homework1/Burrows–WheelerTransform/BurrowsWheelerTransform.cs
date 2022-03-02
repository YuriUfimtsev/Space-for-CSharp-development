namespace BurrowsWheelerTransform;

internal static class BurrowsWheelerTransform
{
    internal static (string ResultString, int EndStringPosition) DirectBWT(string stringForDirectBWT)
    {
        var endStringPosition = stringForDirectBWT.Length - 1;
        var arrayOfSuffixes = new int[stringForDirectBWT.Length];
        for (int i = 0; i < arrayOfSuffixes.Length; ++i)
        {
            arrayOfSuffixes[i] = i;
        }

        SortByInsertionForSuffixesArray(arrayOfSuffixes, stringForDirectBWT);
        var resultString = string.Empty;
        for (int i = 0; i < arrayOfSuffixes.Length; ++i)
        {
            if (arrayOfSuffixes[i] == 0)
            {
                endStringPosition = resultString.Length;
                resultString += stringForDirectBWT[stringForDirectBWT.Length - 1];
            }
            else
            {
                resultString += stringForDirectBWT[arrayOfSuffixes[i] - 1];
            }
        }

        return (resultString, endStringPosition);
    }

    internal static string ReverseBWT(string stringForReverseBWT, int endStringPosition)
    {
        var arrayWithSortedStringElements = stringForReverseBWT.ToCharArray();
        Array.Sort(arrayWithSortedStringElements);
        var arrayWithDifferentStringSymbols = new char[arrayWithSortedStringElements.Length];
        var arrayWithStartingPositionOfSymbols = new int[arrayWithSortedStringElements.Length];
        (arrayWithDifferentStringSymbols[0], arrayWithStartingPositionOfSymbols[0])
            = (arrayWithSortedStringElements[0], 0);
        var indexOfStringSymbolsArray = 0;
        for (int i = 1; i < arrayWithSortedStringElements.Length; ++i)
        {
            if (arrayWithSortedStringElements[i] != arrayWithSortedStringElements[i - 1])
            {
                ++indexOfStringSymbolsArray;
                arrayWithDifferentStringSymbols[indexOfStringSymbolsArray] = arrayWithSortedStringElements[i];
                arrayWithStartingPositionOfSymbols[indexOfStringSymbolsArray] = i;
            }
        }

        var arrayForCreatingResultString = new int[arrayWithSortedStringElements.Length];
        for (int i = 0; i < arrayWithSortedStringElements.Length; ++i)
        {
            int currentIndexInArrayWithDiffStrSymbols
                = Array.IndexOf(arrayWithDifferentStringSymbols, stringForReverseBWT[i]);
            arrayForCreatingResultString[i] = arrayWithStartingPositionOfSymbols[currentIndexInArrayWithDiffStrSymbols];
            ++arrayWithStartingPositionOfSymbols[currentIndexInArrayWithDiffStrSymbols];
        }

        var currentPosition = endStringPosition;
        var resultString = string.Empty;
        while (resultString.Length != stringForReverseBWT.Length)
        {
            resultString = stringForReverseBWT[currentPosition] + resultString;
            currentPosition = arrayForCreatingResultString[currentPosition];
        }

        return resultString;
    }

    private static int Main(string[] args)
    {
        if (!TestsForBWT.AreTestsPassing())
        {
            Console.WriteLine("Tests failed");
            return -1;
        }

        Console.WriteLine("Enter the string for Burrows-Wheeler transform");
        var stringForBWT = Console.ReadLine();
        Console.WriteLine("Enter the correct number:\n 1 if you want to execute direct Burrows-Wheeler transform\n"
            + " 2 if you want to execute reverse Burrows-Wheeler transform");
        var keyForBWT = Console.ReadLine();
        if ((string.Compare(keyForBWT, "1") != 0 && string.Compare(keyForBWT, "2") != 0) || stringForBWT == null)
        {
            Console.WriteLine("Incorrect input.");
            return -1;
        }

        switch (keyForBWT)
        {
            case "1":
                var (directTransformedString, directEndStringPosition) = DirectBWT(stringForBWT);
                Console.WriteLine($"Transformed string: {directTransformedString}," +
                    $" end string position (counting from 0): {directEndStringPosition}");
                break;
            case "2":
                Console.WriteLine("Enter the end string position for Burrows-Wheeler transform (enter the number): ");
                var reverseEndStringPosition = Convert.ToInt32(Console.ReadLine());
                var reverseTransformedString = ReverseBWT(stringForBWT, reverseEndStringPosition);
                Console.WriteLine($"Transformed string: {reverseTransformedString}");
                break;
        }

        return 0;
    }

    private static void SortByInsertionForSuffixesArray(int[] suffixesArray, string basicString)
    {
        for (var i = 1; i < suffixesArray.Length; ++i)
        {
            var j = i;
            while (j >= 1 && string.Compare(
                basicString,
                suffixesArray[j - 1],
                basicString,
                suffixesArray[j],
                Math.Min(basicString.Length - suffixesArray[j], basicString.Length - suffixesArray[j - 1])) > 0)
            {
                (suffixesArray[j - 1], suffixesArray[j]) =
                    (suffixesArray[j], suffixesArray[j - 1]);
                --j;
            }
        }
    }
}
