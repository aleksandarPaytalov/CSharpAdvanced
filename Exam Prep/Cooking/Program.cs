Queue<int> liquids = new(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));
Stack<int> ingredients = new(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

SortedDictionary<string, int> foodMade = new SortedDictionary<string, int>()
{
    { "Bread", 0 },
    { "Cake" , 0 },
    { "Pastry", 0 },
    { "Fruit Pie", 0 }
};
while (liquids.Any() && ingredients.Any())
{
    int currentLiquid = liquids.Dequeue();
    int currentIngredient = ingredients.Pop();
    int sum = currentLiquid + currentIngredient;

    switch (sum)
    {
        case 25:
            foodMade["Bread"]++;
            break;
        case 50:
            foodMade["Cake"]++;
            break;
        case 75:
            foodMade["Pastry"]++;
            break;
        case 100:
            foodMade["Fruit Pie"]++;
            break;
        default:
            currentIngredient += 3;
            ingredients.Push(currentIngredient);
            break;
    }   
}

if (foodMade.All(x => x.Value >= 1))
{
    Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
}
else
{
    Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
}
if (liquids.Any() && !ingredients.Any())
{
    Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
    Console.WriteLine("Ingredients left: none");
}
else if (!liquids.Any() && ingredients.Any())
{
    Console.WriteLine("Liquids left: none");
    Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
}
else
{
    Console.WriteLine("Liquids left: none");
        Console.WriteLine("Ingredients left: none");
}

foreach (var product in foodMade)
{
    Console.WriteLine($"{product.Key}: {product.Value}");
}