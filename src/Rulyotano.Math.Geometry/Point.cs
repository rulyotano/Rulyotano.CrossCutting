namespace Rulyotano.Math.Geometry
{
    public class Point
    {
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; }

        public double Y { get; }

        public override bool Equals(object obj)
        {
            if (!(obj is Point point)) return false;

            return Numeric.DoubleEquals(X, point.X) && Numeric.DoubleEquals(Y, point.Y);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() << 10 + Y.GetHashCode();
        }
    }
}
