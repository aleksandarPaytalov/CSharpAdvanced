int[] input = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .OrderByDescending(n => n)
    .ToArray();

for (int i = 0; i < input.Length; i++)
{
    if (i == 3)
    {
        break;
    }
    Console.Write(input[i] + " ");
}