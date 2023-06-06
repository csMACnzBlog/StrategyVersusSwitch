using System.Diagnostics;
using StrategyVersusSwitch.Data;

namespace StrategyVersusSwitch;

public static class StaticFuncStrategies
{
    public static Lazy<Func<Shape, double>[]> LazyStrategyCache = new Lazy<Func<Shape, double>[]>(() =>
    {
        var result = new (ShapeType shapeType, Func<Shape, double> func)[]
        {
            (ShapeType.Rectangle, RectangleArea),
            (ShapeType.Circle, CircleArea),
            (ShapeType.Triangle, TriangleArea),
            (ShapeType.Oval, OvalArea),
            (ShapeType.Shape0, Shape0Area),
            (ShapeType.Shape1, Shape1Area),
            (ShapeType.Shape2, Shape2Area),
            (ShapeType.Shape3, Shape3Area),
            (ShapeType.Shape4, Shape4Area),
            (ShapeType.Shape5, Shape5Area),
            (ShapeType.Shape6, Shape6Area),
            (ShapeType.Shape7, Shape7Area),
            (ShapeType.Shape8, Shape8Area),
            (ShapeType.Shape9, Shape9Area),
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
            ShapeType.Rectangle => RectangleArea,
            ShapeType.Circle => item => CircleArea(item),
            ShapeType.Triangle => item => TriangleArea(item),
            ShapeType.Oval => item => OvalArea(item),
            ShapeType.Shape0 => item => Shape0Area(item),
            ShapeType.Shape1 => item => Shape1Area(item),
            ShapeType.Shape2 => item => Shape2Area(item),
            ShapeType.Shape3 => item => Shape3Area(item),
            ShapeType.Shape4 => item => Shape4Area(item),
            ShapeType.Shape5 => item => Shape5Area(item),
            ShapeType.Shape6 => item => Shape6Area(item),
            ShapeType.Shape7 => item => Shape7Area(item),
            ShapeType.Shape8 => item => Shape8Area(item),
            ShapeType.Shape9 => item => Shape9Area(item),
            _ => throw new NotSupportedException()
        };
    }

    private static double TriangleArea(Shape item)
    {
        return item.DimX * 0.5 * item.DimY;
    }

    private static double CircleArea(Shape item)
    {
        return Math.PI * item.DimX * item.DimY;
    }

    private static double RectangleArea(Shape item)
    {
        return item.DimX * item.DimY;
    }

    private static double OvalArea(Shape item)
    {
        return Math.PI * item.DimX * item.DimY;
    }

    private static double Shape0Area(Shape item)
    {
        return 0.05 * item.DimX * item.DimX;
    }

    private static double Shape1Area(Shape item)
    {
        return 0.1 * item.DimX * item.DimX;
    }

    private static double Shape2Area(Shape item)
    {
        return 0.2 * item.DimX * item.DimX;
    }

    private static double Shape3Area(Shape item)
    {
        return 0.3 * item.DimX * item.DimX;
    }

    private static double Shape4Area(Shape item)
    {
        return 0.4 * item.DimX * item.DimX;
    }

    private static double Shape5Area(Shape item)
    {
        return 0.5 * item.DimX * item.DimX;
    }

    private static double Shape6Area(Shape item)
    {
        return 0.6 * item.DimX * item.DimX;
    }

    private static double Shape7Area(Shape item)
    {
        return 0.7 * item.DimX * item.DimX;
    }

    private static double Shape8Area(Shape item)
    {
        return 0.8* item.DimX * item.DimX;
    }

    private static double Shape9Area(Shape item)
    {
        return 0.9 * item.DimX * item.DimX;
    }
}