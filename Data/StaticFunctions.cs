using StrategyVersusSwitch.Data;

namespace StrategyVersusSwitch;

public static class StaticFunctions
{
    public static double TriangleArea(Shape item)
    {
        return item.DimX * 0.5 * item.DimY;
    }

    public static double CircleArea(Shape item)
    {
        return Math.PI * item.DimX * item.DimY;
    }

    public static double RectangleArea(Shape item)
    {
        return item.DimX * item.DimY;
    }

    public static double OvalArea(Shape item)
    {
        return Math.PI * item.DimX * item.DimY;
    }

    public static double Shape0Area(Shape item)
    {
        return 0.05 * item.DimX * item.DimX;
    }

    public static double Shape1Area(Shape item)
    {
        return 0.1 * item.DimX * item.DimX;
    }

    public static double Shape2Area(Shape item)
    {
        return 0.2 * item.DimX * item.DimX;
    }

    public static double Shape3Area(Shape item)
    {
        return 0.3 * item.DimX * item.DimX;
    }

    public static double Shape4Area(Shape item)
    {
        return 0.4 * item.DimX * item.DimX;
    }

    public static double Shape5Area(Shape item)
    {
        return 0.5 * item.DimX * item.DimX;
    }

    public static double Shape6Area(Shape item)
    {
        return 0.6 * item.DimX * item.DimX;
    }

    public static double Shape7Area(Shape item)
    {
        return 0.7 * item.DimX * item.DimX;
    }

    public static double Shape8Area(Shape item)
    {
        return 0.8 * item.DimX * item.DimX;
    }

    public static double Shape9Area(Shape item)
    {
        return 0.9 * item.DimX * item.DimX;
    }
}
