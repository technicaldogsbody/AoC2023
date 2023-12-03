using AdventOfCode.Shared;
using Day03;
using System.Diagnostics.CodeAnalysis;

var parser = new EnginePartParser();

var sample = FileService.GetFileAsArray("sample.txt");

var sumOfPartNumbers = parser.SumOfPartNumbers(sample.ToArray());

Console.WriteLine($"Sample: {sumOfPartNumbers}");

var full = FileService.GetFileAsArray("full.txt");

sumOfPartNumbers = parser.SumOfPartNumbers(full.ToArray());

Console.WriteLine($"Full: {sumOfPartNumbers}");

var sumOfGearRatios = parser.SumOfGearRatios(sample.ToArray());

Console.WriteLine($"Sample 2: {sumOfGearRatios}");

sumOfGearRatios = parser.SumOfGearRatios(full.ToArray());

Console.WriteLine($"Full 2: {sumOfGearRatios}");

[ExcludeFromCodeCoverage]
public partial class Program { }