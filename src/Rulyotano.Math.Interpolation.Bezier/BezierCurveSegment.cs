using Rulyotano.Math.Geometry;

namespace Rulyotano.Math.Interpolation.Bezier
{
    public class BezierCurveSegment
    {
        public BezierCurveSegment()
        {

        }

        public BezierCurveSegment(Point startPoint, Point firstControlPoint, Point secondControlPoint, Point endPoint)
        {
            StartPoint = startPoint;
            FirstControlPoint = firstControlPoint;
            SecondControlPoint = secondControlPoint;
            EndPoint = endPoint;
        }

        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public Point FirstControlPoint { get; set; }
        public Point SecondControlPoint { get; set; }

        public override bool Equals(object obj)
        {
            var otherCurve = obj as BezierCurveSegment;
            if (otherCurve == null)
                return false;

            return otherCurve.StartPoint.Equals(StartPoint)
                && otherCurve.FirstControlPoint.Equals(FirstControlPoint)
                && otherCurve.SecondControlPoint.Equals(SecondControlPoint)
                && otherCurve.EndPoint.Equals(EndPoint);
        }

        public override int GetHashCode()
        {
            return StartPoint.GetHashCode() << 5 + EndPoint.GetHashCode() << 10 +
              FirstControlPoint.GetHashCode() << 15 + SecondControlPoint.GetHashCode() << 20;
        }
    }
}
