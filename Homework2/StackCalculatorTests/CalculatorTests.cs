using StackCalculator;

namespace StackCalculatorTests;

using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class CalculatorTests
{
    private static IEnumerable<TestCaseData> StackCalulator
        => new TestCaseData[]
    {
        new TestCaseData(new StackCalculator.StackCalculator(new StackCalculator.StackOnArray())),
        new TestCaseData(new StackCalculator.StackCalculator(new StackCalculator.StackOnList())),
    };

    [TestCaseSource(nameof(StackCalulator))]
    public void CalculateStandartCorrectPostfixSequence(StackCalculator.StackCalculator stackCalculator)
    {
        (float calculationResult, var isComputingCorrect) = stackCalculator.CalculateInPostfixForm("1 2 3 + *");
        Assert.IsTrue(calculationResult == 5 && isComputingCorrect);
    }

    [TestCaseSource(nameof(StackCalulator))]
    public void IncorrectSequenceForCalculation(StackCalculator.StackCalculator stackCalculator)
    {
        (float calculationResult, var isComputingCorrect) = stackCalculator.CalculateInPostfixForm("1 2 3 *");
        Assert.IsFalse(isComputingCorrect);
    }

    [TestCaseSource(nameof(StackCalulator))]
    public void CalculatePostfixSequenceWithBigNumbers(StackCalculator.StackCalculator stackCalculator)
    {
        (float calculationResult, var isComputingCorrect) = stackCalculator.CalculateInPostfixForm("200 120 - 300 * 1234 +");
        Assert.IsTrue(calculationResult == 25234 && isComputingCorrect);
    }

    [TestCaseSource(nameof(StackCalulator))]
    public void CalculationWithDivisionByZero(StackCalculator.StackCalculator stackCalculator)
    {
        (float calculationResult, var isComputingCorrect) = stackCalculator.CalculateInPostfixForm("200 120 - 0 /");
        Assert.IsFalse(isComputingCorrect);
    }

    [TestCaseSource(nameof(StackCalulator))]
    public void CalculationWithMyltiplicationByZero(StackCalculator.StackCalculator stackCalculator)
    {
        (float calculationResult, var isComputingCorrect) = stackCalculator.CalculateInPostfixForm("200 120 - 0 *");
        Assert.IsTrue(calculationResult == 0 && isComputingCorrect);
    }

    [TestCaseSource(nameof(StackCalulator))]
    public void CalculationWithFloatResult(StackCalculator.StackCalculator stackCalculator)
    {
        (float calculationResult, var isComputingCorrect) = stackCalculator.CalculateInPostfixForm("5 2 /");
        Assert.IsTrue(calculationResult == 2.5F && isComputingCorrect);
    }
}
