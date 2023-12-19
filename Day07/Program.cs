using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AdventOfCode.Shared;
using Day07;

// Example input
string[] input =
{
    "32T3K 765",
    "T55J5 684",
    "KK677 28",
    "KTJJT 220",
    "QQQJA 483"
};

var actualinput = FileService.GetFileAsArray("full.txt").ToArray();

FancyConsole.WriteInfo("Day 07", new List<(string name, Func<object> function)>
{
    ("Sample 1", () => GetTotalWinnings(input)),
    ("Full 1", () => GetTotalWinnings(actualinput)),
    ("Sample 2", () => GetJokerTotalWinnings(input)),
    ("Full 2", () => GetJokerTotalWinnings(actualinput))
});

int GetTotalWinnings(string[] strings)
{
    var hands = strings.Select(line => line.Split(' '))
        .Select(parts => new JokerHand(parts[0], int.Parse(parts[1])))
        .ToList();

    hands.Sort();

    return hands.Select((t, i) => t.Bid * (i + 1)).Sum();
}

int GetJokerTotalWinnings(string[] strings)
{
    var hands = strings.Select(line => line.Split(' '))
        .Select(parts => new JokerHand(parts[0], int.Parse(parts[1])))
        .ToList();

    hands.Sort();

    return hands.Select((t, i) => t.Bid * (i + 1)).Sum();
}

[ExcludeFromCodeCoverage]
public partial class Program { }