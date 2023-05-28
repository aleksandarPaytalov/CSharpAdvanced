string[] names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

Action<string[]> action = names => 
Console.WriteLine(string.Join(Environment.NewLine, names));

action(names);