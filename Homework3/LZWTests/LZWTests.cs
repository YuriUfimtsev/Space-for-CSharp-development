using NUnit.Framework;
using System.IO;
using LZW;
using System.Collections.Generic;

namespace LZWTests;

[TestFixture]
public class LZWTests
{
    [Test]
    public void CompressAndDecompressTXTFile()
    {
        var fileToCompress = "..//..//..//TestTXTFile.txt";
        var fileToCompareWithResult = ("..//..//..//TestTXTFileBase.txt");
        LZW.LZW.Compress(fileToCompress);
        if (File.ReadAllBytes(fileToCompress + ".zipped").Length == File.ReadAllBytes(fileToCompress).Length)
        {
            Assert.Fail();
        }

        bool isDecompressCorrect = LZW.LZW.Decompress(fileToCompress + ".zipped");
        var bytesOfBaseFile = File.ReadAllBytes(fileToCompareWithResult);
        var bytesOfDecompressedFile = File.ReadAllBytes(fileToCompress);
        if (!isDecompressCorrect || bytesOfDecompressedFile.Length != bytesOfBaseFile.Length)
        {
            Assert.Fail();
        }

        for (var i = 0; i < bytesOfBaseFile.Length; ++i)
        {
            if (bytesOfBaseFile[i] != bytesOfDecompressedFile[i])
            {
                Assert.Fail();
            }
        }

        Assert.Pass();
    }

    [Test]
    public void CompressAndDecompressBINFile()
    {
        var fileToCompress = "..//..//..//TestFile.bin";
        var fileToCompareWithResult = ("..//..//..//TestFileBase.bin");
        LZW.LZW.Compress(fileToCompress);
        if (File.ReadAllBytes(fileToCompress + ".zipped").Length == File.ReadAllBytes(fileToCompress).Length)
        {
            Assert.Fail();
        }

        bool isDecompressCorrect = LZW.LZW.Decompress(fileToCompress + ".zipped");
        var bytesOfBaseFile = File.ReadAllBytes(fileToCompareWithResult);
        var bytesOfDecompressedFile = File.ReadAllBytes(fileToCompress);
        if (!isDecompressCorrect || bytesOfDecompressedFile.Length != bytesOfBaseFile.Length)
        {
            Assert.Fail();
        }

        for (var i = 0; i < bytesOfBaseFile.Length; ++i)
        {
            if (bytesOfBaseFile[i] != bytesOfDecompressedFile[i])
            {
                Assert.Fail();
            }
        }

        Assert.Pass();
    }
}