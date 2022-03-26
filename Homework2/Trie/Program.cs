namespace Trie
{
    /// <summary>
    /// Class consists of "Main" method. Designed for communicate with user.
    /// </summary>
    internal class Program // Text for commit and launch Trie with CI
    {
        /// <summary>
        /// Method communicates with user.
        /// </summary>
        /// <param name="args">Parameters for command line.</param>
        internal static void Main(string[] args)
        {
            var newTrie = new Trie();

            var key = 1;
            while (key != '0')
            {
                WritesIntroduction();
                string? stringElement = " ";
                key = Convert.ToInt32(Console.ReadLine());
                if (key == 1 || key == 2 || key == 3 || key == 4)
                {
                    Console.WriteLine("Enter the element:");
                    stringElement = Console.ReadLine();
                    if (stringElement == null || stringElement.Length == 0)
                    {
                        Console.WriteLine("Incorrect input");
                        return;
                    }
                }

                switch (key)
                {
                    case 0:
                        return;
                    case 1:
                        var checkOfAdding = newTrie.Add(stringElement);
                        Console.WriteLine(checkOfAdding ? "The element has been added" : "The element has already been in Trie");
                        break;
                    case 2:
                        var isContain = newTrie.Contains(stringElement);
                        Console.WriteLine(isContain ? "The element exists in the Trie"
                            : "The element has'n been found in the Trie");
                        break;
                    case 3:
                        var checkOfRemoving = newTrie.Remove(stringElement);
                        Console.WriteLine(checkOfRemoving ? "The element has been removed"
                            : "The element hasn't been found in Trie");
                        break;
                    case 4:
                        var countOfElements = newTrie.HowManyStartsWithPrefix(stringElement);
                        Console.WriteLine($"{countOfElements} elements starts with this prefix");
                        break;
                    case 5:
                        Console.WriteLine($"The size of Trie = {newTrie.Size} elements");
                        break;
                    default:
                        Console.WriteLine("Incorrect input");
                        break;
                }
            }
        }

        private static void WritesIntroduction()
        {
            Console.WriteLine("\nYou use the structure 'Trie'. Press");
            Console.WriteLine("0 if You want to break the program;");
            Console.WriteLine("1 if You want to Add element in structure;");
            Console.WriteLine("2 if You want to check existence element in structure;");
            Console.WriteLine("3 if You want to remove element from structure;");
            Console.WriteLine("4 if You want to know how many elements starts with current element (prefix);");
            Console.WriteLine("5 if You want to get size of the structure.");
        }
    }
}
