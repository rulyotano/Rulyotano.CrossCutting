using Xunit;
using Rulyotano.Math.Geometry;
using Rulyotano.Math.Interpolation.Bezier;

namespace Rulyotano.Math.Interpolation.Bezier.Tests
{
    public class InterpolationBezierCurveSegmentTests
    {
        private readonly Point[] _testPoints = new[] {
            new Point(12, 33),
            new Point(1.43111111, 2),
            new Point(4, 2),
            new Point(5, 30)
        };

        [Fact]
        public void Constructor_Should_InitializeThePointsInOrder_Start_FirstControl_SecondControl_And_Endpoint()
        {
            var result = new BezierCurveSegment(_testPoints[0], _testPoints[1], _testPoints[2], _testPoints[3]);
            Assert.Equal(_testPoints[0], result.StartPoint);
            Assert.Equal(_testPoints[1], result.FirstControlPoint);
            Assert.Equal(_testPoints[2], result.SecondControlPoint);
            Assert.Equal(_testPoints[3], result.EndPoint);
        }

        #region Equals
        [Fact]
        public void WhenAllPointsAreEqual_Equals_Should_ReturnTrue()
        {
            var curve1 = new BezierCurveSegment(_testPoints[0], _testPoints[1], _testPoints[2], _testPoints[3]);
            var curve2 = new BezierCurveSegment(_testPoints[0], _testPoints[1], _testPoints[2], _testPoints[3]);

            Assert.Equal(curve1, curve2);
        }

        [Fact]
        public void WhenStartPointIsDifferent_Equals_Should_ReturnFalse()
        {
            var curve1 = new BezierCurveSegment(_testPoints[0], _testPoints[1], _testPoints[2], _testPoints[3]);
            var curve2 = new BezierCurveSegment(new Point(0, 0), _testPoints[1], _testPoints[2], _testPoints[3]);

            Assert.NotEqual(curve1, curve2);
        }

        [Fact]
        public void WhenFirstControlPointIsDifferent_Equals_Should_ReturnFalse()
        {
            var curve1 = new BezierCurveSegment(_testPoints[0], _testPoints[1], _testPoints[2], _testPoints[3]);
            var curve2 = new BezierCurveSegment(_testPoints[0], new Point(0, 0), _testPoints[2], _testPoints[3]);

            Assert.NotEqual(curve1, curve2);
        }

        [Fact]
        public void WhenSecondControlPointIsDifferent_Equals_Should_ReturnFalse()
        {
            var curve1 = new BezierCurveSegment(_testPoints[0], _testPoints[1], _testPoints[2], _testPoints[3]);
            var curve2 = new BezierCurveSegment(_testPoints[0], _testPoints[1], new Point(0, 0), _testPoints[3]);

            Assert.NotEqual(curve1, curve2);
        }

        [Fact]
        public void WhenLastPointIsDifferent_Equals_Should_ReturnFalse()
        {
            var curve1 = new BezierCurveSegment(_testPoints[0], _testPoints[1], _testPoints[2], _testPoints[3]);
            var curve2 = new BezierCurveSegment(_testPoints[0], _testPoints[1], _testPoints[2], new Point(0, 0));

            Assert.NotEqual(curve1, curve2);
        }

        [Fact]
        public void WhenAnyOtherType_Equals_Should_ReturnFalse()
        {
            var curve1 = new BezierCurveSegment(_testPoints[0], _testPoints[1], _testPoints[2], _testPoints[3]);

            Assert.False(curve1.Equals(""));
        }
        #endregion

    }
}
