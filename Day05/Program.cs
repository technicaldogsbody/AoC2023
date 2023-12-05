using AdventOfCode.Shared;
using Day05;

var sample = FileService.GetFileAsString("sample.txt");
var full = FileService.GetFileAsString("full.txt");
var mapper = new GardenMapper();

var lowestLocation = mapper.GetLowestLocation(sample, false);
Console.WriteLine($"Sample: {lowestLocation}");

lowestLocation = mapper.GetLowestLocation(full, false);
Console.WriteLine($"Full: {lowestLocation}");

lowestLocation = mapper.GetLowestLocation(sample, true);
Console.WriteLine($"Sample 2: {lowestLocation}");

lowestLocation = mapper.GetLowestLocation(full, true);
Console.WriteLine($"Full 2: {lowestLocation}");