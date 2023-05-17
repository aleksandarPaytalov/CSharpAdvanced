using System;
using System.Collections.Generic;

string text = string.Empty;

int operations = int.Parse(Console.ReadLine());
Stack<string> stack = new();

for (int i = 0; i < operations; i++)
{
    string[] cmd = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string cmdType = cmd[0];

    if (cmdType == "1")
    {
        stack.Push(text);
        text += cmd[1];
    }
    else if (cmdType == "2")
    {
        stack.Push(text);
        int lengthToErase = int.Parse(cmd[1]);
        text = text.Remove(text.Length - lengthToErase);        
    }
    else if (cmdType == "3")
    {
        int index = int.Parse(cmd[1]) - 1;
        Console.WriteLine(text[index]);
    }
    else if (cmdType == "4")
    {
        text = stack.Pop();
    }
}