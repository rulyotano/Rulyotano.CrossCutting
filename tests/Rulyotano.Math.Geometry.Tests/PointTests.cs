using Xunit;
using Rulyotano.Math.Geometry;

namespace Rulyotano.Math.Tests.Geometry
{
    public class PointTests
    {
        const double FakeX = 3.4;
        const double FakeY = 9.3;

        [Fact]
        public void Constructor_Should_InitializeXandY()
        {
            var newPoint = new Point(FakeX, FakeY);

            Assert.Equal(FakeX, newPoint.X);
            Assert.Equal(FakeY, newPoint.Y);
        }

        [Theory]
        [InlineData(0, 1, 0, 1, true)]
        [InlineData(2, 1, 0, 1, false)]
        [InlineData(0, 1, 2, 1, false)]
        [InlineData(0, 2, 0, 1, false)]
        [InlineData(0, 1, 0, 2, false)]
        [InlineData(0.000000001, 1.000000001, 0, 1, true)]
        public void When_XandYAreQueal_Should_BeEqual(double x1, double y1, double x2, double y2, bool expected)
        {
            Assert.Equal(expected, new Point(x1, y1).Equals(new Point(x2, y2)));
        }
    }
}
