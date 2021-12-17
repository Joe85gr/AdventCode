using Day16;

const string filePath = "Day16.txt";

var fileLines = File.ReadAllLines(filePath);
var watch = new System.Diagnostics.Stopwatch();

watch.Start();
var firstPartResult = FirstPart.GetResult(fileLines);
watch.Stop();
Console.WriteLine($"Day 16 - First Part result: {firstPartResult}");
Console.WriteLine($"Elapsed time: {watch.ElapsedMilliseconds}ms");

// watch.Reset();
//
// watch.Start();
// var secondPartResult = SecondPart.GetResult(fileLines);
// watch.Stop();
// Console.WriteLine($"Day 15 - Second Part result: {secondPartResult}");
// Console.WriteLine($"Elapsed time: {watch.ElapsedMilliseconds}ms");