namespace CalculatorTests;

using NUnit.Framework;

public class CalculatorTests
{
    private readonly string pathToStateTable = "..\\..\\..\\..\\Calculator\\StateTable.txt";

    [Test]
    public void StandartTestWithAddition()
    {
        Calculator.Calculator calculator = new(pathToStateTable);
        calculator.Calculate('1');
        calculator.Calculate('2');
        calculator.Calculate('3');
        calculator.Calculate('+');
        calculator.Calculate('8');
        calculator.Calculate('4');
        calculator.Calculate('=');
        Assert.AreEqual(calculator.CalculationResult, 207);
    }

    [Test]
    public void StandartTestWithSubtraction()
    {
        Calculator.Calculator calculator = new(pathToStateTable);
        calculator.Calculate('1');
        calculator.Calculate('2');
        calculator.Calculate('-');
        calculator.Calculate('8');
        calculator.Calculate('4');
        calculator.Calculate('=');
        Assert.AreEqual(calculator.CalculationResult, -72);
    }

    [Test]
    public void StandartTestWithMultiplication()
    {
        Calculator.Calculator calculator = new(pathToStateTable);
        calculator.Calculate('1');
        calculator.Calculate('2');
        calculator.Calculate('*');
        calculator.Calculate('5');
        calculator.Calculate('1');
        calculator.Calculate('=');
        Assert.AreEqual(calculator.CalculationResult, 612);
    }

    [Test]
    public void StandartTestWithIntegerDivision()
    {
        Calculator.Calculator calculator = new(pathToStateTable);
        calculator.Calculate('8');
        calculator.Calculate('0');
        calculator.Calculate('/');
        calculator.Calculate('1');
        calculator.Calculate('5');
        calculator.Calculate('=');
        Assert.AreEqual(calculator.CalculationResult, 5);
    }

    [Test]
    public void DivisionByZeroTest()
    {
        Calculator.Calculator calculator = new(pathToStateTable);
        calculator.Calculate('8');
        calculator.Calculate('/');
        calculator.Calculate('0');
        Assert.Throws<System.InvalidOperationException>(() => calculator.Calculate('='));
    }

    [Test]
    public void ContiniousComputingTest()
    {
        Calculator.Calculator calculator = new(pathToStateTable);
        calculator.Calculate('8');
        calculator.Calculate('0');
        calculator.Calculate('+');
        calculator.Calculate('1');
        calculator.Calculate('-');
        Assert.AreEqual(calculator.CalculationResult, 81);
        calculator.Calculate('9');
        calculator.Calculate('0');
        calculator.Calculate('*');
        Assert.AreEqual(calculator.CalculationResult, -9);
        calculator.Calculate('5');
        calculator.Calculate('/');
        Assert.AreEqual(calculator.CalculationResult, -45);
        calculator.Calculate('1');
        calculator.Calculate('1');
        calculator.Calculate('=');
        Assert.AreEqual(calculator.CalculationResult, -4);
    }

    [Test]
    public void AdditionWithNegativeNumberAndClearCalculationStreamTest()
    {
        Calculator.Calculator calculator = new(pathToStateTable);
        calculator.Calculate('8');
        calculator.Calculate('0');
        calculator.Calculate('+');
        calculator.Calculate('-');
        calculator.Calculate('1');
        calculator.Calculate('=');
        Assert.AreEqual(calculator.CalculationResult, 79);
        calculator.ClearCalculatorStream();
        calculator.Calculate('-');
        calculator.Calculate('7');
        calculator.Calculate('2');
        calculator.Calculate('+');
        calculator.Calculate('1');
        calculator.Calculate('=');
        Assert.AreEqual(calculator.CalculationResult, -71);
    }

    [Test]
    public void SubtractionWithNegativeNumbersTest()
    {
        Calculator.Calculator calculator = new(pathToStateTable);
        calculator.Calculate('-');
        calculator.Calculate('7');
        calculator.Calculate('5');
        calculator.Calculate('-');
        calculator.Calculate('-');
        calculator.Calculate('1');
        calculator.Calculate('=');
        Assert.AreEqual(calculator.CalculationResult, -74);
    }

    [Test]
    public void DivisionAndMultiplicationWithNegativeNumberTest()
    {
        Calculator.Calculator calculator = new(pathToStateTable);
        calculator.Calculate('8');
        calculator.Calculate('0');
        calculator.Calculate('*');
        calculator.Calculate('-');
        calculator.Calculate('5');
        calculator.Calculate('=');
        Assert.AreEqual(calculator.CalculationResult, -400);
        calculator.Calculate('/');
        calculator.Calculate('-');
        calculator.Calculate('1');
        calculator.Calculate('0');
        calculator.Calculate('=');
        Assert.AreEqual(calculator.CalculationResult, 40);
    }

    [Test]
    public void EnteringMathematicalSignsInsteadOfNumbersTest()
    {
        Calculator.Calculator calculator = new(pathToStateTable);
        Assert.Throws<System.InvalidOperationException>(() => calculator.Calculate('+'));
        Assert.Throws<System.InvalidOperationException>(() => calculator.Calculate('*'));
        Assert.Throws<System.InvalidOperationException>(() => calculator.Calculate('/'));
        Assert.Throws<System.InvalidOperationException>(() => calculator.Calculate('='));
    }

    [Test]
    public void EnteringMathematicalSignsInsteadOfNegativeNumberTest()
    {
        Calculator.Calculator calculator = new(pathToStateTable);
        calculator.Calculate('-');
        Assert.Throws<System.InvalidOperationException>(() => calculator.Calculate('+'));
        Assert.Throws<System.InvalidOperationException>(() => calculator.Calculate('='));
    }

    [Test]
    public void EnteringNewNumberAfterReceivingResultOfCalculation()
    {
        Calculator.Calculator calculator = new(pathToStateTable);
        calculator.Calculate('8');
        calculator.Calculate('0');
        calculator.Calculate('*');
        calculator.Calculate('5');
        calculator.Calculate('5');
        calculator.Calculate('=');
        Assert.Throws<System.InvalidOperationException>(() => calculator.Calculate('5'));
    }
}