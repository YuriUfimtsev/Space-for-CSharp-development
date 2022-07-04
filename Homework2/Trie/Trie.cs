namespace Trie;
using System.Collections;

/// <summary>
/// Trie-structure.
/// </summary>
public class Trie
{
    private readonly TrieElement head = new();
    private TrieElement? triePointer;

    /// <summary>
    /// Initializes a new instance of the <see cref="Trie"/> class.
    /// </summary>
    public Trie()
        => this.triePointer = this.head;

    /// <summary>
    /// Gets the size of the TrieElement.
    /// </summary>
    public int Size => this.head.SizeOfTrieElement;

    /// <summary>
    /// Method adds the element into Trie.
    /// </summary>
    /// <param name="stringElement">The string type element to add.</param>
    /// <returns>True if the stringElement hasn't been previously consisted in Trie. Else false.</returns>
    public bool Add(string stringElement)
    {
        if (stringElement.Length == 0 || this.Contain(stringElement))
        {
            return false;
        }

        var stringElementIndex = 0;
        TrieElement? currentElement = this.head;
        ++currentElement.SizeOfTrieElement;
        while (currentElement != null && currentElement.Vertexes.ContainsKey(stringElement[stringElementIndex]))
        {
            currentElement = currentElement.Vertexes[stringElement[stringElementIndex]];
            if (currentElement == null)
            {
                throw new InvalidOperationException();
            }

            ++currentElement.SizeOfTrieElement;
            if (stringElementIndex == stringElement.Length - 1)
            {
                if (!currentElement.IsTerminal)
                {
                    currentElement.IsTerminal = true;
                    return true;
                }
            }

            ++stringElementIndex;
        }

        while (currentElement != null && stringElementIndex != stringElement.Length)
        {
            currentElement.Vertexes.Add(stringElement[stringElementIndex], new TrieElement());
            currentElement = currentElement.Vertexes[stringElement[stringElementIndex]];
            ++currentElement!.SizeOfTrieElement;
            ++stringElementIndex;
        }

        return currentElement!.IsTerminal = true;
    }

    /// <summary>
    /// Method adds char type element in Trie.
    /// </summary>
    /// <param name="newElement">element to add.</param>
    public void AddWithPointer(char newElement)
    {
        TrieElement? currentElement = this.triePointer;
        if (currentElement!.Vertexes.ContainsKey(newElement))
        {
            currentElement = currentElement.Vertexes[newElement];
            if (!currentElement!.IsTerminal)
            {
                currentElement!.IsTerminal = true;
                ++currentElement.SizeOfTrieElement;
                ++this.head.SizeOfTrieElement;
                currentElement.VertexValue = this.head.SizeOfTrieElement + 255;
                this.triePointer = this.head;
            }

            this.triePointer = (TrieElement?)currentElement.Vertexes[newElement];
        }

        currentElement.Vertexes[newElement] = new TrieElement();
        currentElement = currentElement.Vertexes[newElement];
        currentElement!.IsTerminal = true;
        ++currentElement.SizeOfTrieElement;
        ++this.head.SizeOfTrieElement;
        currentElement.VertexValue = this.head.SizeOfTrieElement + 255;
        this.triePointer = this.head;
    }

    /// <summary>
    /// Method checks the existence of an element in the Trie.
    /// </summary>
    /// <param name="stringElement">The string type element to check.</param>
    /// <returns>True if element contains in Trie. Else false.</returns>
    public bool Contain(string stringElement)
    {
        if (stringElement.Length == 0)
        {
            return false;
        }

        var stringElementIndex = 0;
        TrieElement? currentElement = this.head;
        while (currentElement != null && currentElement.Vertexes.ContainsKey(stringElement[stringElementIndex]))
        {
            currentElement = currentElement.Vertexes[stringElement[stringElementIndex]];
            if (stringElementIndex == stringElement.Length - 1)
            {
                return currentElement!.IsTerminal;
            }

            ++stringElementIndex;
        }

        return false;
    }

    /// <summary>
    /// Method removes the element from the Trie.
    /// </summary>
    /// <param name="stringElement">The string type element to remove.</param>
    /// <returns>True if element has been contained in the Trie. Else false.</returns>
    public bool Remove(string stringElement)
    {
        if (!this.Contain(stringElement) || stringElement.Length == 0)
        {
            return false;
        }

        var stringElementIndex = 0;
        TrieElement? currentElement = this.head;

while (currentElement != null && currentElement.Vertexes.ContainsKey(stringElement[stringElementIndex]))
        {
            --currentElement.SizeOfTrieElement;
            currentElement = currentElement.Vertexes[stringElement[stringElementIndex]];

            if (stringElementIndex == stringElement.Length - 1)
            {
                currentElement.IsTerminal = false;
                return true;
            }

            ++stringElementIndex;
        }

        return false;
    }

    /// <summary>
    /// Method counts the number of Trie elements that start with a given prefix.
    /// </summary>
    /// <param name="prefix">The string type element to check.</param>
    /// <returns>Number of Trie's elements which start with a given prefix.</returns>
    public int HowManyStartsWithPrefix(string prefix)
    {
        if (prefix.Length == 0 || prefix == null)
        {
            return 0;
        }

        var prefixIndex = 0;
        TrieElement? currentElement = this.head;
        while (currentElement != null && currentElement.Vertexes.ContainsKey(prefix[prefixIndex]))
        {
            currentElement = currentElement.Vertexes[prefix[prefixIndex]];
            if (prefixIndex == prefix.Length - 1)
            {
                return currentElement!.SizeOfTrieElement;
            }

            ++prefixIndex;
        }

        return 0;
    }

    /// <summary>
    /// Nested class. Presents the elements of "Trie" class.
    /// </summary>
    private class TrieElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrieElement"/> class.
        /// </summary>
        public TrieElement()
            => this.Vertexes = new Dictionary<char, TrieElement>();

        /// <summary>
        /// Gets or sets the size of TrieElement.
        /// </summary>
        public int SizeOfTrieElement { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is this element terminal.
        /// </summary>
        public bool IsTerminal { get; set; }

        /// <summary>
        /// Gets or sets a hashtable of vertexes.
        /// </summary>
        public Dictionary<char, TrieElement> Vertexes { get; set; }

        public int VertexValue { get; set; }
    }
}
