using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01
{
    public class Calibrations
    {
        public int GetTotal(IEnumerable<string> enumerable)
        {
            var i = 0;

            foreach (var line in enumerable)
            {
                var nums = line.Where(char.IsDigit).ToList();
                if (nums.Any())
                {
                    var value = $"{nums.First()}{nums.Last()}";
                    i += int.Parse(value);
                }
            }

            return i;
        }

        public int GetTrueTotal(IEnumerable<string> enumerable)
        {
            var totalSum = 0;
            var numberTable = new Dictionary<string, int>
            {
                {"one", 1}, {"two", 2}, {"three", 3}, {"four", 4},
                {"five", 5}, {"six", 6}, {"seven", 7}, {"eight", 8}, {"nine", 9}
            };

            foreach (var line in enumerable)
            {
                int first = 0;
                int last = 0;
                var firstWord = new StringBuilder();
                var lastWord = new StringBuilder();

                foreach (var c in line)
                {
                    if (char.IsDigit(c))
                    {
                        first = int.Parse(c.ToString());
                        break;
                    }

                    firstWord.Append(c);
                    var found = false;

                    foreach (var pair in numberTable.Where(pair => firstWord.ToString().EndsWith(pair.Key, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        first = pair.Value;
                        found = true;
                    }

                    if (found)
                    {
                        break;
                    }
                }

                foreach (var c in line.Reverse())
                {
                    if (char.IsDigit(c))
                    {
                        last = int.Parse(c.ToString());
                        break;
                    }

                    lastWord.Insert(0, c);
                    var found = false;

                    foreach (var pair in numberTable.Where(pair => lastWord.ToString().StartsWith(pair.Key, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        last = pair.Value;
                        found = true;
                    }

                    if (found)
                    {
                        break;
                    }
                }

                var number = $"{first}{last}";

                totalSum += int.Parse(number);
            }

            return totalSum;
        }
    }
}
