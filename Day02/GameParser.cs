namespace Day02
{
    public class GameParser
    {
        private Dictionary<int, List<(int red, int green, int blue)>> ParseGames(IEnumerable<string> lines)
        {
            var gamesList = new Dictionary<int, List<(int red, int green, int blue)>>();

            foreach (var game in lines)
            {
                var parts = game.Split(':');
                var gameId = int.Parse(parts[0].Replace("Game ", "").Trim());
                var cubeCounts = parts[1].Split(';').Select(s => ParseCubeCounts(s.Trim())).ToList();
                gamesList[gameId] = cubeCounts;
            }

            return gamesList;
        }

        private (int red, int green, int blue) ParseCubeCounts(string subset)
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

        public int GetSumOfValidGameIds(IEnumerable<string> lines, int maxRed, int maxGreen, int maxBlue)
        {
            var games = ParseGames(lines);
            
            return games.Where(game => IsGameValid(game.Value, maxRed, maxGreen, maxBlue)).Sum(game => game.Key);
        }

        private bool IsGameValid(List<(int red, int green, int blue)> subsets, int maxRed, int maxGreen, int maxBlue)
        {
            return subsets.All(subset => subset.red <= maxRed && subset.green <= maxGreen && subset.blue <= maxBlue);
        }

        public long CalculateSumOfPowers(IEnumerable<string> lines)
        {
            var games = ParseGames(lines);
            
            long sum = 0;
            foreach (var game in games)
            {
                var (red, green, blue) = FindMinimumCubes(game.Value);
                var power = (long)red * green * blue;
                sum += power;
            }
            return sum;
        }

        private (int red, int green, int blue) FindMinimumCubes(List<(int red, int green, int blue)> subsets)
        {
            var minRed = subsets.Max(subset => subset.red);
            var minGreen = subsets.Max(subset => subset.green);
            var minBlue = subsets.Max(subset => subset.blue);

            return (minRed, minGreen, minBlue);
        }
    }
}
