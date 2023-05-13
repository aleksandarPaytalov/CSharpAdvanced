// 1 + (2 - (2 + 3) * 4 / (3 + 1)) * 5
// (2 + 3) - (2 + 3)

string input = Console.ReadLine();

Stack<int> bracketsPosition = new();
for (int i = 0; i < input.Length; i++)
{
    char current = input[i];
    if (current == '(')
    {
        bracketsPosition.Push(i);
    }
    else if (current == ')')
    {
        int startIndexOfSubstring = bracketsPosition.Pop();
        string subString = input.Substring(startIndexOfSubstring, i - startIndexOfSubstring + 1);
        Console.WriteLine(subString);
    }
}


