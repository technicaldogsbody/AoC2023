using AdventOfCode.Shared;
using Day03;
using System.Diagnostics.CodeAnalysis;

var parser = new EnginePartParser();

var sample = FileService.GetFileAsArray("sample.txt");
var full = FileService.GetFileAsArray("full.txt");


FancyConsole.WriteInfo("Day 03", new List<(string name, Func<object> function)>
{
    ("Sample 1", () => parser.SumOfPartNumbers(sample.ToArray())),
    ("Full 1", () => parser.SumOfPartNumbers(full.ToArray())),
    ("Sample 2", () => parser.SumOfGearRatios(sample.ToArray())),
    ("Full 2", () => parser.SumOfGearRatios(full.ToArray()))
});

[ExcludeFromCodeCoverage]
public partial class Program { }