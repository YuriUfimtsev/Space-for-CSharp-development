namespace SparseVector;

/// <summary>
/// Realizes SparseVector and its methods.
/// </summary>
public class SparseVector
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SparseVector"/> class.
    /// </summary>
    /// <param name="length">length of current SparseVector.</param>
    /// <param name="coordinates">coordinates for current SparseVector.</param>
    public SparseVector(int length, Dictionary<int, int> coordinates)
    {
        this.Coordinates = new Dictionary<int, int>(coordinates);
        this.Length = length;
    }

    /// <summary>
    /// Gets SparseVector coordinates.
    /// </summary>
    public Dictionary<int, int> Coordinates { get; }

    /// <summary>
    /// Gets SparseVector length.
    /// </summary>
    public int Length { get; }

    /// <summary>
    /// Adds second SparseVector to this SparseVector.
    /// </summary>
    /// <param name="secondVector">vector to add.</param>
    /// <exception cref="VectorLengthMismatchException">throws this exception if the length of the second vector
    /// doesn't match the length of the current vector.</exception>
    public void Add(SparseVector secondVector)
    {
        if (secondVector.Length != this.Length)
        {
            throw new VectorLengthMismatchException();
        }

        foreach (var i in secondVector.Coordinates.Keys)
        {
            if (this.Coordinates.ContainsKey(i))
            {
                this.Coordinates[i] += secondVector.Coordinates[i];
            }
            else
            {
                this.Coordinates.Add(i, secondVector.Coordinates[i]);
            }
        }
    }

    /// <summary>
    /// Subtracts from this vector the second.
    /// </summary>
    /// <param name="secondVector">vector to substract.</param>
    /// <exception cref="VectorLengthMismatchException">throws this exception if the length of the second vector
    /// doesn't match the length of the current vector.</exception>
    public void Substract(SparseVector secondVector)
    {
        if (secondVector.Length != this.Length)
        {
            throw new VectorLengthMismatchException();
        }

        foreach (var i in secondVector.Coordinates.Keys)
        {
            if (this.Coordinates.ContainsKey(i))
            {
                this.Coordinates[i] -= secondVector.Coordinates[i];
            }
            else
            {
                this.Coordinates.Add(i, -secondVector.Coordinates[i]);
            }

            if (this.Coordinates[i] == 0)
            {
                this.Coordinates.Remove(i);
            }
        }
    }

    /// <summary>
    /// Сhecks whether the vector is null.
    /// </summary>
    /// <returns>true if vector is null. else false.</returns>
    public bool IsNullVector()
    {
        return this.Coordinates.Count == 0;
    }

    /// <summary>
    /// Ьultiplies the current vector by the given one.
    /// </summary>
    /// <param name="secondVector">vector to multiply.</param>
    /// <returns>result of the scalar multiplication.</returns>
    /// <exception cref="VectorLengthMismatchException">throws this exception if the length of the second vector
    /// doesn't match the length of the current vector.</exception>
    public int ScalarMultiply(SparseVector secondVector)
    {
        if (secondVector.Length != this.Length)
        {
            throw new VectorLengthMismatchException();
        }

        var result = 0;
        foreach (var i in this.Coordinates.Keys)
        {
            if (secondVector.Coordinates.ContainsKey(i))
            {
                result += secondVector.Coordinates[i] * this.Coordinates[i];
            }
        }

        return result;
    }
}
