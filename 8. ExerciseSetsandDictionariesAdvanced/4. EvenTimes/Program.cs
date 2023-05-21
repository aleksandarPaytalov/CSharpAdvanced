int input = int.Parse(Console.ReadLine());

Dictionary<int, int> numbers = new();
for (int i = 0; i < input; i++)
{
    int token = int.Parse(Console.ReadLine());
    if (!numbers.ContainsKey(token))
    {
        numbers.Add(token, new int());    
    }
    numbers[token]++;
}
foreach (var item in numbers)
{
    if (item.Value % 2 == 0)
    {
        Console.WriteLine(item.Key);
    }
}