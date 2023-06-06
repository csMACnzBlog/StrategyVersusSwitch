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
        10 - 0.0000110ms/shape :: 0.0001ms (Min: 0.0001ms, Max: 0.0005ms, Diff: 0.0004)
       100 - 0.0000078ms/shape :: 0.0008ms (Min: 0.0007ms, Max: 0.0008ms, Diff: 0.0001)
     1,000 - 0.0000115ms/shape :: 0.0115ms (Min: 0.0075ms, Max: 0.3278ms, Diff: 0.3203)
    10,000 - 0.0000020ms/shape :: 0.0196ms (Min: 0.019ms, Max: 0.0242ms, Diff: 0.0052)
   100,000 - 0.0000013ms/shape :: 0.1259ms (Min: 0.1225ms, Max: 0.1427ms, Diff: 0.0202)
 1,000,000 - 0.0000027ms/shape :: 2.7107ms (Min: 2.5695ms, Max: 3.3234ms, Diff: 0.7539)

If Checks:
        10 - 0.0000182ms/shape :: 0.0002ms (Min: 0.0001ms, Max: 0.0003ms, Diff: 0.0002)
       100 - 0.0000159ms/shape :: 0.0016ms (Min: 0.0015ms, Max: 0.0019ms, Diff: 0.0004)
     1,000 - 0.0000267ms/shape :: 0.0267ms (Min: 0.018ms, Max: 0.8358ms, Diff: 0.8178)
    10,000 - 0.0000094ms/shape :: 0.0942ms (Min: 0.0911ms, Max: 0.1045ms, Diff: 0.0134)
   100,000 - 0.0000083ms/shape :: 0.8301ms (Min: 0.8129ms, Max: 0.9052ms, Diff: 0.0923)
 1,000,000 - 0.0000084ms/shape :: 8.3536ms (Min: 8.1706ms, Max: 8.5874ms, Diff: 0.4168)

Switch:
        10 - 0.0000082ms/shape :: 0.0001ms (Min: 0ms, Max: 0.0002ms, Diff: 0.0002)
       100 - 0.0000093ms/shape :: 0.0009ms (Min: 0.0009ms, Max: 0.001ms, Diff: 0.0001)
     1,000 - 0.0000236ms/shape :: 0.0236ms (Min: 0.0167ms, Max: 0.6568ms, Diff: 0.6401)
    10,000 - 0.0000097ms/shape :: 0.0971ms (Min: 0.0939ms, Max: 0.135ms, Diff: 0.0411)
   100,000 - 0.0000086ms/shape :: 0.8575ms (Min: 0.8221ms, Max: 0.9078ms, Diff: 0.0857)
 1,000,000 - 0.0000085ms/shape :: 8.4866ms (Min: 8.2991ms, Max: 8.756ms, Diff: 0.4569)

Switch Expression:
        10 - 0.0000079ms/shape :: 0.0001ms (Min: 0ms, Max: 0.0002ms, Diff: 0.0002)
       100 - 0.0000088ms/shape :: 0.0009ms (Min: 0.0008ms, Max: 0.0009ms, Diff: 0.0001)
     1,000 - 0.0000241ms/shape :: 0.0241ms (Min: 0.0175ms, Max: 0.6331ms, Diff: 0.6156)
    10,000 - 0.0000099ms/shape :: 0.0992ms (Min: 0.0943ms, Max: 0.1137ms, Diff: 0.0194)
   100,000 - 0.0000089ms/shape :: 0.8932ms (Min: 0.8574ms, Max: 0.9837ms, Diff: 0.1263)
 1,000,000 - 0.0000087ms/shape :: 8.6805ms (Min: 8.5066ms, Max: 8.9661ms, Diff: 0.4595)

Static Functions Switch Expression:
        10 - 0.0000126ms/shape :: 0.0001ms (Min: 0.0001ms, Max: 0.0007ms, Diff: 0.0006)
       100 - 0.0000175ms/shape :: 0.0017ms (Min: 0.0017ms, Max: 0.002ms, Diff: 0.0003)
     1,000 - 0.0000260ms/shape :: 0.0260ms (Min: 0.0211ms, Max: 0.4328ms, Diff: 0.4117)
    10,000 - 0.0000140ms/shape :: 0.1400ms (Min: 0.1372ms, Max: 0.1507ms, Diff: 0.0135)
   100,000 - 0.0000132ms/shape :: 1.3192ms (Min: 1.2969ms, Max: 1.4331ms, Diff: 0.1362)
 1,000,000 - 0.0000134ms/shape :: 13.4381ms (Min: 13.1358ms, Max: 14.5464ms, Diff: 1.4106)

Class Strategy With Jump Table:
        10 - 0.0000219ms/shape :: 0.0002ms (Min: 0.0001ms, Max: 0.0017ms, Diff: 0.0016)
       100 - 0.0000159ms/shape :: 0.0016ms (Min: 0.0015ms, Max: 0.0018ms, Diff: 0.0003)
     1,000 - 0.0000204ms/shape :: 0.0204ms (Min: 0.0163ms, Max: 0.3205ms, Diff: 0.3042)
    10,000 - 0.0000125ms/shape :: 0.1246ms (Min: 0.1226ms, Max: 0.1371ms, Diff: 0.0145)
   100,000 - 0.0000121ms/shape :: 1.2099ms (Min: 1.1749ms, Max: 1.2546ms, Diff: 0.0797)
 1,000,000 - 0.0000120ms/shape :: 11.9709ms (Min: 11.7484ms, Max: 12.6681ms, Diff: 0.9197)

