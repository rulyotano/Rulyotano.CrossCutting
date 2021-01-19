using System.Collections.Generic;
using System.Linq;

namespace Rulyotano.Math.Geometry
{
    public static class Helpers
    {
        /// <summary>
        /// Convert from radians to degree
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        public static float RadianToDegreeConvert(float radian)
        {
            //return (180*radian)/Math.PI;
            return 57.29577951308232f * radian;
        }

        /// <summary>
        /// Convert degree to radians
        /// </summary>
        /// <param name="degree"></param>
        /// <returns></returns>
        public static double DegreeToRadianConvert(double degree)
        {
            return (degree * System.Math.PI) / 180;
        }

        /// <summary>
        /// Euclidean distance. From points.
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public static double EuclideanDistance(Point point1, Point point2)
        {
            var xDiff = point2.X - point1.X;
            var yDiff = point2.Y - point1.Y;
            return System.Math.Sqrt(xDiff * xDiff + yDiff * yDiff);
        }

        /// <summary>
        /// Euclidean distance. From points coordinates.
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        public static double EuclideanDistance(double x1, double y1, double x2, double y2)
        {
            var xDiff = x2 - x1;
            var yDiff = y2 - y1;
            return System.Math.Sqrt(xDiff * xDiff + yDiff * yDiff);
        }

        /// <summary>
        /// Find best place to insert a new point by minimizing the total length.
        /// Useful for instance when want to add points to an ordered points sequence,
        /// that could be interpolated then using Beizer curves.
        /// </summary>
        /// <param name="newPoint"></param>
        /// <param name="points"></param>
        /// <returns></returns>
        public static int BestPlaceToInsert(Point newPoint, List<Point> points)
        {
            if (points.Count == 0) return 0;
            if (points.Count == 1) return 1;

            var bestIndex = 0;
            var bestDistance = EuclideanDistance(newPoint, points.First());

            for (int i = 1; i < points.Count; i++)
            {
                var previousPoint = points[i - 1];
                var currentPoint = points[i];
                var oldDistance = EuclideanDistance(previousPoint, currentPoint);
                var distance1 = EuclideanDistance(previousPoint, newPoint);
                var distance2 = EuclideanDistance(newPoint, currentPoint);
                var distanceDifference = distance1 + distance2 - oldDistance;
                if (distanceDifference < bestDistance)
                {
                    bestDistance = distanceDifference;
                    bestIndex = i;
                }
            }


            var lastDistance = EuclideanDistance(points.Last(), newPoint);

            if (lastDistance < bestDistance)
            {
                bestIndex = points.Count;
            }

            return bestIndex;
        }
    }
}
