﻿namespace PriorityQueue;

/// <summary>
/// Implements priority queue.
/// </summary>
/// <typeparam name="T">type for queue item values.</typeparam>
public class PriorityQueue<T>
{
    private PriorityQueueItem<T>? head;
    private PriorityQueueItem<T>? tail;

    /// <summary>
    /// Gets a value indicating whether the queue is empty.
    /// </summary>
    public bool Empty
    {
        get { return this.head == null; }
    }

    /// <summary>
    /// Adds new element in the priority queue.
    /// </summary>
    /// <param name="priority">element priority value.</param>
    /// <param name="value">element value.</param>
    public void Enqueue(int priority, T value)
    {
        PriorityQueueItem<T> priorityQueueItem = new(priority, value);
        if (this.head == null)
        {
            this.head = priorityQueueItem;
            this.tail = priorityQueueItem;
            return;
        }

        PriorityQueueItem<T> currentItem = this.head;

        if (currentItem.NextItem == null || currentItem.Priority < priorityQueueItem.Priority)
        {
            if (currentItem.Priority < priorityQueueItem.Priority)
            {
                this.head = priorityQueueItem;
                priorityQueueItem.NextItem = currentItem;
                return;
            }

            currentItem.NextItem = priorityQueueItem;
            return;
        }

        while (currentItem.NextItem != null && currentItem.NextItem!.Priority >= priority)
        {
            currentItem = currentItem.NextItem;
        }

        if (currentItem.NextItem == null)
        {
            this.tail = priorityQueueItem;
        }

        (currentItem.NextItem, priorityQueueItem.NextItem) = (priorityQueueItem, currentItem.NextItem);
    }

    /// <summary>
    /// Кemoves the element with the highest priority from the priority queue.
    /// </summary>
    /// <returns>The value of the removed element.</returns>
    /// <exception cref="InvalidOperationException">throws if the queue is empty.</exception>
    public T Dequeue()
    {
        if (this.head == null)
        {
            throw new InvalidOperationException();
        }

        T item = this.head.Value;
        if (this.head == this.tail)
        {
            this.tail = null;
        }

        this.head = this.head.NextItem;
        return item;
    }

    private class PriorityQueueItem<T>
    {
        public PriorityQueueItem(int priority, T value)
        {
            this.Priority = priority;
            this.Value = value;
            this.NextItem = null;
        }

        public int Priority { get; private set; }

        public T Value { get; private set; }

        public PriorityQueueItem<T>? NextItem { get; set; }
    }
}
