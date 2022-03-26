namespace UniqueList;

using System;
public class Program
{
    public static void Main(string[] args)
    {
        List<int> list = new();
        list.AddByPosition(21, 0);
        list.AddByPosition(22, 0);
        list.AddByPosition(1, 1);
        list.RemoveByPosition(0);
        list.RemoveByPosition(1);
        list.RemoveByPosition(2);
    }
}
