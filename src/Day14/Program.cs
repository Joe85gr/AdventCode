using Day14;

const string filePath = "Day14_MockData.txt";

var fileLines = File.ReadAllLines(filePath);
var watch = new System.Diagnostics.Stopwatch();

watch.Start();
var firstPartResult = FirstAndSecondPart.GetResult(fileLines, 10);
watch.Stop();
Console.WriteLine($"Day 14 - Second Part result: {firstPartResult}");
Console.WriteLine($"Elapsed time: {watch.ElapsedMilliseconds}ms");

watch.Start();
var secondPartResult = FirstAndSecondPart.GetResult(fileLines, 40);
watch.Stop();
Console.WriteLine($"Day 14 - Second Part result: {secondPartResult}");
Console.WriteLine($"Elapsed time: {watch.ElapsedMilliseconds}ms");