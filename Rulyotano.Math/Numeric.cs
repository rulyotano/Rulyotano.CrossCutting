namespace Rulyotano.Math
{
    public static class Numeric
    {
        public const double Epsilon = 0.00001;

        /// <summary>
        /// Equal function between two doubles
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public static bool DoubleEquals(double d1, double d2, double error = Epsilon)
        {
            if (double.IsNegativeInfinity(d1) && double.IsNegativeInfinity(d2) || double.IsPositiveInfinity(d1) && double.IsPositiveInfinity(d2) || double.IsNaN(d1) && double.IsNaN(d2))
                return true;
            return System.Math.Abs(d1 - d2) < error;
        }

        /// <summary>
        /// Equal function between two float values
        /// </summary>
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public static bool FloatEquals(float f1, float f2, double error = Epsilon)
        {
            if (float.IsNegativeInfinity(f1) && float.IsNegativeInfinity(f2) || float.IsPositiveInfinity(f1) && float.IsPositiveInfinity(f2) || float.IsNaN(f1) && float.IsNaN(f2))
                return true;
            return System.Math.Abs(f1 - f2) < error;
        }

        /// <summary>
        /// Middle distance between two values
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public static double Middle(double value1, double value2)
        {
            return (value1 + value2) / 2.0;
        }
    }
}
