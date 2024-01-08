
using AdventOfCode.Shared;
using Day08;

var sampleInput = FileService.GetFileAsArray("sample.txt").ToArray();
var sample2Input = FileService.GetFileAsArray("sample2.txt").ToArray();
var sample3Input = FileService.GetFileAsArray("sample3.txt").ToArray();
var fullInput = FileService.GetFileAsArray("full.txt").ToArray();
var navigator = new MapNavigator();

FancyConsole.WriteInfo("Day 08", new List<(string name, Func<object> function)>
{
    ("Sample 1", () => navigator.StepsToEscape(sampleInput)),
    ("Sample 2", () => navigator.StepsToEscape(sample2Input)),
    ("Full 1", () => navigator.StepsToEscape(fullInput)),
    ("Sample 3", () => navigator.GhostStepsToEscape(sample3Input)),
    ("Full 2", () => navigator.GhostStepsToEscape(fullInput)),
});