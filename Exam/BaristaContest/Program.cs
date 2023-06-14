Queue<int> coffee = new(Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));
Stack<int> milk = new(Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

Dictionary<int, string> coffeeDrink = new()
{
    {50, "Cortado" },
    {75, "Espresso" },
    {100, "Capuccino" },
    {150, "Americano" },
    {200, "Latte" }
};
Dictionary<string, int> makedDrinks = new();

while (coffee.Any() && milk.Any())
{
    int currentCoffee = coffee.Dequeue();
    int currentMilk = milk.Pop();
    int sum = currentCoffee + currentMilk;


    if (coffeeDrink.ContainsKey(sum))
    {
        if (!makedDrinks.ContainsKey(coffeeDrink[sum]))
        {
            makedDrinks.Add(coffeeDrink[sum], 0);
        }
        makedDrinks[coffeeDrink[sum]]++;
    }
    else
    {
        currentMilk -= 5;
        milk.Push(currentMilk);
    }
}
if (!coffee.Any() && !milk.Any())
{
    Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
    Console.WriteLine("Coffee left: none");
    Console.WriteLine("Milk left: none");
}
else
{
    Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
    if (coffee.Any())
    {        
        Console.WriteLine($"Coffee left: {string.Join(", ", coffee)}");  
        Console.WriteLine("Milk left: none");
    }
    else
    {
        Console.WriteLine("Coffee left: none");
        Console.WriteLine($"Milk left: {string.Join(", ", milk)}");        
    }
}

foreach (var item in makedDrinks.OrderBy(n => n.Value).ThenByDescending(n => n.Key))
{
    Console.WriteLine($"{item.Key}: {item.Value}");
}

//тернарен оператор пример

//   //first line
//   var firstLine = coffeeQuantities.Count == 0 && milkQuantities.Count == 0
//       ? "Nina is going to win! She used all the milk and coffee!"
//       : "Nina needs to exercise more! She didn't use all the milk and coffee!";
//   Console.WriteLine(firstLine);
//   //second line
//   var coffeeLeft = coffeeQuantities.Count == 0 ? "none" : String.Join(", ", coffeeQuantities);
//   Console.WriteLine($"Coffee left: {coffeeLeft}");
//   //third line
//   var milkLeft = milkQuantities.Count == 0 ? "none" : String.Join(", ", milkQuantities);
//   Console.WriteLine($"Milk left: {milkLeft}");
