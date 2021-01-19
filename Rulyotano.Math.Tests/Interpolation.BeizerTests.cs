using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rulyotano.Math.Geometry;
using System.Linq;

namespace Rulyotano.Math.Tests
{
    [TestClass]
    public class InterpolationBeizerTests
    {
        #region PoinsToBeizerCurves
        private Point[] samplePoints1 = new[] { new Point(0, 0), new Point(300, -100), new Point(15, 66) };

        [TestMethod("InterpolatePointWithBeizerCurves should begins and ends in initial and ending points")]
        public void InterpolatePointWithBeizerCurvesShouldStartAndEndsSamePoints()
        {
            var result = Interpolation.PoinsToBeizerCurves(samplePoints1.ToList(), false);

            Assert.AreEqual(samplePoints1.First(), result.First().StartPoint);
            Assert.AreEqual(samplePoints1.Last(), result.Last().EndPoint);
        }

        [TestMethod("InterpolatePointWithBeizerCurves when closed curve should ends with start point")]
        public void InterpolatePointWithBeizerCurvesWhenClosedShouldEndWithStartPoint()
        {
            var result = Interpolation.PoinsToBeizerCurves(samplePoints1.ToList(), true);

            Assert.AreEqual(samplePoints1.First(), result.First().StartPoint);
            Assert.AreEqual(samplePoints1.First(), result.Last().EndPoint);
        }

        [TestMethod("InterpolatePointWithBeizerCurves when less than 3 points should return null")]
        public void InterpolatePointWithBeizerCurvesWhenLLessThan3PointsShouldReturnNull()
        {
            var result = Interpolation.PoinsToBeizerCurves(samplePoints1.Take(2).ToList(), false);

            Assert.IsNull(result);
        }

        private void RunTestCase(TestCaseBeizer testCase)
        {
            var result = testCase.Smooth.HasValue
                ? Interpolation.PoinsToBeizerCurves(testCase.InputPoints, testCase.IsClosed, testCase.Smooth.Value)
                : Interpolation.PoinsToBeizerCurves(testCase.InputPoints, testCase.IsClosed);

            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(testCase.ExpectedOutput[i], result[i]);
            }
        }

        [TestMethod("Test case 1. Open")]
        public void TestCase1ShouldReturnSameResult()
        {
            var testCase = TestDataBeizer.TestCas1;
            RunTestCase(testCase);
        }

        [TestMethod("Test case 2. Closed")]
        public void TestCase2ShouldReturnSameResult()
        {
            var testCase = TestDataBeizer.TestCas2;
            RunTestCase(testCase);
        }

        [TestMethod("Test case 3. Smooth value.")]
        public void TestCase3ShouldReturnSameResult()
        {
            var testCase = TestDataBeizer.TestCas3;
            RunTestCase(testCase);
        }
        #endregion
    }
}
