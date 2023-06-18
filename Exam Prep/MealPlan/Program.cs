Queue<string> meals = new(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries));
Stack<int> calories = new(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));
Dictionary<string, int> mealsCatalog = new()
{
    { "salad" , 350 },
    { "soup" , 490 },
    { "pasta" , 680 },
    { "steak" , 790 },
};

int mealsCount = 0;
int leftOver = 0;
bool isValid = true;
while (meals.Any() && calories.Any())
{
    int currentMealCalories = mealsCatalog[meals.Peek()];
    int currentDailyCalories = calories.Pop();

    if (isValid)
    {
        currentMealCalories = mealsCatalog[meals.Peek()];
        mealsCount++;
    }
    else
    {
        currentMealCalories = leftOver;    
    }

    if (currentDailyCalories >= currentMealCalories)
    {
        meals.Dequeue();
        currentDailyCalories -= currentMealCalories;        
        calories.Push(currentDailyCalories);
        isValid = true;
    }
    else
    {
        leftOver = currentMealCalories - currentDailyCalories;
        isValid = false;
    }
}

if (!isValid)
{
    meals.Dequeue();
}

if (!meals.Any())
{
    Console.WriteLine($"John had {mealsCount} meals.");
    Console.WriteLine($"For the next few days, he can eat {string.Join(", ", calories)} calories.");
}
else
{
    Console.WriteLine($"John ate enough, he had {mealsCount} meals.");
    Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
}
