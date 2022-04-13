using NUnit.Framework;
using System.Collections.Generic;
using MapFilterFold;

namespace MapFilterFoldTests;

public class MapFilterFoldTests
{
    private readonly List<string> stringList = new(){ "a", "b", "c", "aa", "ab" };
    private readonly List<int> intList = new(){ 1, 2, 3, 4, 5, 6 };

    [Test]
    public void StandartMapTest()
    {
        var resultIntList = MapFilterFoldFunctions<int>.Map(intList, x => x * 2);
        Assert.AreEqual(resultIntList, new List<int> { 2, 4, 6, 8, 10, 12 });
        var resultStringList = MapFilterFoldFunctions<string>.Map(stringList, x => x += "k");
        Assert.AreEqual(resultStringList, new List<string> { "ak", "bk", "ck", "aak", "abk" });
    }

    [Test]
    public void StandartFilterTest()
    {
        var resultIntList = MapFilterFoldFunctions<int>.Filter(intList, x => x % 2 == 0);
        Assert.AreEqual(resultIntList, new List<int> { 2, 4, 6 });
        var resultStringList = MapFilterFoldFunctions<string>.Filter(stringList, x => string.Equals(x, "a"));
        Assert.AreEqual(resultStringList, new List<string> { "a" });
    }

    [Test]
    public void StandartFoldTest()
    {
        var resultValue = 0;
        var resultString = string.Empty;
        resultValue = MapFilterFoldFunctions<int>.Fold(intList, 1, (acc, elem) => acc * elem);
        Assert.AreEqual(resultValue, 720);
        resultString = MapFilterFoldFunctions<string>.Fold(stringList, resultString, (acc, elem) => acc += elem);
        Assert.AreEqual(resultString, "abcaaab");
    }
}