Queue<int> textiles = new(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray());
Stack<int> medicaments = new(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray());

Dictionary<string, int> healingItems = new()
{
    { "Patch", 0 },
    { "Bandage", 0 },
    { "MedKit", 0 }
};

while (textiles.Any() && medicaments.Any())
{
    int currentTextLine = textiles.Peek();
    int currentMedicine = medicaments.Peek();
    int sumCurrentElements = currentMedicine + currentTextLine;
    int nextMedicine = 0;

    switch (sumCurrentElements)
    {
        case 30:
            textiles.Dequeue();
            medicaments.Pop();
            healingItems["Patch"] += 1;
            break;
        case 40:
            textiles.Dequeue();
            medicaments.Pop();
            healingItems["Bandage"] += 1;
            break;
        case 100:
            textiles.Dequeue();
            medicaments.Pop();
            healingItems["MedKit"] += 1;
            break;
        case > 100: // да се провери дали работи правилно 
            textiles.Dequeue();
            medicaments.Pop();
            sumCurrentElements -= 100;
            healingItems["MedKit"] += 1;
            nextMedicine = medicaments.Pop() + sumCurrentElements;
            medicaments.Push(nextMedicine);
            break;
        default:
            textiles.Dequeue();
            nextMedicine = medicaments.Pop() + 10;
            medicaments.Push(nextMedicine);
            break;
    }
}

if (textiles.Any() && !medicaments.Any())
{
    Console.WriteLine("Medicaments are empty.");
}
else if (!textiles.Any() && medicaments.Any())
{
    Console.WriteLine("Textiles are empty.");
}
else
{
    Console.WriteLine("Textiles and medicaments are both empty.");
}

foreach (var item in healingItems.Where(i => i.Value > 0).OrderByDescending(x => x.Value).ThenBy(i => i.Key))
{
    Console.WriteLine($"{item.Key} - {item.Value}");
}
if (textiles.Any() && !medicaments.Any())
{
    Console.WriteLine($"Textiles left: {string.Join(", ", textiles)}");
}
else if (!textiles.Any() && medicaments.Any())
{
    Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments)}");
}