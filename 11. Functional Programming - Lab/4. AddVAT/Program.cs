decimal[] numbers = Console.ReadLine()
    .Split(", ")
    .Select(decimal.Parse)
    .Select(x => x * 1.20m)
    .ToArray();

foreach (var number in numbers)
{
    Console.WriteLine($"{number:f2}");
}