using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day04
{
    public class GameChecker
    {
        public int GetSumOfCardPoints(IEnumerable<string> lines)
        {
            var results = GetRows(lines);

            return results.Sum(row => 
                row.winning.Where(number => row.numbers.Contains(number))
                    .Aggregate(0, (current, number) => current == 0 ? 1 : current * 2));
        }

        private static IEnumerable<(string[] winning, string[] numbers)> GetRows(IEnumerable<string> lines)
        {
            lines = lines.Select(l => l.Split(':').Last());

            IEnumerable<(string[] winning, string[] numbers)> results =
                lines.Select(l =>
                    (
                        l.Split("|").First().Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries),
                        l.Split("|").Last().Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                    )
                );

            return results;
        }

        public int GetTotalNumberOfCards(IEnumerable<string> lines)
        {
            var cardRows = GetRows(lines).ToList();

            return cardRows.Count + 
                   cardRows.Select(GetNumberOfMatches)
                       .Select((matches, i) => ProcessCardCopies(i, matches, cardRows)).Sum();
        }

        private int ProcessCardCopies(int currentCardIndex, int matches, List<(string[] winning, string[] numbers)> cardRows)
        {
            var totalCopies = 0;
            for (var i = 0; i < matches; i++)
            {
                var nextCardIndex = currentCardIndex + 1 + i;
                if (nextCardIndex < cardRows.Count)
                {
                    var matchesForCopy = GetNumberOfMatches(cardRows[nextCardIndex]);
                    totalCopies++;
                    totalCopies += ProcessCardCopies(nextCardIndex, matchesForCopy, cardRows);
                }
            }
            return totalCopies;
        }

        private int GetNumberOfMatches((string[] winning, string[] numbers) cardRow)
        {
            return cardRow.winning.Count(number => cardRow.numbers.Contains(number));
        }
    }
}
