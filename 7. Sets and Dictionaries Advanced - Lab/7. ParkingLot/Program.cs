string input = string.Empty;

HashSet<string> carNumbers = new();
while ((input = Console.ReadLine()) != "END")
{
    string[] info = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
    string cmd = info[0];
    string carPlate = info[1];

    if (cmd == "IN")
    {
        carNumbers.Add(carPlate);
    }
    else if (cmd == "OUT")
    {
        carNumbers.Remove(carPlate);
    }
}
if (carNumbers.Any())
{
    foreach (var item in carNumbers)
    {
        Console.WriteLine(item);
    }
}
else
{
    Console.WriteLine("Parking Lot is Empty");
}