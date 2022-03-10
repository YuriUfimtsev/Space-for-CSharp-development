namespace StackCalculator;

using System;

/// <summary>
/// Class to make computing using stack.
/// </summary>
internal class StackCalculator
{
    private IStack? newStack;

    /// <summary>
    /// Initializes a new instance of the <see cref="StackCalculator"/> class.
    /// </summary>
    /// <param name="stack">stack element for StackCalculator.</param>
    internal StackCalculator(IStack stack)
       => this.newStack = stack;

    /// <summary>
    /// Method calculate expression in postfix form and return result.
    /// </summary>
    /// <param name="commandSequence">expression in postfix form.</param>
    /// <returns>result of computing. Also return true if method completed the work correctly. Else false.</returns>
    public (float Result, bool CheckOfCorrectWork) CalculateInPostfixForm(string commandSequence)
    {
        var arrayOfNumbersAndOperators = commandSequence.Split();
        var checkOfCorrectWork = true;
        for (int i = 0; i < arrayOfNumbersAndOperators.Length; ++i)
        {
            if (arrayOfNumbersAndOperators[i] == "*" || arrayOfNumbersAndOperators[i] == "/"
            || arrayOfNumbersAndOperators[i] == "+" || arrayOfNumbersAndOperators[i] == "-")
            {
                (var firstElement, checkOfCorrectWork) = this.newStack!.Pop();
                (var secondElement, checkOfCorrectWork) = this.newStack.Pop();
                if (!checkOfCorrectWork)
                {
                    return (0, false);
                }

                float middleResult = 0;
                switch (arrayOfNumbersAndOperators[i])
                {
                    case "*":
                        middleResult = firstElement * secondElement;
                        break;
                    case "/":
                        if (Math.Abs(firstElement) > 0.000000001)
                        {
                            middleResult = secondElement / firstElement;
                        }
                        else
                        {
                            return (0, false);
                        }

                        break;
                    case "-":
                        middleResult = secondElement - firstElement;
                        break;
                    case "+":
                        middleResult = firstElement + secondElement;
                        break;
                    default:
                        break;
                }

                this.newStack.Push(middleResult);
            }
            else
            {
                this.newStack!.Push(float.Parse(arrayOfNumbersAndOperators[i]));
            }
        }

        (float finalResult, checkOfCorrectWork) = this.newStack!.Pop();
        if (!this.newStack.IsEmpty() || !checkOfCorrectWork)
        {
            return (0, false);
        }

        return (finalResult, true);
    }
}
