using NUnit.Framework;
using UniqueListTests;

namespace UniqueListTests
{
    public class StandartListTests
    {
        [SetUp]
        public void Setup()
        {
        }

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
        public void AddingWithBigOrLittlePosition()
        {
            UniqueList.List<int> list = new();
            list.AddByPosition(18, -5);
            list.AddByPosition(20, 100);
            list.AddByPosition(30, 200);
            list.AddByPosition(400, -4);
            Assert.IsTrue(list.Size == 4
                && list.GetElementFromHead() == 400 && list.GetElementFromTail() == 30);
        }
    }
}