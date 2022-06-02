namespace BurrowsWheelerTransform;

/// <summary>
/// Класс содержит методы, которые тестируют Direct and Reverse BWT.
/// </summary>
internal class TestsForBWT
{
    /// <summary>
    /// Метод проверяет корректность выполнения всех тестов.
    /// </summary>
    /// <returns> true, если тесты прошли успешно. false иначе. </returns>
    internal static bool AreTestsPassing()
    {
        return TestWithNonrepeatingSymbols() && TestWithRussianAndRepeatingSymbols() && TestWithOneSymbol();
    }

    private static bool TestWithNonrepeatingSymbols()
    {
        var stringForBWT = "complex678";
        var (directTransformedString, directEndStringPosition) = BurrowsWheelerTransform.DirectBWT(stringForBWT);
        var reverseTransformedString = BurrowsWheelerTransform.ReverseBWT(directTransformedString, directEndStringPosition);
        return string.Compare(directTransformedString, "x678lpocme") == 0
            && string.Compare(reverseTransformedString, stringForBWT) == 0 && directEndStringPosition == 3;
    }

    private static bool TestWithRussianAndRepeatingSymbols()
    {
        var stringForBWT = "carcarcar";
        var (directTransformedString, directEndStringPosition) = BurrowsWheelerTransform.DirectBWT(stringForBWT);
        var reverseTransformedString = BurrowsWheelerTransform.ReverseBWT(directTransformedString, directEndStringPosition);
        return string.Compare(directTransformedString, "cccrrraaa") == 0
            && string.Compare(reverseTransformedString, stringForBWT) == 0 && directEndStringPosition == 5;
    }

    private static bool TestWithOneSymbol()
    {
        var stringForBWT = "h";
        var (directTransformedString, directEndStringPosition) = BurrowsWheelerTransform.DirectBWT(stringForBWT);
        var reverseTransformedString = BurrowsWheelerTransform.ReverseBWT(directTransformedString, directEndStringPosition);
        return string.Compare(directTransformedString, "h") == 0
            && string.Compare(reverseTransformedString, stringForBWT) == 0 && directEndStringPosition == 0;
    }
}