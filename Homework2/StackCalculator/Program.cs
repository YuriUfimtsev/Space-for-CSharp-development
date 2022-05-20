namespace StackCalculator;

/// <summary>
/// Class contains Main method.
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter the string, that you want to calculate (in postfix form):");
        var stringForCalculator = Console.ReadLine();
        if (stringForCalculator == null)
        {
            Console.WriteLine("Incorrect input");
            return;
        }

        StackOnArray stackOnArray = new StackOnArray();
        StackCalculator stackOnArrayCalculator = new StackCalculator(stackOnArray);
        (float resultOnStackOnArray, bool checkOfCorrectWorkForStackOnArray)
            = stackOnArrayCalculator.CalculateInPostfixForm(stringForCalculator);
        if (!checkOfCorrectWorkForStackOnArray)
        {
            Console.WriteLine("Incorrect string. Try again :)");
            return;
        }

        Console.WriteLine($"Result from calculator with stack on array: {resultOnStackOnArray};");

        StackOnList stackOnList = new StackOnList();
        StackCalculator stackOnListCalculator = new StackCalculator(stackOnList);
        (float resultOnStackOnList, bool checkOfCorrectWorkForStackOnList)
            = stackOnListCalculator.CalculateInPostfixForm(stringForCalculator);
        if (!checkOfCorrectWorkForStackOnList)
        {
            Console.WriteLine("Incorrect string. Try again :)");
            return;
        }

        Console.WriteLine($"Result from calculator with stack on list: {resultOnStackOnList}.");
    }
}
