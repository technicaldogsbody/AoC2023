using Xunit;
using Day03;

public class EnginePartParserTests
{
    private readonly EnginePartParser _parser = new();

    [Fact]
    public void SumOfPartNumbers_WithValidInput_ReturnsCorrectSum()
    {
        string[] lines = { "a12b3", "45c..", "d6e7f" };
        Assert.Equal(73, _parser.SumOfPartNumbers(lines));
    }

    [Fact]
    public void SumOfPartNumbers_WithEmptyArray_ReturnsZero()
    {
        string[] lines = { };
        Assert.Equal(0, _parser.SumOfPartNumbers(lines));
    }

    [Fact]
    public void SumOfPartNumbers_WithNoDigits_ReturnsZero()
    {
        string[] lines = { "abc", "def" };
        Assert.Equal(0, _parser.SumOfPartNumbers(lines));
    }

    [Fact]
    public void SumOfPartNumbers_WithAdjacentSymbols_ReturnsAdjustedSum()
    {
        string[] lines = { "a1*b2", "#3@4." };
        Assert.Equal(10, _parser.SumOfPartNumbers(lines));
    }

    [Fact]
    public void SumOfGearRatios_WithValidInput_ReturnsCorrectSum()
    {
        string[] lines = { "12*a3", "*45..", "67*.." };
        Assert.Equal(3555, _parser.SumOfGearRatios(lines));
    }

    [Fact]
    public void SumOfGearRatios_WithEmptyArray_ReturnsZero()
    {
        string[] lines = { };
        Assert.Equal(0, _parser.SumOfGearRatios(lines));
    }

    [Fact]
    public void SumOfGearRatios_WithNoAsterisks_ReturnsZero()
    {
        string[] lines = { "123", "456" };
        Assert.Equal(0, _parser.SumOfGearRatios(lines));
    }

    [Fact]
    public void SumOfGearRatios_WithSingleAdjacentNumber_ReturnsZero()
    {
        string[] lines = { "12.*", "....", "*.34", ".5.*" };
        Assert.Equal(0, _parser.SumOfGearRatios(lines));
    }

    [Fact]
    public void SumOfGearRatios_WithMultipleAdjacentNumbers_ReturnsSumOfProducts()
    {
        string[] lines = { "12*34", ".....", "*56..", "78..." };
        Assert.Equal(4776, _parser.SumOfGearRatios(lines));
    }

    [Fact]
    public void SumOfPartNumbers_WithNumbersAdjacentToSymbols_ReturnsCorrectSum()
    {
        string[] lines = { "a1*b", "2#3" };
        Assert.Equal(6, _parser.SumOfPartNumbers(lines));
    }

    [Fact]
    public void SumOfPartNumbers_WithNumbersNotAdjacentToSymbols_ReturnsZero()
    {
        string[] lines = { "1.a", "...", "b.2", "...", ".3." };
        Assert.Equal(0, _parser.SumOfPartNumbers(lines));
    }

    [Fact]
    public void SumOfPartNumbers_WithNumbersAtStringBoundaries_ReturnsAdjustedSum()
    {
        string[] lines = { "a1.", "2b.", "#3@", "4*5" };
        Assert.Equal(15, _parser.SumOfPartNumbers(lines));
    }
}
