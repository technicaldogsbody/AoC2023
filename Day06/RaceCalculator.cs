namespace Day06;

public class RaceCalculator
{
    public long GetMarginOfError(long[] raceTimes, long[] recordDistances)
    {
        long totalWays = 1;

        for (var i = 0; i < raceTimes.Length; i++)
        {
            var waysToWin = CountWaysToWin(raceTimes[i], recordDistances[i]);
            totalWays *= waysToWin;
        }

        return totalWays;
    }
    
    private int CountWaysToWin(long raceTime, long recordDistance)
    {
        var ways = 0;
        for (var holdTime = 0; holdTime < raceTime; holdTime++)
        {
            var travelTime = raceTime - holdTime;
            var distance = holdTime * travelTime;
            if (distance > recordDistance)
            {
                ways++;
            }
        }
        return ways;
    }
}