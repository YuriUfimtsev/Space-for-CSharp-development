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

    /// <summary>
    /// Method prints the node's content to console.
    /// </summary>
    public void Print()
        => Console.Write($"{this.number} ");

    /// <summary>
    /// Method calculates the node's value.
    /// </summary>
    /// <returns>result of calculation.</returns>
    public int Eval()
        => this.number;
}