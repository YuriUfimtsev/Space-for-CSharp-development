using System;

namespace StackCalculator;
internal interface IStack
{
    void Push(float value);

    (float returningValue, bool isStackEmpty) Pop();

    (float returningValue, bool isStackEmpty) Top();

    int GetSize { get; }

    bool IsEmpty();
}
