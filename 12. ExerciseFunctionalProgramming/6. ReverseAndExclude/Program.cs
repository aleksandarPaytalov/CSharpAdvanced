List<int> numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();
int n = int.Parse(Console.ReadLine());

Func<List<int>, List<int>> reverse = numbers =>
{
    List<int> reverseResult = new();

    for (int i = numbers.Count - 1; i >= 0; i--)
    {
        reverseResult.Add(numbers[i]);
    }

    return reverseResult;

};

Func<List<int>, Predicate<int>, List<int>> divisible = (numbers, divisible) =>
{
    List<int> divisibleNumbers = new();

    foreach (var item in numbers)
    {
        if (!divisible(item))
        {
            divisibleNumbers.Add(item);
        }
    }

    return divisibleNumbers;
};


numbers = reverse(numbers);
numbers = divisible(numbers, numbers => numbers % n == 0);
Console.WriteLine(string.Join(" ", numbers));