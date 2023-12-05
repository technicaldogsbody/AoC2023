using AdventOfCode.Shared;
using Day04;
using System.Diagnostics.CodeAnalysis;

GameChecker checker = new();

var sample = FileService.GetFileAsArray("sample.txt");
var full = FileService.GetFileAsArray("full.txt");

var sumOfCardPoints = checker.GetSumOfCardPoints(sample);
Console.WriteLine($"Sample: {sumOfCardPoints}");

sumOfCardPoints = checker.GetSumOfCardPoints(full);
Console.WriteLine($"Full: {sumOfCardPoints}");

var totalNumOfCards = checker.GetTotalNumberOfCards(sample);
Console.WriteLine($"Sample 2: {totalNumOfCards}");

totalNumOfCards = checker.GetTotalNumberOfCards(full);
Console.WriteLine($"Full 2: {totalNumOfCards}");

Console.ReadLine();

[ExcludeFromCodeCoverage]
public partial class Program { }