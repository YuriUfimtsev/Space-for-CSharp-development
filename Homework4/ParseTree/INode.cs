namespace ParseTree;

/// <summary>
/// Interface for tree's nodes.
/// </summary>
public interface INode
{
    /// <summary>
    /// Method calculates the node's value.
    /// </summary>
    /// <returns>result of calculation.</returns>
    public int Eval();

    /// <summary>
    /// Method prints the node's content to console.
    /// </summary>
    public void Print();
}
