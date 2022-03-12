using Xunit;

namespace Rulyotano.Math.Tests
{
    public class NumericTests
    {
        [Theory]
        [InlineData(0.345f, 0.34500000001f, true)]
        [InlineData(0.345f, 0.347f, false)]
        [InlineData(1.345f, 1.3f, false)]
        [InlineData(0.3f, 0.3f, true)]
        [InlineData(float.PositiveInfinity, float.PositiveInfinity, true)]
        [InlineData(float.NegativeInfinity, float.NegativeInfinity, true)]
        [InlineData(float.NaN, float.NaN, true)]
        public void WhenLessThanEpsilon_FloatEquals_Should_ReturnTrue(float n1, float n2, bool expected)
        {
            Assert.Equal(expected, Numeric.FloatEquals(n1, n2));
            Assert.Equal(expected, Numeric.FloatEquals(n1, n2, Numeric.Epsilon));
        }

        [Theory]
        [InlineData(0.345, 0.34500000001, true)]
        [InlineData(0.345, 0.347, false)]
        [InlineData(1.345, 1.3, false)]
        [InlineData(0.3, 0.3, true)]
        [InlineData(double.PositiveInfinity, double.PositiveInfinity, true)]
        [InlineData(double.NegativeInfinity, double.NegativeInfinity, true)]
        [InlineData(double.NaN, double.NaN, true)]
        public void WhenLessThanEpsilon_DoubleEquals_Should_ReturnTrue(double n1, double n2, bool expected)
        {
            Assert.Equal(expected, Numeric.DoubleEquals(n1, n2));
            Assert.Equal(expected, Numeric.DoubleEquals(n1, n2, Numeric.Epsilon));
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(3, 9)]
        [InlineData(2.5, 6.5)]
        public void Middle_Should_ReturnMiddleValue(double value1, double value2)
        {
            var expected = (value1 + value2) / 2.0;
            Assert.True(Numeric.DoubleEquals(expected, Numeric.Middle(value1, value2)));
        }
    }
}
