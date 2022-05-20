namespace ParseTree;

/// <summary>
/// Abstract class for operators.
/// </summary>
public abstract class Operator : INode
{
    private INode? rightChild;
    private INode? leftChild;

    /// <summary>
    /// Gets or sets the RightChild for node.
    /// </summary>
    public INode? RightChild
    {
        get { return this.rightChild; } set { this.rightChild = value; }
    }

    /// <summary>
    /// Gets or sets the LeftChild for node.
    /// </summary>
    public INode? LeftChild
    {
        get { return this.leftChild; } set { this.leftChild = value; }
    }

    /// <summary>
    /// Method prints the node's content to console.
    /// </summary>
    public abstract void Print();

    /// <summary>
    /// Method calculates the node's value.
    /// </summary>
    /// <returns>result of calculation.</returns>
    public abstract int Eval();
}