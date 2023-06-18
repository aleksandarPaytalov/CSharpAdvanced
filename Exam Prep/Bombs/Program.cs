using System.Security.Cryptography.X509Certificates;

Queue<int> effects = new(Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));
Stack<int> casings = new(Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));


Dictionary<int, string> bombs = new Dictionary<int, string>()
{
    { 40, "Datura Bombs" },
    { 60, "Cherry Bombs" },
    { 120, "Smoke Decoy Bombs" }
};


Dictionary<string, int> bombsMade = new Dictionary<string, int>();
int count = 0;
while (effects.Any() && casings.Any())
{
    int currentEffect = effects.Peek();
    int currentCasing = casings.Pop();
    int sum = currentEffect + currentCasing;

    if (bombs.ContainsKey(sum))
    {
        if (!bombsMade.ContainsKey(bombs[sum]))
        {
            bombsMade.Add(bombs[sum], 0);
        }
        bombsMade[bombs[sum]]++;
        effects.Dequeue();
    }
    else
    {
        currentCasing -= 5;
        casings.Push(currentCasing);
    }

    if (bombsMade.All(x => x.Value >= 3) && bombsMade.Keys.Count == 3)
    {
        break;
    }
    
}


if (count == 3)
{
    Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
}
else
{
    Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
}
if (!effects.Any() && casings.Any())
{
    Console.WriteLine("Bomb Effects: empty");
    Console.WriteLine($"Bomb Casings: {string.Join(", ", casings)}");
}
else if (effects.Any() && !casings.Any())
{
    Console.WriteLine($"Bomb Effects: {string.Join(", ", effects)}");
    Console.WriteLine("Bomb Casings: empty");
}
else if (!effects.Any() && !casings.Any())
{
    Console.WriteLine("Bomb Effects: empty");
    Console.WriteLine("Bomb Casings: empty");
}
else
{
    Console.WriteLine($"Bomb Effects: {string.Join(", ", effects)}");
    Console.WriteLine($"Bomb Casings: {string.Join(", ", casings)}");
}

foreach (var bomb in bombsMade.OrderBy(x => x.Key))
{
    Console.WriteLine($"{bomb.Key}: {bomb.Value}");
}