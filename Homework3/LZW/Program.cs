namespace LZW;
using System;
using System.Collections;
using System.IO;
public class LZW
{
    public static bool Zip(BitArray bitsFromFile, string fileNameForZipping)
    {
        FileInfo newFile = new(fileNameForZipping + ".zipped");
        FileStream zippedFile = newFile.Create();
        return true;
    }

    private static void Main(string[] args)
    {
        byte[] arrayOfBytes
            = File.ReadAllBytes("..\\..\\..\\ExampleDocument.txt");
        BitArray bitsFromFile = new BitArray(arrayOfBytes);
        BitArray zippedBits = new BitArray(64);
        bool result = LZW.Zip(bitsFromFile, "..\\..\\..\\hahaha.txt");
    }
}