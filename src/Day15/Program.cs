using Day15;

const string filePath = "Day15.txt";

var fileLines = File.ReadAllLines(filePath);
var watch = new System.Diagnostics.Stopwatch();

watch.Start();
var firstPartResult = FirstPart.GetResult(fileLines);
watch.Stop();
Console.WriteLine($"Day 15 - Second Part result: {firstPartResult}");
Console.WriteLine($"Elapsed time: {watch.ElapsedMilliseconds}ms");

// watch.Start();
// var secondPartResult = FirstAndSecondPart.GetResult(fileLines, 40);
// watch.Stop();
// Console.WriteLine($"Day 14 - Second Part result: {secondPartResult}");
// Console.WriteLine($"Elapsed time: {watch.ElapsedMilliseconds}ms");