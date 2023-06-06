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

Fast Check:
        10 - 0.0000110ms/shape :: 0.0001ms (Min: 0.0001ms, Max: 0.0008ms, Diff: 0.0007)
       100 - 0.0000086ms/shape :: 0.0009ms (Min: 0.0008ms, Max: 0.0012ms, Diff: 0.0004)
     1,000 - 0.0000118ms/shape :: 0.0118ms (Min: 0.0078ms, Max: 0.3688ms, Diff: 0.3610)
    10,000 - 0.0000020ms/shape :: 0.0197ms (Min: 0.0191ms, Max: 0.0294ms, Diff: 0.0103)
   100,000 - 0.0000014ms/shape :: 0.1422ms (Min: 0.1328ms, Max: 0.1921ms, Diff: 0.0593)
 1,000,000 - 0.0000031ms/shape :: 3.1312ms (Min: 2.8944ms, Max: 4.0691ms, Diff: 1.1747)

If Checks:
        10 - 0.0000193ms/shape :: 0.0002ms (Min: 0.0001ms, Max: 0.0004ms, Diff: 0.0003)
       100 - 0.0000158ms/shape :: 0.0016ms (Min: 0.0015ms, Max: 0.0019ms, Diff: 0.0004)
     1,000 - 0.0000274ms/shape :: 0.0274ms (Min: 0.0181ms, Max: 0.8572ms, Diff: 0.8391)
    10,000 - 0.0000098ms/shape :: 0.0975ms (Min: 0.0931ms, Max: 0.1156ms, Diff: 0.0225)
   100,000 - 0.0000087ms/shape :: 0.8685ms (Min: 0.841ms, Max: 0.9591ms, Diff: 0.1181)
 1,000,000 - 0.0000086ms/shape :: 8.6335ms (Min: 8.4531ms, Max: 8.9435ms, Diff: 0.4904)

Switch:
        10 - 0.0000088ms/shape :: 0.0001ms (Min: 0ms, Max: 0.0002ms, Diff: 0.0002)
       100 - 0.0000074ms/shape :: 0.0007ms (Min: 0.0007ms, Max: 0.001ms, Diff: 0.0003)
     1,000 - 0.0000230ms/shape :: 0.0230ms (Min: 0.016ms, Max: 0.6497ms, Diff: 0.6337)
    10,000 - 0.0000094ms/shape :: 0.0941ms (Min: 0.0917ms, Max: 0.1026ms, Diff: 0.0109)
   100,000 - 0.0000084ms/shape :: 0.8438ms (Min: 0.8182ms, Max: 0.8841ms, Diff: 0.0659)
 1,000,000 - 0.0000084ms/shape :: 8.4424ms (Min: 8.2997ms, Max: 8.673ms, Diff: 0.3733)

Switch Expression:
        10 - 0.0000095ms/shape :: 0.0001ms (Min: 0ms, Max: 0.0001ms, Diff: 0.0001)
       100 - 0.0000075ms/shape :: 0.0008ms (Min: 0.0007ms, Max: 0.0009ms, Diff: 0.0002)
     1,000 - 0.0000238ms/shape :: 0.0238ms (Min: 0.0165ms, Max: 0.634ms, Diff: 0.6175)
    10,000 - 0.0000093ms/shape :: 0.0930ms (Min: 0.0906ms, Max: 0.1263ms, Diff: 0.0357)
   100,000 - 0.0000083ms/shape :: 0.8268ms (Min: 0.8051ms, Max: 0.8687ms, Diff: 0.0636)
 1,000,000 - 0.0000083ms/shape :: 8.3131ms (Min: 8.1624ms, Max: 8.6228ms, Diff: 0.4604)

Class Strategy With Jump Table:
        10 - 0.0000268ms/shape :: 0.0003ms (Min: 0.0001ms, Max: 0.0071ms, Diff: 0.0070)
       100 - 0.0000182ms/shape :: 0.0018ms (Min: 0.0018ms, Max: 0.002ms, Diff: 0.0002)
     1,000 - 0.0000216ms/shape :: 0.0216ms (Min: 0.0178ms, Max: 0.3594ms, Diff: 0.3416)
    10,000 - 0.0000133ms/shape :: 0.1330ms (Min: 0.1266ms, Max: 0.1484ms, Diff: 0.0218)
   100,000 - 0.0000124ms/shape :: 1.2419ms (Min: 1.2225ms, Max: 1.3194ms, Diff: 0.0969)
 1,000,000 - 0.0000125ms/shape :: 12.4834ms (Min: 12.2773ms, Max: 12.8046ms, Diff: 0.5273)

Lambda Strategy With Jump Table:
        10 - 0.0000192ms/shape :: 0.0002ms (Min: 0.0001ms, Max: 0.0014ms, Diff: 0.0013)
       100 - 0.0000253ms/shape :: 0.0025ms (Min: 0.0023ms, Max: 0.0106ms, Diff: 0.0083)
     1,000 - 0.0000268ms/shape :: 0.0268ms (Min: 0.0226ms, Max: 0.3477ms, Diff: 0.3251)
    10,000 - 0.0000153ms/shape :: 0.1534ms (Min: 0.1474ms, Max: 0.1918ms, Diff: 0.0444)
   100,000 - 0.0000144ms/shape :: 1.4383ms (Min: 1.4089ms, Max: 1.498ms, Diff: 0.0891)
 1,000,000 - 0.0000143ms/shape :: 14.3396ms (Min: 14.2046ms, Max: 14.6244ms, Diff: 0.4198)

