﻿namespace Day02
{
    public class GameParser
    {
        public Dictionary<int, List<(int red, int green, int blue)>> ParseGames(IEnumerable<string> gameStrings)
        {
            var gamesList = new Dictionary<int, List<(int red, int green, int blue)>>();

            foreach (var game in gameStrings)
            {
                var parts = game.Split(':');
                var gameId = int.Parse(parts[0].Replace("Game ", "").Trim());
                var cubeCounts = parts[1].Split(';').Select(s => ParseCubeCounts(s.Trim())).ToList();
                gamesList[gameId] = cubeCounts;
            }

            return gamesList;
        }

        public (int red, int green, int blue) ParseCubeCounts(string subset)
        {
            int red = 0, green = 0, blue = 0;
            var counts = subset.Split(',');
            foreach (var count in counts)
            {
                var parts = count.Trim().Split(' ');
                var number = int.Parse(parts[0]);
                switch (parts[1])
                {
                    case "red": red = number; break;
                    case "green": green = number; break;
                    case "blue": blue = number; break;
                }
            }
            return (red, green, blue);
        }

        public int GetSumOfValidGameIds(Dictionary<int, List<(int red, int green, int blue)>> games, int maxRed, int maxGreen, int maxBlue)
        {
            return games.Where(game => IsGameValid(game.Value, maxRed, maxGreen, maxBlue)).Sum(game => game.Key);
        }

        public bool IsGameValid(List<(int red, int green, int blue)> subsets, int maxRed, int maxGreen, int maxBlue)
        {
            return subsets.All(subset => subset.red <= maxRed && subset.green <= maxGreen && subset.blue <= maxBlue);
        }

        public long CalculateSumOfPowers(Dictionary<int, List<(int red, int green, int blue)>> games)
        {
            long sum = 0;
            foreach (var game in games)
            {
                var (red, green, blue) = FindMinimumCubes(game.Value);
                var power = (long)red * green * blue;
                sum += power;
            }
            return sum;
        }

        public (int red, int green, int blue) FindMinimumCubes(List<(int red, int green, int blue)> subsets)
        {
            var minRed = subsets.Max(subset => subset.red);
            var minGreen = subsets.Max(subset => subset.green);
            var minBlue = subsets.Max(subset => subset.blue);

            return (minRed, minGreen, minBlue);
        }
    }
}
