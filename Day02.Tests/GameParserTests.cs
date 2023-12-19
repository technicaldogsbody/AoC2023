using Day02;

public class GameParserTests
{
    private GameParser parser = new GameParser();

    [Fact]
    public void GetSumOfValidGameIds_ValidGames_ReturnsCorrectSum()
    {
        var games = new List<string>
        {
            "Game 1: 3 blue, 4 red; 1 red, 2 green",
            "Game 2: 1 green, 2 blue"
        };


        var result = parser.GetSumOfValidGameIds(games, 4, 5, 6);

        Assert.Equal(3, result); // Only Game 1 is valid
    }

    [Fact]
    public void CalculateSumOfPowers_ValidGames_ReturnsCorrectSum()
    {
        var games = new List<string>
        {
            "Game 1: 3 blue, 4 red; 1 red, 2 green",
            "Game 2: 1 green, 2 blue"
        };


        var result = parser.CalculateSumOfPowers(games);

        Assert.Equal(24, result);
    }

}
