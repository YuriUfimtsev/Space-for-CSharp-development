using UniqueListTests;
namespace UniqueListTests;

using NUnit.Framework;
using System;
using UniqueList;

public class StandartListTests
{
    [Test]
    public void AddingByPositionInEmptyListTest()
    {
        UniqueList.List<int> list = new();
        list.AddByPosition(18, 0);
        list.AddByPosition(20, 1);
        list.AddByPosition(30, 2);
        Assert.AreEqual(3, list.Size);
        Assert.AreEqual(18, list.GetElementFromHead());
        Assert.AreEqual(30, list.GetElementFromTail());
    }

    [Test]
    public void AddingInListHeadTest()
    {
        UniqueList.List<int> list = new();
        list.AddByPosition(18, 0);
        list.AddByPosition(20, 1);
        list.AddByPosition(30, 0);
        list.AddByPosition(400, 0);
        Assert.AreEqual(4, list.Size);
        Assert.AreEqual(400, list.GetElementFromHead());
        Assert.AreEqual(20, list.GetElementFromTail());
    }

    [Test]
    public void AddingWithBigOrLittlePositionTest()
    {
        UniqueList.List<int> list = new();
        list.AddByPosition(18, -5);
        list.AddByPosition(20, 100);
        list.AddByPosition(30, 200);
        list.AddByPosition(400, -4);
        Assert.AreEqual(4, list.Size);
        Assert.AreEqual(400, list.GetElementFromHead());
        Assert.AreEqual(30, list.GetElementFromTail());
    }

    [Test]
    public void RemoveFromNotEmptyListTest()
    {
        UniqueList.List<int> list = new();
        list.AddByPosition(18, -5);
        list.AddByPosition(20, 100);
        list.AddByPosition(30, 200);
        list.RemoveByPosition(0);
        list.RemoveByPosition(1);
        Assert.AreEqual(1, list.Size);
        Assert.AreEqual(20, list.GetElementFromHead());
        Assert.AreEqual(20, list.GetElementFromTail());
    }

    [Test]
    public void RemoveFromStandartExistingPositionTest()
    {
        UniqueList.List<int> list = new();
        list.AddByPosition(18, -5);
        list.AddByPosition(20, 100);
        list.AddByPosition(30, 200);
        list.RemoveByPosition(1);
        Assert.AreEqual(2, list.Size);
        Assert.AreEqual(18, list.GetElementFromHead());
        Assert.AreEqual(30, list.GetElementFromTail());
    }

    [Test]
    public void ChangeValuesByDifferentPositionsTest()
    {
        UniqueList.List<int> list = new();
        list.AddByPosition(18, -5);
        list.AddByPosition(20, 100);
        list.AddByPosition(30, 200);
        list.ChangeByPosition(0, 70);
        list.ChangeByPosition(-5, 80);
        list.ChangeByPosition(1, 2);
        list.ChangeByPosition(2, 0);
        Assert.AreEqual(3, list.Size);
        Assert.AreEqual(80, list.GetElementFromHead());
        Assert.AreEqual(0, list.GetElementFromTail());
    }

    [Test]
    public void RemoveFromEmptyListTest()
    {
        List<int> list = new();
        Assert.Throws<InvalidOperationException>(() => list.RemoveByPosition(0));
    }
}