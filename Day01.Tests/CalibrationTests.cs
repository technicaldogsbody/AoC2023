using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Day01.Tests
{
    public class CalibrationTests
    {
        [Fact]
        public void GetTotal_WithNumericValues_ReturnsCorrectSum()
        {
            var calibrations = new Calibrations();
            var lines = new List<string> { "1abc2", "pqr3stu8vwx" };
            Assert.Equal(50, calibrations.GetTotal(lines));
        }

        [Fact]
        public void GetTotal_WithNoDigits_ReturnsZero()
        {
            var calibrations = new Calibrations();
            var lines = new List<string> { "abc", "xyz" };
            Assert.Equal(0, calibrations.GetTotal(lines));
        }

        [Fact]
        public void GetTrueTotal_WithMixedInput_ReturnsCorrectSum()
        {
            var calibrations = new Calibrations();
            var lines = new List<string> { "two1nine", "eightwothree" };
            Assert.Equal(112, calibrations.GetTrueTotal(lines));
        }

        [Fact]
        public void GetTrueTotal_WithInvalidSpelledNumbers_ReturnsZero()
        {
            var calibrations = new Calibrations();
            var lines = new List<string> { "onxe", "twbo" };
            Assert.Equal(0, calibrations.GetTrueTotal(lines));
        }

        [Fact]
        public void GetTrueTotal_WithNumbersaAtStartAndEnd_ReturnsCorrectSum()
        {
            var calibrations = new Calibrations();
            var lines = new List<string> { "1onxe2", "3twbo4" };
            Assert.Equal(46, calibrations.GetTrueTotal(lines));
        }
    }
}