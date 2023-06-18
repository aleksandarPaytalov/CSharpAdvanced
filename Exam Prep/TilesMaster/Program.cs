Stack<int> whiteTiles = new(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));
Queue<int> greyTiles = new(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));
Dictionary<int, string> tileAreas = new()
{
    { 40, "Sink" },
    { 50, "Oven" },
    { 60, "Countertop" },
    { 70, "Wall" },
};

Dictionary<string, int> locations = new();
while(whiteTiles.Any() && greyTiles.Any())
{
    int currentWhiteTile = whiteTiles.Pop();
    int currentGreyTile = greyTiles.Dequeue();

    if (currentWhiteTile == currentGreyTile)
    {
        int sum = currentWhiteTile + currentGreyTile;
        if (tileAreas.ContainsKey(sum))
        {
            if (!locations.ContainsKey(tileAreas[sum]))
            {
                locations.Add(tileAreas[sum], 0);
            }
            locations[tileAreas[sum]]++;
        }
        else
        {
            if (!locations.ContainsKey("Floor"))
            {
                locations.Add("Floor", 0);
            }
            locations["Floor"]++;
        }
    }
    else
    {
        currentWhiteTile /= 2;
        whiteTiles.Push(currentWhiteTile);
        greyTiles.Enqueue(currentGreyTile);
    }
}

if (whiteTiles.Any() && !greyTiles.Any())
{
    Console.WriteLine($"White tiles left: {string.Join(", ", whiteTiles)}");
    Console.WriteLine("Grey tiles left: none");
}
else if (!whiteTiles.Any() && greyTiles.Any())
{
    Console.WriteLine("White tiles left: none");
    Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTiles)}");
}
else
{
    Console.WriteLine("White tiles left: none");
    Console.WriteLine("Grey tiles left: none");
}
foreach (var location in locations.OrderByDescending(t => t.Value).ThenBy(n => n.Key))
{
    Console.WriteLine($"{location.Key}: {location.Value}");
}