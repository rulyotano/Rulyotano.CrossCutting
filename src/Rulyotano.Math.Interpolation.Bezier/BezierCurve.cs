using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Rulyotano.Math.Interpolation.Bezier
{
    public class BezierCurve
    {
        public BezierCurve(IEnumerable<BezierCurveSegment> segments)
        {
            Segments = segments;
        }

        public IEnumerable<BezierCurveSegment> Segments { get; }

        public string ToPath()
        {
            var builder = new StringBuilder();
            Func<double, string> round = n => System.Math.Round(n, 3).ToString(CultureInfo.InvariantCulture);

            if (Segments.Any())
            {
                var head = Segments.First();
                builder.Append($"M{round(head.StartPoint.X)},{round(head.StartPoint.Y)}");

                foreach (var item in Segments)
                {
                    builder.Append($" C{round(item.FirstControlPoint.X)},{round(item.FirstControlPoint.Y)} {round(item.SecondControlPoint.X)},{round(item.SecondControlPoint.Y)} {round(item.EndPoint.X)},{round(item.EndPoint.Y)}");
                }
            }

            return builder.ToString();
        }
    }
}
