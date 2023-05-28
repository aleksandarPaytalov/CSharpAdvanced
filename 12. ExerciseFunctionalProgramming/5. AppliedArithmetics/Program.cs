using System.Security;

List<int> numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();
string cmd = string.Empty;

Func<string, List<int>, List<int>> calculateNumbers = (command, numbers) =>
{
    List<int> calculateNumbers = new();

    foreach (var item in numbers)
    {
        switch (command)
        {
            case "add":
                calculateNumbers.Add(item + 1);
                break;
            case "multiply":
                calculateNumbers.Add(item * 2);
                break;
            case "subtract":
                calculateNumbers.Add(item - 1);
                break;
        }
    }

    return calculateNumbers;
};
Action<List<int>> print = n => Console.WriteLine(string.Join(" ", n));

while ((cmd = Console.ReadLine()) != "end")
{
    if (cmd == "print")
    {
        print(numbers);
    }
    else
    {
        numbers = calculateNumbers(cmd, numbers);    
    }
}