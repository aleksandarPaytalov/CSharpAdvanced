int[] setsLength = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
int lengthSetOne = setsLength[0];
int lengthSetTwo = setsLength[1];

HashSet<int> setOne = new();
HashSet<int> setTwo = new();
for (int i = 0; i < lengthSetOne; i++)
{
    int currentNumber = int.Parse(Console.ReadLine());
    setOne.Add(currentNumber);
}
for (int i = 0; i < lengthSetTwo; i++)
{
    int currentNumber = int.Parse(Console.ReadLine());
    setTwo.Add(currentNumber);
}
setOne = setOne.Intersect(setTwo).ToHashSet();
Console.WriteLine(string.Join(" ", setOne)); 