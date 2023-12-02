using Day02;

public class GameParserTests
{
    private GameParser parser = new GameParser();

    [Fact]
    public void ParseGames_ValidInput_ReturnsCorrectData()
    {
        var input = new List<string>
        {
            "Game 1: 3 blue, 4 red; 1 red, 2 green",
            "Game 2: 1 green, 2 blue"
        };

        var result = parser.ParseGames(input);

        Assert.Equal(2, result.Count);
        Assert.Equal(3, result[1][0].blue);
        Assert.Equal(1, result[2][0].green);
    }

    [Fact]
    public void ParseCubeCounts_ValidInput_ReturnsCorrectCounts()
    {
        var input = "3 red, 2 green, 1 blue";

        var result = parser.ParseCubeCounts(input);

        Assert.Equal(3, result.red);
        Assert.Equal(2, result.green);
        Assert.Equal(1, result.blue);
    }

    [Fact]
    public void GetSumOfValidGameIds_ValidGames_ReturnsCorrectSum()
    {
        var games = new Dictionary<int, List<(int red, int green, int blue)>>
        {
            { 1, new List<(int red, int green, int blue)> { (3, 2, 1), (2, 3, 4) } },
            { 2, new List<(int red, int green, int blue)> { (1, 2, 3), (4, 5, 6) } }
        };

        var result = parser.GetSumOfValidGameIds(games, 4, 5, 6);

        Assert.Equal(3, result); // Only Game 1 is valid
    }

    [Fact]
    public void IsGameValid_ValidGame_ReturnsTrue()
    {
        var subsets = new List<(int red, int green, int blue)> { (3, 2, 1), (2, 3, 4) };

        var result = parser.IsGameValid(subsets, 4, 5, 6);

        Assert.True(result);
    }

    [Fact]
    public void IsGameValid_InvalidGame_ReturnsFalse()
    {
        var subsets = new List<(int red, int green, int blue)> { (5, 2, 1), (2, 3, 4) };

        var result = parser.IsGameValid(subsets, 4, 5, 6);

        Assert.False(result);
    }

    [Fact]
    public void CalculateSumOfPowers_ValidGames_ReturnsCorrectSum()
    {
        var games = new Dictionary<int, List<(int red, int green, int blue)>>
        {
            { 1, new List<(int red, int green, int blue)> { (3, 2, 1), (2, 3, 4) } },
            { 2, new List<(int red, int green, int blue)> { (1, 2, 3), (4, 5, 6) } }
        };

        var result = parser.CalculateSumOfPowers(games);

        // The power of Game 1 is 3*3*4 = 36 and Game 2 is 4*5*6 = 120
        Assert.Equal(156, result);
    }

    [Fact]
    public void FindMinimumCubes_ValidInput_ReturnsCorrectMinimums()
    {
        var subsets = new List<(int red, int green, int blue)> { (3, 2, 1), (2, 3, 4) };

        var result = parser.FindMinimumCubes(subsets);

        Assert.Equal(3, result.red);
        Assert.Equal(3, result.green);
        Assert.Equal(4, result.blue);
    }
}
