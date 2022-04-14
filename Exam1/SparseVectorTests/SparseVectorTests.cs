using NUnit.Framework;
using SparseVector;
using System.Collections.Generic;

namespace SparseVectorTests
{
    public class SparseVectorTests
    {

        Dictionary<int, int> coordinatesForFirstVector = new()
        {
            { 0, 4 },
            { 3, 4 },
            { 6, 11 },
        };

        Dictionary<int, int> coordinatesForSecondVector = new()
        {
            { 0, 5 },
            { 3, 1 },
            { 2, 15 },
        };

        Dictionary<int, int> coordinatesForNullVector = new()
        {
        };

        [Test]
        public void AddTest()
        {
            SparseVector.SparseVector standartFirstSparseVector = new(7, coordinatesForFirstVector);
            SparseVector.SparseVector standartSecondSparseVector = new(7, coordinatesForSecondVector);
            standartFirstSparseVector.Add(standartSecondSparseVector);
            var resultCoordinates = new Dictionary<int, int>
            {
                { 0, 9 },
                { 3, 5 },
                { 2, 15 },
                { 6, 11 },
            };
            Assert.AreEqual(resultCoordinates, standartFirstSparseVector.Coordinates);
        }

        [Test]
        public void SubstractTest()
        {
            SparseVector.SparseVector standartFirstSparseVector = new(7, coordinatesForFirstVector);
            SparseVector.SparseVector standartSecondSparseVector = new(7, coordinatesForSecondVector);
            standartFirstSparseVector.Substract(standartSecondSparseVector);
            var resultCoordinates = new Dictionary<int, int>
            {
                { 0, -1 },
                { 3, 3 },
                { 2, -15 },
                { 6, 11 },
            };
            Assert.AreEqual(resultCoordinates, standartFirstSparseVector.Coordinates);
        }

        [Test]
        public void ScalarMultiplyTest()
        {
            SparseVector.SparseVector standartFirstSparseVector = new(7, coordinatesForFirstVector);
            SparseVector.SparseVector standartSecondSparseVector = new(7, coordinatesForSecondVector);
            var result = standartFirstSparseVector.ScalarMultiply(standartSecondSparseVector);
            Assert.AreEqual(result, 24);
        }

        [Test]
        public void IsNullVectorTest()
        {
            SparseVector.SparseVector standartFirstSparseVector = new(7, coordinatesForNullVector);
            Assert.IsTrue(standartFirstSparseVector.IsNullVector());
        }

        [Test]
        public void OperationsWithVectorsOfDifferentLengthsTest()
        {
            SparseVector.SparseVector standartFirstSparseVector = new(7, coordinatesForFirstVector);
            SparseVector.SparseVector standartSecondSparseVector = new(15, coordinatesForSecondVector);
            Assert.Throws<VectorLengthMismatchException>(()
                => standartFirstSparseVector.Add(standartSecondSparseVector));
            Assert.Throws<VectorLengthMismatchException>(()
                => standartFirstSparseVector.Substract(standartSecondSparseVector));
            Assert.Throws<VectorLengthMismatchException>(()
                => standartFirstSparseVector.ScalarMultiply(standartSecondSparseVector));
        }
    }
}