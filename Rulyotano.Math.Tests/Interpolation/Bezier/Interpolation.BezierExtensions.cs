using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Rulyotano.Math.Tests.Interpolation.Bezier
{

    [TestClass]
    public class InterpolationExtensionsBezierTests
    {
        [TestMethod("BezierToPath empty should return empty string")]
        public void BezierToPathEmpty()
        {
            var list = new List<BezierCurveSegment> { };

            var result = list.BezierToPath();
            Assert.AreEqual("", result);
        }

        [TestMethod("BezierToPath basic example (one item with integer values)")]
        public void BezierToPathBasic()
        {
            var list = new List<BezierCurveSegment>
            {
                new BezierCurveSegment(
                    new Math.Geometry.Point(1, 2),
                    new Math.Geometry.Point(3, 4),
                    new Math.Geometry.Point(5, 6),
                    new Math.Geometry.Point(7, 8))
            };

            var result = list.BezierToPath();
            Assert.AreEqual("M1,2 C3,4 5,6 7,8", result);
        }

        [TestMethod("BezierToPath several items, should concatenate segments")]
        public void BezierToPathTwoSegmentsIntegerValues()
        {
            var list = new List<BezierCurveSegment>
            {
                new BezierCurveSegment(
                    new Math.Geometry.Point(1, 2),
                    new Math.Geometry.Point(3, 4),
                    new Math.Geometry.Point(5, 6),
                    new Math.Geometry.Point(7, 8)),

                new BezierCurveSegment(
                    new Math.Geometry.Point(7, 8),
                    new Math.Geometry.Point(9, 10),
                    new Math.Geometry.Point(11, 12),
                    new Math.Geometry.Point(13, 14))
            };

            var result = list.BezierToPath();
            Assert.AreEqual("M1,2 C3,4 5,6 7,8 C9,10 11,12 13,14", result);
        }

        [TestMethod("BezierToPath with float values should round up to 3 decimals")]
        public void BezierToPathFloatValues()
        {
            var list = new List<BezierCurveSegment>
            {
                new BezierCurveSegment(
                    new Math.Geometry.Point(1, 2.4357),
                    new Math.Geometry.Point(3.15434534, 4.231),
                    new Math.Geometry.Point(5.776, 6.8954244),
                    new Math.Geometry.Point(7.199999, 8.111111))
            };

            var result = list.BezierToPath();
            Assert.AreEqual("M1,2.436 C3.154,4.231 5.776,6.895 7.2,8.111", result);
        }

        [TestMethod("BezierToPath with negative values should works")]
        public void BezierToPathNegativeValues()
        {
            var list = new List<BezierCurveSegment>
            {
                new BezierCurveSegment(
                    new Math.Geometry.Point(-1, 2.4357),
                    new Math.Geometry.Point(-3.15434534, 4.231),
                    new Math.Geometry.Point(5.776, -6.8954244),
                    new Math.Geometry.Point(7.199999, -8.111111))
            };

            var result = list.BezierToPath();
            Assert.AreEqual("M-1,2.436 C-3.154,4.231 5.776,-6.895 7.2,-8.111", result);
        }
    }
}
