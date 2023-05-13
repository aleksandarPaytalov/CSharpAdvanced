string input = Console.ReadLine();

Queue<string> customerNames = new();
while (input != "End")
{
    if (input != "Paid")
    {
        customerNames.Enqueue(input);    
    }
    else if (input == "Paid")
    {
        while (customerNames.Any())
        {
            Console.WriteLine(customerNames.Dequeue());
        }
    }
    input = Console.ReadLine();
}
Console.WriteLine($"{customerNames.Count} people remaining.");