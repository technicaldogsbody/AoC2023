using AdventOfCode.Shared;
using Day05;

var sample = FileService.GetFileAsString("sample.txt");
var full = FileService.GetFileAsString("full.txt");
var mapper = new GardenMapper();

FancyConsole.WriteInfo("Day 05", new List<(string name, Func<object> function)>
{
    ("Sample 1", () => mapper.GetLowestLocation(sample, false)),
    ("Full 1", () => mapper.GetLowestLocation(full, false)),
    ("Sample 2", () => mapper.GetLowestLocation(sample, true)),
    ("Full 2", () => mapper.GetLowestLocation(full, true))
});