namespace StackCalculator;
internal interface IStack
{
    int GetSize { get; }

    void Push(float value);

    (float ReturningValue, bool IsStackNotEmpty) Pop();

    (float ReturningValue, bool IsStackNotEmpty) Top();

    bool IsEmpty();
}
