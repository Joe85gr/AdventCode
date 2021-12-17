using System;
using System.IO;
using Day12;

const string filePath = "Day12.txt";

var fileLines = File.ReadAllLines(filePath);
var watch = new System.Diagnostics.Stopwatch();

watch.Start();
var firstPartResult = FirstPart.GetResult(fileLines);
watch.Stop();
Console.WriteLine($"Day 12 - First Part result: {firstPartResult}");
Console.WriteLine($"Elapsed time: {watch.ElapsedMilliseconds}ms");

watch.Start();
var secondPartResult = SecondPart.GetResult(fileLines);
watch.Stop();
Console.WriteLine($"Day 12 - Second Part result: {secondPartResult}");
Console.WriteLine($"Elapsed time: {watch.ElapsedMilliseconds}ms");
