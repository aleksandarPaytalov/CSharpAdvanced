Func<string, int> func = int.Parse;

int[] input = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(func)
    .ToArray();

Console.WriteLine(input.Length);
Console.WriteLine(input.Sum());