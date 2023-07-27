// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using SQLPerformancePlayground;

Console.WriteLine("Hello, World!");

var summary = BenchmarkRunner.Run<BenchmarkTests>();