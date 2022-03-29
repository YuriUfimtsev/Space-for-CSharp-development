using NUnit.Framework;
using UniqueListTests;
using System;
using UniqueList;

namespace UniqueListTests;
public class StandartListTests
{
    [Test]
    public void AddingByPositionInEmptyListTest()
    {
        UniqueList.List<int> list = new();
        list.AddByPosition(18, 0);
        list.AddByPosition(20, 1);
        list.AddByPosition(30, 2);
        Assert.IsTrue(list.Size == 3
            && list.GetElementFromHead() == 18 && list.GetElementFromTail() == 30);
    }

    [Test]
    public void AddingInListHeadTest()
    {
        UniqueList.List<int> list = new();
        list.AddByPosition(18, 0);
        list.AddByPosition(20, 1);
        list.AddByPosition(30, 0);
        list.AddByPosition(400, 0);
        Assert.IsTrue(list.Size == 4
            && list.GetElementFromHead() == 400 && list.GetElementFromTail() == 20);
    }

    [Test]
    public void AddingWithBigOrLittlePositionTest()
    {
        UniqueList.List<int> list = new();
        list.AddByPosition(18, -5);
        list.AddByPosition(20, 100);
        list.AddByPosition(30, 200);
        list.AddByPosition(400, -4);
        Assert.IsTrue(list.Size == 4
            && list.GetElementFromHead() == 400 && list.GetElementFromTail() == 30);
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
        Assert.IsTrue(list.GetElementFromHead() == 20
            && list.Size == 1 && list.GetElementFromTail() == 20);
    }

    [Test]
    public void RemoveFromStandartExistingPositionTest()
    {
        UniqueList.List<int> list = new();
        list.AddByPosition(18, -5);
        list.AddByPosition(20, 100);
        list.AddByPosition(30, 200);
        list.RemoveByPosition(1);
        Assert.IsTrue(list.Size == 2 && list.GetElementFromHead() == 18
            && list.GetElementFromTail() == 30);
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
        Assert.IsTrue(list.Size == 3 && list.GetElementFromHead() == 80
            && list.GetElementFromTail() == 0);
    }

    [Test]
    public void RemoveFromEmptyListTest()
    {
        List<int> list = new();
        Assert.Throws<IncorrectOperationException>(() => list.RemoveByPosition(0));
    }
}