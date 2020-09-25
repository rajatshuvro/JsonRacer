using System;
using BenchmarkDotNet.Running;

namespace JsonBenchmark
{
    class JsonRace
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Race to json!");
            BenchmarkSwitcher.FromAssembly(typeof(JsonRace).Assembly).Run(args);
        }
    }
}