namespace Day05;

public class GardenMapper
{
    public async Task<long> GetLowestLocation(string input, bool useSeedRange)
    {
        var seedNumbers = ParseSeeds(input, useSeedRange);
        var seedToSoilMap = ParseMap(input, "seed-to-soil map:");
        var soilToFertilizerMap = ParseMap(input, "soil-to-fertilizer map:");
        var fertilizerToWaterMap = ParseMap(input, "fertilizer-to-water map:");
        var waterToLightMap = ParseMap(input, "water-to-light map:");
        var lightToTemperatureMap = ParseMap(input, "light-to-temperature map:");
        var temperatureToHumidityMap = ParseMap(input, "temperature-to-humidity map:");
        var humidityToLocationMap = ParseMap(input, "humidity-to-location map:");

        var lowestLocation = long.MaxValue;
        var tasks = new List<Task>();

        foreach (var seed in seedNumbers)
        {
            tasks.Add(Task.Run(() =>
            {
                var soil = ConvertNumber(seedToSoilMap, seed);
                var fertilizer = ConvertNumber(soilToFertilizerMap, soil);
                var water = ConvertNumber(fertilizerToWaterMap, fertilizer);
                var light = ConvertNumber(waterToLightMap, water);
                var temperature = ConvertNumber(lightToTemperatureMap, light);
                var humidity = ConvertNumber(temperatureToHumidityMap, temperature);
                var location = ConvertNumber(humidityToLocationMap, humidity);

                lowestLocation = location < lowestLocation ? location : lowestLocation;
            }));
        }

        await Task.WhenAll(tasks);

        return lowestLocation;
    }

    private IEnumerable<long> ParseSeeds(string input, bool useSeedRange)
    {
        var seedsLine = input.Split('\n').FirstOrDefault(line => line.StartsWith("seeds:"));
        var seedsParts = seedsLine?[7..]?.Split(' ').Select(long.Parse).ToList() ?? new List<long>();

        if (useSeedRange)
        {
            for (var i = 0; i < seedsParts.Count; i += 2)
            {
                var start = seedsParts[i];
                var length = seedsParts[i + 1];
                for (long j = 0; j < length; j++)
                {
                    yield return start + j;
                }
            }
        }
        else
        {
            foreach (var seed in seedsParts)
            {
                yield return seed;
            }
        }
    }

    private List<RangeMapping> ParseMap(string input, string mapHeader)
    {
        var mapBlock = input.Split($"{mapHeader}\r\n", StringSplitOptions.RemoveEmptyEntries);
        var mapLines = mapBlock.Last().Split("\r\n");
        var mappings = new List<RangeMapping>();

        foreach (var line in mapLines)
        {
            if (string.IsNullOrWhiteSpace(line)) break;

            var parts = line.Trim().Split(' ').Select(long.Parse).ToList();
            if (parts.Count == 3)
            {
                mappings.Add(new RangeMapping 
                {
                    DestStart = parts[0],
                    SourceStart = parts[1],
                    Length = parts[2]
                });
            }
        }

        return mappings;
    }

    private long ConvertNumber(List<RangeMapping> mappings, long number)
    {
        var mapping = mappings.FirstOrDefault(m => m.Contains(number));
        return mapping?.MapNumber(number) ?? number;
    }
}