int totalNames = int.Parse(Console.ReadLine());

HashSet<string> uniqueNames = new();
for (int i = 0; i < totalNames; i++)
{
    string currentName = Console.ReadLine();
    uniqueNames.Add(currentName);    
}

foreach (var item in uniqueNames)
{
    Console.WriteLine(item);
}