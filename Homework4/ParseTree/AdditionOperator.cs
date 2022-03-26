namespace ParseTree;

/// <summary>
/// Class for "+" operator.
/// </summary>
public class AdditionOperator : Operator
{
    public override int Eval()
    {
        if (this.LeftChild == null || this.RightChild == null)
        {
            throw new ArgumentException();
        }

        return this.LeftChild.Eval() + this.RightChild.Eval();
    }

    public override void Print()
    {
        if (this.LeftChild == null || this.RightChild == null)
        {
            throw new InvalidOperationException();
        }

        Console.Write("( ");
        this.LeftChild.Print();
        Console.Write("+ ");
        this.RightChild.Print();
        Console.Write(") ");
    }
}