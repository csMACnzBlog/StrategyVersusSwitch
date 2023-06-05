using System.Diagnostics;
using StrategyVersusSwitch.Data;

namespace StrategyVersusSwitch;

public static class FuncStrategies
{
    public static Lazy<Func<Shape, double>[]> LazyStrategyCache = new Lazy<Func<Shape, double>[]>(() =>
    {
        var result = new (ShapeType shapeType, Func<Shape, double> func)[]
        {
            (shapeType: ShapeType.Rectangle, func:shape => shape.Width * shape.Height),
            (shapeType: ShapeType.Circle, func: shape => Math.PI * shape.Radius * shape.Radius),
            (shapeType: ShapeType.Triangle, func: shape => shape.Width * 0.5 * shape.Height),
            (shapeType: ShapeType.Shape0, func: shape => 0.05 * shape.Width * shape.Width * shape.Radius),
            (shapeType: ShapeType.Shape1, func: shape => 0.1 * shape.Width * shape.Width * shape.Radius),
            (shapeType: ShapeType.Shape2, func: shape => 0.2 * shape.Width * shape.Width * shape.Radius),
            (shapeType: ShapeType.Shape3, func: shape => 0.3 * shape.Width * shape.Width * shape.Radius),
            (shapeType: ShapeType.Shape4, func: shape => 0.4 * shape.Width * shape.Width * shape.Radius),
            (shapeType: ShapeType.Shape5, func: shape => 0.5 * shape.Width * shape.Width * shape.Radius),
            (shapeType: ShapeType.Shape6, func: shape => 0.6 * shape.Width * shape.Width * shape.Radius),
            (shapeType: ShapeType.Shape7, func: shape => 0.7 * shape.Width * shape.Width * shape.Radius),
            (shapeType: ShapeType.Shape8, func: shape => 0.8 * shape.Width * shape.Width * shape.Radius),
            (shapeType: ShapeType.Shape9, func: shape => 0.9 * shape.Width * shape.Width * shape.Radius),
        }
            .OrderBy(s => s.shapeType)
            .Select(kvp => kvp.func)
            .ToArray();

        Debug.Assert(result.Length == (int)ShapeType.NumberOfShapes);
        return result;
    });

    public static Func<Shape, double> GetStrategy(Shape shape)
    {
        return LazyStrategyCache.Value[(int)shape.ShapeType];
    }
    

    public static Func<Shape, double> GetStrategy2(Shape shape)
    {
        return shape.ShapeType switch
        {
            ShapeType.Rectangle => item => item.Width * item.Height,
            ShapeType.Circle => item => Math.PI * item.Radius * item.Radius,
            ShapeType.Triangle => item => item.Width * 0.5 * item.Height,
            ShapeType.Shape0 => item => 0.05 * item.Width * item.Width * item.Radius,
            ShapeType.Shape1 => item => 0.1 * item.Width * item.Width * item.Radius,
            ShapeType.Shape2 => item => 0.2 * item.Width * item.Width * item.Radius,
            ShapeType.Shape3 => item => 0.3 * item.Width * item.Width * item.Radius,
            ShapeType.Shape4 => item => 0.4 * item.Width * item.Width * item.Radius,
            ShapeType.Shape5 => item => 0.5 * item.Width * item.Width * item.Radius,
            ShapeType.Shape6 => item => 0.6 * item.Width * item.Width * item.Radius,
            ShapeType.Shape7 => item => 0.7 * item.Width * item.Width * item.Radius,
            ShapeType.Shape8 => item => 0.8 * item.Width * item.Width * item.Radius,
            ShapeType.Shape9 => item => 0.9 * item.Width * item.Width * item.Radius,
            _ => throw new NotSupportedException()
        };
    }
}