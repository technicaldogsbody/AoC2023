using AdventOfCode.Shared;
using Day01;

var calibrations = new Calibrations();

var sample = FileService.GetFileAsArray("sample.txt");
var total = calibrations.GetTotal(sample);

Console.WriteLine("Sample: " + total);

var full = FileService.GetFileAsArray("full.txt");
total = calibrations.GetTotal(full);

Console.WriteLine("Full: " + total);

var sample2 = FileService.GetFileAsArray("sample2.txt");
total = calibrations.GetTrueTotal(sample2);

Console.WriteLine("Sample2: " + total);

total = calibrations.GetTrueTotal(full);
Console.WriteLine("Full2: " + total);

Console.ReadLine();