using System.Diagnostics;
using StrategyVersusSwitch.Data;

namespace StrategyVersusSwitch;

public static class LambdaFuncStrategies
{
    public static Lazy<Func<Shape, double>[]> LazyStrategyCache = new Lazy<Func<Shape, double>[]>(() =>
    {
        var result = new (ShapeType shapeType, Func<Shape, double> func)[]
        {
            (shapeType: ShapeType.Rectangle, func:shape => shape.DimX * shape.DimY),
            (shapeType: ShapeType.Circle, func: shape => Math.PI * shape.DimX * shape.DimY),
            (shapeType: ShapeType.Triangle, func: shape => shape.DimX * 0.5 * shape.DimY),
            (shapeType: ShapeType.Oval, func: shape => Math.PI * shape.DimX * shape.DimY),
            (shapeType: ShapeType.Shape0, func: shape => 0.05 * shape.DimX * shape.DimX),
            (shapeType: ShapeType.Shape1, func: shape => 0.1 * shape.DimX * shape.DimX),
            (shapeType: ShapeType.Shape2, func: shape => 0.2 * shape.DimX * shape.DimX),
            (shapeType: ShapeType.Shape3, func: shape => 0.3 * shape.DimX * shape.DimX),
            (shapeType: ShapeType.Shape4, func: shape => 0.4 * shape.DimX * shape.DimX),
            (shapeType: ShapeType.Shape5, func: shape => 0.5 * shape.DimX * shape.DimX),
            (shapeType: ShapeType.Shape6, func: shape => 0.6 * shape.DimX * shape.DimX),
            (shapeType: ShapeType.Shape7, func: shape => 0.7 * shape.DimX * shape.DimX),
            (shapeType: ShapeType.Shape8, func: shape => 0.8 * shape.DimX * shape.DimX),
            (shapeType: ShapeType.Shape9, func: shape => 0.9 * shape.DimX * shape.DimX),
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
            ShapeType.Rectangle => item => item.DimX * item.DimY,
            ShapeType.Circle => item => Math.PI * item.DimX * item.DimY,
            ShapeType.Triangle => item => item.DimX * 0.5 * item.DimY,
            ShapeType.Oval => item => Math.PI * item.DimX * item.DimY,
            ShapeType.Shape0 => item => 0.05 * item.DimX * item.DimX,
            ShapeType.Shape1 => item => 0.1 * item.DimX * item.DimX,
            ShapeType.Shape2 => item => 0.2 * item.DimX * item.DimX,
            ShapeType.Shape3 => item => 0.3 * item.DimX * item.DimX,
            ShapeType.Shape4 => item => 0.4 * item.DimX * item.DimX,
            ShapeType.Shape5 => item => 0.5 * item.DimX * item.DimX,
            ShapeType.Shape6 => item => 0.6 * item.DimX * item.DimX,
            ShapeType.Shape7 => item => 0.7 * item.DimX * item.DimX,
            ShapeType.Shape8 => item => 0.8 * item.DimX * item.DimX,
            ShapeType.Shape9 => item => 0.9 * item.DimX * item.DimX,
            _ => throw new NotSupportedException()
        };
    }
}