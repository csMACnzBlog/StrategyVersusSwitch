using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;
using StrategyVersusSwitch.Data;

namespace StrategyVersusSwitch;

[SimpleJob(runStrategy: RunStrategy.Throughput, runtimeMoniker: RuntimeMoniker.Net70, launchCount: 1, warmupCount: 5, iterationCount: 5, invocationCount: 10)]
public class Benchmarks
{
    private static int seed = Environment.TickCount;

    private Shape[] data = Array.Empty<Shape>();

    [Params(10, 100, 1000, 10_000, 100_000, 1_000_000)]
    public int itemCount;

    [GlobalSetup]
    public void Setup()
    {
        data = Shape.LoadData(seed, itemCount);
    }

    [Benchmark]
    public double FastCheck()
    {
        double result = 0;
        foreach (var item in data)
        {
            double area =
            result += FastCheckCache.LazyMultiplierCache.Value[(int)item.ShapeType] * item.DimX * item.DimY; ;
        }
        return result;
    }

    [Benchmark]
    public double IfChecks()
    {
        double result = 0;
        foreach (var item in data)
        {
            double area;
            if (item.ShapeType is ShapeType.Rectangle)
            {
                area = item.DimX * item.DimY;
            }
            else if (item.ShapeType is ShapeType.Circle)
            {
                area = Math.PI * item.DimX * item.DimY;
            }
            else if (item.ShapeType is ShapeType.Triangle)
            {
                area = item.DimX * 0.5 * item.DimY;
            }
            else if (item.ShapeType is ShapeType.Oval)
            {
                area = Math.PI * item.DimX * item.DimY;
            }
            else if (item.ShapeType is ShapeType.Shape0)
            {
                area = 0.05 * item.DimX * item.DimX;
            }
            else if (item.ShapeType is ShapeType.Shape1)
            {
                area = 0.1 * item.DimX * item.DimX;
            }

            else if (item.ShapeType is ShapeType.Shape2)
            {
                area = 0.2 * item.DimX * item.DimX;
            }

            else if (item.ShapeType is ShapeType.Shape3)
            {
                area = 0.3 * item.DimX * item.DimX;
            }

            else if (item.ShapeType is ShapeType.Shape4)
            {
                area = 0.4 * item.DimX * item.DimX;
            }

            else if (item.ShapeType is ShapeType.Shape5)
            {
                area = 0.5 * item.DimX * item.DimX;
            }

            else if (item.ShapeType is ShapeType.Shape6)
            {
                area = 0.6 * item.DimX * item.DimX;
            }

            else if (item.ShapeType is ShapeType.Shape7)
            {
                area = 0.7 * item.DimX * item.DimX;
            }

            else if (item.ShapeType is ShapeType.Shape8)
            {
                area = 0.8 * item.DimX * item.DimX;
            }

            else if (item.ShapeType is ShapeType.Shape9)
            {
                area = 0.9 * item.DimX * item.DimX;
            }

            else
            {
                throw new NotSupportedException();
            }
            result += area;
        }
        return result;
    }

    [Benchmark]
    public double Switch()
    {
        double result = 0;
        foreach (var item in data)
        {
            switch (item.ShapeType)
            {
                case ShapeType.Rectangle:
                    result += item.DimX * item.DimY;
                    break;
                case ShapeType.Circle:
                    result += Math.PI * item.DimX * item.DimY;
                    break;
                case ShapeType.Triangle:
                    result += item.DimX * 0.5 * item.DimY;
                    break;
                case ShapeType.Oval:
                    result += Math.PI * item.DimX * item.DimY;
                    break;
                case ShapeType.Shape0:
                    result += 0.05 * item.DimX * item.DimX;
                    break;
                case ShapeType.Shape1:
                    result += 0.1 * item.DimX * item.DimX;
                    break;
                case ShapeType.Shape2:
                    result += 0.2 * item.DimX * item.DimX;
                    break;
                case ShapeType.Shape3:
                    result += 0.3 * item.DimX * item.DimX;
                    break;
                case ShapeType.Shape4:
                    result += 0.4 * item.DimX * item.DimX;
                    break;
                case ShapeType.Shape5:
                    result += 0.5 * item.DimX * item.DimX;
                    break;
                case ShapeType.Shape6:
                    result += 0.6 * item.DimX * item.DimX;
                    break;
                case ShapeType.Shape7:
                    result += 0.7 * item.DimX * item.DimX;
                    break;
                case ShapeType.Shape8:
                    result += 0.8 * item.DimX * item.DimX;
                    break;
                case ShapeType.Shape9:
                    result += 0.9 * item.DimX * item.DimX;
                    break;
                default:
                    throw new NotSupportedException();
            }
        }
        return result;
    }

