namespace Calculator;
internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Calculator calculator = new Calculator("..//..//..//StateTable.txt");
        calculator.Calculate('1');
        calculator.Calculate('4');
        calculator.Calculate('+');
        calculator.Calculate('1');
        calculator.Calculate('-');
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        //ApplicationConfiguration.Initialize();
        //Application.Run(new Form1());
    }
}