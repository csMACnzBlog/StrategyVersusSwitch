# C# Switch Expressions vs Strategy patterns #
This is testing switch expressions against if, classic switch, and strategy using classes or functions.

## The Experiment ##

Creating a bunch of Shape variants in an Entity-Component-esque approach. One Shape class with a ShapeType Enum to algorithmically "switch" on. All Properties exist but only some are used by each different ShapeType. (C-style union could be applied to compress memory.) There are 3 real variants with 10 artificial variants generated to increase the testing space.

No Inheritance was used, and only the Class-based strategy approach uses an Interface.

## Changes ##

This was run using release mode:  `dotnet run -c Release`
I used an array iteration for all item iteration to keep the algorithms comparible. This iteration will be adding some
overhead compared to alternatives, but this wasn't measured.

I first ran this will  list provisioning and adding inside the loop, this caused variance due to the memory
allocations. I changed to instead sum the areas and return the total area instead to avoid this.

I cached and pinned a shared seed for the data generation to eliminate variance between approaches. I also added some
code from Stack Overflow in an attempt to measure just the right part of the algorithm.
https://stackoverflow.com/questions/969290/exact-time-measurement-for-performance-testing

This is based on a fixed small number of variants (ShapeType enum). The variability of that alorithm may not be
representative enough of a real space. I added some dummy extra ones to bulk the numbers.

## Results ##

```
// N items in an array, 100 repeats each with average, min and max calculated
//       N - ms/shape          :: average total loop count (Min: min loop duration, Max: max loop duration, Diff: difference across repeats)

If Checks:
        10 - 0.0000163ms/shape :: 0.0002ms (Min: 0.0001ms, Max: 0.0006ms, Diff: 0.0005)
       100 - 0.0000150ms/shape :: 0.0015ms (Min: 0.0013ms, Max: 0.0022ms, Diff: 0.0009)
     1,000 - 0.0000265ms/shape :: 0.0265ms (Min: 0.0176ms, Max: 0.8417ms, Diff: 0.8241)
    10,000 - 0.0000096ms/shape :: 0.0963ms (Min: 0.0938ms, Max: 0.135ms, Diff: 0.0412)
   100,000 - 0.0000086ms/shape :: 0.8616ms (Min: 0.8233ms, Max: 0.9648ms, Diff: 0.1415)
 1,000,000 - 0.0000086ms/shape :: 8.5673ms (Min: 8.3418ms, Max: 9.5006ms, Diff: 1.1588)

Switch:
        10 - 0.0000094ms/shape :: 0.0001ms (Min: 0ms, Max: 0.0002ms, Diff: 0.0002)
       100 - 0.0000107ms/shape :: 0.0011ms (Min: 0.001ms, Max: 0.0011ms, Diff: 0.0001)
     1,000 - 0.0000252ms/shape :: 0.0252ms (Min: 0.0179ms, Max: 0.6718ms, Diff: 0.6539)
    10,000 - 0.0000098ms/shape :: 0.0980ms (Min: 0.0941ms, Max: 0.1219ms, Diff: 0.0278)
   100,000 - 0.0000088ms/shape :: 0.8821ms (Min: 0.8512ms, Max: 0.9204ms, Diff: 0.0692)
 1,000,000 - 0.0000087ms/shape :: 8.7338ms (Min: 8.5389ms, Max: 8.9291ms, Diff: 0.3902)

Switch Expression:
        10 - 0.0000101ms/shape :: 0.0001ms (Min: 0.0001ms, Max: 0.0002ms, Diff: 0.0001)
       100 - 0.0000098ms/shape :: 0.0010ms (Min: 0.0009ms, Max: 0.0012ms, Diff: 0.0003)
     1,000 - 0.0000248ms/shape :: 0.0248ms (Min: 0.0177ms, Max: 0.6915ms, Diff: 0.6738)
    10,000 - 0.0000097ms/shape :: 0.0966ms (Min: 0.0936ms, Max: 0.1049ms, Diff: 0.0113)
   100,000 - 0.0000085ms/shape :: 0.8453ms (Min: 0.8243ms, Max: 0.892ms, Diff: 0.0677)
 1,000,000 - 0.0000086ms/shape :: 8.5640ms (Min: 8.4173ms, Max: 8.7489ms, Diff: 0.3316)

Class Strategy:
        10 - 0.0000192ms/shape :: 0.0002ms (Min: 0.0001ms, Max: 0.0018ms, Diff: 0.0017)
       100 - 0.0000176ms/shape :: 0.0018ms (Min: 0.0017ms, Max: 0.0022ms, Diff: 0.0005)
     1,000 - 0.0000205ms/shape :: 0.0205ms (Min: 0.0164ms, Max: 0.388ms, Diff: 0.3716)
    10,000 - 0.0000119ms/shape :: 0.1191ms (Min: 0.1168ms, Max: 0.1719ms, Diff: 0.0551)
   100,000 - 0.0000114ms/shape :: 1.1374ms (Min: 1.1033ms, Max: 1.2683ms, Diff: 0.1650)
 1,000,000 - 0.0000115ms/shape :: 11.5422ms (Min: 11.3631ms, Max: 12.1826ms, Diff: 0.8195)

Func Strategy:
        10 - 0.0000248ms/shape :: 0.0002ms (Min: 0.0002ms, Max: 0.0018ms, Diff: 0.0016)
       100 - 0.0000259ms/shape :: 0.0026ms (Min: 0.0025ms, Max: 0.0029ms, Diff: 0.0004)
     1,000 - 0.0000302ms/shape :: 0.0302ms (Min: 0.0255ms, Max: 0.3922ms, Diff: 0.3667)
    10,000 - 0.0000179ms/shape :: 0.1793ms (Min: 0.1711ms, Max: 0.2142ms, Diff: 0.0431)
   100,000 - 0.0000169ms/shape :: 1.6906ms (Min: 1.6555ms, Max: 1.7574ms, Diff: 0.1019)
 1,000,000 - 0.0000169ms/shape :: 16.8721ms (Min: 16.5575ms, Max: 17.2304ms, Diff: 0.6729)
```

## Observations ##

It was hard to test the jump logic only and some of the algorithmic complexity is likely affecting the results.

Both strategy patterns come at a performance cost. They also seem to come at a readability cost - though could be due to the simplistic nature of the calculation.
My preference for readability (again, for such simplistic algorithms) is the switch expression. This also seems to be the fastest, comparible to raw `if` checks.

the comparison between `switch`, `if` and switch expression varies at different scales and the margin of error isn't great for comparing definitively.

## Conclusion ##

I conclude that using Switch Expressions is a good default choice - especially for readability - before measuring anything. But choosing if and switch are also acceptible default perf choices.

You have to measure in your own situation as there are many factors that affect how different switching performs - don't just blindly take these results as definitive.

Using the strategy pattern has to really improve Developer/Development Maintainance and/or readability to be worth considering, based on the results presented here.


This exercise was Inspired by ["Clean" Code, Horrible Performance](https://www.computerenhance.com/p/clean-code-horrible-performance)