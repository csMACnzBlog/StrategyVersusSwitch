using System.Diagnostics;
using StrategyVersusSwitch.Data;

namespace StrategyVersusSwitch;

public static class StaticFuncStrategies
{
    public static Lazy<Func<Shape, double>[]> LazyStrategyCache = new Lazy<Func<Shape, double>[]>(() =>
    {
        var result = new (ShapeType shapeType, Func<Shape, double> func)[]
        {
            (ShapeType.Rectangle, StaticFunctions.RectangleArea),
            (ShapeType.Circle, StaticFunctions.CircleArea),
            (ShapeType.Triangle, StaticFunctions.TriangleArea),
            (ShapeType.Oval, StaticFunctions.OvalArea),
            (ShapeType.Shape0, StaticFunctions.Shape0Area),
            (ShapeType.Shape1, StaticFunctions.Shape1Area),
            (ShapeType.Shape2, StaticFunctions.Shape2Area),
            (ShapeType.Shape3, StaticFunctions.Shape3Area),
            (ShapeType.Shape4, StaticFunctions.Shape4Area),
            (ShapeType.Shape5, StaticFunctions.Shape5Area),
            (ShapeType.Shape6, StaticFunctions.Shape6Area),
            (ShapeType.Shape7, StaticFunctions.Shape7Area),
            (ShapeType.Shape8, StaticFunctions.Shape8Area),
            (ShapeType.Shape9, StaticFunctions.Shape9Area),
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
            ShapeType.Rectangle => StaticFunctions.RectangleArea,
            ShapeType.Circle => StaticFunctions.CircleArea,
            ShapeType.Triangle => StaticFunctions.TriangleArea,
            ShapeType.Oval => StaticFunctions.OvalArea,
            ShapeType.Shape0 => StaticFunctions.Shape0Area,
            ShapeType.Shape1 => StaticFunctions.Shape1Area,
            ShapeType.Shape2 => StaticFunctions.Shape2Area,
            ShapeType.Shape3 => StaticFunctions.Shape3Area,
            ShapeType.Shape4 => StaticFunctions.Shape4Area,
            ShapeType.Shape5 => StaticFunctions.Shape5Area,
            ShapeType.Shape6 => StaticFunctions.Shape6Area,
            ShapeType.Shape7 => StaticFunctions.Shape7Area,
            ShapeType.Shape8 => StaticFunctions.Shape8Area,
            ShapeType.Shape9 => StaticFunctions.Shape9Area,
            _ => throw new NotSupportedException()
        };
    }
}
