namespace BurrowsWheelerTransform;

internal static class BurrowsWheelerTransform
{
    private static int Main(string[] args)
    {
        //if (!AreTestsPassed())
        //{
        //    Console.WriteLine("Tests failed");
        //    return -1;
        //}
        Console.WriteLine("Enter the string for Burrows-Wheeler transform");
        var stringForBWT = Console.ReadLine();
        Console.WriteLine("Enter the correct number:\n 1 if you want to execute direct Burrows-Wheeler transform\n"
            + " 2 if you want to execute reverse Burrows-Wheeler transform");
        var keyForBWT = Console.ReadLine();
        if ((String.Compare(keyForBWT, "1") != 0 && String.Compare(keyForBWT, "2") != 0) || stringForBWT == null)
        {
            Console.WriteLine("Incorrect input.");
            return -1;
        }

        switch (keyForBWT)
        {
            case "1":
                var (directTransformedString, directEndStringPosition) = directBWT(stringForBWT);
                Console.WriteLine($"Transformed string: {directTransformedString}," +
                    $" end string position (counting from 0): {directEndStringPosition}");
                break;
            case "2":
                Console.WriteLine("Enter the end string position for Burrows-Wheeler transform (enter the number): ");
                var reverseEndStringPosition = Convert.ToInt32(Console.ReadLine());
                var reverseTransformedString = reverseBWT(stringForBWT, reverseEndStringPosition);
                Console.WriteLine($"Transformed string: {reverseTransformedString}");
                break;
        }
        return 0;
    }

    private static (string, int) directBWT(string stringForDirectBWT)
    {
        var endStringPosition = stringForDirectBWT.Length - 1;
        var arrayOfSuffixes = new int[stringForDirectBWT.Length];
        for (int i = 0; i < arrayOfSuffixes.Length; ++i)
        {
            arrayOfSuffixes[i] = i;
        }
        sortByInsertionForSuffixesArray(arrayOfSuffixes, stringForDirectBWT);
        var resultString = "" + stringForDirectBWT[stringForDirectBWT.Length - 1]; // если строка плохо расшифруется, то мб две проблемы:
        // 1)модификация с добавлением сразу одного символа в начало строки. Второе - сравниваем ограниченное число символов, и выбирается другой вариант.
        // Но если строки совпали, стоит выбирать тот вариант, где больше символов в итоге
        for (int i = 0; i < arrayOfSuffixes.Length; ++i)
        {
            if (arrayOfSuffixes[i] == 0)
            {
                endStringPosition = resultString.Length;
               //resultString += stringForDirectBWT[stringForDirectBWT.Length - 1]; //
            }
            else
            {
                resultString += stringForDirectBWT[arrayOfSuffixes[i] - 1];
            }
        }
        return (resultString, endStringPosition);
    }

    private static string reverseBWT(string stringForReverseBWT, int endStringPosition)
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
        var relevantSizeOfDifferentStringSymbolsArray = indexOfStringSymbolsArray + 1;
        var arrayForCreatingResultString = new int[arrayWithSortedStringElements.Length + 1];
        for (int i = 0; i <= arrayWithSortedStringElements.Length - 1; ++i)
        {
            arrayForCreatingResultString[i] = arrayWithStartingPositionOfSymbols
                [Array.IndexOf(arrayWithDifferentStringSymbols, stringForReverseBWT[i])];
            ++arrayWithStartingPositionOfSymbols
                [Array.IndexOf(arrayWithDifferentStringSymbols, stringForReverseBWT[i])];
        }
        for (var i = 0; i < endStringPosition; ++i)
        {
            ++arrayForCreatingResultString[i];
        }
        arrayForCreatingResultString[arrayWithSortedStringElements.Length]
            = arrayForCreatingResultString[arrayWithSortedStringElements.Length - 1] + 1;
        // строим результат перемещаясь по перестановке. Она задается массивами 1..n и arrayForCreatingResultString
        if (endStringPosition != stringForReverseBWT.Length - 1)
        {
            var indexOfEmptySpace = endStringPosition;
            for (
                var i = endStringPosition + 1; i < arrayWithSortedStringElements.Length + 1; ++i)
            {
                var buffer = arrayForCreatingResultString[i];
                arrayForCreatingResultString[i] = arrayForCreatingResultString[indexOfEmptySpace];
                arrayForCreatingResultString[indexOfEmptySpace] = buffer;
            }
        }
        stringForReverseBWT += stringForReverseBWT[endStringPosition];
        var currentPosition = arrayForCreatingResultString[endStringPosition];
        var resultString = stringForReverseBWT[currentPosition] + "";
        while (currentPosition != endStringPosition)
        {
            //currentPosition = arrayForCreatingResultString[currentPosition];
            resultString = stringForReverseBWT[currentPosition] + resultString;
            currentPosition = arrayForCreatingResultString[currentPosition];
        }
        return resultString;
    }
    private static void sortByInsertionForSuffixesArray(int[] suffixesArray, string basicString)
    {
        for (var i = 1; i < suffixesArray.Length; ++i)
        {
            var j = i;
            while (j >= 1 && ((String.Compare(basicString, suffixesArray[j - 1], basicString, suffixesArray[j],
                Math.Min(basicString.Length - suffixesArray[j], basicString.Length - suffixesArray[j - 1])) > 0)
                || (String.Compare(basicString, suffixesArray[j - 1], basicString, suffixesArray[j],
                Math.Min(basicString.Length - suffixesArray[j], basicString.Length - suffixesArray[j - 1])) == 0 &&
                (suffixesArray[j] > suffixesArray[j - 1]))))
            {
                (suffixesArray[j - 1], suffixesArray[j]) =
                    (suffixesArray[j], suffixesArray[j - 1]);
                --j;
            }
        }
    }
}
