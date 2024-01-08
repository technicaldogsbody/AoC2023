using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Xml.Linq;
using Humanizer;
using Spectre.Console;

namespace AdventOfCode.Shared
{
    [ExcludeFromCodeCoverage]
    public static class FancyConsole
    {
        public static void WriteInfo(string day, IEnumerable<(string name, Func<object> function)> functions)
        {
            AnsiConsole.Write(new FigletText(day));
            var table = new Table();

            // Add some columns
            table.AddColumn("Name");
            table.AddColumn("Result");
            table.AddColumn("Time Taken");

            AnsiConsole.Live(table).Start(ctx =>
            {
                foreach (var function in functions)
                {
                    var sw = Stopwatch.StartNew();
                    var result = function.function.Invoke();
                    sw.Stop();
                    table.AddRow(function.name, result.ToString(), sw.Elapsed.Humanize());
                    ctx.Refresh();
                }
            });
        }
    }
}