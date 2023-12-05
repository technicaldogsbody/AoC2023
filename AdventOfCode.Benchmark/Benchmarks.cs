using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Shared;
using BenchmarkDotNet.Attributes;
using Day01;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCode.Benchmark
{
    [SimpleJob()]
    public class Benchmarks
    {
        private IEnumerable<string> _day01;

        [GlobalSetup]
        public void Setup()
        {
            _day01 = FileService.GetFileAsArray("day1.txt");
        }

        [Benchmark]
        public void Day1Part1() => new Calibrations().GetTotal(_day01);
        [Benchmark]
        public void Day1Part2() => new Calibrations().GetTrueTotal(_day01);
    }
}
