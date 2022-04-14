using NUnit.Framework;
using SparseVector;
using System.Collections.Generic;

namespace SparseVectorTests
{
    public class SparseVectorTests
    {

        private SparseVector.SparseVector standartFirstSparseVector = new(
            7,
            new Dictionary<int, int>
            {
                { 0, 8 },
                { 3, 4 },
                { 6, 11 },
            }
            );

        private SparseVector.SparseVector standartSecondSparseVector = new(
            7,
            new Dictionary<int, int>
            {
                { 0, 5 },
                { 3, 1 },
                { 2, 15 },
            }
            );


        [Test]
        public void AddTest()
        {
            standartFirstSparseVector.Add(standartSecondSparseVector);
            var resultCoordinates = new Dictionary<int, int>
            {
                { 0, 13 },
                { 3, 5 },
                { 2, 15 },
                { 6, 11 },
            };
            Assert.AreEqual(resultCoordinates, standartFirstSparseVector.Coordinates);

        }
    }
}