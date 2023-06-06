using System.Diagnostics;
using StrategyVersusSwitch.Data;

namespace StrategyVersusSwitch;

public static class FastCheck
{

    public static Lazy<double[]> LazyMultiplierCache = new Lazy<double[]>(() =>
    {
        var result = new (ShapeType shapeType, double)[]
        {
            (shapeType: ShapeType.Rectangle, 1),
            (shapeType: ShapeType.Circle, Math.PI),
            (shapeType: ShapeType.Triangle, 0.5),
            (shapeType: ShapeType.Oval, Math.PI),
            (shapeType: ShapeType.Shape0, 0.05),
            (shapeType: ShapeType.Shape1, 0.1),
            (shapeType: ShapeType.Shape2, 0.2),
            (shapeType: ShapeType.Shape3, 0.3),
            (shapeType: ShapeType.Shape4, 0.4),
            (shapeType: ShapeType.Shape5, 0.5),
            (shapeType: ShapeType.Shape6, 0.6),
            (shapeType: ShapeType.Shape7, 0.7),
            (shapeType: ShapeType.Shape8, 0.8),
            (shapeType: ShapeType.Shape9, 0.9),
        }
            .OrderBy(s => s.shapeType)
            .Select(kvp => kvp.Item2)
            .ToArray();

        Debug.Assert(result.Length == (int)ShapeType.NumberOfShapes);
        return result;
    });



    public static double Run(Shape[] data)
    {
        double result = 0;
        foreach (var item in data)
        {
            double area =
            result += LazyMultiplierCache.Value[(int)item.ShapeType] * item.DimX * item.DimY; ;
        }
        return result;
    }

}