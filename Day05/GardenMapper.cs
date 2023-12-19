using System.Collections.ObjectModel;

namespace Day05;

public class GardenMapper
{
    public long GetLowestLocation(string input, bool useSeedRange)
    {
        var seedNumbers = ParseSeeds(input, useSeedRange).Distinct();
        var seedToSoilMap = ParseMap(input, "seed-to-soil map:");
        var soilToFertilizerMap = ParseMap(input, "soil-to-fertilizer map:");
        var fertilizerToWaterMap = ParseMap(input, "fertilizer-to-water map:");
        var waterToLightMap = ParseMap(input, "water-to-light map:");
        var lightToTemperatureMap = ParseMap(input, "light-to-temperature map:");
        var temperatureToHumidityMap = ParseMap(input, "temperature-to-humidity map:");
        var humidityToLocationMap = ParseMap(input, "humidity-to-location map:");

        var lowestLocation = long.MaxValue;

        Parallel.ForEach(seedNumbers, seed =>
        {
            Parallel.For(seed.SourceStart, seed.SourceStart + seed.Length + 1, i =>
            {
                var soil = ConvertNumber(seedToSoilMap, i);
                var fertilizer = ConvertNumber(soilToFertilizerMap, soil);
                var water = ConvertNumber(fertilizerToWaterMap, fertilizer);
                var light = ConvertNumber(waterToLightMap, water);
                var temperature = ConvertNumber(lightToTemperatureMap, light);
                var humidity = ConvertNumber(temperatureToHumidityMap, temperature);
                var location = ConvertNumber(humidityToLocationMap, humidity);
                
                lowestLocation = location < lowestLocation ? location : lowestLocation;
            });
        });

        return lowestLocation;
    }

    private List<RangeMapping> ParseSeeds(string input, bool useSeedRange)
    {
        var seedsLine = input.Split('\n').FirstOrDefault(line => line.StartsWith("seeds:"));
        var seedsParts = seedsLine?[7..]?.Split(' ').Select(long.Parse).ToList() ?? new List<long>();
        var mappings = new List<RangeMapping>();

        if (useSeedRange)
        {
            for (var i = 0; i < seedsParts.Count; i += 2)
            {
                var start = seedsParts[i];
                var length = seedsParts[i + 1];
                mappings.Add(new RangeMapping
                {
                    SourceStart = start,
                    Length = length
                });
            }
        }
        else
        {
            mappings.AddRange(
                seedsParts.Select(seed => new RangeMapping { SourceStart = seed, Length = 0 }));
        }

        return mappings;
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