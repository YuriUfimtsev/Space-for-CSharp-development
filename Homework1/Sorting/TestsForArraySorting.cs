namespace Sorting;

/// <summary>
/// Класс тестирует методы класса ArraySorting.
/// </summary>
internal static class TestsForArraySorting
{
    /// <summary>
    /// Метод проверяет корректность выполнения тестов для класса ArraySorting.
    /// </summary>
    /// <returns> Возвращает true, если тесты прошли. Else иначе. </returns>
    internal static bool AreTestsCorrect()
    {
        return TestWithEqualElements() && ReverseSortingTest() && StandartTest();
    }

    private static bool StandartTest()
    {
        int[] arrayForStandartTest = { 1, 5, 8, 0, 2 };
        ArraySorting.SortByInsertion(arrayForStandartTest);
        int[] resultArray = { 0, 1, 2, 5, 8 };
        return Enumerable.SequenceEqual(resultArray, arrayForStandartTest);
    }

    private static bool ReverseSortingTest()
    {
        int[] arrayForStandartTest = { 5, 4, 3, 2, 1 };
        ArraySorting.SortByInsertion(arrayForStandartTest);
        int[] resultArray = { 1, 2, 3, 4, 5 };
        return Enumerable.SequenceEqual(arrayForStandartTest, resultArray);
    }

    private static bool TestWithEqualElements()
    {
        int[] arrayForStandartTest = { 1, 8, 1 };
        ArraySorting.SortByInsertion(arrayForStandartTest);
        int[] resultArray = { 1, 1, 8 };
        return Enumerable.SequenceEqual(arrayForStandartTest, resultArray);
    }
}
