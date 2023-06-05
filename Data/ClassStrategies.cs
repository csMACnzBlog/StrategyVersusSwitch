using StrategyVersusSwitch.Data;

namespace StrategyVersusSwitch;

public static class ClassStrategies
{
    public static Lazy<IAreaStrategy[]> LazyStrategyCache = new Lazy<IAreaStrategy[]>(() =>
    {
        return Enumerable
            .Range(0, (int)ShapeType.NumberOfShapes)
            .Cast<ShapeType>()
            .Select<ShapeType, IAreaStrategy>(shapeType => shapeType switch
            {
                ShapeType.Rectangle => new RectangleArea(),
                ShapeType.Circle => new CircleArea(),
                ShapeType.Triangle => new TriangleArea(),
                ShapeType.Shape0 => new ShapeArea(0.05),
                ShapeType.Shape1 => new ShapeArea(0.1),
                ShapeType.Shape2 => new ShapeArea(0.2),
                ShapeType.Shape3 => new ShapeArea(0.3),
                ShapeType.Shape4 => new ShapeArea(0.4),
                ShapeType.Shape5 => new ShapeArea(0.5),
                ShapeType.Shape6 => new ShapeArea(0.6),
                ShapeType.Shape7 => new ShapeArea(0.7),
                ShapeType.Shape8 => new ShapeArea(0.8),
                ShapeType.Shape9 => new ShapeArea(0.9),
                _ => throw new NotSupportedException()
            })
            .ToArray();
    });

    public static IAreaStrategy GetStrategy(Shape shape)
    {
        return LazyStrategyCache.Value[(int)shape.ShapeType];
    }

    public static IAreaStrategy GetStrategy2(Shape shape)
    {
        return shape.ShapeType switch
        {
            ShapeType.Rectangle => new RectangleArea(),
            ShapeType.Circle => new CircleArea(),
            ShapeType.Triangle => new TriangleArea(),
            ShapeType.Shape0 => new ShapeArea(0.05),
            ShapeType.Shape1 => new ShapeArea(0.1),
            ShapeType.Shape2 => new ShapeArea(0.2),
            ShapeType.Shape3 => new ShapeArea(0.3),
            ShapeType.Shape4 => new ShapeArea(0.4),
            ShapeType.Shape5 => new ShapeArea(0.5),
            ShapeType.Shape6 => new ShapeArea(0.6),
            ShapeType.Shape7 => new ShapeArea(0.7),
            ShapeType.Shape8 => new ShapeArea(0.8),
            ShapeType.Shape9 => new ShapeArea(0.9),
            _ => throw new NotSupportedException()
        };
    }

    public interface IAreaStrategy { double CalculateArea(Shape shape); }

    public class RectangleArea : IAreaStrategy
    {
        public double CalculateArea(Shape shape)
        {
            return shape.Width * shape.Height;
        }
    }


    public class CircleArea : IAreaStrategy
    {
        public double CalculateArea(Shape shape)
        {
            return Math.PI * shape.Radius * shape.Radius;
        }
    }


    public class TriangleArea : IAreaStrategy
    {
        public double CalculateArea(Shape shape)
        {
            return shape.Width * 0.5 * shape.Height;
        }
    }
    public class ShapeArea : IAreaStrategy
    {
        private readonly double _multiplier;

        public ShapeArea(double multiplier)
        {
            this._multiplier = multiplier;
        }

        public double CalculateArea(Shape shape)
        {
            return _multiplier * shape.Width * shape.Height;
        }
    }
}