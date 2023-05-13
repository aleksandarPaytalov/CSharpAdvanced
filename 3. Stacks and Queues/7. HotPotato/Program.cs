//Alva James William
//2

string[] playerNames = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
int passes = int.Parse(Console.ReadLine());

Queue<string> queue = new(playerNames);
int counter = 1;
while (queue.Count > 1)
{
    if (counter != passes)
    {
        counter++;
        string currentName = queue.Dequeue();
        queue.Enqueue(currentName);        
    }
    else 
    {
        Console.WriteLine($"Removed {queue.Dequeue()}");
        counter = 1;
    }
}
Console.WriteLine($"Last is {string.Join("", queue)}");