using AdventOfCode.Shared;
using Day02;
using System.Diagnostics.CodeAnalysis;

var parser = new GameParser();

var sample = FileService.GetFileAsArray("sample.txt");
var games = parser.ParseGames(sample);
var sumOfValidGameIds = parser.GetSumOfValidGameIds(games, 12, 13, 14);
var sumOfPowers = parser.CalculateSumOfPowers(games);

Console.WriteLine($"Sample: {sumOfValidGameIds}");
Console.WriteLine($"Sample: {sumOfPowers}");



var full = FileService.GetFileAsArray("full.txt");
games = parser.ParseGames(full);
sumOfValidGameIds = parser.GetSumOfValidGameIds(games, 12, 13, 14);
sumOfPowers = parser.CalculateSumOfPowers(games);

Console.WriteLine($"Full: {sumOfValidGameIds}");
Console.WriteLine($"Full 2: {sumOfPowers}");

[ExcludeFromCodeCoverage]
public partial class Program { }

