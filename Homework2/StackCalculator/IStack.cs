using System;

namespace StackCalculator;
internal interface IStack
{
    void Push(int value);

    (int returningValue, bool isStackEmpty) Pop();

    (int returningValue, bool isStackEmpty) Top();

    int GetSize { get; }

    bool IsEmpty();
}
