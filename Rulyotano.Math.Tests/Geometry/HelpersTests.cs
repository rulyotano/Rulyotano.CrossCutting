using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rulyotano.Math.Geometry;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rulyotano.Math.Tests.Geometry
{
    [TestClass]
    public class HelpersTests
    {
        #region EuclideanDistance
        [TestMethod("Euclidean should give results according to Sqrt(dx^2 + dy^2)")]
        [DataRow(0, 0, 3, 3)]
        [DataRow(1, 7, 1, 7)]
        [DataRow(1, 0.9, 20, 7)]
        [DataRow(0, 0, 10, 0)]
        [DataRow(-10, 5, 5, 8)]
        [DataRow(3, 0.54544, 1, 9)]
        public void EuclideanDistance(double x1, double y1, double x2, double y2)
        {
            var point1 = new Point(x1, y1);
            var point2 = new Point(x2, y2);

            var expected = System.Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1)); ;
            Assert.IsTrue(Numeric.DoubleEquals(expected, Helpers.EuclideanDistance(point1, point2)));
            Assert.IsTrue(Numeric.DoubleEquals(expected, Helpers.EuclideanDistance(x1, y1, x2, y2)));
        }
        #endregion

        #region Converters between radians and degree
        [TestMethod("RadianToDegreeConvert should return according to (180*radian)/PI")]
        [DataRow(3)]
        [DataRow(1)]
        [DataRow(0.6f)]
        [DataRow(0.2f)]
        [DataTestMethod]
        public void RadianToDegreeConvertShouldReturnAccordingToFormula(float n)
        {
            var expected = (float)((n * 180) / System.Math.PI);
            Assert.IsTrue(Numeric.FloatEquals(expected, Helpers.RadianToDegreeConvert(n)));
        }

        [TestMethod("DegreeToRadianConvert should return according to (degree*PI)/180")]
        [DataRow(180)]
        [DataRow(90)]
        [DataRow(30)]
        [DataRow(0.5)]
        [DataRow(330)]
        [DataTestMethod]
        public void DegreeToRadianConvertShouldReturnAccordingToFormula(double n)
        {
            var expected = (n * System.Math.PI) / 180f;
            Assert.IsTrue(Numeric.DoubleEquals(expected, Helpers.DegreeToRadianConvert(n)));
        } 
        #endregion

        #region BestPlaceToInsert

        [TestMethod("BestPlaceToInsert - Should insert at start when array is empty")]
        public void BestPlaceToInsertInsertAtStart()
        {
            var newPoint = new Point(3, 4);
            var list = new List<Point>();

            var result = Helpers.BestPlaceToInsert(newPoint, list);
            Assert.AreEqual(0, result);
        }

        [TestMethod("BestPlaceToInsert - Should insert at the end when array has one item")]
        public void BestPlaceToInsertInsertAtTheEndWhenOnlyOne()
        {
            var newPoint = new Point(3, 4);
            var list = new List<Point> { new Point(10, 5) };

            var result = Helpers.BestPlaceToInsert(newPoint, list);
            Assert.AreEqual(1, result);
        }

        [TestMethod("BestPlaceToInsert - when two items and nearest to first, insert at start")]
        public void BestPlaceToInsertInsertAtStartWhenTwoItems()
        {
            var newPoint = new Point(3, 0);
            var list = new List<Point> { new Point(10, 0), new Point(50, 0) };

            var result = Helpers.BestPlaceToInsert(newPoint, list);
            Assert.AreEqual(0, result);
        }

        [TestMethod("BestPlaceToInsert - when two items and nearest to the latest, insert at end")]
        public void BestPlaceToInsertInsertAtMiddleWhenTwoItems()
        {
            var newPoint = new Point(70, 0);
            var list = new List<Point> { new Point(40, 0), new Point(50, 0) };

            var result = Helpers.BestPlaceToInsert(newPoint, list);
            Assert.AreEqual(list.Count, result);
        }

        [TestMethod("BestPlaceToInsert - when four items and nearest, insert at correct index")]
        public void BestPlaceToInsertInsertAtMiddleWhenFourItems()
        {
            var newPoint = new Point(45, 0);
            var list = new List<Point> { new Point(38, 0), new Point(39, 0), new Point(40, 0), new Point(50, 0) };

            var result = Helpers.BestPlaceToInsert(newPoint, list);
            Assert.AreEqual(3, result);
        }

        #endregion
    }
}
