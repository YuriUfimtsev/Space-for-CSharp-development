namespace LZW;
using System;
using System.Collections;
public class LZW
{
    private static void Main(string[] args)
    {
        byte[] arrayOfBytes
            = File.ReadAllBytes(@"C:\Users\Home\source\repos\Space-for-CSharp-development\Homework3\ExampleDocument.txt");
        BitArray bits = new BitArray(arrayOfBytes.Length * 8);
    }
}