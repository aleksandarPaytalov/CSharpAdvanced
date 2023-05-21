int input = int.Parse(Console.ReadLine());

HashSet<string> elements = new();
for (int i = 0; i < input; i++)
{
    string[] tokens = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

	for (int j = 0; j < tokens.Length; j++)
	{
		elements.Add(tokens[j]);
	}
}
var ordered = elements.OrderBy(x => x);
Console.WriteLine(string.Join(" ", ordered));
