int input = int.Parse(Console.ReadLine());
Dictionary<string, Dictionary<string, int>> wardrobe = new();

for (int i = 0; i < input; i++)
{
    string[] spliters = { " -> ", "," }; //  new string[] { " -> ", "," }
    string[] tokens = Console.ReadLine()
        .Split(spliters, StringSplitOptions.None);

    string currentToken = tokens[0];
    if (!wardrobe.ContainsKey(currentToken))
    {
        wardrobe.Add(currentToken, new());
    }

    for (int j = 1; j < tokens.Length; j++)
    {
        string currentWear = tokens[j];
        if (!wardrobe[currentToken].ContainsKey(currentWear))
        {
            wardrobe[currentToken].Add(tokens[j], new int());
        }
        wardrobe[currentToken][currentWear]++;
    }
}
string[] wear = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
string color = wear[0];
string clothToWear = wear[1];

foreach (var item in wardrobe)
{
    Console.WriteLine($"{item.Key} clothes:");
    foreach (var token in item.Value)
    {
        Console.Write($"* {token.Key} - {token.Value}");
        if (item.Key == color && token.Key == clothToWear)
        {
            Console.Write(" (found!)");
        }
        Console.WriteLine();
    }
}