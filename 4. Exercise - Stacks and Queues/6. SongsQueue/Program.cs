using System;
using System.Collections.Generic;
using System.Linq;

Queue<string> songs = new(Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    );
string inputCommand = Console.ReadLine();

while (songs.Any())
{
    string[] cmd = inputCommand.Split(" ").ToArray();
    string cmdType = cmd[0];
    if (cmdType == "Play")
    {
        songs.Dequeue();
    }
    else if (cmdType == "Add")
    {
        string songName = string.Join(" ", cmd.Skip(1));
        if (songs.Contains(songName))
        {
            inputCommand = Console.ReadLine();
            Console.WriteLine($"{songName} is already contained!");
            continue;
        }
        else
        {
            songs.Enqueue(songName);
        }        
    }
    else if (cmdType == "Show")
    {
        Console.WriteLine(string.Join(", ", songs));
    }
    inputCommand = Console.ReadLine();
}
Console.WriteLine("No more songs!");