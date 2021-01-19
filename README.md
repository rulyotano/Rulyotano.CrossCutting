# Rulyotano.Math
Math helpers. The main feature right now is the interpolation by using Beizer curves

## Interpolations
### Beizer Curves

This library can be used as a nuget package. 

Import the [Rulyotano.Math Nuget Package](https://www.nuget.org/packages/Rulyotano.Math/) like this:

```
Install-Package Rulyotano.Math -Version x.x.x
```

Then can be used like this:

```c#
  var result = Rulyotano.Math.Interpolation.PoinsToBeizerCurves(points, isClosedCurve, smoothValue);
```

The result is a list of `Beizer Curve Segments`. A beizer curve segment is represented with an origin and destination points beside two control points. 

A more detailed usage example can be found at this wpf sample: [rulyotano/wpf-bezier-interpolation](https://github.com/rulyotano/wpf-bezier-interpolation)

#### Reference for this Beizer Curves Interpolation Algorithm

- See this article: [Interpolate 2D points, usign Bezier curves in WPF](http://www.codeproject.com/Articles/769055/Interpolate-2D-points-usign-Bezier-curves-in-WPF)
  
### Geometry Helpers

This library has some geometry useful things, related to the interpolation algorithms implementation. Like a Point definition, conversion from degree to radians and vice versa. Also has a method for knowing the better position for inserting a new point, given a list of points. For example, this is useful for clicking at some point and inserting it to a beizer curve path.

### Numerics

Numeric class has some useful things, like functions for comparing two floating point values and also has a function for calculating the middle value given two ones. 
