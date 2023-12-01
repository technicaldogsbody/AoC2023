namespace AdventOfCode.Shared
{
    public static class FileService
    {
        public static string GetFileAsString(string fileName)
        {
            var contents = File.ReadAllText($"Data/{fileName}");

            return contents;
        }

        public static IEnumerable<string> GetFileAsArray(string fileName, string delimiter = "\r\n")
        {
            var contents = File.ReadAllText($"Data/{fileName}").Split(delimiter);

            return contents;
        }

        public static int[,] GetFileAs2dIntArray(string fileName, string rowDelimiter = "\r\n")
        {
            var rows = File.ReadAllText($"Data/{fileName}").Split(rowDelimiter);

            var response = new int[rows.Length, rows[0].ToCharArray().Length];

            for (var i = 0; i < rows.Length; i++)
            {
                var row = rows[i].ToCharArray();

                for (var j = 0; j < row.Length; j++)
                {
                    response[i, j] = int.Parse(row[j].ToString());
                }
            }

            return response;
        }
    }
}
