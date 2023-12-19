using AdventOfCode.Shared;
using Day02;
using System.Diagnostics.CodeAnalysis;

var sample = FileService.GetFileAsArray("sample.txt");
var full = FileService.GetFileAsArray("full.txt");
var parser = new GameParser();

FancyConsole.WriteInfo("Day 02", new List<(string name, Func<object> function)>
{
    ("Sample 1", () => parser.GetSumOfValidGameIds(sample, 12, 13, 14)),
    ("Full 1", () => parser.GetSumOfValidGameIds(full, 12, 13, 14)),
    ("Sample 2", () => parser.CalculateSumOfPowers(sample)),
    ("Full 2", () => parser.CalculateSumOfPowers(full))
});

Console.ReadLine();

[ExcludeFromCodeCoverage]
public partial class Program { }

