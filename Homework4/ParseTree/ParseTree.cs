namespace ParseTree;

/// <summary>
/// Class for creation ParseTree.
/// </summary>
public class ParseTree
{
    /// <summary>
    /// Method creates new node of Parsee tree.
    /// </summary>
    /// <param name="stringOfNumbersAndOperators">sequence for parse tree.</param>
    /// <param name="index">start sequence index.</param>
    /// <returns>Parse tree's root.</returns>
    public INode? CreateNewNodeForParseTree(string stringOfNumbersAndOperators, ref int index)
    {
    ++index;
    INode? node = null;
    while (index < stringOfNumbersAndOperators.Length && this.IsBracketOrSpace(stringOfNumbersAndOperators[index]))
    {
        ++index;
    }

    if (this.IsOperator(stringOfNumbersAndOperators[index]) && stringOfNumbersAndOperators[index + 1] == ' ')
    {
        node = this.Parse(stringOfNumbersAndOperators, ref index, true);
        (node as Operator)!.LeftChild = this.CreateNewNodeForParseTree(stringOfNumbersAndOperators, ref index);
        (node as Operator)!.RightChild = this.CreateNewNodeForParseTree(stringOfNumbersAndOperators, ref index);
    }
    else if (this.IsDigit(stringOfNumbersAndOperators[index]) || stringOfNumbersAndOperators[index] == '-')
    {
        node = this.Parse(stringOfNumbersAndOperators, ref index, false);
    }

    return node;
}

    /// <summary>
    /// Method gets the next element from sequence.
    /// </summary>
    /// <param name="stringOfNumbersAndOperators">string with numbers and operators.</param>
    /// <param name="index">start string's index for parsing.</param>
    /// <param name="isOperator">shows what type has the next string element.</param>
    /// <returns>Operator or Operand object.</returns>
    /// <exception cref="NotImplementedException">if Parse doesn't find Operator or Operand.</exception>
    public INode? Parse(string stringOfNumbersAndOperators, ref int index, bool isOperator)
    {
        if (!isOperator)
        {
            var (resultNumber, newIndex) = this.GetNumberFromSequence(stringOfNumbersAndOperators, index);
            Operand operand = new();
            operand.Number = resultNumber;
            index = newIndex;
            return operand;
        }
        else
        {
            ++index;
            return stringOfNumbersAndOperators[index - 1] switch
            {
                '+' => new AdditionOperator(),
                '-' => new SubstractionOperator(),
                '/' => new DivisionOperator(),
                '*' => new MultiplicationOperator(),
                _ => throw new NotImplementedException(),
            };
        }
    }

    /// <summary>
    /// Method prints on console expression from Parse tree.
    /// </summary>
    /// <param name="treeRoot">root of Parse tree.</param>
    /// <exception cref="InvalidOperationException">incorrect input.</exception>
    public void Print(INode treeRoot)
    {
        if (treeRoot == null)
        {
            throw new InvalidOperationException();
        }

        treeRoot.Print();
    }

    /// <summary>
    /// Method calculates the mathematical Parse tree expression.
    /// </summary>
    /// <param name="treeRoot">root of Parse tree.</param>
    /// <returns>result of calculation.</returns>
    /// <exception cref="InvalidOperationException">incorrect input.</exception>
    public int Eval(INode treeRoot)
    {
        if (treeRoot == null)
        {
            throw new InvalidOperationException();
        }

        return treeRoot.Eval();
    }

    private bool IsOperator(char symbol)
    => symbol == '+' || symbol == '*' || symbol == '/' || symbol == '-';

    private bool IsDigit(char symbol)
        => symbol >= '0' && symbol <= '9';

    private bool IsBracketOrSpace(char symbol)
        => symbol == '(' || symbol == ')' || symbol == ' ';

    private (int Number, int NewIndex) GetNumberFromSequence(string stringOfNumbersAndOperators, int index)
    {
        string stringForNumber = string.Empty;
        while (index < stringOfNumbersAndOperators.Length
            && (this.IsDigit(stringOfNumbersAndOperators[index]) || stringOfNumbersAndOperators[index] == '-'))
        {
            stringForNumber += stringOfNumbersAndOperators[index];
            ++index;
        }

        --index;
        return (int.Parse(stringForNumber), index);
    }
}