    [Benchmark]
    public double SwitchExpression()
    {
        double result = 0;
        foreach (var item in data)
        {
            result += item.ShapeType switch
            {
                ShapeType.Rectangle => item.DimX * item.DimY,
                ShapeType.Circle => Math.PI * item.DimX * item.DimY,
                ShapeType.Triangle => item.DimX * 0.5 * item.DimY,
                ShapeType.Oval => Math.PI * item.DimX * item.DimY,
                ShapeType.Shape0 => 0.05 * item.DimX * item.DimX,
                ShapeType.Shape1 => 0.1 * item.DimX * item.DimX,
                ShapeType.Shape2 => 0.2 * item.DimX * item.DimX,
                ShapeType.Shape3 => 0.3 * item.DimX * item.DimX,
                ShapeType.Shape4 => 0.4 * item.DimX * item.DimX,
                ShapeType.Shape5 => 0.5 * item.DimX * item.DimX,
                ShapeType.Shape6 => 0.6 * item.DimX * item.DimX,
                ShapeType.Shape7 => 0.7 * item.DimX * item.DimX,
                ShapeType.Shape8 => 0.8 * item.DimX * item.DimX,
                ShapeType.Shape9 => 0.9 * item.DimX * item.DimX,
                _ => throw new NotSupportedException()
            };
        }
        return result;
    }

    [Benchmark]
    public double StaticFunctionSwitchExpression()
    {
        double result = 0;
        foreach (var item in data)
        {
            result += item.ShapeType switch
            {
                ShapeType.Rectangle => StaticFunctions.RectangleArea(item),
                ShapeType.Circle => StaticFunctions.CircleArea(item),
                ShapeType.Triangle => StaticFunctions.TriangleArea(item),
                ShapeType.Oval => StaticFunctions.OvalArea(item),
                ShapeType.Shape0 => StaticFunctions.Shape0Area(item),
                ShapeType.Shape1 => StaticFunctions.Shape1Area(item),
                ShapeType.Shape2 => StaticFunctions.Shape2Area(item),
                ShapeType.Shape3 => StaticFunctions.Shape3Area(item),
                ShapeType.Shape4 => StaticFunctions.Shape4Area(item),
                ShapeType.Shape5 => StaticFunctions.Shape5Area(item),
                ShapeType.Shape6 => StaticFunctions.Shape6Area(item),
                ShapeType.Shape7 => StaticFunctions.Shape7Area(item),
                ShapeType.Shape8 => StaticFunctions.Shape8Area(item),
                ShapeType.Shape9 => StaticFunctions.Shape9Area(item),
                _ => throw new NotSupportedException()
            };
        }
        return result;
    }

    [Benchmark]
    public double StrategyClassWithJumpTable()
    {
        double result = 0;
        foreach (var item in data)
        {
            var strategy = ClassStrategies.GetStrategy(item);

            result += strategy.CalculateArea(item);
        }
        return result;
    }

    [Benchmark]
    public double StrategyLambdasWithJumpTable()
    {
        double result = 0;
        foreach (var item in data)
        {
            var strategy = LambdaFuncStrategies.GetStrategy(item);

            result += strategy(item);
        }
        return result;
    }

    [Benchmark]
    public double StrategyStaticFunctionsWithJumpTable()
    {
        double result = 0;
        foreach (var item in data)
        {
            var strategy = StaticFuncStrategies.GetStrategy(item);

            result += strategy(item);
        }
        return result;
    }

    [Benchmark]
    public double StrategyClassWithoutJumpTable()
    {
        double result = 0;
        foreach (var item in data)
        {
            var strategy = ClassStrategies.GetStrategy2(item);

            result += strategy.CalculateArea(item);
        }
        return result;
    }

    [Benchmark]
    public double StrategyLambdasWithoutJumpTable()
    {
        double result = 0;
        foreach (var item in data)
        {
            var strategy = LambdaFuncStrategies.GetStrategy2(item);

            result += strategy(item);
        }
        return result;
    }

    [Benchmark]
    public double StrategyStaticFunctionsWithoutJumpTable()
    {
        double result = 0;
        foreach (var item in data)
        {
            var strategy = StaticFuncStrategies.GetStrategy2(item);

            result += strategy(item);
        }
        return result;
    }
}