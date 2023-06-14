Stack<int> dailyPortions = new
    (Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));
Queue<int> dailyStamina = new
    (Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

Dictionary<string, int> peeks = new()
{
    { "Vihren",  80 },
    { "Kutelo",  90 },
    { "Banski Suhodol", 100 },
    { "Polezhan" ,60 },
    { "Kamenitza", 70 }
};

Queue<string> peekNames = new(); //
Queue<string> climbedPeeks = new(); //
foreach (var peek in peeks)
{
    peekNames.Enqueue(peek.Key);
}


while (dailyPortions.Any() && dailyStamina.Any() && peekNames.Any()) 
{
    if (dailyPortions.Pop() + dailyStamina.Dequeue() >= peeks[peekNames.Peek()])
    {
        climbedPeeks.Enqueue(peekNames.Dequeue());    
    }
}

if (!peekNames.Any())
{
    Console.WriteLine($"Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
}
else
{
    Console.WriteLine($"Alex failed! He has to organize his journey better next time -> @PIRINWINS");
}
if (climbedPeeks.Any())
{
    Console.WriteLine("Conquered peaks:");
    Console.WriteLine(string.Join(Environment.NewLine, climbedPeeks));
}

