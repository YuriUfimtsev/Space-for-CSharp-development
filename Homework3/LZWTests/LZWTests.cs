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

    //[Test]
    //public void BWTTransformTheFileAndCompressAndDecompress()
    //{
    //    (var str, var i) = BurrowsWheelerTransform.BurrowsWheelerTransform.DirectBWT("fxhdfhdjdtyfhgfj uykf gh hg   hgfhf hgf ghf ghfghfkuytyuktyutukfjthfjthfdrsxthe658658768968");
    //    var pop = BurrowsWheelerTransform.BurrowsWheelerTransform.ReverseBWT(str, i);
    //    var fileToCompress = "..//..//..//TestFile.bin";
    //    var fileToCompareWithResult = ("..//..//..//TestFileBase.bin");
    //    var (resultString, endStringPosition)
    //        = BurrowsWheelerTransform.BurrowsWheelerTransform.DirectBWT(File.ReadAllText(fileToCompress));
    //    string OOObasedStringFromFile = BurrowsWheelerTransform.BurrowsWheelerTransform.ReverseBWT
    //(resultString, endStringPosition);
    //    var extension = Path.GetExtension(fileToCompress);
    //    FileInfo fileWithBWTResult = new(fileToCompress.Remove(fileToCompress.Length - extension.Length) + "BWT" + extension);
    //    File.WriteAllText(fileWithBWTResult.FullName, resultString);
    //    LZW.LZW.Compress(fileWithBWTResult.FullName);
    //    if (File.ReadAllBytes(fileWithBWTResult + ".zipped").Length == File.ReadAllBytes(fileToCompress).Length)
    //    {
    //        Assert.Fail();
    //    }

    //    bool isDecompressCorrect = LZW.LZW.Decompress(fileWithBWTResult + ".zipped");
    //    string basedStringFromFile = BurrowsWheelerTransform.BurrowsWheelerTransform.ReverseBWT
    //        (File.ReadAllText(fileWithBWTResult.FullName), endStringPosition);
    //    Assert.IsTrue(isDecompressCorrect && Equals(basedStringFromFile, File.ReadAllText(fileToCompareWithResult)));
    //}
}