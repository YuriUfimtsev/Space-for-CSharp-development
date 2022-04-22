using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator;
public class Calculator
{
    public int CalculationResult { get; set; }
    private int[,]? StateTable;
    private int State;
    private StringBuilder currentNumber;
    private char currentOperator;

    public Calculator(string pathToStateTable)
    {
        currentNumber = new StringBuilder();
        CreateStateTableFromFile(pathToStateTable);
    }

    private bool IsNumber(char symbol)
        => symbol >= '0' && symbol <= '9';

    private bool IsDivisionOrMultiplicationOrAdditionOperator(char symbol)
        => symbol == '+' || symbol == '*' || symbol == '/';

    private (int, bool) Evaluate(int secondOperand)
        => this.currentOperator switch
        {
            '+' => (this.CalculationResult + secondOperand, true),
            '-' => (this.CalculationResult - secondOperand, true),
            '*' => (this.CalculationResult * secondOperand, true),
            '/' => secondOperand == 0 ? (0, false) : (this.CalculationResult / secondOperand, true),
            _ => (secondOperand, true)
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

        var TemporaryStateTable = new int[countOfLinesWithStates, lengthOfLine];
        using (StreamReader fileStreamToCreateStateTable = new(pathToFile))
        {
            var line = fileStreamToCreateStateTable.ReadLine();
            for (var i = 0; i < countOfLinesWithStates; ++i)
            {
                line = fileStreamToCreateStateTable.ReadLine();
                var lineSymbols = line!.Split();
                for (var j = 0; j < lineSymbols.Length; ++j)
                {
                    TemporaryStateTable[i, j] = int.Parse(lineSymbols[j]);
                }
            }
        }

        StateTable = TemporaryStateTable;
    }

    private int GetNumberFromStateTable(char symbol)
    {
        var result = -1;
        if (symbol == '-')
        {
            result = 0;
        }

        if (IsDivisionOrMultiplicationOrAdditionOperator(symbol))
        {
            result = 1;
        }

        if (IsNumber(symbol))
        {
            result = 2;
        }

        if (symbol == '=')
        {
            result = 3;
        }

        return result;
    }

    public void ClearCalculatorStream()
    {
        this.State = 0;
        this.CalculationResult = 0;
        this.currentNumber.Clear();
        this.currentOperator = ' ';
    }

    public void Calculate(char symbol)
    {
        var column = GetNumberFromStateTable(symbol);
        State = StateTable![State, column];
        var isEvaluatingCorrect = true;
        switch (State)
        {
            case 0:
                if (int.TryParse(this.currentNumber.ToString(), out int operand))
                {
                    (this.CalculationResult, isEvaluatingCorrect) = Evaluate(operand);
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
                    (this.CalculationResult, isEvaluatingCorrect) = Evaluate(secondOperand);
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
                State = 0;
                throw new InvalidOperationException();
        }
    }


}
