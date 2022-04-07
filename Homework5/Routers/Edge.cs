namespace Routers;

/// <summary>
/// Realizes the "edge" model.
/// </summary>
internal class Edge
{
    private int value;
    private int firstNode;
    private int secondNode;

    /// <summary>
    /// Gets or sets edge's value.
    /// </summary>
    public int Value
    {
        get { return this.value; } set { this.value = value; }
    }

    /// <summary>
    /// Gets or sets number of first adjacent node.
    /// </summary>
    public int FirstNode
    {
        get { return this.firstNode; } set { this.firstNode = value; }
    }

    /// <summary>
    /// Gets or sets number of second adjacent node.
    /// </summary>
    public int SecondNode
    {
        get { return this.secondNode; } set { this.secondNode = value; }
    }
}
