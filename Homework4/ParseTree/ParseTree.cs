using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTree;
internal class ParseTree
{
    private bool isOperator(char symbol)
        => symbol == '+' || symbol == '*' || symbol == '/' || symbol == '-';

    private bool isDigit(char symbol)
        => symbol >= '0' && symbol <= '9';

    private bool isBracketOrSpace(char symbol)
        => symbol == '(' || symbol == ')' || symbol == ' ';

    private (int Number, int NewIndex) getNumberFromSequence(string stringOfNumbersAndOperators, int index)
    {
        string stringForNumber = "";
        while (isDigit(stringOfNumbersAndOperators[index]) || stringOfNumbersAndOperators[index] == '-')
        {
            stringForNumber += stringOfNumbersAndOperators[index];
            ++index;
        }
        --index;
        return (int.Parse(stringForNumber), index);
    }

    //public void createNewNodeForParseTree(Operator? @operator, Operand? operand)
    //{
    //    if (operand == null)
    //    {
    //        if (node == null)
    //        {
    //            node = @operator!;
    //        }

    //        if (treeRoot == null)
    //        {
    //            treeRoot = node;
    //        }

    //        else if ((node as Operator)!.RightChild == null)
    //        {
    //            (node as Operator)!.RightChild = @operator!;
    //            node = (node as Operator)!.RightChild;
    //        }

    //        else if ((node as Operator)!.LeftChild == null)
    //        {
    //            (node as Operator)!.LeftChild = @operator!;
    //            node = (node as Operator)!.LeftChild;
    //        }
    //    }

    //    else if (@operator == null)
    //    {
    //        if ((node as Operator)!.LeftChild == null)
    //        {
    //            (node as Operator)!.LeftChild = operand;
    //        }

    //        else if((node as Operator)!.RightChild == null)
    //        {
    //            (node as Operator)!.RightChild = operand;
    //        }

    //        int.TryParse()
    //    }
    //}
    private INode? node = null;
    public INode? createNewNodeForParseTree(string stringOfNumbersAndOperators, ref int index)
    {
        ++index;
        while (index < stringOfNumbersAndOperators.Length && isBracketOrSpace(stringOfNumbersAndOperators[index]))
        {
            ++index;
        }
        if (isOperator(stringOfNumbersAndOperators[index]) && stringOfNumbersAndOperators[index + 1] == ' ')
        {
            node = Parse(stringOfNumbersAndOperators, ref index, true);
            (node as Operator)!.LeftChild = createNewNodeForParseTree(stringOfNumbersAndOperators, ref index);
            (node as Operator)!.RightChild = createNewNodeForParseTree(stringOfNumbersAndOperators, ref index);
        }
        else if (isDigit(stringOfNumbersAndOperators[index]) || stringOfNumbersAndOperators[index] == '-')
        {
            node = Parse(stringOfNumbersAndOperators, ref index, false);
        }
        return node;
    }

    public INode? Parse(string stringOfNumbersAndOperations, ref int index, bool isOperator)
    {
        if (!isOperator)
        {
            var (resultNumber, newIndex) = getNumberFromSequence(stringOfNumbersAndOperations, index);
            Operand operand = new();
            operand.Number = resultNumber;
            index = newIndex;
            return operand;
        }
        else
        {
            ++index;
            return (stringOfNumbersAndOperations[index - 1]) switch
            {
                '+' => new AdditionOperator(),
                '-' => new SubstractionOperator(),
                '/' => new DivisionOperator(),
                '*' => new MultiplicationOperator(),
                _ => throw new NotImplementedException()
            };
        }
    }

    //public INode? Parse(string stringOfNumbersAndOperators, int index)
    //{
    //    var index = 0;
    //    while (index < stringOfNumbersAndOperators.Length)
    //    {
    //        while (isBracketOrSpace(stringOfNumbersAndOperators[index]))
    //        {
    //            ++index;
    //        }

    //        if (index >= stringOfNumbersAndOperators.Length)
    //        {
    //            return;
    //        }

    //        if (isOperator(stringOfNumbersAndOperators[index])
    //            && stringOfNumbersAndOperators[index + 1] == ' ')
    //        {
    //            switch (stringOfNumbersAndOperators[index])
    //            {
    //                case '+':
    //                    createNewNodeForParseTree(new MultiplicationOperator(), null);
    //                    break;
    //                case '-':
    //                    createNewNodeForParseTree(new SubstractionOperator(), null);
    //                    break;
    //                case '/':
    //                    createNewNodeForParseTree(new DivisionOperator(), null);
    //                    break;
    //                case '*':
    //                    createNewNodeForParseTree(new MultiplicationOperator(), null);
    //                    break;
    //                default:
    //                    break;
    //            }
    //            ++index;
    //        }
    //        else if (isDigit(stringOfNumbersAndOperators[index]) || stringOfNumbersAndOperators[index] == '-')
    //        {
    //            var (number, newIndex) = getNumberFromSequence(stringOfNumbersAndOperators, index);
    //            index = newIndex;
    //            var newOperand = new Operand();
    //            newOperand.Number = number;
    //            createNewNodeForParseTree(null, newOperand);
    //        }
    //    }
    //}

    //public void Print()
    //{
    //    if (treeRoot == null)
    //    {
    //        throw new InvalidOperationException();
    //    }

    //    treeRoot.Print();
    //}

    //public int Eval()
    //{
    //    if (treeRoot == null)
    //    {
    //        throw new InvalidOperationException();
    //    }

    //    return treeRoot.Eval();
    //}
}