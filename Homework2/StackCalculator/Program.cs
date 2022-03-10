using System.Collections;

namespace StackCalculator;
internal class Program
{
    public static void Main(string[] args)
    {
        StackOnArray stackOnArray = new StackOnArray();
        StackCalculator stackOnArrayCalculator = new StackCalculator(stackOnArray);
        (float result, bool checkOfCorrectWork) = stackOnArrayCalculator.CalculateInPostfixForm("1 0 /");

        StackOnList stackOnList = new StackOnList();
        StackCalculator stackOnListCalculator = new StackCalculator(stackOnList);
        (float newResult, bool newCheckOfCorrectWork) = stackOnListCalculator.CalculateInPostfixForm("1 0 /");
    }
}
