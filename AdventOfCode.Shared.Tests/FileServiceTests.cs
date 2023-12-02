namespace AdventOfCode.Shared.Tests
{
    public class FileServiceTests
    {
        [Fact]
        public void GetFileAsString_ValidFile_ReturnsCorrectContent()
        {
            var content = FileService.GetFileAsString("test1.txt"); // Ensure test.txt exists with known content
            Assert.Equal("Hello, World!", content);
        }

        [Fact]
        public void GetFileAsString_FileNotFound_ThrowsFileNotFoundException()
        {
            Assert.Throws<FileNotFoundException>(() => FileService.GetFileAsString("nonexistent.txt"));
        }

        [Fact]
        public void GetFileAsArray_ValidFile_ReturnsCorrectArray()
        {
            var lines = FileService.GetFileAsArray("test2.txt"); // Ensure test.txt exists with multiple lines
            Assert.Equal(new string[] { "Hello, World!", "This is a test file.", "It contains multiple lines." }, lines);
        }

        [Fact]
        public void GetFileAs2dIntArray_ValidFile_ReturnsCorrect2dArray()
        {
            var array = FileService.GetFileAs2dIntArray("matrix.txt"); // Ensure matrix.txt exists with numeric 2D data
            Assert.Equal(new int[,] { { 1, 2 }, { 3, 4 } }, array);
        }

        // Additional tests for other methods and edge cases...
    }
}