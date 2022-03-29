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
        Assert.Throws<IncorrectOperationException>(() => uniqueList.AddByPosition("ha", 2));
    }

    [Test]

    public void StandartAddsThreeElementsWithEqualsPositionsTest()
    {
        UniqueList<int> uniqueList = new();
        uniqueList.AddByPosition(1, 0);
        uniqueList.AddByPosition(3, 0);
        uniqueList.AddByPosition(4, 0);
        Assert.IsTrue(uniqueList.GetElementFromHead() == 4
            && uniqueList.Size == 3 && uniqueList.GetElementFromTail() == 1);
    }

    [Test]

    public void AddsFourDifferentElementsAndChangesOnesValueToTheExistsValueTest()
    {
        UniqueList<int> uniqueList = new();
        uniqueList.AddByPosition(1, 0);
        uniqueList.AddByPosition(3, 1);
        uniqueList.AddByPosition(4, -5);
        Assert.Throws<IncorrectOperationException>(() => uniqueList.ChangeByPosition(0, 3));
    }

    [Test]

    public void RemovesElementFromEmptyUniqueListTest()
    {
        UniqueList<int> uniqueList = new();
        Assert.Throws<IncorrectOperationException>(() => uniqueList.RemoveByPosition(0));
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
        Assert.IsTrue(momentSize == 3 && uniqueList.Size == 0);
    }
}
