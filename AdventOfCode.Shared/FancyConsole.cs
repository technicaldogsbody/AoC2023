
using System.Diagnostics;
using System.Reflection;
using System.Xml.Linq;
using Humanizer;
using Spectre.Console;

namespace AdventOfCode.Shared
{
    public static class FancyConsole
    {
        public static void WriteInfo(IEnumerable<(string name, Func<object> function)> functions)
        {

            var table = new Table();

            // Add some columns
            table.AddColumn("Name");
            table.AddColumn("Result");
            table.AddColumn("Time Taken");

            foreach (var function in functions)
            {
                var sw = Stopwatch.StartNew();
                var result = function.function.Invoke();
                sw.Stop();
                table.AddRow(function.name, result.ToString(), sw.Elapsed.Humanize());
            }

            // Render the table to the console
            AnsiConsole.Write(table);
        }
    }
}
