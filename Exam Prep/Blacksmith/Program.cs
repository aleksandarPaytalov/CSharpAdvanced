Queue<int> steel = new(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));
Stack<int> carbon = new(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));
Dictionary<int, string> swords = new Dictionary<int, string>()
{
    { 70, "Gladius" },
    { 80, "Shamshir" },
    { 90, "Katana" },
    { 110, "Sabre" },
    { 150, "Broadsword" },
};


Dictionary<string, int> swordsMade = new Dictionary<string, int>();
int count = 0;
while (steel.Any() && carbon.Any())
{
    int currentSteel = steel.Dequeue();
    int currentCarbon = carbon.Pop();
    int sum = currentSteel + currentCarbon;

    if (swords.ContainsKey(sum))                   
    {
        if (!swordsMade.ContainsKey(swords[sum]))
        {
            swordsMade.Add(swords[sum], 0);
        }
        swordsMade[swords[sum]]++;
        count++;
    }
    else
    {
        currentCarbon += 5;
        carbon.Push(currentCarbon);    
    }
}

if (swordsMade.Any())
{
    Console.WriteLine($"You have forged {count} swords.");
}
else 
{
    Console.WriteLine("You did not have enough resources to forge a sword.");
}
if (steel.Any() && !carbon.Any())
{
    Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
    Console.WriteLine("Carbon left: none");
}
else if (!steel.Any() && carbon.Any())
{
    Console.WriteLine("Steel left: none");
    Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
}
else
{
    Console.WriteLine("Steel left: none");
    Console.WriteLine("Carbon left: none");
}

foreach (var sword in swordsMade.OrderBy(x => x.Key))
{
    Console.WriteLine($"{sword.Key}: {sword.Value}");
}