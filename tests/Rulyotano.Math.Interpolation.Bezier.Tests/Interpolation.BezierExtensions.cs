using Xunit;
using System.Collections.Generic;

namespace Rulyotano.Math.Interpolation.Bezier.Tests
{
    public class InterpolationExtensionsBezierTests
    {
        [Fact]
        public void WhenEmpty_BezierToPath_Should_ReturnEmpty()
        {
            var list = new List<BezierCurveSegment>();

            var result = list.BezierToPath();
            Assert.Equal("", result);
        }

        [Fact]
        public void WhenOneItemWithIntegerValues_BezierToPath_Should_MatchExpectedResult()
        {
            var list = new List<BezierCurveSegment>
            {
                new(
                    new Geometry.Point(1, 2),
                    new Geometry.Point(3, 4),
                    new Geometry.Point(5, 6),
                    new Geometry.Point(7, 8))
            };

            var result = list.BezierToPath();
            Assert.Equal("M1,2 C3,4 5,6 7,8", result);
        }

        [Fact]
        public void WhenSeveralItems_BezierToPath_Should_ConcatenateSegments()
        {
            var list = new List<BezierCurveSegment>
            {
                new(
                    new Geometry.Point(1, 2),
                    new Geometry.Point(3, 4),
                    new Geometry.Point(5, 6),
                    new Geometry.Point(7, 8)),

                new(
                    new Geometry.Point(7, 8),
                    new Geometry.Point(9, 10),
                    new Geometry.Point(11, 12),
                    new Geometry.Point(13, 14))
            };

            var result = list.BezierToPath();
            Assert.Equal("M1,2 C3,4 5,6 7,8 C9,10 11,12 13,14", result);
        }

        [Fact]
        public void WhenFloatValues_BezierToPath_Should_RoundUpTo3Decimals()
        {
            var list = new List<BezierCurveSegment>
            {
                new(
                    new Geometry.Point(1, 2.4357),
                    new Geometry.Point(3.15434534, 4.231),
                    new Geometry.Point(5.776, 6.8954244),
                    new Geometry.Point(7.199999, 8.111111))
            };

            var result = list.BezierToPath();
            Assert.Equal("M1,2.436 C3.154,4.231 5.776,6.895 7.2,8.111", result);
        }

        [Fact]
        public void WhenNegativeValues_BezierToPath_ShouldWorkOk()
        {
            var list = new List<BezierCurveSegment>
            {
                new(
                    new Geometry.Point(-1, 2.4357),
                    new Geometry.Point(-3.15434534, 4.231),
                    new Geometry.Point(5.776, -6.8954244),
                    new Geometry.Point(7.199999, -8.111111))
            };

            var result = list.BezierToPath();
            Assert.Equal("M-1,2.436 C-3.154,4.231 5.776,-6.895 7.2,-8.111", result);
        }
    }
}
