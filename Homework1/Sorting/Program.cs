namespace Sorting
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            if (!AreTestsCorrect())
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
                Console.Write(arrayOfNumbers[i] + " ");
            }

            Console.WriteLine();
            return 0;
        }

        private static int[] MakeArrayFromString(string sequenceOfNumbers)
        {
            string[] stringArrayOfNumbers = sequenceOfNumbers.Split(' ');
            int[] intArrayOfNumbers = new int[stringArrayOfNumbers.Length];
            for (int i = 0; i < stringArrayOfNumbers.Length; ++i)
            {
                intArrayOfNumbers[i] = int.Parse(stringArrayOfNumbers[i]);
            }

            return intArrayOfNumbers;
        }

        private static void SortByInsertion(int[] arrayForSorting)
        {
            for (var i = 1; i < arrayForSorting.Length; ++i)
            {
                var j = i;
                while (j >= 1 && arrayForSorting[j - 1] > arrayForSorting[j])
                {
                    var buffer = arrayForSorting[j - 1];
                    arrayForSorting[j - 1] = arrayForSorting[j];
                    arrayForSorting[j] = buffer;
                    --j;
                }
            }
        }

        private static bool StandartTest()
        {
            int[] arrayForStandartTest = { 1, 5, 8, 0, 2 };
            SortByInsertion(arrayForStandartTest);
            int[] resultArray = { 0, 1, 2, 5, 8 };
            return Enumerable.SequenceEqual(resultArray, arrayForStandartTest);
        }

        private static bool ReverseSortingTest()
        {
            int[] arrayForStandartTest = { 5, 4, 3, 2, 1 };
            SortByInsertion(arrayForStandartTest);
            int[] resultArray = { 1, 2, 3, 4, 5 };
            return Enumerable.SequenceEqual(arrayForStandartTest, resultArray);
        }

        private static bool TestWithEqualElements()
        {
            int[] arrayForStandartTest = { 1, 8, 1 };
            SortByInsertion(arrayForStandartTest);
            int[] resultArray = { 1, 1, 8 };
            return Enumerable.SequenceEqual(arrayForStandartTest, resultArray);
        }

        private static bool AreTestsCorrect()
        {
            return TestWithEqualElements() && ReverseSortingTest() && StandartTest();
        }
    }
}