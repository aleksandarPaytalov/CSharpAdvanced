Queue<int> time = new(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray());
Stack<int> tasks = new(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray());

//Dictionary<string, int> ruberDucks = new()
//{
//    { "Darth Vader Ducky", 0 },
//    { "Thor Ducky", 0 },
//    { "Big Blue Rubber Ducky", 0 },
//    { "Small Yellow Rubber Ducky", 0 }
//};
int darthCount = 0;
int thorCount = 0;
int smallCount = 0;
int bigCount = 0;
int multiplication = 0;
while (time.Any())
{
    int currentTasks = tasks.Peek();
    int currentTime = time.Peek();
    multiplication = currentTasks * currentTime;
    if (multiplication >= 0 && multiplication <= 60)
    {
        //ruberDucks["Darth Vader Ducky"]++;
        darthCount++;    
    }
    else if (multiplication >= 61 && multiplication <= 120)
    {
        thorCount++;
    }
    else if (multiplication >= 121 && multiplication <= 180)
    {
        bigCount++;
    }
    else if (multiplication >= 181 && multiplication <= 240)
    {
        smallCount++;
    }
    else
    {
        currentTasks -= 2;
        tasks.Pop();
        tasks.Push(currentTasks);

        time.Dequeue();
        time.Enqueue(currentTime);
        continue;
    }
    tasks.Pop();
    time.Dequeue();
}

//foreach (var duck in ruberDucks)
//{
//
//}
Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");
Console.WriteLine($"Darth Vader Ducky: {darthCount}");
Console.WriteLine($"Thor Ducky: {thorCount}");
Console.WriteLine($"Big Blue Rubber Ducky: {bigCount}");
Console.WriteLine($"Small Yellow Rubber Ducky: {smallCount}");