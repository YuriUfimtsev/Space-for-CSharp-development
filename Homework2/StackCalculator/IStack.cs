using System;

namespace StackCalculator;
internal interface IStack
{
    void Push(float value);

    (float returningValue, bool isStackNotEmpty) Pop();

    (float returningValue, bool isStackNotEmpty) Top();

    int GetSize { get; }

    bool IsEmpty();
}
