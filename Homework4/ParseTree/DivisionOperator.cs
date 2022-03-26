using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParseTree;
public class DivisionOperator : Operator
{
    public override int Eval()
    {
        if (LeftChild == null || RightChild == null)
        {
            throw new ArgumentException();
        }
        var righChildNumber = RightChild.Eval();
        return righChildNumber == 0 ? throw new ArgumentException("Division by 0")
            : LeftChild.Eval() / RightChild.Eval();
    }
}