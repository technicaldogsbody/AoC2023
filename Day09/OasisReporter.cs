using AdventOfCode.Shared;

namespace Day09
{
    public class OasisReporter
    {
        public int GetExtrapolatedValue(List<List<int>> histories)
        {
            return histories.Sum(ExtrapolateNextValue);
        }

        private static int ExtrapolateNextValue(List<int> history)
        {
            if (history.Count <= 1)
            {
                return history.FirstOrDefault();
            }

            var sequences = new List<List<int>> { history };

            while (sequences.Last().Skip(1).Any(v => v != 0))
            {
                var newSequence = new List<int>();
                for (var i = 0; i < sequences.Last().Count - 1; i++)
                {
                    newSequence.Add(sequences.Last()[i + 1] - sequences.Last()[i]);
                }
                sequences.Add(newSequence);
            }

            for (var level = sequences.Count - 2; level >= 0; level--)
            {
                var lastValue = sequences[level].Last();
                var difference = sequences[level + 1].Last();
                var nextValue = lastValue + difference;
                sequences[level].Add(nextValue);
            }

            return sequences[0].Last();
        }

        public int GetExtrapolatedPreviousValue(List<List<int>> histories)
        {
            return histories.Sum(ExtrapolatePreviousValue);
        }

        private static int ExtrapolatePreviousValue(List<int> history)
        {
            if (history.Count <= 1)
            {
                return history.FirstOrDefault();
            }

            var sequences = new List<List<int>> { history };

            while (sequences.Last().Skip(1).Any(v => v != 0))
            {
                var newSequence = new List<int>();
                for (var i = 0; i < sequences.Last().Count - 1; i++)
                {
                    newSequence.Add(sequences.Last()[i + 1] - sequences.Last()[i]);
                }
                sequences.Add(newSequence);
            }

            for (var level = sequences.Count - 2; level >= 0; level--)
            {
                var firstValue = sequences[level].First();
                var difference = sequences[level + 1].First();
                var prevValue = firstValue - difference;
                sequences[level].Insert(0, prevValue);
            }

            return sequences[0].First();
        }
    }
}