using Rulyotano.Math.Geometry;
using System.Collections.Generic;

namespace Rulyotano.Math.Interpolation.Bezier.Tests
{

    public static class TestDataBezier
    {
        public static TestCaseBezier TestCas1
        {
            get
            {
                var point1 = new Point(173, 42);
                var point2 = new Point(5, 1);
                var point3 = new Point(64, 84);
                var point4 = new Point(210, 64);
                var point5 = new Point(191, 90);
                var point6 = new Point(241, 206);
                var point7 = new Point(31, 138);
                var point8 = new Point(338, 112);
                var point9 = new Point(310, 33);

                return new TestCaseBezier
                {
                    InputPoints = new List<Point> {
                        point1,
                        point2,
                        point3,
                        point4,
                        point5,
                        point6,
                        point7,
                        point8,
                        point9
                    },

                    ExpectedOutput = new List<BezierCurveSegment>
                    {
                        new(point1,  point1, new Point(32.44093, -9.57356), point2),
                        new(point2, new Point(-11.15906, 7.22643), new Point(30.49103, 73.70212), point3),
                        new(point3, new Point(112.49103, 98.90212), new Point(168.31022, 62.03040), point4),
                        new(point4, new Point(219.11022, 64.4304), new Point(188.48099, 78.46135) ,point5),
                        new(point5, new Point(200.88099, 135.26135), new Point(264.29416, 199.01174), point6),
                        new(point6, new Point(200.29416, 218.21174), new Point(14.80489, 153.69422), point7),
                        new(point7, new Point(53.60489, 116.09422), new Point(250.26691, 145.01782), point8),
                        new(point8, new Point(361.86691, 103.01782), point9, point9),
                    },
                    IsClosed = false,
                };
            }
        }

        public static TestCaseBezier TestCas2
        {
            get
            {
                var point1 = new Point(173, 42);
                var point2 = new Point(5, 1);
                var point3 = new Point(64, 84);

                return new TestCaseBezier
                {
                    InputPoints = new List<Point> {
                        point1,
                        point2,
                        point3,
                    },

                    ExpectedOutput = new List<BezierCurveSegment>
                    {
                        new(point1,  new Point(158.91451, 22.18482), new Point(32.44093, -9.57356), point2),
                        new(point2, new Point(-11.15906, 7.22643), new Point( 32.70182, 76.36175), point3),
                        new(point3, new Point( 99.90182, 92.76175), new Point(182.51451, 55.38482), point1),
                        },
                    IsClosed = true,
                };
            }
        }

        public static TestCaseBezier TestCas3
        {
            get
            {
                var point1 = new Point(173, 42);
                var point2 = new Point(5, 1);
                var point3 = new Point(64, 84);

                return new TestCaseBezier
                {
                    InputPoints = new List<Point> {
                        point1,
                        point2,
                        point3,
                    },

                    ExpectedOutput = new List<BezierCurveSegment>
                    {
                        new(point1,  new Point(167.71794, 34.56930), new Point(15.29034, -2.96508), point2),
                        new(point2, new Point(-1.05965, 3.33491), new Point(52.26318, 81.13565), point3),
                        new(point3, new Point(77.46318, 87.28565), new Point(176.56794, 47.01930), point1),
                        },
                    IsClosed = true,
                    Smooth = 0.3
                };
            }
        }

    }

    public class TestCaseBezier
    {
        public bool IsClosed { get; set; }

        public double? Smooth { get; set; }

        public List<Point> InputPoints { get; set; }

        public List<BezierCurveSegment> ExpectedOutput { get; set; }
    }
}
