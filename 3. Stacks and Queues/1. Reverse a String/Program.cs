string input = Console.ReadLine();
Stack<char> reverse = new Stack<char>();

foreach (var item in input)
{
    reverse.Push(item);
}
while (reverse.Any()) //reverse.Count > 0
{
    Console.Write(reverse.Pop());
}
