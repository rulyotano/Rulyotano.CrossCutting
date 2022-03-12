using Xunit;
using Rulyotano.Math.Geometry;
using Rulyotano.Math.Interpolation.Bezier;
using System.Linq;

namespace Rulyotano.Math.Interpolation.Bezier.Tests
{
    public class InterpolationBezierTests
    {
        #region PointsToBezierCurves
        private readonly Point[] samplePoints1 = new[] { new Point(0, 0), new Point(300, -100), new Point(15, 66) };

        [Fact]
        public void InterpolatePointWithBezierCurves_Should_StartAndEndsSamePoints()
        {
            var result = BezierInterpolation.PointsToBezierCurves(samplePoints1.ToList(), false);

            Assert.Equal(samplePoints1.First(), result.First().StartPoint);
            Assert.Equal(samplePoints1.Last(), result.Last().EndPoint);
        }

        [Fact]
        public void WhenClosedCurves_InterpolatePointWithBezierCurves_Should_EndsWithStartPoint()
        {
            var result = BezierInterpolation.PointsToBezierCurves(samplePoints1.ToList(), true);

            Assert.Equal(samplePoints1.First(), result.First().StartPoint);
            Assert.Equal(samplePoints1.First(), result.Last().EndPoint);
        }

        [Fact]
        public void WhenLessThan3Points_InterpolatePointWithBezierCurves_ShouldReturnEmptyList()
        {
            var result = BezierInterpolation.PointsToBezierCurves(samplePoints1.Take(2).ToList(), false);

            Assert.Empty(result);
        }

        private void RunTestCase(TestCaseBezier testCase)
        {
            var result = testCase.Smooth.HasValue
                ? BezierInterpolation.PointsToBezierCurves(testCase.InputPoints, testCase.IsClosed, testCase.Smooth.Value)
                : BezierInterpolation.PointsToBezierCurves(testCase.InputPoints, testCase.IsClosed);

            for (int i = 0; i < result.Count; i++)
            {
                Assert.Equal(testCase.ExpectedOutput[i], result[i]);
            }
        }

        [Fact]
        public void WhenTestCase1_Should_ReturnSameResult()
        {
            var testCase = TestDataBezier.TestCas1;
            RunTestCase(testCase);
        }

        [Fact]
        public void WhenTestCase2_Should_ReturnSameResult()
        {
            var testCase = TestDataBezier.TestCas2;
            RunTestCase(testCase);
        }

        [Fact]
        public void WhenTestCase3_Should_ReturnSameResult()
        {
            var testCase = TestDataBezier.TestCas3;
            RunTestCase(testCase);
        }
        #endregion
    }
}
