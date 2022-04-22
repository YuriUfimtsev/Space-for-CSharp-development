namespace Calculator;

/// <summary>
/// Class realizes user interface for calculator.
/// </summary>
public partial class CalculatorUserInterfaceForm : Form
{
    private Calculator calculator;

    /// <summary>
    /// Initializes a new instance of the <see cref="CalculatorUserInterfaceForm"/> class.
    /// </summary>
    /// <param name="pathToStatesTable">path to the file with State table.</param>
    public CalculatorUserInterfaceForm(string pathToStatesTable)
    {
        this.InitializeComponent();
        this.calculator = new Calculator(pathToStatesTable);
        this.calculator.CalculationResultChanged += this.CurrentCalculationResultChanged;
        this.WindowWithCalculation.Text = string.Empty;
    }

    private void CurrentCalculationResultChanged(object? sender, EventArgs eventArgs)
    {
        this.WindowWithCalculation.Text = this.calculator.CalculationResult.ToString();
    }

    private void ZeroClick(object sender, EventArgs e)
    {
        this.calculator.Calculate('0');
        this.WindowWithCalculation.Text += "0";
    }

    private void OneClick(object sender, EventArgs e)
    {
        this.calculator.Calculate('1');
        this.WindowWithCalculation.Text += "1";
    }

    private void TwoClick(object sender, EventArgs e)
    {
        this.calculator.Calculate('2');
        this.WindowWithCalculation.Text += "2";
    }

    private void ThreeClick(object sender, EventArgs e)
    {
        this.calculator.Calculate('3');
        this.WindowWithCalculation.Text += "3";
    }

    private void FourClick(object sender, EventArgs e)
    {
        this.calculator.Calculate('4');
        this.WindowWithCalculation.Text += "4";
    }

    private void FiveClick(object sender, EventArgs e)
    {
        this.calculator.Calculate('5');
        this.WindowWithCalculation.Text += "5";
    }

    private void SixClick(object sender, EventArgs e)
    {
        this.calculator.Calculate('6');
        this.WindowWithCalculation.Text += "6";
    }

    private void SevenClick(object sender, EventArgs e)
    {
        this.calculator.Calculate('7');
        this.WindowWithCalculation.Text += "7";
    }

    private void EightClick(object sender, EventArgs e)
    {
        this.calculator.Calculate('8');
        this.WindowWithCalculation.Text += "8";
    }

    private void NineClick(object sender, EventArgs e)
    {
        this.calculator.Calculate('9');
        this.WindowWithCalculation.Text += "9";
    }

    private void EqualityClick(object sender, EventArgs e)
    {
        try
        {
            this.WindowWithCalculation.Text += "=";
            this.calculator.Calculate('=');
        }
        catch (InvalidDataException)
        {
            this.WindowWithCalculation.Text = "Incorrect data for operation";
        }
        catch (InvalidOperationException)
        {
            this.WindowWithCalculation.Text = "Incorrect operation";
        }
    }

    private void PlusClick(object sender, EventArgs e)
    {
        try
        {
            this.calculator.Calculate('+');
            this.WindowWithCalculation.Text += "+";
        }
        catch (InvalidDataException)
        {
            this.WindowWithCalculation.Text = "Incorrect data for operation";
        }
        catch (InvalidOperationException)
        {
            this.WindowWithCalculation.Text = "Incorrect operation";
        }
    }

    private void MinusClick(object sender, EventArgs e)
    {
        try
        {
            this.calculator.Calculate('-');
            this.WindowWithCalculation.Text += "-";
        }
        catch (InvalidDataException)
        {
            this.WindowWithCalculation.Text = "Incorrect data for operation";
        }
        catch (InvalidOperationException)
        {
            this.WindowWithCalculation.Text = "Incorrect operation";
        }
    }

    private void MultiplyClick(object sender, EventArgs e)
    {
        try
        {
            this.calculator.Calculate('*');
            this.WindowWithCalculation.Text += "*";
        }
        catch (InvalidDataException)
        {
            this.WindowWithCalculation.Text = "Incorrect data for operation";
        }
        catch (InvalidOperationException)
        {
            this.WindowWithCalculation.Text = "Incorrect operation";
        }
    }

    private void DivisionClick(object sender, EventArgs e)
    {
        try
        {
            this.calculator.Calculate('/');
            this.WindowWithCalculation.Text += "/";
        }
        catch (InvalidDataException)
        {
            this.WindowWithCalculation.Text = "Incorrect data for operation";
        }
        catch (InvalidOperationException)
        {
            this.WindowWithCalculation.Text = "Incorrect operation";
        }
    }

    private void ClearClick(object sender, EventArgs e)
    {
        this.calculator.ClearCalculatorStream();
        this.WindowWithCalculation.Text = string.Empty;
    }
}