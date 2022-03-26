using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParseTree;

abstract public class Operator : INode
{
    private INode? rightChild;
    private INode? leftChild;
    private char nodeOperator;

    public INode? RightChild
    {
        get { return rightChild; } set { rightChild = value; }
    }

    public INode? LeftChild
    {
        get { return leftChild; } set { leftChild = value; }
    }

    public char NodeOperator
    {
        get { return nodeOperator; } set { nodeOperator = value; }
    }

    public void Print()
    {
        if (leftChild == null || rightChild == null)
        {
            throw new InvalidOperationException();
        }

        leftChild.Print();
        Console.Write(nodeOperator);
        rightChild.Print();
    }

    abstract public int Eval();

}