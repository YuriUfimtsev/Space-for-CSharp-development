namespace ParseTree;

/// <summary>
/// Abstract class for operators.
/// </summary>
public abstract class Operator : INode
{
    private INode? rightChild;
    private INode? leftChild;
    private char nodeOperator;

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

    public abstract void Print();

    public abstract int Eval();
}