using System.Collections;

namespace LZW;
public class LZW
{
    public static bool Zip(byte[] arrayOfBites, string fileNameForZipping)
    {
        var newTrie = new Trie.Trie();
        for (int i = 0; i < 256; ++i)
        {
            newTrie.Add(i.ToString());
        }

        FileInfo newFile = new(fileNameForZipping + ".zipped");
        FileStream zippedFile = newFile.Create();
        BitArray temporaryBitArray = new(64);
        int temporaryBitArrayIndex = 0;
        int counterOfBitesArray = 0;
        while (counterOfBitesArray < arrayOfBites.Length)
        {
            (bool isInTrie, int numberOfSymbol) = (true, -1);
            int previousNumberOfSymbol = -1; ;
            while (isInTrie)
            {
                previousNumberOfSymbol = numberOfSymbol;
                (isInTrie, numberOfSymbol) = newTrie.AddWithPointer((char)arrayOfBites[counterOfBitesArray]);
                ++counterOfBitesArray;
            }

            --counterOfBitesArray;
            while (previousNumberOfSymbol > 0)
            {
                int digit = previousNumberOfSymbol % 2;
                temporaryBitArray[temporaryBitArrayIndex] = (digit == 0) ? false : true;
                previousNumberOfSymbol /= 2;
                ++temporaryBitArrayIndex;
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
                zippedFile.WriteByte(newByte);
            }
        }

        return true;
    }

    private static void Main(string[] args)
    {
        byte[] arrayOfBytes
            = File.ReadAllBytes("..\\..\\..\\ExampleDocument.txt");
        bool result = LZW.Zip(arrayOfBytes, "..\\..\\..\\hahaha.txt");
    }
}