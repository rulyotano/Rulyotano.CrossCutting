using Xunit;
using Rulyotano.Math.Geometry;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rulyotano.Math.Tests.Geometry
{
    public class HelpersTests
    {
        #region EuclideanDistance
        [Theory]
        [InlineData(0, 0, 3, 3)]
        [InlineData(1, 7, 1, 7)]
        [InlineData(1, 0.9, 20, 7)]
        [InlineData(0, 0, 10, 0)]
        [InlineData(-10, 5, 5, 8)]
        [InlineData(3, 0.54544, 1, 9)]
        public void EuclideanDistance_Should_GiveResultAccordingToEuclideanDistanceFormula(double x1, double y1, double x2, double y2)
        {
            const string formula = "Sqrt(dx^2 + dy^2)";
            var point1 = new Point(x1, y1);
            var point2 = new Point(x2, y2);

            var expected = System.Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            Assert.True(Numeric.DoubleEquals(expected, Helpers.EuclideanDistance(point1, point2)), $"When two points: formula = {formula}");
            Assert.True(Numeric.DoubleEquals(expected, Helpers.EuclideanDistance(x1, y1, x2, y2)), $"When 4 coordinates: formula = {formula}");
        }
        #endregion

        #region Converters between radians and degree
        [Theory]
        [InlineData(3)]
        [InlineData(1)]
        [InlineData(0.6f)]
        [InlineData(0.2f)]
        public void RadianToDegreeConvert_Should_ReturnAccordingToFormula(float n)
        {
            const string formula = "(180*radian)/PI";
            var expected = (float)((n * 180) / System.Math.PI);
            Assert.True(Numeric.FloatEquals(expected, Helpers.RadianToDegreeConvert(n)), $"Formula = {formula}");
        }

        [Theory]
        [InlineData(180)]
        [InlineData(90)]
        [InlineData(30)]
        [InlineData(0.5)]
        [InlineData(330)]
        public void DegreeToRadianConvert_Should_ReturnAccordingToFormula(double n)
        {
            const string formula = "(degree*PI)/180";
            var expected = (n * System.Math.PI) / 180f;
            Assert.True(Numeric.DoubleEquals(expected, Helpers.DegreeToRadianConvert(n)), $"Formula = {formula}");
        } 
        #endregion

        #region BestPlaceToInsert

        [Fact]
        public void When_ArrayIsEmpty_BestPlaceToInsertInsert_Should_InsertAtStart()
        {
            var newPoint = new Point(3, 4);
            var list = new List<Point>();

            var result = Helpers.BestPlaceToInsert(newPoint, list);
            Assert.Equal(0, result);
        }

        [Fact]
        public void When_OnlyOne_BestPlaceToInsertInsert_Should_InsertAtTheEnd()
        {
            var newPoint = new Point(3, 4);
            var list = new List<Point> { new Point(10, 5) };

            var result = Helpers.BestPlaceToInsert(newPoint, list);
            Assert.Equal(1, result);
        }

        [Fact]
        public void When_TwoItemsAndNearestToFirstOne_BestPlaceToInsertInsert_Should_InsertAtStart()
        {
            var newPoint = new Point(3, 0);
            var list = new List<Point> { new Point(10, 0), new Point(50, 0) };

            var result = Helpers.BestPlaceToInsert(newPoint, list);
            Assert.Equal(0, result);
        }

        [Fact]
        public void When_TwoItemsAndNearestToTheLatestOne_BestPlaceToInsertInsert_Should_InsertAtTheEnd()
        {
            var newPoint = new Point(70, 0);
            var list = new List<Point> { new Point(40, 0), new Point(50, 0) };

            var result = Helpers.BestPlaceToInsert(newPoint, list);
            Assert.Equal(list.Count, result);
        }

        [Fact]
        public void WhenFourItemsAndNearest_BestPlaceToInsertInsert_ShouldInsertAtCorrectIndex()
        {
            const int expectedIndex = 3;
            var newPoint = new Point(45, 0);
            var list = new List<Point> { new Point(38, 0), new Point(39, 0), new Point(40, 0), new Point(50, 0) };

            var result = Helpers.BestPlaceToInsert(newPoint, list);
            Assert.Equal(expectedIndex, result);
        }

        #endregion
    }
}
