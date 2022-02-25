using System;

namespace Sorting
{
    class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("Enter elements of array: ");
            var sequenceOfNumbers = Console.ReadLine();
            if (sequenceOfNumbers == null)
            {
                Console.WriteLine("No elements for sorting");
                return 0;
            }
            int[] arrayOfNumbers = makeArrayFromString(sequenceOfNumbers);

            return 0;
        }
        static int[] makeArrayFromString(string sequenceOfNumbers)
        {
            string[] stringArrayOfNumbers = sequenceOfNumbers.Split(' ');
            int[] intArrayOfNumbers = new int[stringArrayOfNumbers.Length];
            for (int i = 0; i < stringArrayOfNumbers.Length; ++i)
            {
                intArrayOfNumbers[i] = int.Parse(stringArrayOfNumbers[i]);
            }
            return intArrayOfNumbers;
        }
        static void sortByInsertion(int[] arrayForSorting)
        {
            
        }
    }
}
