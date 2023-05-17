using System;
using System.Collections.Generic;
using System.Linq;

int literPerKilometer = 1;

int count = int.Parse(Console.ReadLine());
Queue<int[]> pumps = new();

for (int i = 0; i < count; i++)
{
    int[] currentPump = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();
    pumps.Enqueue(currentPump);    
}

int position = 0;
while (true)
{
    bool isValid = true;
    int totalFuelInTank = 0;

    foreach (var item in pumps)
    {
        int[] currentPump = pumps.Peek();
        int littersFuel = item[0];
        int distance = item[1];
        totalFuelInTank += littersFuel;

        if (totalFuelInTank - distance * literPerKilometer < 0)
        {            
            pumps.Dequeue();
            pumps.Enqueue(currentPump);
            position++;
            isValid = false;
            break;
        }
        totalFuelInTank -= distance * literPerKilometer;        
    }

    if (isValid)
    {
        Console.WriteLine(position);
        break;
    }
}
