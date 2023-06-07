
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using StrategyVersusSwitch;

BenchmarkRunner.Run<Benchmarks>(
                ManualConfig
                    .Create(DefaultConfig.Instance)
                    .WithOption(ConfigOptions.JoinSummary, true) 
                    .WithOption(ConfigOptions.DisableLogFile, true)
                    .WithOption(ConfigOptions.GenerateMSBuildBinLog, false)
                    .WithOption(ConfigOptions.LogBuildOutput, false),
                args);