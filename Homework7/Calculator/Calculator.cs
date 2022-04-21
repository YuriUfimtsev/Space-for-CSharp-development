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

    public Calculator()
    {
        currentNumber = new StringBuilder();
    }

    private bool IsNumber(char symbol)
        => symbol >= '0' && symbol <= '9';

    private bool IsDivisionOrMultiplicationOrAdditionOperator(char symbol)
        => symbol == '+' || symbol == '*' || symbol == '/';

    private (int, bool) Evaluate(int secondOperand)
        => this.currentOperator switch
        {
            '+' => (this.CalculationResult + secondOperand, true),
            '*' => (this.CalculationResult * secondOperand, true),
            '/' => secondOperand == 0 ? (0, false) : (this.CalculationResult / secondOperand, true),
            _ => (secondOperand, true)
        };

    public void CreateStateTableFromFile(string pathToFile)
    {
        var TemporaryStateTable = new int[3, 4];
        using (StreamReader fileStream = new(pathToFile))
        {
            var line = fileStream.ReadLine();
            for (var i = 0; i < 3; ++i)
            {
                line = fileStream.ReadLine();
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
                }
                else
                {
                    throw new InvalidDataException();
                }

                break;
            case 4:
                this.currentNumber.Clear();
                throw new InvalidOperationException();
        }
    }


}
