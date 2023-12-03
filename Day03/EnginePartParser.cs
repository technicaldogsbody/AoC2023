namespace Day03
{
    public class EnginePartParser
    {
        public int SumOfPartNumbers(string[] lines)
        {
            var sum = 0;
            var visited = new HashSet<(int, int)>();

            for (var i = 0; i < lines.Length; i++)
            {
                for (var j = 0; j < lines[i].Length; j++)
                {
                    if (char.IsDigit(lines[i][j]) && !visited.Contains((i, j)))
                    {
                        var (number, coordinates) = ExtractNumber(lines, i, j, visited);
                        if (IsAdjacentToSymbol(lines, coordinates))
                        {
                            sum += number;
                        }
                    }
                }
            }

            return sum;
        }

        private (int Number, List<(int, int)> Coordinates) ExtractNumber(string[] lines, int x, int y, HashSet<(int, int)> visited)
        {
            var number = "";
            var coordinates = new List<(int, int)>();
            while (y < lines[x].Length && char.IsDigit(lines[x][y]))
            {
                visited.Add((x, y));
                number += lines[x][y];
                coordinates.Add((x, y));
                y++;
            }
            return (int.Parse(number), coordinates);
        }

        private bool IsAdjacentToSymbol(string[] lines, List<(int, int)> coordinates)
        {
            foreach (var (x, y) in coordinates)
            {
                if (IsCellAdjacentToSymbol(lines, x, y))
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsCellAdjacentToSymbol(string[] lines, int x, int y)
        {
            int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

            for (var i = 0; i < 8; i++)
            {
                var adjX = x + dx[i];
                var adjY = y + dy[i];

                if (adjX >= 0 && adjX < lines.Length && adjY >= 0 && adjY < lines[adjX].Length)
                {
                    var adjacentChar = lines[adjX][adjY];
                    if (!char.IsDigit(adjacentChar) && adjacentChar != '.')
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public int SumOfGearRatios(string[] lines)
        {
            var sum = 0;
            var allNumbers = new Dictionary<(int, int), int>();

            for (var i = 0; i < lines.Length; i++)
            {
                for (var j = 0; j < lines[i].Length; j++)
                {
                    if (char.IsDigit(lines[i][j]) && !allNumbers.ContainsKey((i, j)))
                    {
                        var (number, coordinates) = ExtractNumber(lines, i, j, new HashSet<(int, int)>());
                        foreach (var c in coordinates)
                        {
                            allNumbers[c] = number;
                        }
                    }
                }
            }

            for (var i = 0; i < lines.Length; i++)
            {
                for (var j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] == '*')
                    {
                        var adjacentNumbers = GetAdjacentNumbers(i, j, allNumbers);
                        if (adjacentNumbers.Count == 2)
                        {
                            sum += adjacentNumbers[0] * adjacentNumbers[1];
                        }
                    }
                }
            }

            return sum;
        }

        private List<int> GetAdjacentNumbers(int x, int y, IReadOnlyDictionary<(int, int), int> allNumbers)
        {
            var adjacentNumbers = new HashSet<int>();
            int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

            for (var i = 0; i < 8; i++)
            {
                var adjX = x + dx[i];
                var adjY = y + dy[i];

                if (allNumbers.ContainsKey((adjX, adjY)))
                {
                    adjacentNumbers.Add(allNumbers[(adjX, adjY)]);
                }
            }

            return adjacentNumbers.ToList();
        }
    }
}
