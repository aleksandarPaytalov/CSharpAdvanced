using System;
using System.Collections.Generic;
using System.Linq;

namespace BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<double> water = new(Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(double.Parse));
            Stack<double> flour = new(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse));
            Dictionary<string, int> products = new()
            {
                { "Croissant", 0 },
                { "Muffin", 0 },
                { "Baguette", 0 },
                { "Bagel", 0 }
            };

            while (water.Any() && flour.Any())
            {
                double currentWater = water.Dequeue();
                double currentFlour = flour.Pop();
                double ratio = (currentWater / (currentFlour + currentWater)) * 100;

                switch (ratio)
                {
                    case 50:
                        products["Croissant"]++;
                        break;
                    case 40:
                        products["Muffin"]++;
                        break;
                    case 30:
                        products["Baguette"]++;
                        break;
                    case 20:
                        products["Bagel"]++;
                        break;
                    default:
                        currentFlour -= currentWater;
                        flour.Push(currentFlour);
                        products["Croissant"]++;
                        break;
                }
            }

            foreach (var item in products.OrderByDescending(p => p.Value).ThenBy(n => n.Key).Where(x => x.Value > 0))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            if (!water.Any() && flour.Any())
            {
                Console.WriteLine("Water left: None");
                Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
            }
            else if (water.Any() && !flour.Any())
            {
                Console.WriteLine($"Water left: {string.Join(", ", water)}");
                Console.WriteLine($"Flour left: None");
            }
            else
            {
                Console.WriteLine("Water left: None");
                Console.WriteLine("Flour left: None");
            }
        }

    }
}


