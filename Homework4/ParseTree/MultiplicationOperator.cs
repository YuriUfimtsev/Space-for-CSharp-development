using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParseTree;
public class MultiplicationOperator : Operator
{
    public override int Eval()
    {
        if (LeftChild == null || RightChild == null)
        {
            throw new ArgumentException();
        }
        return LeftChild.Eval() * RightChild.Eval();
    }
}