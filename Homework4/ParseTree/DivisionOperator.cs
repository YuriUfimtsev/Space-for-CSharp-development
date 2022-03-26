namespace ParseTree;

/// <summary>
/// Class for "/" operator.
/// </summary>
public class DivisionOperator : Operator
{
    public override int Eval()
    {
        if (this.LeftChild == null || this.RightChild == null)
        {
            throw new ArgumentException();
        }

        var righChildNumber = this.RightChild.Eval();
        return righChildNumber == 0 ? throw new ArgumentException("Division by 0")
            : this.LeftChild.Eval() / this.RightChild.Eval();
    }

    public override void Print()
    {
        if (this.LeftChild == null || this.RightChild == null)
        {
            throw new InvalidOperationException();
        }

        Console.Write("( ");
        this.LeftChild.Print();
        Console.Write("/ ");
        this.RightChild.Print();
        Console.Write(") ");
    }
}