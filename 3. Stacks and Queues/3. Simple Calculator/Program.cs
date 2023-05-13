// Input: 2 + 5 + 10 - 2 - 1
// Output: 14

string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
Stack<string> tokens = new(input.Reverse());
int result = int.Parse(tokens.Pop());

while (tokens.Any())
{
    string sign = tokens.Pop();
    int number = int.Parse(tokens.Pop());
    if (sign == "+")
    {
        result += number;
    }
    else if (sign == "-")
    {
        result -= number;
    }
}
Console.WriteLine(result);    
