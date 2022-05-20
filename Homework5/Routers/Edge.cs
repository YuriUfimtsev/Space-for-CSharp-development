namespace Routers;

/// <summary>
/// Realizes the "edge" model.
/// </summary>
internal class Edge
{
    /// <summary>
    /// Gets or sets edge's value.
    /// </summary>
    public int Value { get; set; }

    /// <summary>
    /// Gets or sets number of first adjacent node.
    /// </summary>
    public int FirstNode { get; set; }

    /// <summary>
    /// Gets or sets number of second adjacent node.
    /// </summary>
    public int SecondNode { get; set; }
}
