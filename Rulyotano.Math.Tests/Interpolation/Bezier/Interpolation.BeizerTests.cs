using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rulyotano.Math.Geometry;
using System.Linq;

namespace Rulyotano.Math.Tests.Interpolation.Bezier
{
    [TestClass]
    public class InterpolationBezierTests
    {
        #region PoinsToBezierCurves
        private Point[] samplePoints1 = new[] { new Point(0, 0), new Point(300, -100), new Point(15, 66) };

        [TestMethod("InterpolatePointWithBezierCurves should begins and ends in initial and ending points")]
        public void InterpolatePointWithBezierCurvesShouldStartAndEndsSamePoints()
        {
            var result = Math.Interpolation.PointsToBezierCurves(samplePoints1.ToList(), false);

            Assert.AreEqual(samplePoints1.First(), result.First().StartPoint);
            Assert.AreEqual(samplePoints1.Last(), result.Last().EndPoint);
        }

        [TestMethod("InterpolatePointWithBezierCurves when closed curve should ends with start point")]
        public void InterpolatePointWithBezierCurvesWhenClosedShouldEndWithStartPoint()
        {
            var result = Math.Interpolation.PointsToBezierCurves(samplePoints1.ToList(), true);

            Assert.AreEqual(samplePoints1.First(), result.First().StartPoint);
            Assert.AreEqual(samplePoints1.First(), result.Last().EndPoint);
        }

        [TestMethod("InterpolatePointWithBezierCurves when less than 3 points should return null")]
        public void InterpolatePointWithBezierCurvesWhenLLessThan3PointsShouldReturnNull()
        {
            var result = Math.Interpolation.PointsToBezierCurves(samplePoints1.Take(2).ToList(), false);

            Assert.IsNull(result);
        }

        private void RunTestCase(TestCaseBezier testCase)
        {
            var result = testCase.Smooth.HasValue
                ? Math.Interpolation.PointsToBezierCurves(testCase.InputPoints, testCase.IsClosed, testCase.Smooth.Value)
                : Math.Interpolation.PointsToBezierCurves(testCase.InputPoints, testCase.IsClosed);

            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(testCase.ExpectedOutput[i], result[i]);
            }
        }

        [TestMethod("Test case 1. Open")]
        public void TestCase1ShouldReturnSameResult()
        {
            var testCase = TestDataBezier.TestCas1;
            RunTestCase(testCase);
        }

        [TestMethod("Test case 2. Closed")]
        public void TestCase2ShouldReturnSameResult()
        {
            var testCase = TestDataBezier.TestCas2;
            RunTestCase(testCase);
        }

        [TestMethod("Test case 3. Smooth value.")]
        public void TestCase3ShouldReturnSameResult()
        {
            var testCase = TestDataBezier.TestCas3;
            RunTestCase(testCase);
        }
        #endregion
    }
}
