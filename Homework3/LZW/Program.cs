using System.Collections;

namespace LZW;
public class LZW
{
    public static void Compress(byte[] arrayOfBites, string fileNameForCompress)
    {
        var newTrie = new Trie.Trie();
        for (int i = 0; i < 256; ++i)
        {
            (bool isInTrie, int number) = newTrie.AddWithPointer((char)i);
        }

        FileInfo newFile = new(fileNameForCompress + ".zipped");
        FileStream compressedFile = newFile.Create();
        BitArray temporaryBitArray = new(64);
        int temporaryBitArrayIndex = 0;
        int counterOfBitesArray = 0;
        int currentBitSize = 9;
        while (counterOfBitesArray < arrayOfBites.Length)
        {
            (bool isInTrie, int numberOfSymbol) = (true, -1);
            int previousNumberOfSymbol = -1;

            while (isInTrie && counterOfBitesArray < arrayOfBites.Length)
            {
                previousNumberOfSymbol = numberOfSymbol;
                (isInTrie, numberOfSymbol) = newTrie.AddWithPointer((char)arrayOfBites[counterOfBitesArray]);
                ++counterOfBitesArray;
            }

            counterOfBitesArray -= isInTrie && counterOfBitesArray == arrayOfBites.Length ? 0 : 1;

            if (isInTrie && counterOfBitesArray == arrayOfBites.Length)
            {
                previousNumberOfSymbol = numberOfSymbol;
            }

            int countOfNotNulls = 0;
            while (previousNumberOfSymbol > 0)
            {
                int digit = previousNumberOfSymbol % 2;
                temporaryBitArray[temporaryBitArrayIndex] = (digit == 0) ? false : true;
                previousNumberOfSymbol /= 2;
                ++temporaryBitArrayIndex;
                ++countOfNotNulls;
            }

            for (int i = 0; i < currentBitSize - countOfNotNulls; ++i)
            {
                temporaryBitArray[temporaryBitArrayIndex] = false;
                ++temporaryBitArrayIndex;
            }

            if (counterOfBitesArray == arrayOfBites.Length)
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
                int multiplier = 1;
                for (int i = 0; i < 8; ++i)
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

    public static bool Decompress(byte[] arrayOfBites, string fileNameForDecompressing)
    {
        var dictionary = new Dictionary<int, string>();
        for (int i = 0; i < 256; ++i)
        {
            dictionary.Add(i, char.ToString((char)i));
        }

        FileInfo newFile = new(fileNameForDecompressing.Remove(fileNameForDecompressing.Length - 7));
        FileStream decompressedFile = newFile.Create();
        BitArray arrayOfCompressedFileBits = new BitArray(arrayOfBites);
        int arrayOfCompressedFileBitsIndex = 0;
        int currentBitSize = 9;
        string? previousValue = null;
        int currentNumber = 256;
        while (arrayOfCompressedFileBitsIndex < arrayOfCompressedFileBits.Length)
        {
            int multiplier = 1;
            int newNumber = 0;
            for (int i = 0; i < currentBitSize; ++i)
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

            var dictionaryValue = dictionary.ContainsKey(newNumber) ? dictionary[newNumber] : previousValue + previousValue[0];
            for (int i = 0; i < dictionaryValue.Length; ++i)
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
        byte[] arrayOfBytes
            = File.ReadAllBytes("..\\..\\..\\attribcache140.bin");
        Compress(arrayOfBytes, "..\\..\\..\\attribcache140.bin");
        byte[] arrayOfBytes1
            = File.ReadAllBytes("..\\..\\..\\attribcache140.bin.zipped");
        bool m = Decompress(arrayOfBytes1, "..\\..\\..\\attribcache140.bin.zipped");
    }
}