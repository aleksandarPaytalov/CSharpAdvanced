string text = Console.ReadLine();

Dictionary<char, int> tokens = new();
for (int i = 0; i < text.Length; i++)
{
    char currentToken = text[i];
    if (!tokens.ContainsKey(currentToken))
    {
        tokens.Add(currentToken, new int());    
    }
    tokens[currentToken]++;
}

foreach (var item in tokens.OrderBy(x => x.Key))
{
    Console.WriteLine($"{item.Key}: {item.Value} time/s");
}