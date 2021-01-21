# Rulyotano.Math
Math helpers. The main feature right now is the interpolation by using Bezier curves

## Interpolations
### Bezier Curves

This library can be used as a nuget package. 

Import the [Rulyotano.Math Nuget Package](https://www.nuget.org/packages/Rulyotano.Math/) like this:

```
Install-Package Rulyotano.Math -Version x.x.x
```

Then can be used like this:

```c#
  var result = Rulyotano.Math.Interpolation.PointsToBezierCurves(points, isClosedCurve, smoothValue);
```

The result is a list of `Bezier Curve Segments`. A bezier curve segment is represented with an origin and destination points beside two control points. 

A more detailed usage example can be found at this wpf sample: [rulyotano/wpf-bezier-interpolation](https://github.com/rulyotano/wpf-bezier-interpolation)

#### Reference for this Bezier Curves Interpolation Algorithm

- See this article: [Interpolate 2D points, using Bezier curves in WPF](http://www.codeproject.com/Articles/769055/Interpolate-2D-points-usign-Bezier-curves-in-WPF)

#### Converting from Bezier interpolation results to svg path

You can convert the result of the `PointsToBezierCurves` by using an extension method named `BezierToPath`:

``` c#
  var result = Math.Interpolation.PointsToBezierCurves(samplePoints1.ToList(), false);
  var path = TestDataBezier.TestCas1.ExpectedOutput.BezierToPath();
```

This will generate a path string like this, that can be used in `xaml` or `html`:

```
M173,42 C173,42 32.441,-9.574 5,1 C-11.159,7.226 30.491,73.702 64,84 C112.491,98.902 168.31,62.03 210,64 C219.11,64.43 188.481,78.461 191,90 C200.881,135.261 264.294,199.012 241,206 C200.294,218.212 14.805,153.694 31,138 C53.605,116.094 250.267,145.018 338,112 C361.867,103.018 310,33 310,33
```

### Geometry Helpers

This library has some geometry useful things, related to the interpolation algorithms implementation. Like a Point definition, conversion from degree to radians and vice versa. Also has a method for knowing the better position for inserting a new point, given a list of points. For example, this is useful for clicking at some point and inserting it to a bezier curve path.

### Numerics

Numeric class has some useful things, like functions for comparing two floating point values and also has a function for calculating the middle value given two ones. 
