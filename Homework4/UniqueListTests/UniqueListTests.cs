using NUnit.Framework;
using UniqueListTests;
using System;
using UniqueList;

namespace UniqueListTests;
public class UniqueListTests
{
    [Test]
    public void AddsTwoEqualsElementsTest()
    {
        UniqueList<string> uniqueList = new();
        uniqueList.AddByPosition("ha", 0);
        Assert.Throws<InvalidOperationException>(() => uniqueList.AddByPosition("ha", 2));
    }

    [Test]

    public void StandartAddsThreeElementsWithEqualsPositionsTest()
    {
        UniqueList<int> uniqueList = new();
        uniqueList.AddByPosition(1, 0);
        uniqueList.AddByPosition(3, 0);
        uniqueList.AddByPosition(4, 0);
        Assert.AreEqual(3, uniqueList.Size);
        Assert.AreEqual(4, uniqueList.GetElementFromHead());
        Assert.AreEqual(1, uniqueList.GetElementFromTail());
    }

    [Test]

    public void AddsFourDifferentElementsAndChangesOnesValueToTheExistsValueTest()
    {
        UniqueList<int> uniqueList = new();
        uniqueList.AddByPosition(1, 0);
        uniqueList.AddByPosition(3, 1);
        uniqueList.AddByPosition(4, -5);
        Assert.Throws<InvalidOperationException>(() => uniqueList.ChangeByPosition(0, 3));
    }

    [Test]

    public void RemovesElementFromEmptyUniqueListTest()
    {
        UniqueList<int> uniqueList = new();
        Assert.Throws<InvalidOperationException>(() => uniqueList.RemoveByPosition(0));
    }

    [Test]
    public void AddsAndRemovesListTest()
    {
        UniqueList<int> uniqueList = new();
        uniqueList.AddByPosition(5, 0);
        uniqueList.AddByPosition(-5, 1);
        uniqueList.AddByPosition(8, 2);
        int momentSize = uniqueList.Size;
        uniqueList.RemoveByPosition(2);
        uniqueList.RemoveByPosition(1);
        uniqueList.RemoveByPosition(0);
        Assert.AreEqual(3, momentSize);
        Assert.AreEqual(0, uniqueList.Size);
    }
}
