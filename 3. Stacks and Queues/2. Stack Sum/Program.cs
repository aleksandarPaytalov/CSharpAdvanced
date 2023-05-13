int[] input = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();
Stack<int> stackOfNumbers = new Stack<int>(input);

string command = Console.ReadLine().ToLower();
while (command != "end")
{
    string[] cmd = command.Split();
    string cmdType = cmd[0];

    if (cmdType == "add")
    {
        int[] numbers = cmd.Skip(1).Select(int.Parse).ToArray();

        foreach (var item in numbers)
        {
            stackOfNumbers.Push(item);
        }
    }
    else if (cmdType == "remove")
    {
        int n = int.Parse(cmd[1]);

        if (n <= stackOfNumbers.Count)
        {
            for (int i = 0; i < n; i++)
            {
                stackOfNumbers.Pop();
            }
        }          
    }

    command = Console.ReadLine().ToLower();
}
Console.WriteLine($"Sum: {stackOfNumbers.Sum()}");
