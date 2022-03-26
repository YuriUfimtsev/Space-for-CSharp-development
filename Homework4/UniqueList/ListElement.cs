using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueList;
public class ListElement<T>
{
    public ListElement(T value)
    {
        Value = value;
        Next = null;
    }
    public T Value { get; set; }
    public ListElement<T>? Next { get; set; }
}
