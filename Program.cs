//prevent the JIT Compiler from optimizing Fkt calls away
using System.Diagnostics;
using StrategyVersusSwitch;
using StrategyVersusSwitch.Data;

int seed = Environment.TickCount;

if (OperatingSystem.IsWindows() || OperatingSystem.IsLinux())
{
    //use the second Core/Processor for the test
    Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(2);

    //prevent "Normal" Processes from interrupting Threads
    Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
}
//prevent "Normal" Threads from interrupting this thread
Thread.CurrentThread.Priority = ThreadPriority.Highest;

RunTest("Fast Check", FastCheck.Run);
RunTest("If Checks", IfChecks);
RunTest("Switch", Switch);
RunTest("Switch Expression", SwitchExpression);
RunTest("Class Strategy With Jump Table", StrategyClassWithJumpTable);
RunTest("Lambda Strategy With Jump Table", StrategyLambdasWithJumpTable);
RunTest("Static Func Strategy With Jump Table", StrategyStaticFunctionsWithJumpTable);
RunTest("Class Strategy Without Jump Table", StrategyClassWithoutJumpTable);
RunTest("Lambda Strategy Without Jump Table", StrategyLambdasWithoutJumpTable);
RunTest("Static Func Strategy Without Jump Table", StrategyStaticFunctionsWithoutJumpTable);

void RunTest(string action, Func<Shape[], double> method)
{
    var stopwatch = new Stopwatch();

    Console.WriteLine($"{action}:");
    foreach (var itemCount in new int[] { 10, 100, 1000, 10_000, 100_000, 1_000_000 })
    {
        var data = Shape.LoadData(seed, itemCount);
        //warm up
        method(data);

        var minDurationMilliseconds = double.MaxValue;
        var maxDurationMilliseconds = double.MinValue;
        var totalMilliseconds = 0.0;
        var repetitionCount = 100;
        for (int repetition = 0; repetition < repetitionCount; repetition++)
        {
            stopwatch.Reset();

            stopwatch.Start();
            var result = method(data);
            stopwatch.Stop();
            minDurationMilliseconds = Math.Min(stopwatch.Elapsed.TotalMilliseconds, minDurationMilliseconds);
            maxDurationMilliseconds = Math.Max(stopwatch.Elapsed.TotalMilliseconds, maxDurationMilliseconds);
            totalMilliseconds += stopwatch.Elapsed.TotalMilliseconds;
        }

        Console.WriteLine($"{itemCount,10:N0} - {(totalMilliseconds / repetitionCount / itemCount):N7}ms/shape :: {(totalMilliseconds / repetitionCount):N4}ms (Min: {minDurationMilliseconds}ms, Max: {maxDurationMilliseconds}ms, Diff: {(maxDurationMilliseconds - minDurationMilliseconds):N4})");
    }
    Console.WriteLine();
}

double IfChecks(Shape[] data)
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

double Switch(Shape[] data)
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

double SwitchExpression(Shape[] data)
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

double StrategyClassWithJumpTable(Shape[] data)
{
    double result = 0;
    foreach (var item in data)
    {
        var strategy = ClassStrategies.GetStrategy(item);

        result += strategy.CalculateArea(item);
    }
    return result;
}

double StrategyLambdasWithJumpTable(Shape[] data)
{
    double result = 0;
    foreach (var item in data)
    {
        var strategy = LambdaFuncStrategies.GetStrategy(item);

        result += strategy(item);
    }
    return result;
}

double StrategyStaticFunctionsWithJumpTable(Shape[] data)
{
    double result = 0;
    foreach (var item in data)
    {
        var strategy = StaticFuncStrategies.GetStrategy(item);

        result += strategy(item);
    }
    return result;
}

double StrategyClassWithoutJumpTable(Shape[] data)
{
    double result = 0;
    foreach (var item in data)
    {
        var strategy = ClassStrategies.GetStrategy2(item);

        result += strategy.CalculateArea(item);
    }
    return result;
}

double StrategyLambdasWithoutJumpTable(Shape[] data)
{
    double result = 0;
    foreach (var item in data)
    {
        var strategy = LambdaFuncStrategies.GetStrategy2(item);

        result += strategy(item);
    }
    return result;
}

double StrategyStaticFunctionsWithoutJumpTable(Shape[] data)
{
    double result = 0;
    foreach (var item in data)
    {
        var strategy = StaticFuncStrategies.GetStrategy2(item);

        result += strategy(item);
    }
    return result;
}
