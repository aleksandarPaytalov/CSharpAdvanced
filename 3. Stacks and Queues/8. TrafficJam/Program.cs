using System;
using System.Collections.Generic;
using System.Linq;

int carPassing = int.Parse(Console.ReadLine());
string input = Console.ReadLine();

Queue<string> carsInQueue = new();

int carPassed = 0;
while (input != "end")
{
    int counter = 0;
    if (input == "green")
    {
        while (carsInQueue.Any() && counter < carPassing)
        {
            Console.WriteLine($"{carsInQueue.Dequeue()} passed!");
            counter++;
            carPassed++;
        }       
    }
    else
    {
        carsInQueue.Enqueue(input);
    }
    input = Console.ReadLine();
}
Console.WriteLine($"{carPassed} cars passed the crossroads.");