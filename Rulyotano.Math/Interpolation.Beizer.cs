using Rulyotano.Math.Geometry;
using System.Collections.Generic;
using System.Linq;

namespace Rulyotano.Math
{
    public static partial class Interpolation
    {
        /// <summary>
        /// Interpolate a list of points to a list of ordered Beizer curve segments
        /// </summary>
        /// <param name="points"></param>
        /// <param name="isClosedCurve">True if is a closed curve</param>
        /// <param name="smoothValue">Optional value for making the curve smoother or not</param>
        /// <returns></returns>
        public static IList<BeizerCurveSegment> PoinsToBeizerCurves(IList<Point> points, bool isClosedCurve, double smoothValue = 0.8)
        {
            if (points.Count < 3)
                return null;
            var toRet = new List<BeizerCurveSegment>();

            //if is close curve then add the first point at the end
            if (isClosedCurve)
                points.Add(points.First());

            for (int i = 0; i < points.Count - 1; i++)   //iterate for points but the last one
            {
                // Assume we need to calculate the control
                // points between (x1,y1) and (x2,y2).
                // Then x0,y0 - the previous vertex,
                //      x3,y3 - the next one.
                double x1 = points[i].X;
                double y1 = points[i].Y;

                double x2 = points[i + 1].X;
                double y2 = points[i + 1].Y;

                double x0;
                double y0;

                if (i == 0) //if is first point
                {
                    if (isClosedCurve)
                    {
                        var previousPoint = points[points.Count - 2];    //last Point, but one (due inserted the first at the end)
                        x0 = previousPoint.X;
                        y0 = previousPoint.Y;
                    }
                    else    //Get some previouse point
                    {
                        var previousPoint = points[i];  //if is the first point the previous one will be it self
                        x0 = previousPoint.X;
                        y0 = previousPoint.Y;
                    }
                }
                else
                {
                    x0 = points[i - 1].X;   //Previous Point
                    y0 = points[i - 1].Y;
                }

                double x3, y3;

                if (i == points.Count - 2)    //if is the last point
                {
                    if (isClosedCurve)
                    {
                        var nextPoint = points[1];  //second Point(due inserted the first at the end)
                        x3 = nextPoint.X;
                        y3 = nextPoint.Y;
                    }
                    else    //Get some next point
                    {
                        var nextPoint = points[i + 1];  //if is the last point the next point will be the last one
                        x3 = nextPoint.X;
                        y3 = nextPoint.Y;
                    }
                }
                else
                {
                    x3 = points[i + 2].X;   //Next Point
                    y3 = points[i + 2].Y;
                }

                double xc1 = Numeric.Middle(x0, x1);
                double yc1 = Numeric.Middle(y0, y1);
                double xc2 = Numeric.Middle(x1, x2);
                double yc2 = Numeric.Middle(y1, y2);
                double xc3 = Numeric.Middle(x2, x3);
                double yc3 = Numeric.Middle(y2, y3);

                double len1 = Helpers.EuclideanDistance(x0, y0, x1, y1);
                double len2 = Helpers.EuclideanDistance(x1, y1, x2, y2);
                double len3 = Helpers.EuclideanDistance(x2, y2, x3, y3);

                double k1 = len1 / (len1 + len2);
                double k2 = len2 / (len2 + len3);

                double xm1 = xc1 + (xc2 - xc1) * k1;
                double ym1 = yc1 + (yc2 - yc1) * k1;

                double xm2 = xc2 + (xc3 - xc2) * k2;
                double ym2 = yc2 + (yc3 - yc2) * k2;

                // Resulting control points. Here smooth_value is mentioned
                // above coefficient K whose value should be in range [0...1].
                double ctrl1_x = xm1 + (xc2 - xm1) * smoothValue + x1 - xm1;
                double ctrl1_y = ym1 + (yc2 - ym1) * smoothValue + y1 - ym1;

                double ctrl2_x = xm2 + (xc2 - xm2) * smoothValue + x2 - xm2;
                double ctrl2_y = ym2 + (yc2 - ym2) * smoothValue + y2 - ym2;
                toRet.Add(new BeizerCurveSegment
                {
                    StartPoint = new Point(x1, y1),
                    EndPoint = new Point(x2, y2),
                    FirstControlPoint = i == 0 && !isClosedCurve ? new Point(x1, y1) : new Point(ctrl1_x, ctrl1_y),
                    SecondControlPoint = i == points.Count - 2 && !isClosedCurve ? new Point(x2, y2) : new Point(ctrl2_x, ctrl2_y)
                });
            }

            return toRet;
        }
    }

    public class BeizerCurveSegment
    {
        public BeizerCurveSegment()
        {

        }

        public BeizerCurveSegment(Point startPoint, Point firstControlPoint, Point secondControlPoint, Point endPoint)
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
            var otherCurve = obj as BeizerCurveSegment;
            if (otherCurve == null)
                return false;

            return otherCurve.StartPoint.Equals(StartPoint)
                && otherCurve.FirstControlPoint.Equals(FirstControlPoint)
                && otherCurve.SecondControlPoint.Equals(SecondControlPoint)
                && otherCurve.EndPoint.Equals(EndPoint);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
