using NUnit.Framework;
using System.Collections.Generic;
using BubbleSort;
using System;

namespace BubbleSortTests;
public class BubbleSortTests
{

    [Test]
    public void StandartIntObjectsTest()
    {
        List<int> intObjectsList = new() { 1, 3, 8, 8, 99, 97, 96, 95 };
        var intComparer = new ObjectComparer<int>((firstNumber, secondNumber) => firstNumber - secondNumber);
        var sortedList = BubbleSort<int>.Sort(intObjectsList, intComparer);
        List<int> resultList = new() { 1, 3, 8, 8, 95, 96, 97, 99 };
        Assert.AreEqual(sortedList, resultList);
    }

    [Test]
    public void StandartStringObjectsTest()
    {
        List<string> intObjectsList = new() { "ab", "abc", "dd", "bcb" };
        var stringComparer = new ObjectComparer<string>((firstNumber, secondNumber) => string.Compare(firstNumber, secondNumber));
        var sortedList = BubbleSort<string>.Sort(intObjectsList, stringComparer);
        List<string> resultList = new() { "ab", "abc", "bcb", "dd" };
        Assert.AreEqual(sortedList, resultList);
    }
}