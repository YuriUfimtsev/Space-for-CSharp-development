namespace ParseTree;

public class Program
{
    public static void Main(string[] args)
    {
        var hh = "(* 2 (+ 1 1))"; // Наоборот точно не сработает!!!
        ParseTree k = new();
        int p = 0;
        INode? newTree = k.createNewNodeForParseTree(hh, ref p);
    }
}