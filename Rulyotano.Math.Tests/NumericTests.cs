using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rulyotano.Math.Tests
{
    [TestClass]
    public class NumericTests
    {
        [TestMethod("FloatEquals should return true when less than epsilon and false otherwise")]
        [DataRow(0.345f, 0.34500000001f, true)]
        [DataRow(0.345f, 0.347f, false)]
        [DataRow(1.345f, 1.3f, false)]
        [DataRow(0.3f, 0.3f, true)]
        [DataRow(float.PositiveInfinity, float.PositiveInfinity, true)]
        [DataRow(float.NegativeInfinity, float.NegativeInfinity, true)]
        [DataRow(float.NaN, float.NaN, true)]
        [DataTestMethod]
        public void FloatEqualsWhenEquals(float n1, float n2, bool expected)
        {
            Assert.AreEqual(expected, Numeric.FloatEquals(n1, n2));
            Assert.AreEqual(expected, Numeric.FloatEquals(n1, n2, Numeric.Epsilon));
        }

        [TestMethod("DoubleEquals should return true when less than epsilon and false otherwise")]
        [DataRow(0.345, 0.34500000001, true)]
        [DataRow(0.345, 0.347, false)]
        [DataRow(1.345, 1.3, false)]
        [DataRow(0.3, 0.3, true)]
        [DataRow(double.PositiveInfinity, double.PositiveInfinity, true)]
        [DataRow(double.NegativeInfinity, double.NegativeInfinity, true)]
        [DataRow(double.NaN, double.NaN, true)]
        [DataTestMethod]
        public void DoubleEqualsWhenEquals(double n1, double n2, bool expected)
        {
            Assert.AreEqual(expected, Numeric.DoubleEquals(n1, n2));
            Assert.AreEqual(expected, Numeric.DoubleEquals(n1, n2, Numeric.Epsilon));
        }

        [TestMethod("Middle value, should return it")]
        [DataRow(0, 1)]
        [DataRow(3, 9)]
        [DataRow(2.5, 6.5)]
        public void Middle(double value1, double value2)
        {
            var expected = (value1 + value2) / 2.0;
            Assert.IsTrue(Numeric.DoubleEquals(expected, Numeric.Middle(value1, value2)));
        }
    }
}
