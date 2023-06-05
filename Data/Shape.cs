namespace StrategyVersusSwitch.Data;

public class Shape
{
    public static Shape Rectangle(double width, double height)
    {
        return new Shape { ShapeType = ShapeType.Rectangle, Width = width, Height = height };
    }
    public static Shape Circle(double radius)
    {
        return new Shape { ShapeType = ShapeType.Circle, Radius = radius };
    }

    public static Shape Triangle(double width, double height)
    {
        return new Shape { ShapeType = ShapeType.Triangle, Width = width, Height = height };
    }

    public static Shape AShape(ShapeType type, double width, double height, double radius)
    {
        return new Shape { ShapeType = type, Width = width, Height = height, Radius = radius };
    }

    public ShapeType ShapeType { get; set; }

    public double Width { get; set; }

    public double Height { get; set; }

    public double Radius { get; set; }

    private static Dictionary<(int seed, int itemCount), Shape[]> _cache = new();

    public static Shape[] LoadData(int seed, int itemCount)
    {
        if (_cache.ContainsKey((seed, itemCount)))
        {
            return _cache[(seed, itemCount)];
        }

        Random r = new Random(seed);
        var result = Enumerable
            .Range(0, itemCount)
            .Select(_ => (ShapeType)r.Next((int)ShapeType.NumberOfShapes))
            .Select(shapeType => shapeType switch
            {
                ShapeType.Rectangle => Shape.Rectangle(r.Next(), r.Next()),
                ShapeType.Circle => Shape.Circle(r.Next()),
                ShapeType.Triangle => Shape.Triangle(r.Next(), r.Next()),
                ShapeType.Shape0 => Shape.AShape(ShapeType.Shape0, r.Next(), r.Next(), r.Next()),
                ShapeType.Shape1 => Shape.AShape(ShapeType.Shape1, r.Next(), r.Next(), r.Next()),
                ShapeType.Shape2 => Shape.AShape(ShapeType.Shape2, r.Next(), r.Next(), r.Next()),
                ShapeType.Shape3 => Shape.AShape(ShapeType.Shape3, r.Next(), r.Next(), r.Next()),
                ShapeType.Shape4 => Shape.AShape(ShapeType.Shape4, r.Next(), r.Next(), r.Next()),
                ShapeType.Shape5 => Shape.AShape(ShapeType.Shape5, r.Next(), r.Next(), r.Next()),
                ShapeType.Shape6 => Shape.AShape(ShapeType.Shape6, r.Next(), r.Next(), r.Next()),
                ShapeType.Shape7 => Shape.AShape(ShapeType.Shape7, r.Next(), r.Next(), r.Next()),
                ShapeType.Shape8 => Shape.AShape(ShapeType.Shape8, r.Next(), r.Next(), r.Next()),
                ShapeType.Shape9 => Shape.AShape(ShapeType.Shape9, r.Next(), r.Next(), r.Next()),
                _ => throw new NotImplementedException()
            })
        .ToArray();

        _cache[(seed, itemCount)] = result;
        return result;
    }
}

public enum ShapeType
{
    Rectangle,
    Circle,
    Triangle,

    // Extras for scale testing
    Shape0,
    Shape1,
    Shape2,
    Shape3,
    Shape4,
    Shape5,
    Shape6,
    Shape7,
    Shape8,
    Shape9,

    //Enum representing count
    NumberOfShapes
}
