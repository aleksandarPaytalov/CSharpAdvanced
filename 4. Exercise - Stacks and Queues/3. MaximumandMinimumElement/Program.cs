using System;
using System.Collections.Generic;
using System.Linq;

int operations = int.Parse(Console.ReadLine());

Stack<string> stackElements = new();
for (int i = 0; i < operations; i++)
{
    string[] cmd = Console.ReadLine()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries);
    string cmdType = cmd[0];

    if (cmdType == "1")
    {
        stackElements.Push(cmd[1]);
    }
    else if (stackElements.Any())
    {
        if (cmdType == "2")
        {
            stackElements.Pop();
        }
        else if (cmdType == "3")
        {
            Console.WriteLine(stackElements.Max());
        }
        else if (cmdType == "4")
        {
            Console.WriteLine(stackElements.Min());
        }        
    }
}
Console.WriteLine(string.Join(", ", stackElements));
