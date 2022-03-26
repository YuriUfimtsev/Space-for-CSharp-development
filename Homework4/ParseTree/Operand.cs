using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParseTree;
public class Operand : INode
{
    private int number;
    private Operator? parent;

    public Operator? Parent
    {
        get { return parent; } set { parent = value; }
    }
    public int Number
    {
        get { return number; } set { number = value; }
    }

    public void Print()
        => Console.Write($"{number} ");

    public int Eval()
        => number;
}