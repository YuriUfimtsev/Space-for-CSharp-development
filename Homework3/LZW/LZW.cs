namespace LZW;

using System.Collections;

/// <summary>
/// Class realizes two base methods: "Compress the file" and "Decompress the file". Founded on LZW algorithm.
/// </summary>
public class LZW
{
    /// <summary>
    /// Method compresses the file.
    /// </summary>
    /// <param name="fileNameForCompress">Name of file you want to compress.</param>
    public static void Compress(string fileNameForCompress)
    {
        byte[] arrayOfBytes = File.ReadAllBytes(fileNameForCompress);
        var newTrie = new Trie.Trie();
        for (var i = 0; i < 256; ++i)
        {
            (var isInTrie, var number) = newTrie.AddWithPointer((char)i);
        }

        FileInfo newFile = new(fileNameForCompress + ".zipped");
        var compressedFile = newFile.Create();
        BitArray temporaryBitArray = new(64);
        var temporaryBitArrayIndex = 0;
        var counterOfBitesArray = 0;
        var currentBitSize = 9;
        while (counterOfBitesArray < arrayOfBytes.Length)
        {
            (var isInTrie, var numberOfSymbol) = (true, -1);
            var previousNumberOfSymbol = -1;
            while (isInTrie && counterOfBitesArray < arrayOfBytes.Length)
            {
                previousNumberOfSymbol = numberOfSymbol;
                (isInTrie, numberOfSymbol) = newTrie.AddWithPointer((char)arrayOfBytes[counterOfBitesArray]);
                ++counterOfBitesArray;
            }

            counterOfBitesArray -= isInTrie && counterOfBitesArray == arrayOfBytes.Length ? 0 : 1;
            if (isInTrie && counterOfBitesArray == arrayOfBytes.Length)
            {
                previousNumberOfSymbol = numberOfSymbol;
            }

            var countOfNotNulls = 0;
            while (previousNumberOfSymbol > 0)
            {
                var digit = previousNumberOfSymbol % 2;
                temporaryBitArray[temporaryBitArrayIndex] = (digit == 0) ? false : true;
                previousNumberOfSymbol /= 2;
                ++temporaryBitArrayIndex;
                ++countOfNotNulls;
            }

            for (var i = 0; i < currentBitSize - countOfNotNulls; ++i)
            {
                temporaryBitArray[temporaryBitArrayIndex] = false;
                ++temporaryBitArrayIndex;
            }

            if (counterOfBitesArray == arrayOfBytes.Length)
            {
                while (temporaryBitArrayIndex % 8 != 0)
                {
                    temporaryBitArray[temporaryBitArrayIndex] = false;
                    ++temporaryBitArrayIndex;
                }
            }

            while (temporaryBitArrayIndex >= 8)
            {
                byte newByte = 0;
                var multiplier = 1;
                for (var i = 0; i < 8; ++i)
                {
                    newByte += (byte)((temporaryBitArray[i] ? 1 : 0) * multiplier);
                    multiplier *= 2;
                    temporaryBitArray[i] = false;
                }

                temporaryBitArrayIndex -= 8;
                temporaryBitArray.RightShift(8);
                compressedFile.WriteByte(newByte);
            }

            if (numberOfSymbol == Math.Pow(2, currentBitSize))
            {
                ++currentBitSize;
            }
        }

        compressedFile.Close();
    }

    /// <summary>
    /// Method decompresses the file.
    /// </summary>
    /// <param name="fileNameForDecompressing">Name of file you want to decompress.</param>
    /// <returns>true if decompressing is correct. Else false.</returns>
    public static bool Decompress(string fileNameForDecompressing)
    {
        byte[] arrayOfBytes = File.ReadAllBytes(fileNameForDecompressing);
        var dictionary = new Dictionary<int, string>();
        for (var i = 0; i < 256; ++i)
        {
            dictionary.Add(i, char.ToString((char)i));
        }

        FileInfo newFile = new(fileNameForDecompressing.Remove(fileNameForDecompressing.Length - 7));
        FileStream decompressedFile = newFile.Create();
        BitArray arrayOfCompressedFileBits = new BitArray(arrayOfBytes);
        var arrayOfCompressedFileBitsIndex = 0;
        var currentBitSize = 9;
        string? previousValue = null;
        var currentNumber = 256;
        while (arrayOfCompressedFileBitsIndex < arrayOfCompressedFileBits.Length)
        {
            var multiplier = 1;
            var newNumber = 0;
            for (var i = 0; i < currentBitSize; ++i)
            {
                newNumber += multiplier * (arrayOfCompressedFileBits[arrayOfCompressedFileBitsIndex] ? 1 : 0);
                multiplier *= 2;
                ++arrayOfCompressedFileBitsIndex;
                if (arrayOfCompressedFileBitsIndex >= arrayOfCompressedFileBits.Length)
                {
                    decompressedFile.Close();
                    return newNumber == 0;
                }
            }

            var dictionaryValue = dictionary.ContainsKey(newNumber) ? dictionary[newNumber]
                : previousValue + previousValue![0];
            for (var i = 0; i < dictionaryValue.Length; ++i)
            {
                decompressedFile.WriteByte((byte)dictionaryValue[i]);
            }

            if (previousValue != null)
            {
                dictionary.Add(currentNumber, previousValue + dictionaryValue[0]);
                ++currentNumber;
                if (currentNumber == Math.Pow(2, currentBitSize))
                {
                    ++currentBitSize;
                }
            }

            previousValue = dictionaryValue;
        }

        decompressedFile.Close();
        return true;
    }

    private static void Main(string[] args)
    {
        if (args.Length == 0 || args.Length == 1)
        {
            Console.WriteLine("Incorrect input");
            return;
        }

        Console.WriteLine(string.Equals(args[1], "-c")
            ? "You want to compressed file with path: " : (string.Equals(args[1], "-u")
            ? "You want to UNcompressed file with path: " : "Incorrect input. Try again"));
        if (!string.Equals(args[1], "-u") && !string.Equals(args[1], "-c"))
        {
            return;
        }

        Console.WriteLine(args[0]);
        if (string.Equals(args[1], "-u"))
        {
            var isDecompressCorrect = Decompress(args[0]);
            if (!isDecompressCorrect)
            {
                Console.WriteLine("Unfortunately, Uncompressed has been made with error.");
                return;
            }

            Console.WriteLine("Result file without extension '.zipped' has been added");
        }
        else if (string.Equals(args[1], "-c"))
        {
            Compress(args[0]);
            Console.WriteLine("Result file with extension '.zipped' has been added");
            var file = new FileInfo(args[0]);
            Compress(args[0]);
            var compressedFile = new FileInfo(args[0] + ".zipped");
            long compressionFactor = file.Length / compressedFile.Length;
            Console.WriteLine($"Compression factor without using BWT = {compressionFactor}");
        }
    }
}