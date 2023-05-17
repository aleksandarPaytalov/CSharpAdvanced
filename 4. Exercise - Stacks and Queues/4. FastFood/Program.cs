using System;
using System.Collections.Generic;
using System.Linq;

int foodQuantity = int.Parse(Console.ReadLine());
Queue<int> orders = new(Console.ReadLine()
    .Split(' ')
    .Select(int.Parse)
    );
Console.WriteLine(orders.Max());

while (orders.Any())
{
    int currentOrder = orders.Peek();
    if (foodQuantity >= currentOrder)
    {
        orders.Dequeue();
        foodQuantity -= currentOrder;
    }
    else
    {
        Console.WriteLine($"Orders left: {string.Join(' ', orders)}");
        break;
    }
}
if (!orders.Any())
{
    Console.WriteLine("Orders complete");
}
