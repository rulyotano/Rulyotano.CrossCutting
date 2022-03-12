using Rulyotano.Math.Geometry;
using System.Collections.Generic;
using System.Linq;

namespace Rulyotano.Math.Interpolation.Bezier
{
    public static class BezierInterpolation
    {
        /// <summary>
        /// Interpolate a list of points to a list of ordered Bezier curve segments
        /// </summary>
        /// <param name="points"></param>
        /// <param name="isClosedCurve">True if is a closed curve</param>
        /// <param name="smoothValue">Optional value for making the curve smoother or not</param>
        /// <returns></returns>
        public static IList<BezierCurveSegment> PointsToBezierCurves(IList<Point> points, bool isClosedCurve, double smoothValue = 0.8)
        {
            if (points.Count < 3)
                return new List<BezierCurveSegment>();

            var toRet = new List<BezierCurveSegment>();

            //if is close curve then add the first point at the end
            if (isClosedCurve)
                points.Add(points.First());

            for (var i = 0; i < points.Count - 1; i++)   //iterate for points but the last one
            {
                // Assume we need to calculate the control
                // points between (x1,y1) and (x2,y2).
                // Then x0,y0 - the previous vertex,
                //      x3,y3 - the next one.
                var x1 = points[i].X;
                var y1 = points[i].Y;

                var x2 = points[i + 1].X;
                var y2 = points[i + 1].Y;

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
                    else    //Get some previous point
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

                var xc1 = Numeric.Middle(x0, x1);
                var yc1 = Numeric.Middle(y0, y1);
                var xc2 = Numeric.Middle(x1, x2);
                var yc2 = Numeric.Middle(y1, y2);
                var xc3 = Numeric.Middle(x2, x3);
                var yc3 = Numeric.Middle(y2, y3);

                var len1 = Helpers.EuclideanDistance(x0, y0, x1, y1);
                var len2 = Helpers.EuclideanDistance(x1, y1, x2, y2);
                var len3 = Helpers.EuclideanDistance(x2, y2, x3, y3);

                var k1 = len1 / (len1 + len2);
                var k2 = len2 / (len2 + len3);

                var xm1 = xc1 + (xc2 - xc1) * k1;
                var ym1 = yc1 + (yc2 - yc1) * k1;

                var xm2 = xc2 + (xc3 - xc2) * k2;
                var ym2 = yc2 + (yc3 - yc2) * k2;

                // Resulting control points. Here smooth_value is mentioned
                // above coefficient K whose value should be in range [0...1].
                var ctrl1X = xm1 + (xc2 - xm1) * smoothValue + x1 - xm1;
                var ctrl1Y = ym1 + (yc2 - ym1) * smoothValue + y1 - ym1;

                var ctrl2X = xm2 + (xc2 - xm2) * smoothValue + x2 - xm2;
                var ctrl2Y = ym2 + (yc2 - ym2) * smoothValue + y2 - ym2;
                toRet.Add(new BezierCurveSegment
                (
                    startPoint: new Point(x1, y1),
                    endPoint: new Point(x2, y2),
                    firstControlPoint:i == 0 && !isClosedCurve ? new Point(x1, y1) : new Point(ctrl1X, ctrl1Y),
                    secondControlPoint: i == points.Count - 2 && !isClosedCurve ? new Point(x2, y2) : new Point(ctrl2X, ctrl2Y)
                ));
            }

            return toRet;
        }
    }
}