Lambda Strategy With Jump Table:
        10 - 0.0000132ms/shape :: 0.0001ms (Min: 0.0001ms, Max: 0.0007ms, Diff: 0.0006)
       100 - 0.0000151ms/shape :: 0.0015ms (Min: 0.0015ms, Max: 0.0017ms, Diff: 0.0002)
     1,000 - 0.0000230ms/shape :: 0.0230ms (Min: 0.0191ms, Max: 0.3278ms, Diff: 0.3087)
    10,000 - 0.0000133ms/shape :: 0.1329ms (Min: 0.1281ms, Max: 0.1513ms, Diff: 0.0232)
   100,000 - 0.0000126ms/shape :: 1.2622ms (Min: 1.2253ms, Max: 1.3183ms, Diff: 0.0930)
 1,000,000 - 0.0000127ms/shape :: 12.6927ms (Min: 12.4098ms, Max: 12.9578ms, Diff: 0.5480)

Static Func Strategy With Jump Table:
        10 - 0.0000170ms/shape :: 0.0002ms (Min: 0.0001ms, Max: 0.0008ms, Diff: 0.0007)
       100 - 0.0000181ms/shape :: 0.0018ms (Min: 0.0017ms, Max: 0.0023ms, Diff: 0.0006)
     1,000 - 0.0000240ms/shape :: 0.0240ms (Min: 0.0199ms, Max: 0.3168ms, Diff: 0.2969)
    10,000 - 0.0000146ms/shape :: 0.1459ms (Min: 0.1415ms, Max: 0.1886ms, Diff: 0.0471)
   100,000 - 0.0000141ms/shape :: 1.4091ms (Min: 1.3474ms, Max: 1.4803ms, Diff: 0.1329)
 1,000,000 - 0.0000141ms/shape :: 14.1047ms (Min: 13.8202ms, Max: 14.574ms, Diff: 0.7538)

Class Strategy Without Jump Table:
        10 - 0.0000323ms/shape :: 0.0003ms (Min: 0.0001ms, Max: 0.0046ms, Diff: 0.0045)
       100 - 0.0000332ms/shape :: 0.0033ms (Min: 0.0024ms, Max: 0.0175ms, Diff: 0.0151)
     1,000 - 0.0000361ms/shape :: 0.0361ms (Min: 0.0309ms, Max: 0.2326ms, Diff: 0.2017)
    10,000 - 0.0000536ms/shape :: 0.5356ms (Min: 0.2351ms, Max: 14.0535ms, Diff: 13.8184)
   100,000 - 0.0000244ms/shape :: 2.4364ms (Min: 2.3085ms, Max: 2.8862ms, Diff: 0.5777)
 1,000,000 - 0.0000251ms/shape :: 25.1282ms (Min: 24.706ms, Max: 25.7872ms, Diff: 1.0812)

Lambda Strategy Without Jump Table:
        10 - 0.0000184ms/shape :: 0.0002ms (Min: 0.0001ms, Max: 0.0006ms, Diff: 0.0005)
       100 - 0.0000215ms/shape :: 0.0021ms (Min: 0.0021ms, Max: 0.0022ms, Diff: 0.0001)
     1,000 - 0.0000237ms/shape :: 0.0237ms (Min: 0.0211ms, Max: 0.1992ms, Diff: 0.1781)
    10,000 - 0.0000202ms/shape :: 0.2019ms (Min: 0.1918ms, Max: 0.2498ms, Diff: 0.0580)
   100,000 - 0.0000195ms/shape :: 1.9517ms (Min: 1.9053ms, Max: 2.0546ms, Diff: 0.1493)
 1,000,000 - 0.0000196ms/shape :: 19.6419ms (Min: 19.321ms, Max: 20.4619ms, Diff: 1.1409)

Static Func Strategy Without Jump Table:
        10 - 0.0000190ms/shape :: 0.0002ms (Min: 0.0001ms, Max: 0.0004ms, Diff: 0.0003)
       100 - 0.0000225ms/shape :: 0.0023ms (Min: 0.0022ms, Max: 0.0023ms, Diff: 0.0001)
     1,000 - 0.0000245ms/shape :: 0.0245ms (Min: 0.0215ms, Max: 0.2385ms, Diff: 0.2170)
    10,000 - 0.0000202ms/shape :: 0.2022ms (Min: 0.1961ms, Max: 0.2476ms, Diff: 0.0515)
   100,000 - 0.0000200ms/shape :: 1.9983ms (Min: 1.9645ms, Max: 2.0958ms, Diff: 0.1313)
 1,000,000 - 0.0000202ms/shape :: 20.1976ms (Min: 19.8736ms, Max: 20.6171ms, Diff: 0.7435)


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