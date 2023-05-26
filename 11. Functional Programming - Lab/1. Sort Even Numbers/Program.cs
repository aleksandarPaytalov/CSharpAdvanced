int[] numbers = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .Where(n => n % 2 == 0)
    .OrderBy(n => n)
    .ToArray();

Console.WriteLine(string.Join(", ", numbers));

//4, 2, 1, 3, 5, 7, 1, 4, 2, 12