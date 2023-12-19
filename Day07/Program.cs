using System;
using System.Collections.Generic;
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

var hands = actualinput.Select(line => line.Split(' '))
    .Select(parts => new JokerHand(parts[0], int.Parse(parts[1])))
    .ToList();

hands.Sort();

int totalWinnings = 0;
for (int i = 0; i < hands.Count; i++)
{
    Console.WriteLine($"{hands[i].Cards} ({hands[i].SortedCards}) - { hands[i].DetermineHandType() } - {hands[i].Bid} * {i + 1}");
    totalWinnings += hands[i].Bid * (i + 1);
}

Console.WriteLine($"Total winnings: {totalWinnings}");