Static Func Strategy With Jump Table:
        10 - 0.0000116ms/shape :: 0.0001ms (Min: 0.0001ms, Max: 0.0004ms, Diff: 0.0003)
       100 - 0.0000158ms/shape :: 0.0016ms (Min: 0.0015ms, Max: 0.0017ms, Diff: 0.0002)
     1,000 - 0.0000232ms/shape :: 0.0232ms (Min: 0.0196ms, Max: 0.3275ms, Diff: 0.3079)
    10,000 - 0.0000143ms/shape :: 0.1434ms (Min: 0.1388ms, Max: 0.1779ms, Diff: 0.0391)
   100,000 - 0.0000134ms/shape :: 1.3428ms (Min: 1.3165ms, Max: 1.4036ms, Diff: 0.0871)
 1,000,000 - 0.0000134ms/shape :: 13.3845ms (Min: 13.2292ms, Max: 15.0009ms, Diff: 1.7717)

Class Strategy Without Jump Table:
        10 - 0.0000356ms/shape :: 0.0004ms (Min: 0.0002ms, Max: 0.0031ms, Diff: 0.0029)
       100 - 0.0000370ms/shape :: 0.0037ms (Min: 0.0028ms, Max: 0.0084ms, Diff: 0.0056)
     1,000 - 0.0000392ms/shape :: 0.0392ms (Min: 0.033ms, Max: 0.2312ms, Diff: 0.1982)
    10,000 - 0.0000554ms/shape :: 0.5539ms (Min: 0.2539ms, Max: 17.3243ms, Diff: 17.0704)
   100,000 - 0.0000274ms/shape :: 2.7388ms (Min: 2.546ms, Max: 3.0527ms, Diff: 0.5067)
 1,000,000 - 0.0000277ms/shape :: 27.6766ms (Min: 26.9672ms, Max: 28.3966ms, Diff: 1.4294)

Lambda Strategy Without Jump Table:
        10 - 0.0000184ms/shape :: 0.0002ms (Min: 0.0001ms, Max: 0.0007ms, Diff: 0.0006)
       100 - 0.0000225ms/shape :: 0.0023ms (Min: 0.0022ms, Max: 0.0024ms, Diff: 0.0002)
     1,000 - 0.0000237ms/shape :: 0.0237ms (Min: 0.0211ms, Max: 0.2159ms, Diff: 0.1948)
    10,000 - 0.0000204ms/shape :: 0.2044ms (Min: 0.199ms, Max: 0.2287ms, Diff: 0.0297)
   100,000 - 0.0000200ms/shape :: 2.0035ms (Min: 1.9615ms, Max: 2.0865ms, Diff: 0.1250)
 1,000,000 - 0.0000201ms/shape :: 20.0666ms (Min: 19.7824ms, Max: 21.1721ms, Diff: 1.3897)

Static Func Strategy Without Jump Table:
        10 - 0.0000207ms/shape :: 0.0002ms (Min: 0.0001ms, Max: 0.0015ms, Diff: 0.0014)
       100 - 0.0000236ms/shape :: 0.0024ms (Min: 0.0023ms, Max: 0.0034ms, Diff: 0.0011)
     1,000 - 0.0000261ms/shape :: 0.0261ms (Min: 0.0235ms, Max: 0.2277ms, Diff: 0.2042)
    10,000 - 0.0000220ms/shape :: 0.2204ms (Min: 0.2103ms, Max: 0.2454ms, Diff: 0.0351)
   100,000 - 0.0000219ms/shape :: 2.1936ms (Min: 2.1137ms, Max: 2.3146ms, Diff: 0.2009)
 1,000,000 - 0.0000216ms/shape :: 21.6153ms (Min: 21.2336ms, Max: 22.1892ms, Diff: 0.9556)

```

## Observations ##

Fast Check is super fast! (always look for algorithmic replacements for perf increases instead of micro-optimising language features!)

It was hard to test the jump logic only and some of the algorithmic complexity is likely affecting the results.

Strategy patterns come at a performance cost. They also seem to come at a readability cost - though could be due to the simplistic nature of the calculation.
My preference for readability (again, for such simplistic algorithms) is the switch expression. This also seems to be the fastest (comparing apples to apples), comparible to raw `if` checks.

the comparison between `switch`, `if` and switch expression varies at different scales and the margin of error isn't great for comparing definitively.

## Conclusion ##

I conclude that using Switch Expressions is a good default choice - especially for readability - before measuring anything. But choosing if and switch are also acceptible default perf choices.

You have to measure in your own situation as there are many factors that affect how different switching performs - don't just blindly take these results as definitive.

Using the strategy pattern has to really improve Developer/Development Maintainance and/or readability to be worth considering, based on the results presented here.


This exercise was Inspired by ["Clean" Code, Horrible Performance](https://www.computerenhance.com/p/clean-code-horrible-performance)

Another Blog doing similar analysis and conclusions: https://davidkroell.com/blog/2022/switch-is-faster-than-if/