﻿using System;

namespace StackCalculator;
internal class StackCalculator
{
    private IStack? newStack;

    public (float result, bool checkOfCorrectWork) CalculateInPostfixForm(string commandSequence)
    {
        var arrayOfNumbersAndOperators = commandSequence.Split();
        var checkOfCorrectWork = true;
        for (int i = 0; i < arrayOfNumbersAndOperators.Length; ++i)
        {
            if (commandSequence[i] == '*' || commandSequence[i] == '/'
            || commandSequence[i] == '+' || commandSequence[i] == '-')
            {
                (var firstElement, checkOfCorrectWork) = newStack!.Pop();
                (var secondElement, checkOfCorrectWork) = newStack.Pop();
                if (!checkOfCorrectWork)
                {
                    return (0, false);
                }

                float middleResult = 0;
                switch (commandSequence[i])
                {
                    case '*':
                        middleResult = firstElement * secondElement;
                        break;
                    case '/':
                        if (firstElement.Equals((float)0))
                        {
                            return (0, false);
                        }
                        middleResult = secondElement / firstElement;
                        break;
                    case '-':
                        middleResult = secondElement - firstElement;
                        break;
                    case '+':
                        middleResult = firstElement + secondElement;
                        break;
                    default:
                        break;
                }
                newStack.Push(middleResult);
            }
            else
            {
                newStack.Push(float.Parse(arrayOfNumbersAndOperators[i]));
            }
        }

        (float finalResult, checkOfCorrectWork) = newStack!.Pop();
        if (!newStack.IsEmpty() || !checkOfCorrectWork)
        {
            return (0, false);
        }

        return (finalResult, true);
    }
}

