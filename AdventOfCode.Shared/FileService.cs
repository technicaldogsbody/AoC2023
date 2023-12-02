using System.Text.RegularExpressions;

namespace AdventOfCode.Shared
{
    public static class FileService
    {
        public static string GetFileAsString(string fileName)
        {
            var contents = File.ReadAllText($"Data/{fileName}");

            return contents;
        }

        public static IEnumerable<string> GetFileAsArray(string fileName, string delimiterPattern = @"\r\n|\n")
        {
            string contents = File.ReadAllText($"Data/{fileName}");
            return Regex.Split(contents, delimiterPattern).Where(line => !string.IsNullOrEmpty(line));
        }

        public static int[,] GetFileAs2dIntArray(string fileName, string rowDelimiterPattern = @"\r\n|\n")
        {
            string[] rows = Regex.Split(File.ReadAllText($"Data/{fileName}"), rowDelimiterPattern).Where(row => !string.IsNullOrEmpty(row)).ToArray();

            if (rows.Length == 0)
            {
                return new int[0, 0];
            }

            int[,] response = new int[rows.Length, rows[0].Length];

            for (int i = 0; i < rows.Length; i++)
            {
                char[] row = rows[i].ToCharArray();

                for (int j = 0; j < row.Length; j++)
                {
                    response[i, j] = int.Parse(row[j].ToString());
                }
            }

            return response;
        }
    }
}
