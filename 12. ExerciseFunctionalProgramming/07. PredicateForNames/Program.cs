int n = int.Parse(Console.ReadLine());

List<string> names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

Action<List<string>, Predicate<string>> print = (names, match) =>
{
    foreach (var name in names)
    {
        if (match(name))
        {
            Console.WriteLine(name);
        }
    }

};

print(names, names => names.Length <= n);