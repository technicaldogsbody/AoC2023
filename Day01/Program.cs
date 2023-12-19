using AdventOfCode.Shared;
using Day01;
using System.Diagnostics.CodeAnalysis;

var calibrations = new Calibrations();

var sample = FileService.GetFileAsArray("sample.txt");
var full = FileService.GetFileAsArray("full.txt");
var sample2 = FileService.GetFileAsArray("sample2.txt");

FancyConsole.WriteInfo("Day 01", new List<(string name, Func<object> function)>
{
    ("Sample 1", () => calibrations.GetTotal(sample)),
    ("Full 1", () => calibrations.GetTotal(full)),
    ("Sample 2", () => calibrations.GetTrueTotal(sample2)),
    ("Full 2", () => calibrations.GetTrueTotal(full))
});

Console.ReadLine();

[ExcludeFromCodeCoverage]
public partial class Program { }