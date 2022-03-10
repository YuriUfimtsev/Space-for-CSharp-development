namespace StackCalculator;

using System;

internal class StackCalculator
{
    private IStack? newStack;

    internal StackCalculator(IStack stack)
       => this.newStack = stack;

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
