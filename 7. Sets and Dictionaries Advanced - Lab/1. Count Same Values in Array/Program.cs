double[] input = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(double.Parse)
    .ToArray();

Dictionary<double, int> numbers = new();
foreach (var item in input)
{
    if (!numbers.ContainsKey(item))
    {
        numbers.Add(item, 0);
    }
    numbers[item]++;
}
foreach (var item in numbers)
{
    Console.WriteLine($"{item.Key} - {item.Value} times");
}