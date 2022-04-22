namespace Calculator;

using System.Text;

/// <summary>
/// Class realizes сalculator methods with character-by-character input.
/// </summary>
public class Calculator
{
    private readonly StringBuilder currentNumber;
    private int calculationResult;
    private int[,]? stateTable;
    private int state;
    private char currentOperator;

    /// <summary>
    /// Initializes a new instance of the <see cref="Calculator"/> class.
    /// </summary>
    /// <param name="pathToStateTable">path to the file with State table.</param>
    public Calculator(string pathToStateTable)
    {
        this.currentNumber = new StringBuilder();
        this.CalculationResult = 0;
        this.CreateStateTableFromFile(pathToStateTable);
    }

    /// <summary>
    /// Event occurs when property CalculationResult is changed.
    /// </summary>
    public event EventHandler<EventArgs>? CalculationResultChanged;

    /// <summary>
    /// Gets or sets current calculationResult.
    /// </summary>
    public int CalculationResult
    {
        get
        {
            return this.calculationResult;
        }

        set
        {
            this.calculationResult = value;
            if (this.CalculationResultChanged != null)
            {
                this.CalculationResultChanged(this, EventArgs.Empty);
            }
        }
    }

    /// <summary>
    /// Clears current calculationResullt and currentOperator.
    /// </summary>
    public void ClearCalculatorStream()
    {
        this.state = 0;
        this.CalculationResult = 0;
        this.currentNumber.Clear();
        this.currentOperator = ' ';
    }

    /// <summary>
    /// The method calculates a new value based on the previous results and the new character.
    /// </summary>
    /// <param name="symbol">current symbol from the input stream.</param>
    /// <exception cref="InvalidOperationException">throws if current operation isn't correct.
    /// For example, division by xero is incorrect.</exception>
    /// <exception cref="InvalidDataException">throws if current data isn't correct.
    /// For example, number is greater than the int maximum.</exception>
    public void Calculate(char symbol)
    {
        var column = this.GetNumberFromStateTable(symbol);
        this.state = this.stateTable![this.state, column];
        var isEvaluatingCorrect = true;
        switch (this.state)
        {
            case 0:
                if (int.TryParse(this.currentNumber.ToString(), out int operand))
                {
                    (this.CalculationResult, isEvaluatingCorrect) = this.Evaluate(operand);
                    if (!isEvaluatingCorrect)
                    {
                        throw new InvalidOperationException();
                    }

                    this.currentNumber.Clear();
                }
                else
                {
                    throw new InvalidDataException();
                }

                this.currentOperator = symbol;
                break;
            case 1:
                this.currentNumber.Append(symbol);
                break;
            case 2:
                this.currentNumber.Append(symbol);
                break;
            case 3:
                if (int.TryParse(this.currentNumber.ToString(), out int secondOperand))
                {
                    (this.CalculationResult, isEvaluatingCorrect) = this.Evaluate(secondOperand);
                    if (!isEvaluatingCorrect)
                    {
                        throw new InvalidOperationException();
                    }

                    this.currentNumber.Clear();
                    this.currentNumber.Append(this.CalculationResult);
                    this.currentOperator = ' ';
                }
                else
                {
                    throw new InvalidDataException();
                }

                break;
            case 4:
                this.currentNumber.Clear();
                this.currentOperator = ' ';
                this.state = 0;
                throw new InvalidOperationException();
            default:
                break;
        }
    }

    private bool IsNumber(char symbol)
        => symbol >= '0' && symbol <= '9';

    private bool IsDivisionOrMultiplicationOrAdditionOperator(char symbol)
        => symbol == '+' || symbol == '*' || symbol == '/';

    private (int CalculationResult, bool IsOperationCorrect) Evaluate(int secondOperand)
        => this.currentOperator switch
        {
            '+' => (this.CalculationResult + secondOperand, true),
            '-' => (this.CalculationResult - secondOperand, true),
            '*' => (this.CalculationResult * secondOperand, true),
            '/' => secondOperand == 0 ? (0, false) : (this.CalculationResult / secondOperand, true),
            _ => (secondOperand, true),
        };

    private void CreateStateTableFromFile(string pathToFile)
    {
        var countOfLinesWithStates = 0;
        var lengthOfLine = 0;
        using (StreamReader fileStreamToCalculateTheDimensions = new(pathToFile))
        {
            var line = fileStreamToCalculateTheDimensions.ReadLine();
            if (line == null)
            {
                throw new InvalidDataException();
            }

            lengthOfLine = line.Length;
            while ((line = fileStreamToCalculateTheDimensions.ReadLine()) != null)
            {
                ++countOfLinesWithStates;
            }
        }

        var temporaryStateTable = new int[countOfLinesWithStates, lengthOfLine];
        using (StreamReader fileStreamToCreateStateTable = new(pathToFile))
        {
            var line = fileStreamToCreateStateTable.ReadLine();
            for (var i = 0; i < countOfLinesWithStates; ++i)
            {
                line = fileStreamToCreateStateTable.ReadLine();
                var lineSymbols = line!.Split();
                for (var j = 0; j < lineSymbols.Length; ++j)
                {
                    temporaryStateTable[i, j] = int.Parse(lineSymbols[j]);
                }
            }
        }

        this.stateTable = temporaryStateTable;
    }

    private int GetNumberFromStateTable(char symbol)
    {
        var result = -1;
        if (symbol == '-')
        {
            result = 0;
        }

        if (this.IsDivisionOrMultiplicationOrAdditionOperator(symbol))
        {
            result = 1;
        }

        if (this.IsNumber(symbol))
        {
            result = 2;
        }

        if (symbol == '=')
        {
            result = 3;
        }

        return result;
    }
}
