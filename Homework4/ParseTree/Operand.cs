namespace ParseTree;

/// <summary>
/// Class for operands.
/// </summary>
public class Operand : INode
{
    private int number;

    /// <summary>
    /// Gets or sets operand's value.
    /// </summary>
    public int Number
    {
        get { return this.number; } set { this.number = value; }
    }

    public void Print()
        => Console.Write($"{this.number} ");

    public int Eval()
        => this.number;
}