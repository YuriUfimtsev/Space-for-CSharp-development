using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTree;
public interface INode
{
    public int Eval();

    public void Print();
    //private INode OperatorOrOperand
    //{

    //}

}
