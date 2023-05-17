using System;
using System.Collections.Generic;
using System.Linq;

int[] operations = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
int[] numbers = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
int numbersToPush = operations[0];
int numbersToPop = operations[1];
int numberToContain = operations[2];

Queue<int> stackOfNumbers = new();

for (int i = 0; i < numbersToPush; i++)
{
    stackOfNumbers.Enqueue(numbers[i]);
}
for (int i = 0; i < numbersToPop; i++)
{
    if (stackOfNumbers.Any())
    {
        stackOfNumbers.Dequeue();
    }
}

if (stackOfNumbers.Any())
{
    if (stackOfNumbers.Contains(numberToContain))
    {
        Console.WriteLine("true");
    }
    else
    {
        Console.WriteLine(stackOfNumbers.Min());
    }
}
else
{
    Console.WriteLine(0);
}