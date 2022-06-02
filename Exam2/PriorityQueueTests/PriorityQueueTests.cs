using NUnit.Framework;
using PriorityQueue;

namespace PriorityQueueTests;

public class PriorityQueueTests
{

    [Test]
    public void IntEnqueueAndDequeueStandartTest()
    {
        PriorityQueue<int> priorityQueue = new();
        priorityQueue.Enqueue(1, 5);
        priorityQueue.Enqueue(2, 6);
        priorityQueue.Enqueue(3, 7);
        Assert.AreEqual(priorityQueue.Dequeue(), 7);
        Assert.AreEqual(priorityQueue.Dequeue(), 6);
        Assert.AreEqual(priorityQueue.Dequeue(), 5);
    }


    [Test]
    public void IntEnqueueAndDequeueWithEqualsPriorityTest()
    {
        PriorityQueue<int> priorityQueue = new();
        priorityQueue.Enqueue(1, 5);
        priorityQueue.Enqueue(1, 6);
        priorityQueue.Enqueue(1, 7);
        Assert.AreEqual(priorityQueue.Dequeue(), 5);
        Assert.AreEqual(priorityQueue.Dequeue(), 6);
        Assert.AreEqual(priorityQueue.Dequeue(), 7);
    }
    [Test]
    public void StringEnqueueAndDequeueStandartTest()
    {
        PriorityQueue<string> priorityQueue = new();
        priorityQueue.Enqueue(1, "a");
        priorityQueue.Enqueue(2, "bc");
        priorityQueue.Enqueue(3, "dd");
        Assert.AreEqual(priorityQueue.Dequeue(), "dd");
        Assert.AreEqual(priorityQueue.Dequeue(), "bc");
        Assert.AreEqual(priorityQueue.Dequeue(), "a");
    }


    [Test]
    public void StringEnqueueAndDequeueWithEqualsPriorityTest()
    {
        PriorityQueue<string> priorityQueue = new();
        priorityQueue.Enqueue(1, "a");
        priorityQueue.Enqueue(1, "bc");
        priorityQueue.Enqueue(1, "dd");
        Assert.AreEqual(priorityQueue.Dequeue(), "a");
        Assert.AreEqual(priorityQueue.Dequeue(), "bc");
        Assert.AreEqual(priorityQueue.Dequeue(), "dd");
    }

    [Test]
    public void QueueEmptyTest()
    {
        PriorityQueue<string> priorityQueue = new();
        Assert.IsTrue(priorityQueue.Empty);
        priorityQueue.Enqueue(1, "bc");
        Assert.IsFalse(priorityQueue.Empty);
        priorityQueue.Dequeue();
        Assert.IsTrue(priorityQueue.Empty);
    }

    [Test]
    public void DequeueFromEmptyQueueTest()
    {
        PriorityQueue<int> priorityQueue = new();
        Assert.Throws<System.InvalidOperationException>(() => priorityQueue.Dequeue());
    }
}