using AdventOfCode.Shared;
using Day09;
using System.Diagnostics.CodeAnalysis;

var sampleInput = FileService.GetFileAsListOfListOfInt("sample.txt");
var fullInput = FileService.GetFileAsListOfListOfInt("full.txt");

var reporter = new OasisReporter();

FancyConsole.WriteInfo("Day 09", new List<(string name, Func<object> function)>
{
    ("Sample 1", () => reporter.GetExtrapolatedValue(sampleInput)),
    ("Full 1", () => reporter.GetExtrapolatedValue(fullInput)),
    ("Sample 2", () => reporter.GetExtrapolatedPreviousValue(sampleInput)),
    ("Full 2", () => reporter.GetExtrapolatedPreviousValue(fullInput)),

});

[ExcludeFromCodeCoverage]
public partial class Program { }