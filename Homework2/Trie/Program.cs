using Trie;

var newTrie = new Trie.Trie();

var key = 1;

while (key != '0')
{
    WriteIntroduction();
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
            var resultOfAdding = newTrie.Add(stringElement);
            Console.WriteLine(resultOfAdding ? "The element has been added" : "The element has already been in Trie");
            break;
        case 2:
            var doesContain = newTrie.Contain(stringElement);
            Console.WriteLine(doesContain ? "The element exists in the Trie"
                : "The element has'n been found in the Trie");
            break;
        case 3:
            var resultOfRemoving = newTrie.Remove(stringElement);
            Console.WriteLine(resultOfRemoving ? "The element has been removed"
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

void WriteIntroduction()
{
    Console.WriteLine("\nYou use the structure 'Trie'. Press");
    Console.WriteLine("0 if You want to break the program;");
    Console.WriteLine("1 if You want to Add element in structure;");
    Console.WriteLine("2 if You want to check existence element in structure;");
    Console.WriteLine("3 if You want to remove element from structure;");
    Console.WriteLine("4 if You want to know how many elements starts with current element (prefix);");
    Console.WriteLine("5 if You want to get size of the structure.");
}
