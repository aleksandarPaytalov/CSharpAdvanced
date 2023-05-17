using System;
using System.Collections.Generic;
using System.Linq;

Stack<int> clothesInBox = new(Console.ReadLine()
    .Split(' ')
    .Select(int.Parse)
    );
int rackCapacity = int.Parse(Console.ReadLine());
int capacityCurrentRack = rackCapacity;
int rackCount = 1;

while (clothesInBox.Any())
{
    capacityCurrentRack -= clothesInBox.Peek();
    if (capacityCurrentRack < 0)
    {
        rackCount++;
        capacityCurrentRack = rackCapacity;
        continue;
    }
    clothesInBox.Pop();
}
Console.WriteLine(rackCount);