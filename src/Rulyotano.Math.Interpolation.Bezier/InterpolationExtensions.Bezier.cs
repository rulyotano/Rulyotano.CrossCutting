using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Rulyotano.Math.Interpolation.Bezier
{
    public static class InterpolationExtensionsBezier
    {
        public static string BezierToPath(this IEnumerable<BezierCurveSegment> bezierPaths)
        {
            var builder = new StringBuilder();
            Func<double, string> round = n => System.Math.Round(n, 3).ToString(CultureInfo.InvariantCulture);

            if (bezierPaths.Any())
            {
                var head = bezierPaths.First();
                builder.Append($"M{round(head.StartPoint.X)},{round(head.StartPoint.Y)}");

                foreach (var item in bezierPaths)
                {
                    builder.Append($" C{round(item.FirstControlPoint.X)},{round(item.FirstControlPoint.Y)} {round(item.SecondControlPoint.X)},{round(item.SecondControlPoint.Y)} {round(item.EndPoint.X)},{round(item.EndPoint.Y)}");
                }
            }

            return builder.ToString();
        }
    }
}
