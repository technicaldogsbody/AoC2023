using AdventOfCode.Shared;
using Day04;
using System.Diagnostics.CodeAnalysis;

GameChecker checker = new();

var sample = FileService.GetFileAsArray("sample.txt");
var full = FileService.GetFileAsArray("full.txt");

FancyConsole.WriteInfo("Day 04", new List<(string name, Func<object> function)>
{
    ("Sample 1", () => checker.GetSumOfCardPoints(sample)),
    ("Full 1", () => checker.GetSumOfCardPoints(full)),
    ("Sample 2", () => checker.GetTotalNumberOfCards(sample)),
    ("Full 2", () => checker.GetTotalNumberOfCards(full))
});

[ExcludeFromCodeCoverage]
public partial class Program { }