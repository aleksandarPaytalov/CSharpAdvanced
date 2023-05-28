Func<int, int, List<int>> range = (start, end) =>
{
    List<int> numbers = new();

    for (int i = start; i <= end; i++)
    {
        numbers.Add(i);
    }
    return numbers;
};

Func<string, int, bool> oddEvenMatch = (command, num) =>
{
    if (command == "even")
    {
        return num % 2 == 0;
    }
    else
    {
        return num % 2 != 0;
    }
};


int[] numbersRange = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
string cmd = Console.ReadLine();

List<int> numbers = range(numbersRange[0], numbersRange[1]);

foreach (var item in numbers)
{
    if (oddEvenMatch(cmd, item))
    {
        Console.Write($"{item} ");
    }
}