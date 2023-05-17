using System;
using System.Collections.Generic;
using System.Linq;

int bulletPrice = int.Parse(Console.ReadLine());
int gunBarrelSize = int.Parse(Console.ReadLine());
Stack<int> bulletsSize = new (Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    );
Queue<int> locksSize = new(Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    );
int inteligence = int.Parse(Console.ReadLine());

int totalBulletsCounter = 0;
int barelCounter = 0;

while (true)
{
    if (bulletsSize.Any() && locksSize.Any())
    {
        totalBulletsCounter++;
        barelCounter++;

        if (bulletsSize.Peek() <= locksSize.Peek())
        {
            bulletsSize.Pop();
            locksSize.Dequeue();
            Console.WriteLine("Bang!");
        }
        else
        {
            bulletsSize.Pop();
            Console.WriteLine("Ping!");
        }

        if (barelCounter == gunBarrelSize)
        {
            if (!locksSize.Any())
            {
                int moneyEarn = inteligence - bulletPrice * totalBulletsCounter;
                if (bulletsSize.Any())
                {
                    Console.WriteLine("Reloading!");
                    Console.WriteLine($"{bulletsSize.Count} bullets left. Earned ${moneyEarn}");
                    break;
                }
                else
                {
                    Console.WriteLine($"{bulletsSize.Count} bullets left. Earned ${moneyEarn}");
                    break;
                }
            }
            else if (!bulletsSize.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksSize.Count}");
                break;
            }
            else
            {
                Console.WriteLine("Reloading!");
            }
            barelCounter = 0;
        }
    }
    else
    {
        if (!locksSize.Any())
        {
            int moneyEarn = inteligence - bulletPrice * totalBulletsCounter;
            Console.WriteLine($"{bulletsSize.Count} bullets left. Earned ${moneyEarn}");
            break;
        }
        else if (!bulletsSize.Any())
        {
            Console.WriteLine($"Couldn't get through. Locks left: {locksSize.Count}");
            break;
        }
    }
}