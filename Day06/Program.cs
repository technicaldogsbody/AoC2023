using System.Diagnostics.CodeAnalysis;
using AdventOfCode.Shared;
using Day06;

long[] sampleRaceTimes = { 7, 15, 30 };
long[] sampleRecordDistances = { 9, 40, 200 };
long[] raceTimes = { 54, 70, 82, 75 };
long[] recordDistances = { 239, 1142, 1295, 1253 };

long[] sampleRaceTimes2 = { 71530 };
long[] sampleRecordDistances2 = { 940200 };
long[] raceTimes2 = { 54708275 };
long[] recordDistances2 = { 239114212951253 };

var calculator = new RaceCalculator();

FancyConsole.WriteInfo("Day 06", new List<(string name, Func<object> function)>
{
    ("Sample 1", () => calculator.GetMarginOfError(sampleRaceTimes, sampleRecordDistances)),
    ("Full 1", () => calculator.GetMarginOfError(raceTimes, recordDistances)),
    ("Sample 2", () => calculator.GetMarginOfError(sampleRaceTimes2, sampleRecordDistances2)),
    ("Full 2", () => calculator.GetMarginOfError(raceTimes2, recordDistances2))
});

[ExcludeFromCodeCoverage]
public partial class Program { }