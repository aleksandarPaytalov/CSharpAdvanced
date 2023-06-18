Queue<int> tools = new(Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse));
Stack<int> substances = new(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));
List<int> sequence = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

while (tools.Any() && substances.Any() && sequence.Any())
{
    int currentTool = tools.Dequeue();
    int currentSubstance = substances.Pop();
    int value = currentTool * currentSubstance;

    if (sequence.Contains(value))
    {
        sequence.Remove(value);
    }
    else if (!sequence.Contains(value))
    {
        currentTool++;
        tools.Enqueue(currentTool);
        currentSubstance--;
        if (currentSubstance == 0) // да се провери бордър кейса ако е едно по условие не е това
        {
            continue;
        }
        substances.Push(currentSubstance);
    }
}

if ((!tools.Any() || !substances.Any()) && sequence.Any()) // изключваме случай при който и трите колекции са празни едновременно. 
{
    Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");    
    if (tools.Any() && !substances.Any())
    {
        Console.WriteLine($"Tools: {string.Join(", ", tools)}");
    }
    else if (!tools.Any() && substances.Any())
    {
        Console.WriteLine($"Substances: {string.Join(", ", substances)}");
    }

    Console.WriteLine($"Challenges: {string.Join(", ", sequence)}");    
}
else if (!sequence.Any())
{
    Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
    if (tools.Any() && substances.Any())
    {
        Console.WriteLine($"Tools: {string.Join(", ", tools)}");
        Console.WriteLine($"Substances: {string.Join(", ", substances)}");
    }
    else if (!tools.Any() && substances.Any())
    {
        Console.WriteLine($"Substances: {string.Join(", ", substances)}");
    }
    else if (tools.Any() && !substances.Any())
    {
        Console.WriteLine($"Tools: {string.Join(", ", tools)}");
    }
    else if (!tools.Any() && !substances.Any())
    {
        return;
    }
}