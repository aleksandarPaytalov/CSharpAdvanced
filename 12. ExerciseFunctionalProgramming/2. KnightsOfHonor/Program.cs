string[] names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

Action<string[]> title = names => 
{
	foreach (var name in names)
	{
        Console.WriteLine($"Sir {name}");
    }
};

title(names);
