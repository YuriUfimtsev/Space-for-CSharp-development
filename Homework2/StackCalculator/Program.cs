using System.Collections;

namespace StackCalculator;
internal class Program
{
    public static void Main(string[] args)
    {
        StackOnArray
        StackCalculator news = new();
        news.CalculateInPostfixForm("1 2 3 + *");
    }
}
